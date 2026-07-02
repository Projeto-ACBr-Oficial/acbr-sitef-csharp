using ACBr.CliSiTef.Demo.Helpers;
using ACBr.CliSiTef.Demo.Models;
using ACBr.CliSiTef.Demo.Services;
using Lib.CliSitef.Classes;
using Lib.FormsAuxiliares;
using Lib.Utils.Classes;
using Lib.Utils.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo
{
    public partial class FrmPdv : Form
    {
        private readonly TefDemoService _tef = new TefDemoService();
        private DemoPosPrinterService _impressora;
        private readonly BindingList<PagamentoGridItem> _pagamentos = new BindingList<PagamentoGridItem>();
        private int _itemPagamento;

        public FrmPdv()
        {
            InitializeComponent();
        }

        private void FrmPdv_Load(object sender, EventArgs e)
        {
            AcbrNativeThread.RegistrarControleUi(this);
            pnlPrincipal.Resize += (s, ev) => { if (pnlQr.Visible) CentralizarPainelQr(); };
            gridPagamentos.Resize += (s, ev) => { if (pnlQr.Visible) CentralizarPainelQr(); };
            Text = "ACBr CliSiTef - Demo";
            AppIconHelper.AplicarIcone(this);
            ConfigurarColunasGridPagamentos();
            gridPagamentos.DataSource = _pagamentos;
            _impressora = new DemoPosPrinterService();
            ConfigurarTef();
            AtualizarTotais();
            DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
        }

        private void FrmPdv_Shown(object sender, EventArgs e)
        {
            bkgInicioTef.RunWorkerAsync();
        }

        private void ConfigurarColunasGridPagamentos()
        {
            gridPagamentos.AutoGenerateColumns = false;
            gridPagamentos.Columns.Clear();
            gridPagamentos.ScrollBars = ScrollBars.Both;

            AdicionarColunaGrid("Item", "Item", "#", 36, "N0");
            AdicionarColunaGrid("FormaPagamento", "FormaPagamento", "Forma", 100);
            AdicionarColunaGrid("Valor", "Valor", "Valor", 80, "C2");
            AdicionarColunaGrid("Nsu", "Nsu", "NSU", 72);
            AdicionarColunaGrid("Host", "Host", "Host", 95);
            AdicionarColunaGrid("Autorizacao", "Autorizacao", "Autoriz.", 72);
            AdicionarColunaGrid("Rede", "Rede", "Rede", 90);
            AdicionarColunaGrid("CodigoRede", "CodigoRede", "Cód.Rede", 60);
            AdicionarColunaGrid("Bandeira", "Bandeira", "Bandeira", 95);
            AdicionarColunaGrid("Modalidade", "Modalidade", "Modalidade", 110);
            AdicionarColunaGrid("SubModalidade", "SubModalidade", "Submod.", 80);
            AdicionarColunaGrid("TipoTransacao", "TipoTransacao", "Tipo", 55);
            AdicionarColunaGrid("Cartao", "Cartao", "Cartão", 130);
            AdicionarColunaGrid("Bin", "Bin", "BIN", 55);
            AdicionarColunaGrid("Titular", "Titular", "Titular", 120);
            AdicionarColunaGrid("DataTransacao", "DataTransacao", "Data", 78);
            AdicionarColunaGrid("HoraTransacao", "HoraTransacao", "Hora", 65);
            AdicionarColunaGrid("IdTransacao", "IdTransacao", "Id Transação", 140);
            AdicionarColunaGrid("Cnpj", "Cnpj", "CNPJ", 115);
            AdicionarColunaGrid("Credenciadora", "Credenciadora", "Credenciadora", 140);
            AdicionarColunaGrid("Status", "Status", "Status", 80);
        }

        private void AdicionarColunaGrid(string nome, string propriedade, string titulo, int largura, string formato = null)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = nome,
                DataPropertyName = propriedade,
                HeaderText = titulo,
                Width = largura,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (!string.IsNullOrEmpty(formato))
                col.DefaultCellStyle.Format = formato;
            gridPagamentos.Columns.Add(col);
        }

        private void ConfigurarTef()
        {
            _tef.UiOwner = this;
            _tef.CarregarConfiguracao();
            _tef.OnLog = msg => EscreverLogPainel(msg, gravarArquivo: false);
            _tef.OnStatus = msg => { if (InvokeRequired) BeginInvoke(new Action(() => lblStatusOperacao.Text = msg)); else lblStatusOperacao.Text = msg; };
            _tef.OnComprovanteAtualizado = texto =>
            {
                if (InvokeRequired)
                    BeginInvoke(new Action(() => txtComprovante.Text = texto));
                else
                    txtComprovante.Text = texto;
            };

            // Mesmo fluxo do FrmTelaTesteVenda (demo Fiserv): cmd 50 exibe painel na tela.
            _tef.Tef.OnCallPanelQrCode += Tef_OnCallPanelQrCode;
            _tef.Tef.OnClosePanelQrCode += Tef_OnClosePanelQrCode;
        }

        private void Tef_OnCallPanelQrCode(TefFuncaoInterativa interativa)
        {
            if (!interativa.FormAberto && interativa.DataType == DataTypeEnum.QrCode && interativa.TipoCampo == 584)
            {
                lblMenuTituloQrCode.Invoke((MethodInvoker)delegate
                {
                    lblMenuTituloQrCode.Text = interativa.Titulo;
                    lblMenuTituloQrCode.Refresh();
                });
                lblQrCode.Invoke((MethodInvoker)delegate
                {
                    lblQrCode.ImageAlign = ContentAlignment.MiddleCenter;
                    Image qrCode = Functions.Gerar_QRCode(lblQrCode.Width, lblQrCode.Height, interativa.Mensagem);
                    lblQrCode.Image = qrCode;
                    lblQrCode.Text = "";
                    lblQrCode.Refresh();
                });
                CentralizarPainelQr();
                pnlQr.BringToFront();
                pnlQr.Visible = true;
                pnlQr.Refresh();
                interativa.FormAberto = true;
                AppendLog("QR Code exibido (cmd 50).");
            }
        }

        /// <summary>
        /// Centraliza o painel QR sobre o grid de pagamentos. Para posição fixa, edite pnlQr.Location no Designer.
        /// </summary>
        private void CentralizarPainelQr()
        {
            Rectangle area = ObterAreaReferenciaQr();
            int x = area.X + Math.Max(0, (area.Width - pnlQr.Width) / 2);
            int y = area.Y + Math.Max(0, (area.Height - pnlQr.Height) / 2);
            pnlQr.Location = new Point(x, y);
        }

        private Rectangle ObterAreaReferenciaQr()
        {
            if (gridPagamentos.IsHandleCreated && gridPagamentos.Width > 8 && gridPagamentos.Height > 8)
            {
                return pnlPrincipal.RectangleToClient(
                    gridPagamentos.RectangleToScreen(gridPagamentos.ClientRectangle));
            }

            return new Rectangle(0, 0, pnlPrincipal.ClientSize.Width, pnlPrincipal.ClientSize.Height);
        }

        private void Tef_OnClosePanelQrCode(TefFuncaoInterativa interativa)
        {
            if (interativa.FormFechar)
            {
                pnlQr.SendToBack();
                pnlQr.Visible = false;
                lblMenuTituloQrCode.Text = "";
                lblQrCode.Image = null;
                lblQrCode.Text = "";
                interativa.FormAberto = false;
                interativa.FormFechar = false;
            }
        }

        private void bkgInicioTef_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = _tef.InicializarTef();
        }

        private void bkgInicioTef_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int sts = (int)e.Result;
            pnlPrincipal.Enabled = sts == 0;
            if (sts == 0)
            {
                AppendLog("TEF inicializado com sucesso.");
                DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
            }
            else
            {
                AppendLog("Falha ao inicializar TEF: " + _tef.Mensagem(sts));
                DefinirStatusCaixa("TEF INDISPONÍVEL", Color.DarkRed);
                MessageBox.Show(this, _tef.Mensagem(sts), "Inicialização TEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DefinirStatusCaixa(string texto, Color cor)
        {
            lblStatusCaixa.Text = texto;
            lblStatusCaixa.ForeColor = cor;
        }

        private void AppendLog(string linha)
        {
            EscreverLogPainel(linha, gravarArquivo: true);
        }

        private void EscreverLogPainel(string linha, bool gravarArquivo)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => EscreverLogPainel(linha, gravarArquivo)));
                return;
            }
            if (txtLog.TextLength > 120000)
                txtLog.Clear();
            txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + " -> " + linha + Environment.NewLine);
            if (gravarArquivo)
                _tef.RegistrarLogArquivo(linha);
        }

        private void AtualizarTotais()
        {
            decimal total = ObterValorTotalOperacaoAtual();
            if (_tef.ValorTotalOperacao <= 0 && _pagamentos.Count > 0)
            {
                ExibirTotaisVenda(total, _pagamentos.Sum(p => p.Valor));
                return;
            }
            ExibirTotaisVenda(total, _tef.ValorPago);
        }

        private decimal ObterValorTotalOperacaoAtual()
        {
            if (_tef.ValorPago > 0 || _tef.VendaFinalizada)
                return _tef.ValorTotalOperacao;
            return numValorOperacao.Value;
        }

        private string ObterDocumento()
        {
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
                txtDocumento.Text = _tef.GerarDocumento();
            return txtDocumento.Text.Trim();
        }

        private void btnGerarDocumento_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = _tef.GerarDocumento();
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            var posPrinter = _impressora != null ? _impressora.Configuracao : PosPrinterConfigService.ObterInstancia();
            using (var frm = new FrmConfiguracao(posPrinter))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tef.CarregarConfiguracao();
                    _impressora.AplicarConfiguracaoSalva();
                }
            }
        }

        private void btnLimparComprovante_Click(object sender, EventArgs e)
        {
            txtComprovante.Clear();
        }

        private void btnLimparLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = _tef.ObterTextoComprovanteImpressao();
                if (string.IsNullOrWhiteSpace(texto) && !string.IsNullOrWhiteSpace(txtComprovante.Text))
                    texto = ComprovanteBuilder.PreviewParaImpressao(txtComprovante.Text);

                if (string.IsNullOrWhiteSpace(texto))
                {
                    MessageBox.Show(this, "Não há comprovante para imprimir. Efetue um pagamento TEF antes.",
                        "Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _impressora.ImprimirTexto(texto, true);
                AppendLog("Impressão enviada (" + texto.Length + " caracteres).");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(0, "Pagamento");
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(2, "Débito");
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(3, "Crédito");
        }

        private void btnCreditoParceladoEstabelecimento_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(3, "Crédito Parcelado Estabelecimento", "[16;17;24;26;28;34;36;45;3004;3049;3052;3053;3480;3988]");
        }

        private void btnCreditoParceladoEmissor_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(3, "Crédito Parcelado Emissor", "[16;17;24;26;27;34;36;45;3004;3049;3052;3053;3480;3988]");
        }

        private void btnCarteiraDigital_Click(object sender, EventArgs e)
        {
            ExecutarPagamento(122, "Carteira Digital");
        }

        private void ExecutarPagamento(int funcao, string descricao, string parametrosAdicionais = "")
        {
            if (_tef.VendaFinalizada)
            {
                MessageBox.Show(this,
                    "Esta venda já foi concluída. Clique em \"Nova venda\" para iniciar outra operação.",
                    "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numValorOperacao.Value <= 0)
            {
                MessageBox.Show(this, "Informe o valor da operação.", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string documento = ObterDocumento();

            if (_tef.ValorPago > 0)
            {
                if (numValorOperacao.Value != _tef.ValorTotalOperacao)
                    numValorOperacao.Value = _tef.ValorTotalOperacao;
            }
            else
                _tef.ValorTotalOperacao = numValorOperacao.Value;

            decimal restante = _tef.ValorTotalOperacao - _tef.ValorPago;
            if (restante <= 0)
            {
                MessageBox.Show(this, "Operação já quitada.", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal valorPagamento = restante;
            using (var frm = new FrmConfirmarValor(valorPagamento))
            {
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;
                valorPagamento = frm.gValorParaEstaTransacao;
            }

            DefinirStatusCaixa("EM PAGAMENTO", Color.DarkOrange);
            int sts = _tef.EfetuarPagamento(documento, valorPagamento, funcao, parametrosAdicionais);
            if (sts == TefDemoService.CodigoPagamentoDesfeito)
            {
                bool operacaoReiniciada = TratarDesfazimentoPagamento(documento);
                MessageBox.Show(this,
                    operacaoReiniciada
                        ? "Transação desfeita no SiTef (NCN). O pagamento não foi registrado na venda.\n\n" +
                          "Documento e valor da operação foram limpos para iniciar uma nova venda."
                        : "Transação desfeita no SiTef (NCN). O pagamento não foi registrado na venda.\n\n" +
                          "Foi gerado um novo número de documento para o próximo pagamento desta venda.",
                    "TEF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DefinirStatusCaixa(_tef.ValorPago > 0 ? "PAGAMENTO PARCIAL" : "CAIXA LIVRE",
                    _tef.ValorPago > 0 ? Color.DarkGoldenrod : Color.DarkGreen);
                return;
            }

            if (sts == 0)
            {
                _itemPagamento++;
                string statusGrid = _tef.ConfirmacaoAutomatica ? "Aprovado" : "Pendente";
                _pagamentos.Add(_tef.CriarItemGridPagamento(_itemPagamento, descricao, valorPagamento, statusGrid));
                gridPagamentos.Refresh();
                AtualizarTotais();
                BloquearCamposVendaEmAndamento();

                if (_tef.ValorPago >= _tef.ValorTotalOperacao)
                {
                    FinalizarVenda(documento);
                }
                else
                {
                    DefinirStatusCaixa("PAGAMENTO PARCIAL", Color.DarkGoldenrod);
                    AppendLog("Falta pagar: " + (_tef.ValorTotalOperacao - _tef.ValorPago).ToString("C2"));
                }
            }
            else
            {
                MessageBox.Show(this, _tef.Mensagem(sts), "TEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
            }
        }

        /// <summary>
        /// Após NCN: reinicia operação inteira (sem pagamentos) ou só troca o documento TEF (venda parcial).
        /// </summary>
        /// <returns>true se documento e valor da operação foram limpos.</returns>
        private bool TratarDesfazimentoPagamento(string documentoDesfeito)
        {
            bool reiniciarOperacao = _tef.ValorPago <= 0 && _pagamentos.Count == 0;
            _tef.DescartarOperacaoDesfeita(documentoDesfeito);

            if (reiniciarOperacao)
            {
                txtDocumento.Clear();
                numValorOperacao.Value = 0;
                txtComprovante.Clear();
                LiberarCamposVenda();
                HabilitarControlesPagamento(true);
                AtualizarTotais();
                AppendLog("Documento e valor da operação limpos (NCN) doc=" + documentoDesfeito);
                return true;
            }

            txtDocumento.Text = _tef.GerarDocumento();
            AppendLog("Novo documento para próximo pagamento (NCN) doc=" + documentoDesfeito + " -> " + txtDocumento.Text);
            return false;
        }

        private void ReverterVendaAposDesfazerPendentes(string documento)
        {
            _tef.DescartarOperacaoDesfeita(documento);
            _pagamentos.Clear();
            _itemPagamento = 0;
            _tef.ReiniciarVenda();
            txtDocumento.Clear();
            numValorOperacao.Value = 0;
            txtComprovante.Clear();
            LiberarCamposVenda();
            HabilitarControlesPagamento(true);
            AtualizarTotais();
            AppendLog("Venda revertida após NCN na finalização doc=" + documento);
        }

        private void FinalizarVenda(string documento)
        {
            var resultado = _tef.ConfirmarPendentesParaFinalizarVenda(this, documento);
            if (resultado == ResultadoConfirmacaoPendentes.DesfeitoNcn)
            {
                ReverterVendaAposDesfazerPendentes(documento);
                MessageBox.Show(this,
                    "Transações desfeitas no SiTef (NCN). Os pagamentos deste cupom foram removidos da venda.",
                    "TEF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
                return;
            }

            try
            {
                string texto = _tef.ObterTextoComprovanteImpressao();
                if (!string.IsNullOrWhiteSpace(texto) && _impressora.EnviarImpressora)
                    _impressora.ImprimirTexto(texto, true);
            }
            catch (Exception ex)
            {
                AppendLog("Impressão: " + ex.Message);
            }

            AppendLog("Venda finalizada. Documento " + documento);

            foreach (var item in _pagamentos)
                item.Status = "Finalizado";
            gridPagamentos.Refresh();

            // Mantém grid, totais e ValorPago; bloqueia novos pagamentos até "Nova venda".
            decimal totalVenda = _tef.ValorTotalOperacao;
            decimal totalPago = _tef.ValorPago;
            _tef.MarcarVendaFinalizada();
            ExibirTotaisVenda(totalVenda, totalPago);
            DefinirStatusCaixa("VENDA CONCLUÍDA", Color.DarkGreen);
            HabilitarControlesPagamento(false);
            BloquearCamposVendaEmAndamento();
        }

        private void HabilitarControlesPagamento(bool habilitar)
        {
            btnEfetuarPagamento.Enabled = habilitar;
            btnDebito.Enabled = habilitar;
            btnCredito.Enabled = habilitar;
            btnCarteiraDigital.Enabled = habilitar;
        }

        private void BloquearCamposVendaEmAndamento()
        {
            numValorOperacao.Enabled = false;
            txtDocumento.Enabled = false;
            btnGerarDocumento.Enabled = false;
        }

        private void LiberarCamposVenda()
        {
            numValorOperacao.Enabled = true;
            txtDocumento.Enabled = true;
            btnGerarDocumento.Enabled = true;
        }

        private void ExibirTotaisVenda(decimal total, decimal pago)
        {
            decimal troco = pago > total ? pago - total : 0;
            lblTotalOperacao.Text = total.ToString("C2");
            lblTotalPago.Text = pago.ToString("C2");
            lblTroco.Text = troco.ToString("C2");
        }

        private void btnMenuAdm_Click(object sender, EventArgs e)
        {
            string doc = ObterDocumento();
            DefinirStatusCaixa("ADMINISTRATIVO", Color.SteelBlue);
            int sts = _tef.MenuAdministrativo(doc);
            if (sts != 0)
                MessageBox.Show(this, _tef.Mensagem(sts), "ADM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            string doc = ObterDocumento();
            int sts = _tef.CancelarTransacao(doc);
            if (sts == 0)
                AppendLog("Cancelamento executado.");
            else
                MessageBox.Show(this, _tef.Mensagem(sts), "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _tef.ReiniciarVenda();
            _pagamentos.Clear();
            _itemPagamento = 0;
            AtualizarTotais();
            HabilitarControlesPagamento(true);
            LiberarCamposVenda();
            DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
        }

        private void btnVerificarPinPad_Click(object sender, EventArgs e)
        {
            int sts = _tef.VerificarPinPad();
            MessageBox.Show(this, sts > 0 ? "PinPad OK." : "PinPad não responde (código " + sts + ").",
                "PinPad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAtv_Click(object sender, EventArgs e)
        {
            int sts = _tef.Atv();
            MessageBox.Show(this, _tef.Mensagem(sts), "Ativação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            if (_tef.ValorPago > 0 && _tef.ValorPago < _tef.ValorTotalOperacao)
            {
                if (MessageBox.Show(this, "Existem pagamentos parciais. Deseja cancelar pendências e reiniciar?",
                    "Nova venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _tef.CancelarPendentes(ObterDocumento());
            }
            _tef.ReiniciarVenda();
            _pagamentos.Clear();
            _itemPagamento = 0;
            numValorOperacao.Value = 0;
            txtDocumento.Clear();
            txtComprovante.Clear();
            AtualizarTotais();
            HabilitarControlesPagamento(true);
            LiberarCamposVenda();
            DefinirStatusCaixa("CAIXA LIVRE", Color.DarkGreen);
        }
    }
}
