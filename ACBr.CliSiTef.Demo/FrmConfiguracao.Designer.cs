namespace ACBr.CliSiTef.Demo
{
    partial class FrmConfiguracao
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
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabTef = new System.Windows.Forms.TabPage();
            this.chkConfirmacaoAutomatica = new System.Windows.Forms.CheckBox();
            this.txtTipoComunicacao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSenhaSupervisor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkPinPadQrCode = new System.Windows.Forms.CheckBox();
            this.chkPinPadVerificar = new System.Windows.Forms.CheckBox();
            this.txtPinPadMensagem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPinPadPorta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoftwareHouseCnpj = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmpresaCnpj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabImpressora = new System.Windows.Forms.TabPage();
            this.chkEnviarImpressora = new System.Windows.Forms.CheckBox();
            this.grpPosPrinter = new System.Windows.Forms.GroupBox();
            this.cmbPaginaCodigo = new System.Windows.Forms.ComboBox();
            this.labelPagCodigo = new System.Windows.Forms.Label();
            this.btnArqLog = new System.Windows.Forms.Button();
            this.txtArqLog = new System.Windows.Forms.TextBox();
            this.labelArqLog = new System.Windows.Forms.Label();
            this.chkIgnorarTags = new System.Windows.Forms.CheckBox();
            this.chkTraduzirTags = new System.Windows.Forms.CheckBox();
            this.chkCortarPapel = new System.Windows.Forms.CheckBox();
            this.chkControlePorta = new System.Windows.Forms.CheckBox();
            this.nudLinhasPular = new System.Windows.Forms.NumericUpDown();
            this.labelLinhasPular = new System.Windows.Forms.Label();
            this.nudBuffer = new System.Windows.Forms.NumericUpDown();
            this.labelBuffer = new System.Windows.Forms.Label();
            this.nudEspacos = new System.Windows.Forms.NumericUpDown();
            this.labelEspacos = new System.Windows.Forms.Label();
            this.nudColunas = new System.Windows.Forms.NumericUpDown();
            this.labelColunas = new System.Windows.Forms.Label();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.cmbPorta = new System.Windows.Forms.ComboBox();
            this.labelPorta = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.labelModelo = new System.Windows.Forms.Label();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTestarImpressora = new System.Windows.Forms.Button();
            this.btnTestarTef = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConfig.SuspendLayout();
            this.tabTef.SuspendLayout();
            this.tabImpressora.SuspendLayout();
            this.grpPosPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhasPular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEspacos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunas)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tabTef);
            this.tabConfig.Controls.Add(this.tabImpressora);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfig.Location = new System.Drawing.Point(0, 35);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(535, 347);
            this.tabConfig.TabIndex = 0;
            // 
            // tabTef
            // 
            this.tabTef.Controls.Add(this.chkConfirmacaoAutomatica);
            this.tabTef.Controls.Add(this.txtTipoComunicacao);
            this.tabTef.Controls.Add(this.label11);
            this.tabTef.Controls.Add(this.txtSenhaSupervisor);
            this.tabTef.Controls.Add(this.label10);
            this.tabTef.Controls.Add(this.chkPinPadQrCode);
            this.tabTef.Controls.Add(this.chkPinPadVerificar);
            this.tabTef.Controls.Add(this.txtPinPadMensagem);
            this.tabTef.Controls.Add(this.label9);
            this.tabTef.Controls.Add(this.txtPinPadPorta);
            this.tabTef.Controls.Add(this.label8);
            this.tabTef.Controls.Add(this.txtSoftwareHouseCnpj);
            this.tabTef.Controls.Add(this.label7);
            this.tabTef.Controls.Add(this.txtTerminal);
            this.tabTef.Controls.Add(this.label6);
            this.tabTef.Controls.Add(this.txtEmpresaCnpj);
            this.tabTef.Controls.Add(this.label5);
            this.tabTef.Controls.Add(this.txtEmpresa);
            this.tabTef.Controls.Add(this.label4);
            this.tabTef.Controls.Add(this.txtIp);
            this.tabTef.Controls.Add(this.label3);
            this.tabTef.Location = new System.Drawing.Point(4, 22);
            this.tabTef.Name = "tabTef";
            this.tabTef.Padding = new System.Windows.Forms.Padding(7);
            this.tabTef.Size = new System.Drawing.Size(527, 321);
            this.tabTef.TabIndex = 0;
            this.tabTef.Text = "Configuração TEF";
            this.tabTef.UseVisualStyleBackColor = true;
            // 
            // chkConfirmacaoAutomatica
            // 
            this.chkConfirmacaoAutomatica.AutoSize = true;
            this.chkConfirmacaoAutomatica.Checked = true;
            this.chkConfirmacaoAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirmacaoAutomatica.Location = new System.Drawing.Point(12, 285);
            this.chkConfirmacaoAutomatica.Name = "chkConfirmacaoAutomatica";
            this.chkConfirmacaoAutomatica.Size = new System.Drawing.Size(209, 17);
            this.chkConfirmacaoAutomatica.TabIndex = 20;
            this.chkConfirmacaoAutomatica.Text = "Confirmar transações automaticamente";
            this.chkConfirmacaoAutomatica.UseVisualStyleBackColor = true;
            // 
            // txtTipoComunicacao
            // 
            this.txtTipoComunicacao.Location = new System.Drawing.Point(137, 255);
            this.txtTipoComunicacao.Name = "txtTipoComunicacao";
            this.txtTipoComunicacao.Size = new System.Drawing.Size(172, 20);
            this.txtTipoComunicacao.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Comunicação externa:";
            // 
            // txtSenhaSupervisor
            // 
            this.txtSenhaSupervisor.Location = new System.Drawing.Point(137, 227);
            this.txtSenhaSupervisor.Name = "txtSenhaSupervisor";
            this.txtSenhaSupervisor.Size = new System.Drawing.Size(69, 20);
            this.txtSenhaSupervisor.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Senha supervisor:";
            // 
            // chkPinPadQrCode
            // 
            this.chkPinPadQrCode.AutoSize = true;
            this.chkPinPadQrCode.Location = new System.Drawing.Point(240, 203);
            this.chkPinPadQrCode.Name = "chkPinPadQrCode";
            this.chkPinPadQrCode.Size = new System.Drawing.Size(122, 17);
            this.chkPinPadQrCode.TabIndex = 15;
            this.chkPinPadQrCode.Text = "QR Code no PinPad";
            this.chkPinPadQrCode.UseVisualStyleBackColor = true;
            // 
            // chkPinPadVerificar
            // 
            this.chkPinPadVerificar.AutoSize = true;
            this.chkPinPadVerificar.Location = new System.Drawing.Point(137, 203);
            this.chkPinPadVerificar.Name = "chkPinPadVerificar";
            this.chkPinPadVerificar.Size = new System.Drawing.Size(101, 17);
            this.chkPinPadVerificar.TabIndex = 14;
            this.chkPinPadVerificar.Text = "Verificar PinPad";
            this.chkPinPadVerificar.UseVisualStyleBackColor = true;
            // 
            // txtPinPadMensagem
            // 
            this.txtPinPadMensagem.Location = new System.Drawing.Point(137, 135);
            this.txtPinPadMensagem.Multiline = true;
            this.txtPinPadMensagem.Name = "txtPinPadMensagem";
            this.txtPinPadMensagem.Size = new System.Drawing.Size(326, 62);
            this.txtPinPadMensagem.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Mensagem PinPad:";
            // 
            // txtPinPadPorta
            // 
            this.txtPinPadPorta.Location = new System.Drawing.Point(137, 107);
            this.txtPinPadPorta.Name = "txtPinPadPorta";
            this.txtPinPadPorta.Size = new System.Drawing.Size(172, 20);
            this.txtPinPadPorta.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Porta PinPad:";
            // 
            // txtSoftwareHouseCnpj
            // 
            this.txtSoftwareHouseCnpj.Location = new System.Drawing.Point(137, 80);
            this.txtSoftwareHouseCnpj.Name = "txtSoftwareHouseCnpj";
            this.txtSoftwareHouseCnpj.Size = new System.Drawing.Size(172, 20);
            this.txtSoftwareHouseCnpj.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "CNPJ Software House:";
            // 
            // txtTerminal
            // 
            this.txtTerminal.Location = new System.Drawing.Point(343, 52);
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(121, 20);
            this.txtTerminal.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Terminal:";
            // 
            // txtEmpresaCnpj
            // 
            this.txtEmpresaCnpj.Location = new System.Drawing.Point(137, 52);
            this.txtEmpresaCnpj.Name = "txtEmpresaCnpj";
            this.txtEmpresaCnpj.Size = new System.Drawing.Size(138, 20);
            this.txtEmpresaCnpj.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CNPJ Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(343, 24);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(121, 20);
            this.txtEmpresa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Empresa:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(137, 24);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(138, 20);
            this.txtIp.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP SiTef:";
            // 
            // tabImpressora
            // 
            this.tabImpressora.Controls.Add(this.chkEnviarImpressora);
            this.tabImpressora.Controls.Add(this.grpPosPrinter);
            this.tabImpressora.Location = new System.Drawing.Point(4, 22);
            this.tabImpressora.Name = "tabImpressora";
            this.tabImpressora.Padding = new System.Windows.Forms.Padding(7);
            this.tabImpressora.Size = new System.Drawing.Size(527, 321);
            this.tabImpressora.TabIndex = 1;
            this.tabImpressora.Text = "Configuração Impressora";
            this.tabImpressora.UseVisualStyleBackColor = true;
            // 
            // chkEnviarImpressora
            // 
            this.chkEnviarImpressora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnviarImpressora.AutoSize = true;
            this.chkEnviarImpressora.Location = new System.Drawing.Point(16, 290);
            this.chkEnviarImpressora.Name = "chkEnviarImpressora";
            this.chkEnviarImpressora.Size = new System.Drawing.Size(230, 17);
            this.chkEnviarImpressora.TabIndex = 1;
            this.chkEnviarImpressora.Text = "Enviar comprovante TEF para a impressora";
            this.chkEnviarImpressora.UseVisualStyleBackColor = true;
            // 
            // grpPosPrinter
            // 
            this.grpPosPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPosPrinter.Controls.Add(this.cmbPaginaCodigo);
            this.grpPosPrinter.Controls.Add(this.labelPagCodigo);
            this.grpPosPrinter.Controls.Add(this.btnArqLog);
            this.grpPosPrinter.Controls.Add(this.txtArqLog);
            this.grpPosPrinter.Controls.Add(this.labelArqLog);
            this.grpPosPrinter.Controls.Add(this.chkIgnorarTags);
            this.grpPosPrinter.Controls.Add(this.chkTraduzirTags);
            this.grpPosPrinter.Controls.Add(this.chkCortarPapel);
            this.grpPosPrinter.Controls.Add(this.chkControlePorta);
            this.grpPosPrinter.Controls.Add(this.nudLinhasPular);
            this.grpPosPrinter.Controls.Add(this.labelLinhasPular);
            this.grpPosPrinter.Controls.Add(this.nudBuffer);
            this.grpPosPrinter.Controls.Add(this.labelBuffer);
            this.grpPosPrinter.Controls.Add(this.nudEspacos);
            this.grpPosPrinter.Controls.Add(this.labelEspacos);
            this.grpPosPrinter.Controls.Add(this.nudColunas);
            this.grpPosPrinter.Controls.Add(this.labelColunas);
            this.grpPosPrinter.Controls.Add(this.btnAtivar);
            this.grpPosPrinter.Controls.Add(this.cmbPorta);
            this.grpPosPrinter.Controls.Add(this.labelPorta);
            this.grpPosPrinter.Controls.Add(this.cmbModelo);
            this.grpPosPrinter.Controls.Add(this.labelModelo);
            this.grpPosPrinter.Location = new System.Drawing.Point(9, 10);
            this.grpPosPrinter.Name = "grpPosPrinter";
            this.grpPosPrinter.Size = new System.Drawing.Size(509, 269);
            this.grpPosPrinter.TabIndex = 0;
            this.grpPosPrinter.TabStop = false;
            this.grpPosPrinter.Text = "Configuração (ACBrLib.PosPrinter)";
            // 
            // cmbPaginaCodigo
            // 
            this.cmbPaginaCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaginaCodigo.FormattingEnabled = true;
            this.cmbPaginaCodigo.Location = new System.Drawing.Point(103, 232);
            this.cmbPaginaCodigo.Name = "cmbPaginaCodigo";
            this.cmbPaginaCodigo.Size = new System.Drawing.Size(189, 21);
            this.cmbPaginaCodigo.TabIndex = 21;
            // 
            // labelPagCodigo
            // 
            this.labelPagCodigo.AutoSize = true;
            this.labelPagCodigo.Location = new System.Drawing.Point(14, 235);
            this.labelPagCodigo.Name = "labelPagCodigo";
            this.labelPagCodigo.Size = new System.Drawing.Size(67, 13);
            this.labelPagCodigo.TabIndex = 20;
            this.labelPagCodigo.Text = "Pág. código:";
            // 
            // btnArqLog
            // 
            this.btnArqLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArqLog.Location = new System.Drawing.Point(470, 201);
            this.btnArqLog.Name = "btnArqLog";
            this.btnArqLog.Size = new System.Drawing.Size(27, 22);
            this.btnArqLog.TabIndex = 19;
            this.btnArqLog.Text = "...";
            this.btnArqLog.UseVisualStyleBackColor = true;
            this.btnArqLog.Click += new System.EventHandler(this.btnArqLog_Click);
            // 
            // txtArqLog
            // 
            this.txtArqLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArqLog.Location = new System.Drawing.Point(103, 202);
            this.txtArqLog.Name = "txtArqLog";
            this.txtArqLog.Size = new System.Drawing.Size(362, 20);
            this.txtArqLog.TabIndex = 18;
            // 
            // labelArqLog
            // 
            this.labelArqLog.AutoSize = true;
            this.labelArqLog.Location = new System.Drawing.Point(14, 205);
            this.labelArqLog.Name = "labelArqLog";
            this.labelArqLog.Size = new System.Drawing.Size(46, 13);
            this.labelArqLog.TabIndex = 17;
            this.labelArqLog.Text = "Arq. log:";
            // 
            // chkIgnorarTags
            // 
            this.chkIgnorarTags.AutoSize = true;
            this.chkIgnorarTags.Location = new System.Drawing.Point(267, 173);
            this.chkIgnorarTags.Name = "chkIgnorarTags";
            this.chkIgnorarTags.Size = new System.Drawing.Size(82, 17);
            this.chkIgnorarTags.TabIndex = 16;
            this.chkIgnorarTags.Text = "Ignorar tags";
            this.chkIgnorarTags.UseVisualStyleBackColor = true;
            // 
            // chkTraduzirTags
            // 
            this.chkTraduzirTags.AutoSize = true;
            this.chkTraduzirTags.Location = new System.Drawing.Point(144, 173);
            this.chkTraduzirTags.Name = "chkTraduzirTags";
            this.chkTraduzirTags.Size = new System.Drawing.Size(87, 17);
            this.chkTraduzirTags.TabIndex = 15;
            this.chkTraduzirTags.Text = "Traduzir tags";
            this.chkTraduzirTags.UseVisualStyleBackColor = true;
            // 
            // chkCortarPapel
            // 
            this.chkCortarPapel.AutoSize = true;
            this.chkCortarPapel.Location = new System.Drawing.Point(14, 173);
            this.chkCortarPapel.Name = "chkCortarPapel";
            this.chkCortarPapel.Size = new System.Drawing.Size(83, 17);
            this.chkCortarPapel.TabIndex = 14;
            this.chkCortarPapel.Text = "Cortar papel";
            this.chkCortarPapel.UseVisualStyleBackColor = true;
            // 
            // chkControlePorta
            // 
            this.chkControlePorta.AutoSize = true;
            this.chkControlePorta.Location = new System.Drawing.Point(391, 173);
            this.chkControlePorta.Name = "chkControlePorta";
            this.chkControlePorta.Size = new System.Drawing.Size(92, 17);
            this.chkControlePorta.TabIndex = 13;
            this.chkControlePorta.Text = "Controle porta";
            this.chkControlePorta.UseVisualStyleBackColor = true;
            // 
            // nudLinhasPular
            // 
            this.nudLinhasPular.Location = new System.Drawing.Point(405, 139);
            this.nudLinhasPular.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudLinhasPular.Name = "nudLinhasPular";
            this.nudLinhasPular.Size = new System.Drawing.Size(51, 20);
            this.nudLinhasPular.TabIndex = 12;
            // 
            // labelLinhasPular
            // 
            this.labelLinhasPular.AutoSize = true;
            this.labelLinhasPular.Location = new System.Drawing.Point(329, 140);
            this.labelLinhasPular.Name = "labelLinhasPular";
            this.labelLinhasPular.Size = new System.Drawing.Size(67, 13);
            this.labelLinhasPular.TabIndex = 11;
            this.labelLinhasPular.Text = "Linhas pular:";
            // 
            // nudBuffer
            // 
            this.nudBuffer.Location = new System.Drawing.Point(254, 139);
            this.nudBuffer.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudBuffer.Name = "nudBuffer";
            this.nudBuffer.Size = new System.Drawing.Size(51, 20);
            this.nudBuffer.TabIndex = 10;
            // 
            // labelBuffer
            // 
            this.labelBuffer.AutoSize = true;
            this.labelBuffer.Location = new System.Drawing.Point(206, 140);
            this.labelBuffer.Name = "labelBuffer";
            this.labelBuffer.Size = new System.Drawing.Size(38, 13);
            this.labelBuffer.TabIndex = 9;
            this.labelBuffer.Text = "Buffer:";
            // 
            // nudEspacos
            // 
            this.nudEspacos.Location = new System.Drawing.Point(144, 139);
            this.nudEspacos.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudEspacos.Name = "nudEspacos";
            this.nudEspacos.Size = new System.Drawing.Size(51, 20);
            this.nudEspacos.TabIndex = 8;
            // 
            // labelEspacos
            // 
            this.labelEspacos.AutoSize = true;
            this.labelEspacos.Location = new System.Drawing.Point(82, 140);
            this.labelEspacos.Name = "labelEspacos";
            this.labelEspacos.Size = new System.Drawing.Size(51, 13);
            this.labelEspacos.TabIndex = 7;
            this.labelEspacos.Text = "Espaços:";
            // 
            // nudColunas
            // 
            this.nudColunas.Location = new System.Drawing.Point(14, 139);
            this.nudColunas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudColunas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColunas.Name = "nudColunas";
            this.nudColunas.Size = new System.Drawing.Size(51, 20);
            this.nudColunas.TabIndex = 6;
            this.nudColunas.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // labelColunas
            // 
            this.labelColunas.AutoSize = true;
            this.labelColunas.Location = new System.Drawing.Point(14, 123);
            this.labelColunas.Name = "labelColunas";
            this.labelColunas.Size = new System.Drawing.Size(48, 13);
            this.labelColunas.TabIndex = 5;
            this.labelColunas.Text = "Colunas:";
            // 
            // btnAtivar
            // 
            this.btnAtivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivar.Location = new System.Drawing.Point(405, 42);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(92, 55);
            this.btnAtivar.TabIndex = 4;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // cmbPorta
            // 
            this.cmbPorta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPorta.FormattingEnabled = true;
            this.cmbPorta.Location = new System.Drawing.Point(103, 76);
            this.cmbPorta.Name = "cmbPorta";
            this.cmbPorta.Size = new System.Drawing.Size(292, 21);
            this.cmbPorta.TabIndex = 3;
            // 
            // labelPorta
            // 
            this.labelPorta.AutoSize = true;
            this.labelPorta.Location = new System.Drawing.Point(14, 79);
            this.labelPorta.Name = "labelPorta";
            this.labelPorta.Size = new System.Drawing.Size(35, 13);
            this.labelPorta.TabIndex = 2;
            this.labelPorta.Text = "Porta:";
            // 
            // cmbModelo
            // 
            this.cmbModelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(103, 42);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(292, 21);
            this.cmbModelo.TabIndex = 1;
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(14, 44);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(45, 13);
            this.labelModelo.TabIndex = 0;
            this.labelModelo.Text = "Modelo:";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnTestarImpressora);
            this.pnlBotoes.Controls.Add(this.btnTestarTef);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 382);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(535, 42);
            this.pnlBotoes.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(456, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 24);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Fechar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTestarImpressora
            // 
            this.btnTestarImpressora.Location = new System.Drawing.Point(230, 9);
            this.btnTestarImpressora.Name = "btnTestarImpressora";
            this.btnTestarImpressora.Size = new System.Drawing.Size(103, 24);
            this.btnTestarImpressora.TabIndex = 2;
            this.btnTestarImpressora.Text = "Testar impressora";
            this.btnTestarImpressora.UseVisualStyleBackColor = true;
            this.btnTestarImpressora.Click += new System.EventHandler(this.btnTestarImpressora_Click);
            // 
            // btnTestarTef
            // 
            this.btnTestarTef.Location = new System.Drawing.Point(122, 9);
            this.btnTestarTef.Name = "btnTestarTef";
            this.btnTestarTef.Size = new System.Drawing.Size(103, 24);
            this.btnTestarTef.TabIndex = 1;
            this.btnTestarTef.Text = "Testar TEF";
            this.btnTestarTef.UseVisualStyleBackColor = true;
            this.btnTestarTef.Click += new System.EventHandler(this.btnTestarTef_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(10, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(103, 24);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(7, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(535, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Configuração - ACBr CliSiTef Demo";
            // 
            // FrmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 424);
            this.Controls.Add(this.tabConfig);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.FrmConfiguracao_Load);
            this.tabConfig.ResumeLayout(false);
            this.tabTef.ResumeLayout(false);
            this.tabTef.PerformLayout();
            this.tabImpressora.ResumeLayout(false);
            this.tabImpressora.PerformLayout();
            this.grpPosPrinter.ResumeLayout(false);
            this.grpPosPrinter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhasPular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEspacos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunas)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabTef;
        private System.Windows.Forms.TabPage tabImpressora;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnTestarTef;
        private System.Windows.Forms.Button btnTestarImpressora;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpresaCnpj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoftwareHouseCnpj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPinPadPorta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPinPadMensagem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPinPadVerificar;
        private System.Windows.Forms.CheckBox chkPinPadQrCode;
        private System.Windows.Forms.TextBox txtSenhaSupervisor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTipoComunicacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpPosPrinter;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.ComboBox cmbPorta;
        private System.Windows.Forms.Label labelPorta;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.NumericUpDown nudColunas;
        private System.Windows.Forms.Label labelColunas;
        private System.Windows.Forms.NumericUpDown nudEspacos;
        private System.Windows.Forms.Label labelEspacos;
        private System.Windows.Forms.NumericUpDown nudBuffer;
        private System.Windows.Forms.Label labelBuffer;
        private System.Windows.Forms.NumericUpDown nudLinhasPular;
        private System.Windows.Forms.Label labelLinhasPular;
        private System.Windows.Forms.CheckBox chkControlePorta;
        private System.Windows.Forms.CheckBox chkCortarPapel;
        private System.Windows.Forms.CheckBox chkTraduzirTags;
        private System.Windows.Forms.CheckBox chkIgnorarTags;
        private System.Windows.Forms.TextBox txtArqLog;
        private System.Windows.Forms.Label labelArqLog;
        private System.Windows.Forms.Button btnArqLog;
        private System.Windows.Forms.ComboBox cmbPaginaCodigo;
        private System.Windows.Forms.Label labelPagCodigo;
        private System.Windows.Forms.CheckBox chkEnviarImpressora;
        private System.Windows.Forms.CheckBox chkConfirmacaoAutomatica;
    }
}
