namespace Lib.FormsAuxiliares
{
    partial class FrmConfirmarDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDocumentoTransacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDocumentoTransacao
            // 
            this.txtDocumentoTransacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumentoTransacao.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoTransacao.Location = new System.Drawing.Point(12, 14);
            this.txtDocumentoTransacao.Name = "txtDocumentoTransacao";
            this.txtDocumentoTransacao.Size = new System.Drawing.Size(208, 26);
            this.txtDocumentoTransacao.TabIndex = 0;
            // 
            // FrmConfirmarDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 52);
            this.ControlBox = false;
            this.Controls.Add(this.txtDocumentoTransacao);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfirmarDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Documento";
            this.Load += new System.EventHandler(this.FrmConfirmarDoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfirmarDoc_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocumentoTransacao;
    }
}