using System;
using System.Windows.Forms;

namespace Lib.FormsAuxiliares
{
    public partial class FrmConfirmarValor : Form
    {
        public decimal gValorParaEstaTransacao { get; set; }

        public FrmConfirmarValor(decimal _valorTransacao)
        {
            InitializeComponent();
            numValorVenda.Value = _valorTransacao;
        }

        private void FrmConfirmarValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Confirmar();
            else if (e.KeyCode == Keys.Escape)
                Cancelar();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        private void Confirmar()
        {
            if (numValorVenda.Value <= 0)
                return;

            gValorParaEstaTransacao = numValorVenda.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancelar()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
