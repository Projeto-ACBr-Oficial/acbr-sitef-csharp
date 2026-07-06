namespace ACBr.CliSiTef.Demo
{
    partial class FrmPdv
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnConfiguracao = new System.Windows.Forms.Button();
            this.lblStatusOperacao = new System.Windows.Forms.Label();
            this.lblStatusCaixa = new System.Windows.Forms.Label();
            this.splitPrincipal = new System.Windows.Forms.SplitContainer();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.tabOperacao = new System.Windows.Forms.TabControl();
            this.tabVenda = new System.Windows.Forms.TabPage();
            this.gridPagamentos = new System.Windows.Forms.DataGridView();
            this.pnlVendaTopo = new System.Windows.Forms.Panel();
            this.btnCreditoParceladoEmissor = new System.Windows.Forms.Button();
            this.btnCreditoParceladoEstabelecimento = new System.Windows.Forms.Button();
            this.btnNovaVenda = new System.Windows.Forms.Button();
            this.btnCarteiraDigital = new System.Windows.Forms.Button();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.btnEfetuarPagamento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numValorOperacao = new System.Windows.Forms.NumericUpDown();
            this.btnGerarDocumento = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlVendaRodape = new System.Windows.Forms.Panel();
            this.tblTotais = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalOperacao = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnAtv = new System.Windows.Forms.Button();
            this.btnVerificarPinPad = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnMenuAdm = new System.Windows.Forms.Button();
            this.pnlQr = new System.Windows.Forms.Panel();
            this.lblQrCabecalho = new System.Windows.Forms.Label();
            this.lblQrCode = new System.Windows.Forms.Label();
            this.lblMenuTituloQrCode = new System.Windows.Forms.Label();
            this.splitDireita = new System.Windows.Forms.SplitContainer();
            this.grpComprovante = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimparComprovante = new System.Windows.Forms.Button();
            this.txtComprovante = new System.Windows.Forms.TextBox();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.btnLimparLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.bkgInicioTef = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.numQtdParcelas = new System.Windows.Forms.NumericUpDown();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tabOperacao.SuspendLayout();
            this.tabVenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).BeginInit();
            this.pnlVendaTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValorOperacao)).BeginInit();
            this.pnlVendaRodape.SuspendLayout();
            this.tblTotais.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.pnlQr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDireita)).BeginInit();
            this.splitDireita.Panel1.SuspendLayout();
            this.splitDireita.Panel2.SuspendLayout();
            this.splitDireita.SuspendLayout();
            this.grpComprovante.SuspendLayout();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlTopo.Controls.Add(this.btnConfiguracao);
            this.pnlTopo.Controls.Add(this.lblStatusOperacao);
            this.pnlTopo.Controls.Add(this.lblStatusCaixa);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1172, 64);
            this.pnlTopo.TabIndex = 0;
            // 
            // btnConfiguracao
            // 
            this.btnConfiguracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfiguracao.Location = new System.Drawing.Point(1052, 16);
            this.btnConfiguracao.Name = "btnConfiguracao";
            this.btnConfiguracao.Size = new System.Drawing.Size(108, 32);
            this.btnConfiguracao.TabIndex = 2;
            this.btnConfiguracao.Text = "Configuração";
            this.btnConfiguracao.UseVisualStyleBackColor = true;
            this.btnConfiguracao.Click += new System.EventHandler(this.btnConfiguracao_Click);
            // 
            // lblStatusOperacao
            // 
            this.lblStatusOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusOperacao.Location = new System.Drawing.Point(12, 40);
            this.lblStatusOperacao.Name = "lblStatusOperacao";
            this.lblStatusOperacao.Size = new System.Drawing.Size(1028, 18);
            this.lblStatusOperacao.TabIndex = 1;
            this.lblStatusOperacao.Text = "Aguardando...";
            // 
            // lblStatusCaixa
            // 
            this.lblStatusCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusCaixa.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatusCaixa.Location = new System.Drawing.Point(120, 8);
            this.lblStatusCaixa.Name = "lblStatusCaixa";
            this.lblStatusCaixa.Size = new System.Drawing.Size(908, 32);
            this.lblStatusCaixa.TabIndex = 0;
            this.lblStatusCaixa.Text = "CAIXA LIVRE";
            this.lblStatusCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitPrincipal
            // 
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.Location = new System.Drawing.Point(0, 64);
            this.splitPrincipal.Name = "splitPrincipal";
            // 
            // splitPrincipal.Panel1
            // 
            this.splitPrincipal.Panel1.Controls.Add(this.pnlPrincipal);
            this.splitPrincipal.Panel1MinSize = 520;
            // 
            // splitPrincipal.Panel2
            // 
            this.splitPrincipal.Panel2.Controls.Add(this.splitDireita);
            this.splitPrincipal.Panel2MinSize = 320;
            this.splitPrincipal.Size = new System.Drawing.Size(1172, 617);
            this.splitPrincipal.SplitterDistance = 673;
            this.splitPrincipal.TabIndex = 1;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.tabOperacao);
            this.pnlPrincipal.Controls.Add(this.pnlQr);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Enabled = false;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(673, 617);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // tabOperacao
            // 
            this.tabOperacao.Controls.Add(this.tabVenda);
            this.tabOperacao.Controls.Add(this.tabAdmin);
            this.tabOperacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperacao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabOperacao.Location = new System.Drawing.Point(0, 0);
            this.tabOperacao.Name = "tabOperacao";
            this.tabOperacao.SelectedIndex = 0;
            this.tabOperacao.Size = new System.Drawing.Size(673, 617);
            this.tabOperacao.TabIndex = 0;
            // 
            // tabVenda
            // 
            this.tabVenda.Controls.Add(this.gridPagamentos);
            this.tabVenda.Controls.Add(this.pnlVendaTopo);
            this.tabVenda.Controls.Add(this.pnlVendaRodape);
            this.tabVenda.Location = new System.Drawing.Point(4, 24);
            this.tabVenda.Name = "tabVenda";
            this.tabVenda.Padding = new System.Windows.Forms.Padding(8);
            this.tabVenda.Size = new System.Drawing.Size(665, 589);
            this.tabVenda.TabIndex = 0;
            this.tabVenda.Text = "Venda";
            this.tabVenda.UseVisualStyleBackColor = true;
            // 
            // gridPagamentos
            // 
            this.gridPagamentos.AllowUserToAddRows = false;
            this.gridPagamentos.AllowUserToDeleteRows = false;
            this.gridPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPagamentos.Location = new System.Drawing.Point(8, 200);
            this.gridPagamentos.Name = "gridPagamentos";
            this.gridPagamentos.ReadOnly = true;
            this.gridPagamentos.RowHeadersVisible = false;
            this.gridPagamentos.Size = new System.Drawing.Size(649, 305);
            this.gridPagamentos.TabIndex = 5;
            // 
            // pnlVendaTopo
            // 
            this.pnlVendaTopo.Controls.Add(this.numQtdParcelas);
            this.pnlVendaTopo.Controls.Add(this.label1);
            this.pnlVendaTopo.Controls.Add(this.btnCreditoParceladoEmissor);
            this.pnlVendaTopo.Controls.Add(this.btnCreditoParceladoEstabelecimento);
            this.pnlVendaTopo.Controls.Add(this.btnNovaVenda);
            this.pnlVendaTopo.Controls.Add(this.btnCarteiraDigital);
            this.pnlVendaTopo.Controls.Add(this.btnCredito);
            this.pnlVendaTopo.Controls.Add(this.btnDebito);
            this.pnlVendaTopo.Controls.Add(this.btnEfetuarPagamento);
            this.pnlVendaTopo.Controls.Add(this.label3);
            this.pnlVendaTopo.Controls.Add(this.numValorOperacao);
            this.pnlVendaTopo.Controls.Add(this.btnGerarDocumento);
            this.pnlVendaTopo.Controls.Add(this.txtDocumento);
            this.pnlVendaTopo.Controls.Add(this.label2);
            this.pnlVendaTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVendaTopo.Location = new System.Drawing.Point(8, 8);
            this.pnlVendaTopo.Name = "pnlVendaTopo";
            this.pnlVendaTopo.Size = new System.Drawing.Size(649, 192);
            this.pnlVendaTopo.TabIndex = 1;
            // 
            // btnCreditoParceladoEmissor
            // 
            this.btnCreditoParceladoEmissor.Location = new System.Drawing.Point(380, 124);
            this.btnCreditoParceladoEmissor.Name = "btnCreditoParceladoEmissor";
            this.btnCreditoParceladoEmissor.Size = new System.Drawing.Size(117, 53);
            this.btnCreditoParceladoEmissor.TabIndex = 18;
            this.btnCreditoParceladoEmissor.Text = "Crédito Parcelado Emissor";
            this.btnCreditoParceladoEmissor.UseVisualStyleBackColor = true;
            this.btnCreditoParceladoEmissor.Click += new System.EventHandler(this.btnCreditoParceladoEmissor_Click);
            // 
            // btnCreditoParceladoEstabelecimento
            // 
            this.btnCreditoParceladoEstabelecimento.Location = new System.Drawing.Point(257, 126);
            this.btnCreditoParceladoEstabelecimento.Name = "btnCreditoParceladoEstabelecimento";
            this.btnCreditoParceladoEstabelecimento.Size = new System.Drawing.Size(117, 53);
            this.btnCreditoParceladoEstabelecimento.TabIndex = 17;
            this.btnCreditoParceladoEstabelecimento.Text = "Crédito Parcelado Estabelecimento";
            this.btnCreditoParceladoEstabelecimento.UseVisualStyleBackColor = true;
            this.btnCreditoParceladoEstabelecimento.Click += new System.EventHandler(this.btnCreditoParceladoEstabelecimento_Click);
            // 
            // btnNovaVenda
            // 
            this.btnNovaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaVenda.Location = new System.Drawing.Point(509, 64);
            this.btnNovaVenda.Name = "btnNovaVenda";
            this.btnNovaVenda.Size = new System.Drawing.Size(132, 41);
            this.btnNovaVenda.TabIndex = 16;
            this.btnNovaVenda.Text = "Nova venda";
            this.btnNovaVenda.UseVisualStyleBackColor = true;
            this.btnNovaVenda.Click += new System.EventHandler(this.btnNovaVenda_Click);
            // 
            // btnCarteiraDigital
            // 
            this.btnCarteiraDigital.Location = new System.Drawing.Point(503, 124);
            this.btnCarteiraDigital.Name = "btnCarteiraDigital";
            this.btnCarteiraDigital.Size = new System.Drawing.Size(117, 53);
            this.btnCarteiraDigital.TabIndex = 15;
            this.btnCarteiraDigital.Text = "Carteira digital";
            this.btnCarteiraDigital.UseVisualStyleBackColor = true;
            this.btnCarteiraDigital.Click += new System.EventHandler(this.btnCarteiraDigital_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.Location = new System.Drawing.Point(134, 124);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(117, 53);
            this.btnCredito.TabIndex = 14;
            this.btnCredito.Text = "Crédito";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnDebito
            // 
            this.btnDebito.Location = new System.Drawing.Point(11, 126);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(117, 53);
            this.btnDebito.TabIndex = 13;
            this.btnDebito.Text = "Débito";
            this.btnDebito.UseVisualStyleBackColor = true;
            this.btnDebito.Click += new System.EventHandler(this.btnDebito_Click);
            // 
            // btnEfetuarPagamento
            // 
            this.btnEfetuarPagamento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEfetuarPagamento.Location = new System.Drawing.Point(278, 49);
            this.btnEfetuarPagamento.Name = "btnEfetuarPagamento";
            this.btnEfetuarPagamento.Size = new System.Drawing.Size(219, 69);
            this.btnEfetuarPagamento.TabIndex = 12;
            this.btnEfetuarPagamento.Text = "Efetuar Pagamento";
            this.btnEfetuarPagamento.UseVisualStyleBackColor = true;
            this.btnEfetuarPagamento.Click += new System.EventHandler(this.btnEfetuarPagamento_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor operação:";
            // 
            // numValorOperacao
            // 
            this.numValorOperacao.DecimalPlaces = 2;
            this.numValorOperacao.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numValorOperacao.Location = new System.Drawing.Point(112, 56);
            this.numValorOperacao.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numValorOperacao.Name = "numValorOperacao";
            this.numValorOperacao.Size = new System.Drawing.Size(160, 29);
            this.numValorOperacao.TabIndex = 3;
            this.numValorOperacao.ThousandsSeparator = true;
            // 
            // btnGerarDocumento
            // 
            this.btnGerarDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarDocumento.Location = new System.Drawing.Point(509, 16);
            this.btnGerarDocumento.Name = "btnGerarDocumento";
            this.btnGerarDocumento.Size = new System.Drawing.Size(132, 28);
            this.btnGerarDocumento.TabIndex = 2;
            this.btnGerarDocumento.Text = "Gerar documento";
            this.btnGerarDocumento.UseVisualStyleBackColor = true;
            this.btnGerarDocumento.Click += new System.EventHandler(this.btnGerarDocumento_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumento.Location = new System.Drawing.Point(112, 20);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(385, 23);
            this.txtDocumento.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Documento:";
            // 
            // pnlVendaRodape
            // 
            this.pnlVendaRodape.Controls.Add(this.tblTotais);
            this.pnlVendaRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVendaRodape.Location = new System.Drawing.Point(8, 505);
            this.pnlVendaRodape.Name = "pnlVendaRodape";
            this.pnlVendaRodape.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.pnlVendaRodape.Size = new System.Drawing.Size(649, 76);
            this.pnlVendaRodape.TabIndex = 2;
            // 
            // tblTotais
            // 
            this.tblTotais.ColumnCount = 3;
            this.tblTotais.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblTotais.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblTotais.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblTotais.Controls.Add(this.label4, 0, 0);
            this.tblTotais.Controls.Add(this.label5, 1, 0);
            this.tblTotais.Controls.Add(this.label6, 2, 0);
            this.tblTotais.Controls.Add(this.lblTotalOperacao, 0, 1);
            this.tblTotais.Controls.Add(this.lblTotalPago, 1, 1);
            this.tblTotais.Controls.Add(this.lblTroco, 2, 1);
            this.tblTotais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTotais.Location = new System.Drawing.Point(8, 4);
            this.tblTotais.Name = "tblTotais";
            this.tblTotais.RowCount = 2;
            this.tblTotais.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblTotais.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTotais.Size = new System.Drawing.Size(633, 68);
            this.tblTotais.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total operação";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(213, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(424, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Troco";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTotalOperacao
            // 
            this.lblTotalOperacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalOperacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalOperacao.Location = new System.Drawing.Point(3, 22);
            this.lblTotalOperacao.Name = "lblTotalOperacao";
            this.lblTotalOperacao.Size = new System.Drawing.Size(204, 46);
            this.lblTotalOperacao.TabIndex = 9;
            this.lblTotalOperacao.Text = "R$ 0,00";
            this.lblTotalOperacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPago.Location = new System.Drawing.Point(213, 22);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(205, 46);
            this.lblTotalPago.TabIndex = 10;
            this.lblTotalPago.Text = "R$ 0,00";
            this.lblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTroco
            // 
            this.lblTroco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTroco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTroco.Location = new System.Drawing.Point(424, 22);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(206, 46);
            this.lblTroco.TabIndex = 11;
            this.lblTroco.Text = "R$ 0,00";
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btnAtv);
            this.tabAdmin.Controls.Add(this.btnVerificarPinPad);
            this.tabAdmin.Controls.Add(this.btnCancelarVenda);
            this.tabAdmin.Controls.Add(this.btnMenuAdm);
            this.tabAdmin.Location = new System.Drawing.Point(4, 24);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(8);
            this.tabAdmin.Size = new System.Drawing.Size(665, 589);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "Administrativo";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // btnAtv
            // 
            this.btnAtv.Location = new System.Drawing.Point(16, 160);
            this.btnAtv.Name = "btnAtv";
            this.btnAtv.Size = new System.Drawing.Size(200, 36);
            this.btnAtv.TabIndex = 3;
            this.btnAtv.Text = "Ativação (ATV)";
            this.btnAtv.UseVisualStyleBackColor = true;
            this.btnAtv.Click += new System.EventHandler(this.btnAtv_Click);
            // 
            // btnVerificarPinPad
            // 
            this.btnVerificarPinPad.Location = new System.Drawing.Point(16, 112);
            this.btnVerificarPinPad.Name = "btnVerificarPinPad";
            this.btnVerificarPinPad.Size = new System.Drawing.Size(200, 36);
            this.btnVerificarPinPad.TabIndex = 2;
            this.btnVerificarPinPad.Text = "Verificar PinPad";
            this.btnVerificarPinPad.UseVisualStyleBackColor = true;
            this.btnVerificarPinPad.Click += new System.EventHandler(this.btnVerificarPinPad_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.Location = new System.Drawing.Point(16, 64);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(200, 36);
            this.btnCancelarVenda.TabIndex = 1;
            this.btnCancelarVenda.Text = "Cancelar transação";
            this.btnCancelarVenda.UseVisualStyleBackColor = true;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // btnMenuAdm
            // 
            this.btnMenuAdm.Location = new System.Drawing.Point(16, 16);
            this.btnMenuAdm.Name = "btnMenuAdm";
            this.btnMenuAdm.Size = new System.Drawing.Size(200, 36);
            this.btnMenuAdm.TabIndex = 0;
            this.btnMenuAdm.Text = "Menu administrativo";
            this.btnMenuAdm.UseVisualStyleBackColor = true;
            this.btnMenuAdm.Click += new System.EventHandler(this.btnMenuAdm_Click);
            // 
            // pnlQr
            // 
            this.pnlQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQr.Controls.Add(this.lblQrCabecalho);
            this.pnlQr.Controls.Add(this.lblQrCode);
            this.pnlQr.Controls.Add(this.lblMenuTituloQrCode);
            this.pnlQr.Location = new System.Drawing.Point(224, 186);
            this.pnlQr.Name = "pnlQr";
            this.pnlQr.Size = new System.Drawing.Size(231, 245);
            this.pnlQr.TabIndex = 10;
            this.pnlQr.Visible = false;
            // 
            // lblQrCabecalho
            // 
            this.lblQrCabecalho.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblQrCabecalho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblQrCabecalho.ForeColor = System.Drawing.Color.Gold;
            this.lblQrCabecalho.Location = new System.Drawing.Point(4, 4);
            this.lblQrCabecalho.Name = "lblQrCabecalho";
            this.lblQrCabecalho.Size = new System.Drawing.Size(221, 20);
            this.lblQrCabecalho.TabIndex = 5;
            this.lblQrCabecalho.Text = "Carteira Digital";
            this.lblQrCabecalho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQrCode
            // 
            this.lblQrCode.BackColor = System.Drawing.SystemColors.Window;
            this.lblQrCode.Location = new System.Drawing.Point(25, 58);
            this.lblQrCode.Name = "lblQrCode";
            this.lblQrCode.Size = new System.Drawing.Size(180, 180);
            this.lblQrCode.TabIndex = 4;
            this.lblQrCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuTituloQrCode
            // 
            this.lblMenuTituloQrCode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMenuTituloQrCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMenuTituloQrCode.Location = new System.Drawing.Point(4, 25);
            this.lblMenuTituloQrCode.Name = "lblMenuTituloQrCode";
            this.lblMenuTituloQrCode.Size = new System.Drawing.Size(221, 27);
            this.lblMenuTituloQrCode.TabIndex = 2;
            this.lblMenuTituloQrCode.Text = "Pix";
            this.lblMenuTituloQrCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitDireita
            // 
            this.splitDireita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDireita.Location = new System.Drawing.Point(0, 0);
            this.splitDireita.Name = "splitDireita";
            this.splitDireita.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDireita.Panel1
            // 
            this.splitDireita.Panel1.Controls.Add(this.grpComprovante);
            // 
            // splitDireita.Panel2
            // 
            this.splitDireita.Panel2.Controls.Add(this.grpLog);
            this.splitDireita.Size = new System.Drawing.Size(495, 617);
            this.splitDireita.SplitterDistance = 320;
            this.splitDireita.TabIndex = 0;
            // 
            // grpComprovante
            // 
            this.grpComprovante.Controls.Add(this.btnImprimir);
            this.grpComprovante.Controls.Add(this.btnLimparComprovante);
            this.grpComprovante.Controls.Add(this.txtComprovante);
            this.grpComprovante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComprovante.Location = new System.Drawing.Point(0, 0);
            this.grpComprovante.Name = "grpComprovante";
            this.grpComprovante.Padding = new System.Windows.Forms.Padding(8);
            this.grpComprovante.Size = new System.Drawing.Size(495, 320);
            this.grpComprovante.TabIndex = 0;
            this.grpComprovante.TabStop = false;
            this.grpComprovante.Text = "Comprovante (preview)";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(387, 280);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 28);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimparComprovante
            // 
            this.btnLimparComprovante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimparComprovante.Location = new System.Drawing.Point(11, 280);
            this.btnLimparComprovante.Name = "btnLimparComprovante";
            this.btnLimparComprovante.Size = new System.Drawing.Size(92, 28);
            this.btnLimparComprovante.TabIndex = 1;
            this.btnLimparComprovante.Text = "Limpar";
            this.btnLimparComprovante.UseVisualStyleBackColor = true;
            this.btnLimparComprovante.Click += new System.EventHandler(this.btnLimparComprovante_Click);
            // 
            // txtComprovante
            // 
            this.txtComprovante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComprovante.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtComprovante.Location = new System.Drawing.Point(11, 24);
            this.txtComprovante.Multiline = true;
            this.txtComprovante.Name = "txtComprovante";
            this.txtComprovante.ReadOnly = true;
            this.txtComprovante.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComprovante.Size = new System.Drawing.Size(468, 248);
            this.txtComprovante.TabIndex = 0;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.btnLimparLog);
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(0, 0);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(8);
            this.grpLog.Size = new System.Drawing.Size(495, 293);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log de execução";
            // 
            // btnLimparLog
            // 
            this.btnLimparLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimparLog.Location = new System.Drawing.Point(11, 252);
            this.btnLimparLog.Name = "btnLimparLog";
            this.btnLimparLog.Size = new System.Drawing.Size(92, 28);
            this.btnLimparLog.TabIndex = 1;
            this.btnLimparLog.Text = "Limpar log";
            this.btnLimparLog.UseVisualStyleBackColor = true;
            this.btnLimparLog.Click += new System.EventHandler(this.btnLimparLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtLog.Location = new System.Drawing.Point(11, 24);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(468, 220);
            this.txtLog.TabIndex = 0;
            // 
            // bkgInicioTef
            // 
            this.bkgInicioTef.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgInicioTef_DoWork);
            this.bkgInicioTef.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgInicioTef_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Quantidade de Parcelas:";
            // 
            // numQtdParcelas
            // 
            this.numQtdParcelas.Location = new System.Drawing.Point(148, 91);
            this.numQtdParcelas.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numQtdParcelas.Name = "numQtdParcelas";
            this.numQtdParcelas.Size = new System.Drawing.Size(124, 23);
            this.numQtdParcelas.TabIndex = 21;
            // 
            // FrmPdv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 681);
            this.Controls.Add(this.splitPrincipal);
            this.Controls.Add(this.pnlTopo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "FrmPdv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACBr CliSiTef - Demo";
            this.Load += new System.EventHandler(this.FrmPdv_Load);
            this.Shown += new System.EventHandler(this.FrmPdv_Shown);
            this.pnlTopo.ResumeLayout(false);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.tabOperacao.ResumeLayout(false);
            this.tabVenda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).EndInit();
            this.pnlVendaTopo.ResumeLayout(false);
            this.pnlVendaTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValorOperacao)).EndInit();
            this.pnlVendaRodape.ResumeLayout(false);
            this.tblTotais.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.pnlQr.ResumeLayout(false);
            this.splitDireita.Panel1.ResumeLayout(false);
            this.splitDireita.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDireita)).EndInit();
            this.splitDireita.ResumeLayout(false);
            this.grpComprovante.ResumeLayout(false);
            this.grpComprovante.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Label lblStatusCaixa;
        private System.Windows.Forms.Label lblStatusOperacao;
        private System.Windows.Forms.Button btnConfiguracao;
        private System.Windows.Forms.SplitContainer splitPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.TabControl tabOperacao;
        private System.Windows.Forms.TabPage tabVenda;
        private System.Windows.Forms.Panel pnlVendaTopo;
        private System.Windows.Forms.Panel pnlVendaRodape;
        private System.Windows.Forms.TableLayoutPanel tblTotais;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGerarDocumento;
        private System.Windows.Forms.NumericUpDown numValorOperacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridPagamentos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalOperacao;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Button btnEfetuarPagamento;
        private System.Windows.Forms.Button btnDebito;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnCarteiraDigital;
        private System.Windows.Forms.Button btnNovaVenda;
        private System.Windows.Forms.Button btnMenuAdm;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnVerificarPinPad;
        private System.Windows.Forms.Button btnAtv;
        private System.Windows.Forms.SplitContainer splitDireita;
        private System.Windows.Forms.GroupBox grpComprovante;
        private System.Windows.Forms.TextBox txtComprovante;
        private System.Windows.Forms.Button btnLimparComprovante;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnLimparLog;
        private System.Windows.Forms.Panel pnlQr;
        private System.Windows.Forms.Label lblQrCabecalho;
        public System.Windows.Forms.Label lblQrCode;
        private System.Windows.Forms.Label lblMenuTituloQrCode;
        private System.ComponentModel.BackgroundWorker bkgInicioTef;
        private System.Windows.Forms.Button btnCreditoParceladoEstabelecimento;
        private System.Windows.Forms.Button btnCreditoParceladoEmissor;
        private System.Windows.Forms.NumericUpDown numQtdParcelas;
        private System.Windows.Forms.Label label1;
    }
}
