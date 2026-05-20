using System;
using System.Windows.Forms;

namespace Lib.FormsAuxiliares
{
    public partial class FrmConfirmarDoc : Form
    {
        public string gDocumentoTransacao { get; set; }
        public string gTituloFormulario { get; set; }

        public FrmConfirmarDoc()
        {
            InitializeComponent();
        }

        private void FrmConfirmarDoc_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gTituloFormulario))
                Text = gTituloFormulario;

            txtDocumentoTransacao.Focus();
        }
        private void FrmConfirmarDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(txtDocumentoTransacao.Text) <= 0)
                    return;

                gDocumentoTransacao = txtDocumentoTransacao.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}