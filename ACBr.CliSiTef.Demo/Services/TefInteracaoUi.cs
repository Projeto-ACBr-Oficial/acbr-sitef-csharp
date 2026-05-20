using Lib.CliSitef.Classes;
using Lib.FormsAuxiliares;
using Lib.Utils.Classes;
using Lib.Utils.Enuns;
using System;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Services
{
    public static class TefInteracaoUi
    {
        public static void TratarCallForm(IWin32Window owner, TefFuncaoInterativa interativa, TefConfig config)
        {
            if (interativa == null)
                return;

            if (interativa.DataType == DataTypeEnum.Await)
            {
                using (var frm = new FrmTefAguarde())
                {
                    frm.gMensagem = interativa.Mensagem;
                    frm.ShowDialog(owner);
                }
            }
            else if (interativa.DataType == DataTypeEnum.Confirmation)
            {
                if (MessageBox.Show(owner, interativa.Mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    interativa.RespostaSitef = "0";
                if (interativa.TipoCampo == 5013 && interativa.RespostaSitef == "1")
                    interativa.Interromper = false;
            }
            else if (interativa.DataType == DataTypeEnum.Menu)
            {
                using (var frm = new FrmTefMenu())
                {
                    frm.gTitulo = interativa.Titulo;
                    frm.gItens = interativa.ItensMenu;
                    frm.ShowDialog(owner);
                    if (frm.DialogResult == DialogResult.OK)
                        interativa.RespostaSitef = (frm.gSelecionado + 1).ToString();
                    else
                        interativa.Interromper = !frm.VoltarSelecionado;
                    interativa.Voltar = frm.VoltarSelecionado;
                }
            }
            else if (interativa.DataType == DataTypeEnum.Numeric)
            {
                using (var frm = new FrmTefColetaDados())
                {
                    frm.gTitulo = interativa.Titulo;
                    frm.gTamanhoMinimo = interativa.TamanhoMinimo;
                    frm.gTamanhoMaximo = interativa.TamanhoMaximo;
                    frm.gTipoDeDados = DataTypeEnum.Numeric;
                    if (interativa.TipoCampo == 500)
                        frm.txtDados.PasswordChar = '*';
                    frm.ShowDialog(owner);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        interativa.RespostaSitef = frm.txtDados.Text;
                        if (interativa.TipoCampo == 500 && !frm.VoltarSelecionado &&
                            config.Tef_SenhaCodigoSupervisor != ConvertHelper.ToInt32(frm.txtDados.Text))
                        {
                            MessageBox.Show(owner, "Senha/Código Supervisor inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frm.VoltarSelecionado = true;
                        }
                    }
                    else
                        interativa.Interromper = !frm.VoltarSelecionado;
                    interativa.Voltar = frm.VoltarSelecionado;
                }
            }
            else if (interativa.DataType == DataTypeEnum.Currency &&
                     (interativa.TipoCampo == 0 || interativa.Comando == 34))
            {
                using (var frm = new FrmTefColetaDados())
                {
                    frm.gTitulo = interativa.Titulo;
                    frm.gTamanhoMinimo = interativa.TamanhoMinimo;
                    frm.gTamanhoMaximo = interativa.TamanhoMaximo;
                    frm.gTipoDeDados = DataTypeEnum.Currency;
                    frm.ShowDialog(owner);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        string valor = "";
                        if (!string.IsNullOrWhiteSpace(frm.txtDados.Text) && decimal.TryParse(frm.txtDados.Text, out decimal v) && v > 0)
                            valor = v.ToString("N2");
                        interativa.RespostaSitef = valor;
                    }
                    else
                        interativa.Interromper = !frm.VoltarSelecionado;
                    interativa.Voltar = frm.VoltarSelecionado;
                }
            }
            else if (interativa.DataType == DataTypeEnum.QrCode && interativa.TipoCampo == 584 &&
                     !string.IsNullOrWhiteSpace(interativa.Mensagem))
            {
                using (var frm = new FrmTefQrCode())
                {
                    frm.gTitulo = interativa.Titulo;
                    frm.gStrQrCode = interativa.Mensagem;
                    frm.ShowDialog(owner);
                    if (frm.DialogResult == DialogResult.OK)
                        interativa.RespostaSitef = frm.lblQrCode.Text;
                    else
                        interativa.Interromper = true;
                }
            }
        }
    }
}
