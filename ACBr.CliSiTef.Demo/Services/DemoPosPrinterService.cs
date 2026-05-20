using System;

namespace ACBr.CliSiTef.Demo.Services
{
    public sealed class DemoPosPrinterService
    {
        public PosPrinterConfigService Configuracao => PosPrinterConfigService.ObterInstancia();

        public bool EnviarImpressora => TefConfigService.ObterAppSetting("PosPrinter_EnviarImpressora") == "1";

        public void AplicarConfiguracaoSalva()
        {
            Configuracao.Carregar();
        }

        public void ImprimirTexto(string textoSimples, bool forcarImpressora = false)
        {
            if (string.IsNullOrWhiteSpace(textoSimples))
                throw new InvalidOperationException("Não há comprovante para imprimir.");

            if (!forcarImpressora && !EnviarImpressora)
                return;

            var cfg = Configuracao;
            cfg.Carregar();
            cfg.GarantirAtiva();
            cfg.Imprimir(ComprovanteBuilder.ParaEscPos(textoSimples));
        }

        public void TestarImpressao()
        {
            var cfg = Configuracao;
            cfg.Carregar();
            cfg.GarantirAtiva();
            string texto = "TESTE IMPRESSAO\r\nACBr CliSiTef Demo\r\n" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n</corte_total>";
            cfg.Imprimir(ComprovanteBuilder.ParaEscPos(texto));
        }
    }
}
