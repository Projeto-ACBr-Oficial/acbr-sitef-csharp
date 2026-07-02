using ACBr.CliSiTef.Demo.Models;
using Lib.CliSitef.Classes;
using Lib.CliSitef.ConstantValues;
using Lib.FormsAuxiliares;
using Lib.Utils.Classes;
using Lib.Utils.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Services
{
    public enum ResultadoConfirmacaoPendentes
    {
        SemPendencias,
        Confirmado,
        DesfeitoNcn
    }

    public class TefDemoService
    {
        /// <summary>Retorno legado de <see cref="EfetuarPagamento"/> (NCN imediato não é mais usado no modo manual).</summary>
        public const int CodigoPagamentoDesfeito = 1;

        private const int VK_ESCAPE = 0x1B;

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public readonly TefSoftwareExpress Tef = new TefSoftwareExpress();
        public TefConfig Config { get; private set; }
        public Cupom CupomAtual { get; private set; }

        public decimal ValorTotalOperacao { get; set; }
        public decimal ValorPago { get; set; }
        public bool VendaFinalizada { get; private set; }
        public bool TefInicializado { get; private set; }

        /// <summary>Quando true, confirma (CNF) automaticamente conforme regra do cupom; quando false, pergunta ao operador.</summary>
        public bool ConfirmacaoAutomatica { get; private set; } = true;

        private string _cacheComprovanteImpressao;

        public IWin32Window UiOwner { get; set; }
        public Action<string> OnLog { get; set; }
        public Action<string> OnStatus { get; set; }
        public Action<string> OnComprovanteAtualizado { get; set; }

        public TefDemoService()
        {
            Tef.OnMessageClient += Tef_OnMessageClient;
            Tef.OnCallForm += Tef_OnCallForm;
            Tef.OnVerifyDataCollectionInterruption += Tef_OnVerifyDataCollectionInterruption;
        }

        public void CarregarConfiguracao()
        {
            Config = TefConfigService.Carregar();
            ConfirmacaoAutomatica = TefConfigService.ObterConfirmacaoAutomatica();
            TefConfigService.GarantirCliSiTefIni(Config);
        }

        public int InicializarTef()
        {
            int sts = Tef.InicializarTef(Config);
            TefInicializado = sts == 0;
            AppendLog("InicializarTef -> " + sts + " " + Tef.MensagemTef(sts));
            return sts;
        }

        public string GerarDocumento()
        {
            return new Random().Next(999999).ToString("000000");
        }

        /// <summary>
        /// Limpa apenas o cupom TEF em memória. Totais e <see cref="ValorPago"/> permanecem até <see cref="ReiniciarVenda"/>.
        /// </summary>
        public void LimparCupom()
        {
            if (Tef.gCupomVenda != null)
                Tef.gCupomVenda.Transacoes.Clear();
            Tef.gCupomVenda = null;
            CupomAtual = null;
            // Mantém _cacheComprovanteImpressao para reimpressão manual após finalizar venda.
        }

        public void ReiniciarVenda()
        {
            LimparCupom();
            LimparCacheComprovanteImpressao();
            ValorTotalOperacao = 0;
            ValorPago = 0;
            VendaFinalizada = false;
        }

        /// <summary>
        /// Descarta cupom/comprovante da tentativa NCN. Se não há pagamentos na venda, zera totais TEF.
        /// </summary>
        public void DescartarOperacaoDesfeita(string documento)
        {
            LimparCupom();
            LimparCacheComprovanteImpressao();
            if (ValorPago <= 0)
            {
                ValorTotalOperacao = 0;
                VendaFinalizada = false;
            }
            AppendLog("Operação descartada (NCN) doc=" + documento);
        }

        public void MarcarVendaFinalizada()
        {
            VendaFinalizada = true;
            LimparCupom();
        }

        public void LimparCacheComprovanteImpressao()
        {
            _cacheComprovanteImpressao = null;
        }

        public void PrepararCupom(string tipo, string documento, decimal valorTotal)
        {
            if (CupomAtual == null)
            {
                CupomAtual = new Cupom
                {
                    TipoOperacao = tipo,
                    DocumentoVinculado = documento,
                    ValorTotal = valorTotal
                };
            }
            Tef.gCupomVenda = CupomAtual;
        }

        public int EfetuarPagamento(string documento, decimal valorPagamento, int funcao = 0, string parametrosAdicionais = "")
        {
            PrepararCupom("Crt", documento, ValorTotalOperacao);
            bool confirmarCnfNoCrt = ConfirmacaoAutomatica
                && ValorTotalOperacao > 0
                && ValorTotalOperacao == (ValorPago + valorPagamento);

            AppendLog("Crt(" + funcao + ") doc=" + documento + " valor=" + valorPagamento.ToString("N2")
                + " | modo=" + (ConfirmacaoAutomatica ? "automático" : "manual")
                + (confirmarCnfNoCrt ? " | CNF no Crt=sim" : " | CNF no Crt=não (pendente)")
                + (string.IsNullOrWhiteSpace(parametrosAdicionais) ? "" : " | ParamAdic=" + parametrosAdicionais));

            int sts = Tef.Crt(valorPagamento, documento, "OperadorDemo", funcao, confirmarCnfNoCrt, parametrosAdicionais);
            AppendLog("Crt(" + funcao + ") retorno=" + sts + " " + Mensagem(sts));

            if (sts != 0)
                return sts;

            if (confirmarCnfNoCrt)
                AppendLog("CNF concluído no Crt (cupom quitado) doc=" + documento);

            if (!ConfirmacaoAutomatica)
            {
                int pendentes = Tef.ObtemQuantidadeTransacoesPendentes(documento);
                bool cupomQuitado = ValorTotalOperacao > 0
                    && ValorTotalOperacao == (ValorPago + valorPagamento);
                AppendLog("Pendências após Crt: " + pendentes + " (doc " + documento + ") — "
                    + (cupomQuitado
                        ? "cupom quitado; confirmação na finalização"
                        : "aguardando demais pagamentos"));
            }

            ValorPago += valorPagamento;
            AtualizarComprovante(documento);
            return sts;
        }

        /// <summary>
        /// Confirma ou desfaz pendências ao encerrar a venda. No modo manual, é o único momento da pergunta ao operador.
        /// </summary>
        public ResultadoConfirmacaoPendentes ConfirmarPendentesParaFinalizarVenda(IWin32Window owner, string documento)
        {
            int qtd = Tef.ObtemQuantidadeTransacoesPendentes(documento);
            if (qtd <= 0)
            {
                AppendLog("Finalizar venda: sem pendências (doc " + documento + ")");
                return ResultadoConfirmacaoPendentes.SemPendencias;
            }

            AppendLog("Finalizar venda: " + qtd + " transação(ões) pendente(s) no doc " + documento);

            if (ConfirmacaoAutomatica)
            {
                ConfirmarTodasPendentes(documento);
                AppendLog("CNF automático na finalização doc=" + documento + " qtd=" + qtd);
                return ResultadoConfirmacaoPendentes.Confirmado;
            }

            string msg = qtd == 1
                ? "A transação do documento " + documento + " foi autorizada e está pendente no SiTef.\n\n" +
                  "Deseja confirmar esta transação?"
                : "As " + qtd + " transações do documento " + documento + " foram autorizadas e estão pendentes no SiTef.\n\n" +
                  "Deseja confirmar todas as transações deste cupom?";

            var resp = MessageBox.Show(owner,
                msg + "\n\nSim = confirmar (CNF)\nNão = desfazer (NCN)",
                "Confirmar transações",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (resp == DialogResult.Yes)
            {
                ConfirmarTodasPendentes(documento);
                AppendLog("CNF na finalização (operador) doc=" + documento + " qtd=" + qtd);
                return ResultadoConfirmacaoPendentes.Confirmado;
            }

            CancelarTodasPendentes(documento);
            AppendLog("NCN na finalização (operador) doc=" + documento + " qtd=" + qtd);
            return ResultadoConfirmacaoPendentes.DesfeitoNcn;
        }

        private void ConfirmarTodasPendentes(string documento)
        {
            while (Tef.ObtemQuantidadeTransacoesPendentes(documento) > 0)
                Tef.ConfirmarTransacaoPendente(documento);
        }

        private void CancelarTodasPendentes(string documento)
        {
            while (Tef.ObtemQuantidadeTransacoesPendentes(documento) > 0)
                Tef.CancelarTransacaoPendente(documento);
        }

        /// <summary>Grava apenas no arquivo (evita reentrância com o painel do PDV).</summary>
        public void RegistrarLogArquivo(string mensagem)
        {
            Lib.Utils.Logs.Log.GerarLogProcessoExecucao(mensagem, PathLogs());
        }

        /// <summary>
        /// Lê NSU/rede da última transação do cupom (layout NTK em <see cref="TefRetorno.Codigo"/>, não TipoCampo SiTef).
        /// </summary>
        public DadosTransacaoGrid ObterDadosUltimaTransacaoParaGrid()
        {
            var transacao = Tef.gCupomVenda?.Transacoes.LastOrDefault();
            return MontarDadosTransacaoGrid(transacao);
        }

        public static DadosTransacaoGrid MontarDadosTransacaoGrid(TefTransacao transacao)
        {
            var dados = new DadosTransacaoGrid();
            if (transacao?.Retornos == null || transacao.Retornos.Count == 0)
                return dados;

            dados.Nsu = LerRetorno(transacao, 13, 0);
            dados.Host = LerRetorno(transacao, 12, 0);
            dados.Autorizacao = LerRetorno(transacao, 13, 1);

            dados.CodigoRede = LerRetorno(transacao, 10, 0);
            if (string.IsNullOrWhiteSpace(dados.CodigoRede))
                dados.CodigoRede = LerRetorno(transacao, 739, 0);

            dados.Rede = LerRetorno(transacao, 10, 1);
            if (string.IsNullOrWhiteSpace(dados.Rede))
                dados.Rede = ResolverNomeRede(dados.CodigoRede);
            if (string.IsNullOrWhiteSpace(dados.Rede))
                dados.Rede = LerRetorno(transacao, 748, 0);
            if (string.IsNullOrWhiteSpace(dados.Rede))
                dados.Rede = LerRetorno(transacao, 748, 2);

            dados.Bandeira = LerRetorno(transacao, 748, 0);
            if (string.IsNullOrWhiteSpace(dados.Bandeira))
                dados.Bandeira = LerRetorno(transacao, 748, 2);

            dados.Modalidade = LerRetorno(transacao, 731, 1);
            dados.SubModalidade = LerRetorno(transacao, 732, 1);
            dados.TipoTransacao = LerRetorno(transacao, 11, 0);

            dados.Cartao = LerRetorno(transacao, 740, 0);
            dados.Bin = LerRetorno(transacao, 740, 1);
            dados.Titular = LerRetorno(transacao, 741, 0);

            dados.DataTransacao = FormatarDataRetorno(LerRetorno(transacao, 22, 0));
            dados.HoraTransacao = FormatarHoraRetorno(LerRetorno(transacao, 23, 0));
            dados.IdTransacao = LerRetorno(transacao, 2, 1);

            string credenciadora = LerRetorno(transacao, 603, 1);
            if (string.IsNullOrWhiteSpace(credenciadora))
                credenciadora = LerRetorno(transacao, 603, 0);
            dados.Credenciadora = credenciadora;
            dados.Cnpj = ExtrairCnpjCredenciadora(credenciadora);

            return dados;
        }

        public PagamentoGridItem CriarItemGridPagamento(int item, string formaPagamento, decimal valor, string status)
        {
            var transacao = Tef.gCupomVenda?.Transacoes.LastOrDefault();
            return MontarDadosTransacaoGrid(transacao).ParaGridItem(item, formaPagamento, valor, status);
        }

        private static string LerRetorno(TefTransacao transacao, int codigo, int indice)
        {
            var item = transacao.Retornos.FirstOrDefault(p => p.Codigo == codigo && p.Indice == indice);
            return LimparValorRetorno(item?.Valor);
        }

        private static string LimparValorRetorno(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return "";
            return valor.Trim().Trim('"');
        }

        private static string ResolverNomeRede(string codigoRede)
        {
            if (string.IsNullOrWhiteSpace(codigoRede))
                return "";

            string codigo = codigoRede.Trim().PadLeft(5, '0');
            var rede = RedeAutorizadora.RetornarAutorizadora(codigo);
            return rede?.Nome ?? codigoRede.Trim();
        }

        private static string FormatarDataRetorno(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 8)
                return valor ?? "";

            try
            {
                return valor.Substring(0, 2) + "/" + valor.Substring(2, 2) + "/" + valor.Substring(4, 4);
            }
            catch
            {
                return valor;
            }
        }

        private static string FormatarHoraRetorno(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 4)
                return valor ?? "";

            try
            {
                if (valor.Length >= 6)
                    return valor.Substring(0, 2) + ":" + valor.Substring(2, 2) + ":" + valor.Substring(4, 2);
                return valor.Substring(0, 2) + ":" + valor.Substring(2, 2);
            }
            catch
            {
                return valor;
            }
        }

        private static string ExtrairCnpjCredenciadora(string codigoNomeCnpj)
        {
            if (string.IsNullOrWhiteSpace(codigoNomeCnpj))
                return "";

            string[] partes = codigoNomeCnpj.Split('|');
            for (int i = partes.Length - 1; i >= 0; i--)
            {
                string digitos = new string(partes[i].Where(char.IsDigit).ToArray());
                if (digitos.Length >= 14)
                    return FormatarCnpj(digitos.Substring(0, 14));
            }
            return "";
        }

        private static string FormatarCnpj(string digitos)
        {
            if (digitos.Length != 14)
                return digitos;
            return digitos.Substring(0, 2) + "." + digitos.Substring(2, 3) + "." +
                   digitos.Substring(5, 3) + "/" + digitos.Substring(8, 4) + "-" + digitos.Substring(12, 2);
        }

        public int MenuAdministrativo(string documento)
        {
            PrepararCupom("Adm", documento, 0);
            int sts = Tef.Adm(documento);
            AppendLog("Adm -> " + sts);
            if (sts == 0)
                AtualizarComprovante(documento);
            return sts;
        }

        public int CancelarTransacao(string documento, int funcao = 200)
        {
            PrepararCupom("Cnc", documento, 0);
            int sts = Tef.Cnc(documento, "OperadorDemo", funcao);
            AppendLog("Cnc(" + funcao + ") -> " + sts);
            if (sts == 0)
                AtualizarComprovante(documento);
            return sts;
        }

        public int Atv()
        {
            int sts = Tef.Atv();
            AppendLog("Atv -> " + sts + " " + Tef.MensagemTef(sts));
            return sts;
        }

        public int VerificarPinPad()
        {
            int sts = Tef.VerificarPinpad();
            AppendLog("VerificarPinpad -> " + sts);
            return sts;
        }

        public void AtualizarComprovante(string documento)
        {
            string impressao = MontarTextoComprovanteDoCupom();
            if (!string.IsNullOrWhiteSpace(impressao))
                _cacheComprovanteImpressao = impressao;

            string preview = ComprovanteBuilder.FormatarParaPreview(impressao);
            if (string.IsNullOrWhiteSpace(preview) && !string.IsNullOrWhiteSpace(_cacheComprovanteImpressao))
                preview = ComprovanteBuilder.FormatarParaPreview(_cacheComprovanteImpressao);

            OnComprovanteAtualizado?.Invoke(preview);
        }

        public string ObterTextoComprovanteImpressao()
        {
            string atual = MontarTextoComprovanteDoCupom();
            if (!string.IsNullOrWhiteSpace(atual))
                return atual;
            return _cacheComprovanteImpressao ?? string.Empty;
        }

        private string MontarTextoComprovanteDoCupom()
        {
            return ComprovanteBuilder.MontarParaImpressao(Tef.gCupomVenda, Config.Tef_Terminal);
        }

        public void CancelarPendentes(string documento)
        {
            Tef.CancelarTransacaoPendente(documento);
            AppendLog("NCN (nova venda / limpeza) doc=" + documento);
        }

        private void AppendLog(string msg)
        {
            RegistrarLogArquivo(msg);
            OnLog?.Invoke(msg);
        }

        private static string PathLogs()
        {
            return System.IO.Path.Combine(Application.StartupPath, "Logs");
        }

        private void Tef_OnMessageClient(string mensagem, int tempoMiliSegundos, TefFuncaoInterativa interativa = null)
        {
            OnStatus?.Invoke(mensagem);
            if (EhMensagemOperacaoLonga(mensagem))
            {
                OnLog?.Invoke("TEF: " + mensagem);
                Application.DoEvents();
            }
            if (tempoMiliSegundos > 0)
                Thread.Sleep(tempoMiliSegundos);
        }

        /// <summary>
        /// Identifica mensagens do SiTef em operações longas (cargas e leituras de registros)
        /// que devem aparecer no painel de log para indicar progresso ao operador.
        /// </summary>
        private static bool EhMensagemOperacaoLonga(string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                return false;

            return mensagem.IndexOf("ATUALIZANDO TABELAS", StringComparison.OrdinalIgnoreCase) >= 0
                || mensagem.IndexOf("Atualizando Reg.", StringComparison.OrdinalIgnoreCase) >= 0
                || mensagem.IndexOf("OBTENDO REGISTRO", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void Tef_OnCallForm(TefFuncaoInterativa interativa)
        {
            TefInteracaoUi.TratarCallForm(UiOwner, interativa, Config);
        }

        private void Tef_OnVerifyDataCollectionInterruption(TefFuncaoInterativa interativa)
        {
            interativa.Interromper = TeclaEscPressionada();
        }

        public bool TeclaEscPressionada()
        {
            bool esc = (GetAsyncKeyState(VK_ESCAPE) & 0x8000) != 0;
            if (esc)
                AppendLog("ESC pressionado - interrupção solicitada.");
            return esc;
        }

        public string Mensagem(int codigo)
        {
            return Tef.MensagemTef(codigo);
        }
    }
}
