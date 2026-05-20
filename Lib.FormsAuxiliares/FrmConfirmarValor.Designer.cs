namespace Lib.FormsAuxiliares
{
    partial class FrmConfirmarValor
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
            this.numValorVenda = new System.Windows.Forms.NumericUpDown();
            this.btnPagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValorVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // numValorVenda
            // 
            this.numValorVenda.DecimalPlaces = 2;
            this.numValorVenda.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValorVenda.Location = new System.Drawing.Point(30, 14);
            this.numValorVenda.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numValorVenda.Name = "numValorVenda";
            this.numValorVenda.Size = new System.Drawing.Size(115, 26);
            this.numValorVenda.TabIndex = 0;
            this.numValorVenda.ThousandsSeparator = true;
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPagar.Location = new System.Drawing.Point(151, 12);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(72, 30);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // FrmConfirmarValor
            // 
            this.AcceptButton = this.btnPagar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 52);
            this.ControlBox = false;
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.numValorVenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmConfirmarValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Valor para esta transação";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfirmarValor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numValorVenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numValorVenda;
        private System.Windows.Forms.Button btnPagar;
    }
}