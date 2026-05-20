using ACBr.CliSiTef.Demo.Helpers;
using ACBr.CliSiTef.Demo.Services;
using ACBrLib.Core.PosPrinter;
using Lib.CliSitef.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo
{
    public partial class FrmConfiguracao : Form
    {
        private PosPrinterConfigService _posPrinter;

        public FrmConfiguracao()
            : this(null)
        {
        }

        public FrmConfiguracao(PosPrinterConfigService posPrinterCompartilhado)
        {
            InitializeComponent();
            _posPrinter = posPrinterCompartilhado ?? PosPrinterConfigService.ObterInstancia();
        }

        private void FrmConfiguracao_Load(object sender, EventArgs e)
        {
            AppIconHelper.AplicarIcone(this);
            var cfg = TefConfigService.Carregar();
            txtIp.Text = cfg.Tef_Ip;
            txtEmpresa.Text = cfg.Tef_Empresa;
            txtEmpresaCnpj.Text = cfg.Tef_EmpresaCnpj;
            txtTerminal.Text = cfg.Tef_Terminal;
            txtSoftwareHouseCnpj.Text = cfg.Tef_SoftwareHouseCnpj;
            txtPinPadPorta.Text = cfg.Tef_PinPadPorta;
            txtPinPadMensagem.Text = cfg.Tef_PinPadMensagem;
            chkPinPadVerificar.Checked = cfg.Tef_PinPadVerificar;
            chkPinPadQrCode.Checked = cfg.Tef_PinPadQrCode;
            txtSenhaSupervisor.Text = cfg.Tef_SenhaCodigoSupervisor.ToString();
            txtTipoComunicacao.Text = cfg.Tef_TipoComunicacaoExterna;

            chkEnviarImpressora.Checked = TefConfigService.ObterAppSetting("PosPrinter_EnviarImpressora") == "1";
            chkConfirmacaoAutomatica.Checked = TefConfigService.ObterConfirmacaoAutomatica();

            CarregarConfigImpressora();
        }

        private void CarregarConfigImpressora()
        {
            var cfg = _posPrinter.Instancia.Config;
            _posPrinter.Carregar();

            ComboEnumHelper.PopularEnum(cmbModelo, cfg.Modelo);
            ComboEnumHelper.PopularEnum(cmbPaginaCodigo, cfg.PaginaDeCodigo);

            cmbPorta.Items.Clear();
            cmbPorta.Items.AddRange(_posPrinter.ListarPortas());
            if (!string.IsNullOrWhiteSpace(cfg.Porta))
            {
                if (!cmbPorta.Items.Contains(cfg.Porta))
                    cmbPorta.Items.Insert(0, cfg.Porta);
                cmbPorta.Text = cfg.Porta;
            }
            else if (cmbPorta.Items.Count > 0)
            {
                cmbPorta.SelectedIndex = 0;
            }

            nudColunas.Value = Math.Max(nudColunas.Minimum, Math.Min(nudColunas.Maximum, cfg.ColunasFonteNormal));
            nudEspacos.Value = Math.Max(nudEspacos.Minimum, Math.Min(nudEspacos.Maximum, cfg.EspacoEntreLinhas));
            nudBuffer.Value = Math.Max(nudBuffer.Minimum, Math.Min(nudBuffer.Maximum, cfg.LinhasBuffer));
            nudLinhasPular.Value = Math.Max(nudLinhasPular.Minimum, Math.Min(nudLinhasPular.Maximum, cfg.LinhasEntreCupons));

            chkControlePorta.Checked = cfg.ControlePorta;
            chkCortarPapel.Checked = cfg.CortaPapel;
            chkTraduzirTags.Checked = cfg.TraduzirTags;
            chkIgnorarTags.Checked = cfg.IgnorarTags;
            txtArqLog.Text = PosPrinterConfigService.NormalizarCaminhoArqLog(cfg.ArqLog);

            btnAtivar.Text = @"Ativar";
        }

        private void SalvarConfigImpressora()
        {
            var cfg = _posPrinter.Instancia.Config;
            cfg.Modelo = ComboEnumHelper.ObterSelecionado(cmbModelo, ACBrPosPrinterModelo.ppEscPosEpson);
            cfg.Porta = cmbPorta.Text.Trim();
            cfg.ColunasFonteNormal = (int)nudColunas.Value;
            cfg.EspacoEntreLinhas = (int)nudEspacos.Value;
            cfg.LinhasBuffer = (int)nudBuffer.Value;
            cfg.LinhasEntreCupons = (int)nudLinhasPular.Value;
            cfg.ControlePorta = chkControlePorta.Checked;
            cfg.CortaPapel = chkCortarPapel.Checked;
            cfg.TraduzirTags = chkTraduzirTags.Checked;
            cfg.IgnorarTags = chkIgnorarTags.Checked;
            cfg.ArqLog = PosPrinterConfigService.NormalizarCaminhoArqLog(txtArqLog.Text);
            cfg.PaginaDeCodigo = ComboEnumHelper.ObterSelecionado(cmbPaginaCodigo, PosPaginaCodigo.pc850);
            _posPrinter.Gravar();
        }

        private TefConfig MontarTefConfig()
        {
            return new TefConfig
            {
                Tef_Ip = txtIp.Text.Trim(),
                Tef_Empresa = txtEmpresa.Text.Trim(),
                Tef_EmpresaCnpj = txtEmpresaCnpj.Text.Trim(),
                Tef_Terminal = txtTerminal.Text.Trim(),
                Tef_SoftwareHouseCnpj = txtSoftwareHouseCnpj.Text.Trim(),
                Tef_PinPadPorta = txtPinPadPorta.Text.Trim(),
                Tef_PinPadMensagem = txtPinPadMensagem.Text.Trim(),
                Tef_PinPadVerificar = chkPinPadVerificar.Checked,
                Tef_PinPadQrCode = chkPinPadQrCode.Checked,
                Tef_SenhaCodigoSupervisor = int.TryParse(txtSenhaSupervisor.Text, out int s) ? s : 1234,
                Tef_TipoComunicacaoExterna = txtTipoComunicacao.Text.Trim()
            };
        }

        private void SalvarConfiguracao()
        {
            SalvarConfigImpressora();
            TefConfigService.Salvar(MontarTefConfig(), chkEnviarImpressora.Checked, chkConfirmacaoAutomatica.Checked);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarConfiguracao();
                MessageBox.Show(this, "Configurações salvas.", "ACBr CliSiTef", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Salvar configurações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestarTef_Click(object sender, EventArgs e)
        {
            SalvarConfiguracao();
            var svc = new TefDemoService();
            svc.CarregarConfiguracao();
            int sts = svc.InicializarTef();
            MessageBox.Show(this, sts == 0 ? "TEF inicializado com sucesso." : svc.Mensagem(sts),
                "Testar TEF", MessageBoxButtons.OK, sts == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void btnTestarImpressora_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarConfigImpressora();
                _posPrinter.Carregar();
                _posPrinter.GarantirAtiva();
                string texto = "TESTE IMPRESSAO\r\nACBr CliSiTef Demo\r\n" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n</corte_total>";
                _posPrinter.Imprimir(ComprovanteBuilder.ParaEscPos(texto));
                MessageBox.Show(this, "Comando de impressão enviado.", "Impressora", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Impressora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAtivar.Text == @"Ativar")
                {
                    SalvarConfigImpressora();
                    _posPrinter.Carregar();
                    _posPrinter.GarantirAtiva();
                    btnAtivar.Text = @"Desativar";
                }
                else
                {
                    _posPrinter.Desativar();
                    btnAtivar.Text = @"Ativar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Impressora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAtivar.Text = @"Ativar";
            }
        }

        private void btnArqLog_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = @"Arquivo Log (*.log)|*.log|Todos os Arquivos (*.*)|*.*";
                dlg.CheckFileExists = false;
                if (!string.IsNullOrWhiteSpace(txtArqLog.Text))
                    dlg.FileName = Path.GetFileName(txtArqLog.Text);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtArqLog.Text = dlg.FileName;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
