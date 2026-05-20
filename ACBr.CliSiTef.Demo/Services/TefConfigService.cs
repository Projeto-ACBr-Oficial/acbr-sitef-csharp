using Lib.CliSitef.Classes;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Lib.Utils.Classes;

namespace ACBr.CliSiTef.Demo.Services
{
    public static class TefConfigService
    {
        public static TefConfig Carregar()
        {
            return new TefConfig
            {
                Tef_PathArquivos = Application.StartupPath,
                Tef_Ip = ConfigurationManager.AppSettings["Tef_Ip"],
                Tef_Empresa = ConfigurationManager.AppSettings["Tef_Empresa"],
                Tef_EmpresaCnpj = ConfigurationManager.AppSettings["Tef_EmpresaCnpj"],
                Tef_Terminal = ConfigurationManager.AppSettings["Tef_Terminal"],
                Tef_SoftwareHouseCnpj = ConfigurationManager.AppSettings["Tef_SoftwareHouseCnpj"],
                Tef_PinPadPorta = ConfigurationManager.AppSettings["Tef_PinPadPorta"],
                Tef_PinPadMensagem = ConfigurationManager.AppSettings["Tef_PinPadMensagem"],
                Tef_PinPadVerificar = ConfigurationManager.AppSettings["Tef_PinPadVerificar"] == "1",
                Tef_PinPadQrCode = ConfigurationManager.AppSettings["Tef_PinPadQrCode"] == "1",
                Tef_SenhaCodigoSupervisor = ConvertHelper.ToInt32(ConfigurationManager.AppSettings["Tef_SenhaCodigoSupervisor"], 1234),
                Tef_TipoComunicacaoExterna = ConfigurationManager.AppSettings["Tef_TipoComunicacaoExterna"]
            };
        }

        public static void Salvar(TefConfig config, bool enviarImpressora, bool confirmacaoAutomatica)
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SalvarChave(cfg, "Tef_Ip", config.Tef_Ip);
            SalvarChave(cfg, "Tef_Empresa", config.Tef_Empresa);
            SalvarChave(cfg, "Tef_EmpresaCnpj", config.Tef_EmpresaCnpj);
            SalvarChave(cfg, "Tef_Terminal", config.Tef_Terminal);
            SalvarChave(cfg, "Tef_SoftwareHouseCnpj", config.Tef_SoftwareHouseCnpj);
            SalvarChave(cfg, "Tef_PinPadPorta", config.Tef_PinPadPorta);
            SalvarChave(cfg, "Tef_PinPadMensagem", config.Tef_PinPadMensagem);
            SalvarChave(cfg, "Tef_PinPadVerificar", config.Tef_PinPadVerificar ? "1" : "0");
            SalvarChave(cfg, "Tef_PinPadQrCode", config.Tef_PinPadQrCode ? "1" : "0");
            SalvarChave(cfg, "Tef_SenhaCodigoSupervisor", config.Tef_SenhaCodigoSupervisor.ToString());
            SalvarChave(cfg, "Tef_TipoComunicacaoExterna", config.Tef_TipoComunicacaoExterna ?? "");
            SalvarChave(cfg, "PosPrinter_EnviarImpressora", enviarImpressora ? "1" : "0");
            SalvarChave(cfg, "Tef_ConfirmacaoAutomatica", confirmacaoAutomatica ? "1" : "0");
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            GarantirCliSiTefIni(config);
        }

        public static bool ObterConfirmacaoAutomatica()
        {
            return ObterAppSetting("Tef_ConfirmacaoAutomatica", "1") == "1";
        }

        private static void SalvarChave(Configuration cfg, string key, string value)
        {
            if (cfg.AppSettings.Settings[key] == null)
                cfg.AppSettings.Settings.Add(key, value);
            else
                cfg.AppSettings.Settings[key].Value = value;
        }

        public static void GarantirCliSiTefIni(TefConfig config)
        {
            string path = Path.Combine(Application.StartupPath, "CliSiTef.ini");
            if (File.Exists(path))
                return;

            using (var sw = File.AppendText(path))
            {
                sw.WriteLine("[PinPad]");
                sw.WriteLine("Tipo=Compartilhado");
                sw.WriteLine("");
                sw.WriteLine("[PinPadCompartilhado]");
                sw.WriteLine("Porta=" + config.Tef_PinPadPorta);
                sw.WriteLine("");
                sw.WriteLine("[SiTef]");
                sw.WriteLine("MantemConexaoAtiva=1");
                sw.WriteLine("TempoEsperaConexao=10");
                sw.WriteLine("");
                sw.WriteLine("[Geral]");
                sw.WriteLine("TransacoesAdicionaisHabilitadas=7;8;16;26;29;30;40;42;43;3014;3044;4178;");
                sw.WriteLine("TransacoesDesabilitadas=10;11;12;13;14;17;18;19;31;27;28;32;33;36;44;45;47;3031;3084;3086;3145;3165;3227;3480;3988;3989;");
                sw.WriteLine("");
                sw.WriteLine("[SrvCliSiTef]");
                sw.WriteLine("IpSiTef=" + config.Tef_Ip);
                sw.WriteLine("");
                sw.WriteLine("[RecargaCelular]");
                sw.WriteLine(";0-nao solicita/1-Pinpad/2-PDV");
                sw.WriteLine("TipoConfirmacaoNumeroCelular=2");
                sw.WriteLine("HabilitaRecargaMultiConcessionaria=1");
            }
        }

        public static string ObterAppSetting(string key, string padrao = "")
        {
            return ConfigurationManager.AppSettings[key] ?? padrao;
        }
    }
}
