namespace SerialPortTerminal
{
    partial class SPT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPT));
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkCD = new System.Windows.Forms.CheckBox();
            this.chkDSR = new System.Windows.Forms.CheckBox();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkClearOnOpen = new System.Windows.Forms.CheckBox();
            this.chkClearWithDTR = new System.Windows.Forms.CheckBox();
            this.tmrCheckComPorts = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnFillC = new System.Windows.Forms.Button();
            this.btnFIRE = new System.Windows.Forms.Button();
            this.groupBoxLRF = new System.Windows.Forms.GroupBox();
            this.groupBoxRangeMin = new System.Windows.Forms.GroupBox();
            this.btnSetRmin = new System.Windows.Forms.Button();
            this.txtRmin = new System.Windows.Forms.TextBox();
            this.btnCancelRmin = new System.Windows.Forms.Button();
            this.btnReadStatus = new System.Windows.Forms.Button();
            this.txtBxRminStatus = new System.Windows.Forms.TextBox();
            this.txtBxLRFStatus = new System.Windows.Forms.TextBox();
            this.txtBxDistanceStatus = new System.Windows.Forms.TextBox();
            this.lblStatusi = new System.Windows.Forms.Label();
            this.txtBxR3 = new System.Windows.Forms.TextBox();
            this.txtBxR2 = new System.Windows.Forms.TextBox();
            this.txtBxR1 = new System.Windows.Forms.TextBox();
            this.lblRanges = new System.Windows.Forms.Label();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.gbMode.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxLRF.SuspendLayout();
            this.groupBoxRangeMin.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfTerminal
            // 
            this.rtfTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfTerminal.Location = new System.Drawing.Point(16, 15);
            this.rtfTerminal.Margin = new System.Windows.Forms.Padding(4);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(619, 366);
            this.rtfTerminal.TabIndex = 0;
            this.rtfTerminal.Text = "";
            // 
            // txtSendData
            // 
            this.txtSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendData.Location = new System.Drawing.Point(231, 644);
            this.txtSendData.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(291, 22);
            this.txtSendData.TabIndex = 2;
            this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSendData_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(129, 641);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send Chat";
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(17, 43);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(88, 24);
            this.cmbPortName.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(115, 43);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(91, 24);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.CmbBaudRate_Validating);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(16, 48);
            this.rbHex.Margin = new System.Windows.Forms.Padding(4);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(53, 21);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            this.rbHex.CheckedChanged += new System.EventHandler(this.RbHex_CheckedChanged);
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(16, 23);
            this.rbText.Margin = new System.Windows.Forms.Padding(4);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(56, 21);
            this.rbText.TabIndex = 0;
            this.rbText.Text = "Text";
            this.rbText.CheckedChanged += new System.EventHandler(this.RbText_CheckedChanged);
            // 
            // gbMode
            // 
            this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMode.Controls.Add(this.rbText);
            this.gbMode.Controls.Add(this.rbHex);
            this.gbMode.Location = new System.Drawing.Point(517, 682);
            this.gbMode.Margin = new System.Windows.Forms.Padding(4);
            this.gbMode.Name = "gbMode";
            this.gbMode.Padding = new System.Windows.Forms.Padding(4);
            this.gbMode.Size = new System.Drawing.Size(119, 79);
            this.gbMode.TabIndex = 5;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Data &Mode";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(16, 23);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(73, 17);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(113, 23);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(79, 17);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(217, 23);
            this.lblParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(48, 17);
            this.lblParity.TabIndex = 4;
            this.lblParity.Text = "Parity:";
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(215, 43);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(79, 24);
            this.cmbParity.TabIndex = 5;
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(305, 23);
            this.lblDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(69, 17);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits.Location = new System.Drawing.Point(303, 43);
            this.cmbDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(79, 24);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.CmbDataBits_Validating);
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(393, 23);
            this.lblStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(68, 17);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(391, 43);
            this.cmbStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(85, 24);
            this.cmbStopBits.TabIndex = 9;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPort.Location = new System.Drawing.Point(537, 780);
            this.btnOpenPort.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(100, 28);
            this.btnOpenPort.TabIndex = 6;
            this.btnOpenPort.Text = "&Open Port";
            this.btnOpenPort.Click += new System.EventHandler(this.BtnOpenPort_Click);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.lblParity);
            this.gbPortSettings.Location = new System.Drawing.Point(16, 682);
            this.gbPortSettings.Margin = new System.Windows.Forms.Padding(4);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Padding = new System.Windows.Forms.Padding(4);
            this.gbPortSettings.Size = new System.Drawing.Size(493, 79);
            this.gbPortSettings.TabIndex = 4;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chkRTS);
            this.groupBox1.Controls.Add(this.chkCD);
            this.groupBox1.Controls.Add(this.chkDSR);
            this.groupBox1.Controls.Add(this.chkCTS);
            this.groupBox1.Controls.Add(this.chkDTR);
            this.groupBox1.Location = new System.Drawing.Point(16, 768);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(363, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Line Signals";
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Location = new System.Drawing.Point(87, 25);
            this.chkRTS.Margin = new System.Windows.Forms.Padding(4);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(58, 21);
            this.chkRTS.TabIndex = 1;
            this.chkRTS.Text = "RTS";
            this.toolTip.SetToolTip(this.chkRTS, "Pin 7 on DB9, Output, Request to Send");
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkCD
            // 
            this.chkCD.AutoSize = true;
            this.chkCD.Enabled = false;
            this.chkCD.Location = new System.Drawing.Point(301, 25);
            this.chkCD.Margin = new System.Windows.Forms.Padding(4);
            this.chkCD.Name = "chkCD";
            this.chkCD.Size = new System.Drawing.Size(49, 21);
            this.chkCD.TabIndex = 4;
            this.chkCD.Text = "CD";
            this.toolTip.SetToolTip(this.chkCD, "Pin 1 on DB9, Input, Data Carrier Detect");
            this.chkCD.UseVisualStyleBackColor = true;
            // 
            // chkDSR
            // 
            this.chkDSR.AutoSize = true;
            this.chkDSR.Enabled = false;
            this.chkDSR.Location = new System.Drawing.Point(229, 25);
            this.chkDSR.Margin = new System.Windows.Forms.Padding(4);
            this.chkDSR.Name = "chkDSR";
            this.chkDSR.Size = new System.Drawing.Size(59, 21);
            this.chkDSR.TabIndex = 3;
            this.chkDSR.Text = "DSR";
            this.toolTip.SetToolTip(this.chkDSR, "Pin 6 on DB9, Input, Data Set Ready");
            this.chkDSR.UseVisualStyleBackColor = true;
            // 
            // chkCTS
            // 
            this.chkCTS.AutoSize = true;
            this.chkCTS.Enabled = false;
            this.chkCTS.Location = new System.Drawing.Point(159, 25);
            this.chkCTS.Margin = new System.Windows.Forms.Padding(4);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(57, 21);
            this.chkCTS.TabIndex = 2;
            this.chkCTS.Text = "CTS";
            this.toolTip.SetToolTip(this.chkCTS, "Pin 8 on DB9, Input, Clear to Send");
            this.chkCTS.UseVisualStyleBackColor = true;
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Location = new System.Drawing.Point(13, 25);
            this.chkDTR.Margin = new System.Windows.Forms.Padding(4);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(59, 21);
            this.chkDTR.TabIndex = 0;
            this.chkDTR.Text = "DTR";
            this.toolTip.SetToolTip(this.chkDTR, "Pin 4 on DB9, Output, Data Terminal Ready");
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(537, 641);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkClearOnOpen
            // 
            this.chkClearOnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearOnOpen.AutoSize = true;
            this.chkClearOnOpen.Location = new System.Drawing.Point(387, 780);
            this.chkClearOnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.chkClearOnOpen.Name = "chkClearOnOpen";
            this.chkClearOnOpen.Size = new System.Drawing.Size(122, 21);
            this.chkClearOnOpen.TabIndex = 10;
            this.chkClearOnOpen.Text = "Clear on Open";
            this.chkClearOnOpen.UseVisualStyleBackColor = true;
            // 
            // chkClearWithDTR
            // 
            this.chkClearWithDTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearWithDTR.AutoSize = true;
            this.chkClearWithDTR.Location = new System.Drawing.Point(387, 806);
            this.chkClearWithDTR.Margin = new System.Windows.Forms.Padding(4);
            this.chkClearWithDTR.Name = "chkClearWithDTR";
            this.chkClearWithDTR.Size = new System.Drawing.Size(124, 21);
            this.chkClearWithDTR.TabIndex = 11;
            this.chkClearWithDTR.Text = "Clear with DTR";
            this.chkClearWithDTR.UseVisualStyleBackColor = true;
            // 
            // tmrCheckComPorts
            // 
            this.tmrCheckComPorts.Enabled = true;
            this.tmrCheckComPorts.Interval = 500;
            this.tmrCheckComPorts.Tick += new System.EventHandler(this.TmrCheckComPorts_Tick);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Enabled = false;
            this.btnSendFile.Location = new System.Drawing.Point(16, 641);
            this.btnSendFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(100, 28);
            this.btnSendFile.TabIndex = 12;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnFillC
            // 
            this.btnFillC.Enabled = false;
            this.btnFillC.Location = new System.Drawing.Point(272, 166);
            this.btnFillC.Margin = new System.Windows.Forms.Padding(4);
            this.btnFillC.Name = "btnFillC";
            this.btnFillC.Size = new System.Drawing.Size(107, 28);
            this.btnFillC.TabIndex = 13;
            this.btnFillC.Text = "Fill C";
            this.btnFillC.UseVisualStyleBackColor = true;
            this.btnFillC.Click += new System.EventHandler(this.btnPuniC_Click);
            // 
            // btnFIRE
            // 
            this.btnFIRE.Enabled = false;
            this.btnFIRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFIRE.ForeColor = System.Drawing.Color.Red;
            this.btnFIRE.Location = new System.Drawing.Point(272, 201);
            this.btnFIRE.Margin = new System.Windows.Forms.Padding(4);
            this.btnFIRE.Name = "btnFIRE";
            this.btnFIRE.Size = new System.Drawing.Size(107, 28);
            this.btnFIRE.TabIndex = 14;
            this.btnFIRE.Text = "FIRE";
            this.btnFIRE.UseVisualStyleBackColor = true;
            this.btnFIRE.Click += new System.EventHandler(this.btnFIRE_Click);
            // 
            // groupBoxLRF
            // 
            this.groupBoxLRF.Controls.Add(this.groupBoxRangeMin);
            this.groupBoxLRF.Controls.Add(this.btnReadStatus);
            this.groupBoxLRF.Controls.Add(this.txtBxRminStatus);
            this.groupBoxLRF.Controls.Add(this.txtBxLRFStatus);
            this.groupBoxLRF.Controls.Add(this.txtBxDistanceStatus);
            this.groupBoxLRF.Controls.Add(this.lblStatusi);
            this.groupBoxLRF.Controls.Add(this.txtBxR3);
            this.groupBoxLRF.Controls.Add(this.txtBxR2);
            this.groupBoxLRF.Controls.Add(this.txtBxR1);
            this.groupBoxLRF.Controls.Add(this.lblRanges);
            this.groupBoxLRF.Controls.Add(this.btnOFF);
            this.groupBoxLRF.Controls.Add(this.btnStatus);
            this.groupBoxLRF.Controls.Add(this.btnFIRE);
            this.groupBoxLRF.Controls.Add(this.btnFillC);
            this.groupBoxLRF.Location = new System.Drawing.Point(16, 389);
            this.groupBoxLRF.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLRF.Name = "groupBoxLRF";
            this.groupBoxLRF.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLRF.Size = new System.Drawing.Size(620, 245);
            this.groupBoxLRF.TabIndex = 15;
            this.groupBoxLRF.TabStop = false;
            this.groupBoxLRF.Text = "LRF";
            // 
            // groupBoxRangeMin
            // 
            this.groupBoxRangeMin.Controls.Add(this.btnSetRmin);
            this.groupBoxRangeMin.Controls.Add(this.txtRmin);
            this.groupBoxRangeMin.Controls.Add(this.btnCancelRmin);
            this.groupBoxRangeMin.Location = new System.Drawing.Point(464, 103);
            this.groupBoxRangeMin.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxRangeMin.Name = "groupBoxRangeMin";
            this.groupBoxRangeMin.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxRangeMin.Size = new System.Drawing.Size(136, 126);
            this.groupBoxRangeMin.TabIndex = 30;
            this.groupBoxRangeMin.TabStop = false;
            this.groupBoxRangeMin.Text = "R_min [m]";
            // 
            // btnSetRmin
            // 
            this.btnSetRmin.Enabled = false;
            this.btnSetRmin.Location = new System.Drawing.Point(8, 54);
            this.btnSetRmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetRmin.Name = "btnSetRmin";
            this.btnSetRmin.Size = new System.Drawing.Size(120, 28);
            this.btnSetRmin.TabIndex = 28;
            this.btnSetRmin.Text = "Set R_min";
            this.btnSetRmin.UseVisualStyleBackColor = true;
            this.btnSetRmin.Click += new System.EventHandler(this.btnSetRmin_Click);
            // 
            // txtRmin
            // 
            this.txtRmin.Location = new System.Drawing.Point(8, 23);
            this.txtRmin.Margin = new System.Windows.Forms.Padding(4);
            this.txtRmin.Name = "txtRmin";
            this.txtRmin.Size = new System.Drawing.Size(119, 22);
            this.txtRmin.TabIndex = 27;
            this.txtRmin.TextChanged += new System.EventHandler(this.txtRmin_TextChanged);
            // 
            // btnCancelRmin
            // 
            this.btnCancelRmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelRmin.Location = new System.Drawing.Point(8, 90);
            this.btnCancelRmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelRmin.Name = "btnCancelRmin";
            this.btnCancelRmin.Size = new System.Drawing.Size(120, 28);
            this.btnCancelRmin.TabIndex = 17;
            this.btnCancelRmin.Text = "Cancel R_min";
            this.btnCancelRmin.UseVisualStyleBackColor = true;
            this.btnCancelRmin.Click += new System.EventHandler(this.btnCancelR_min_Click);
            // 
            // btnReadStatus
            // 
            this.btnReadStatus.Enabled = false;
            this.btnReadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadStatus.Location = new System.Drawing.Point(37, 145);
            this.btnReadStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadStatus.Name = "btnReadStatus";
            this.btnReadStatus.Size = new System.Drawing.Size(169, 30);
            this.btnReadStatus.TabIndex = 26;
            this.btnReadStatus.Text = "Read LRF status";
            this.btnReadStatus.UseVisualStyleBackColor = true;
            this.btnReadStatus.Click += new System.EventHandler(this.btnReadStatus_Click);
            // 
            // txtBxRminStatus
            // 
            this.txtBxRminStatus.Location = new System.Drawing.Point(445, 68);
            this.txtBxRminStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxRminStatus.Name = "txtBxRminStatus";
            this.txtBxRminStatus.ReadOnly = true;
            this.txtBxRminStatus.Size = new System.Drawing.Size(153, 22);
            this.txtBxRminStatus.TabIndex = 25;
            // 
            // txtBxLRFStatus
            // 
            this.txtBxLRFStatus.Location = new System.Drawing.Point(272, 68);
            this.txtBxLRFStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxLRFStatus.Multiline = true;
            this.txtBxLRFStatus.Name = "txtBxLRFStatus";
            this.txtBxLRFStatus.ReadOnly = true;
            this.txtBxLRFStatus.Size = new System.Drawing.Size(161, 83);
            this.txtBxLRFStatus.TabIndex = 24;
            // 
            // txtBxDistanceStatus
            // 
            this.txtBxDistanceStatus.Location = new System.Drawing.Point(127, 68);
            this.txtBxDistanceStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxDistanceStatus.Name = "txtBxDistanceStatus";
            this.txtBxDistanceStatus.ReadOnly = true;
            this.txtBxDistanceStatus.Size = new System.Drawing.Size(133, 22);
            this.txtBxDistanceStatus.TabIndex = 23;
            // 
            // lblStatusi
            // 
            this.lblStatusi.AutoSize = true;
            this.lblStatusi.Location = new System.Drawing.Point(57, 71);
            this.lblStatusi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusi.Name = "lblStatusi";
            this.lblStatusi.Size = new System.Drawing.Size(71, 17);
            this.lblStatusi.TabIndex = 22;
            this.lblStatusi.Text = "Statuses: ";
            // 
            // txtBxR3
            // 
            this.txtBxR3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxR3.Location = new System.Drawing.Point(416, 25);
            this.txtBxR3.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxR3.Name = "txtBxR3";
            this.txtBxR3.ReadOnly = true;
            this.txtBxR3.Size = new System.Drawing.Size(132, 23);
            this.txtBxR3.TabIndex = 21;
            // 
            // txtBxR2
            // 
            this.txtBxR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxR2.Location = new System.Drawing.Point(272, 25);
            this.txtBxR2.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxR2.Name = "txtBxR2";
            this.txtBxR2.ReadOnly = true;
            this.txtBxR2.Size = new System.Drawing.Size(132, 23);
            this.txtBxR2.TabIndex = 20;
            // 
            // txtBxR1
            // 
            this.txtBxR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxR1.Location = new System.Drawing.Point(128, 25);
            this.txtBxR1.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxR1.Name = "txtBxR1";
            this.txtBxR1.ReadOnly = true;
            this.txtBxR1.Size = new System.Drawing.Size(132, 23);
            this.txtBxR1.TabIndex = 19;
            // 
            // lblRanges
            // 
            this.lblRanges.AutoSize = true;
            this.lblRanges.Location = new System.Drawing.Point(33, 30);
            this.lblRanges.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRanges.Name = "lblRanges";
            this.lblRanges.Size = new System.Drawing.Size(88, 17);
            this.lblRanges.TabIndex = 18;
            this.lblRanges.Text = "Ranges [m]: ";
            // 
            // btnOFF
            // 
            this.btnOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOFF.Location = new System.Drawing.Point(17, 201);
            this.btnOFF.Margin = new System.Windows.Forms.Padding(4);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(107, 28);
            this.btnOFF.TabIndex = 16;
            this.btnOFF.Text = "OFF";
            this.btnOFF.UseVisualStyleBackColor = true;
            this.btnOFF.Click += new System.EventHandler(this.btnOFF_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(37, 103);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(169, 30);
            this.btnStatus.TabIndex = 15;
            this.btnStatus.Text = "Request LRF status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // SPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 842);
            this.Controls.Add(this.groupBoxLRF);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.chkClearWithDTR);
            this.Controls.Add(this.chkClearOnOpen);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPortSettings);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.rtfTerminal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(667, 297);
            this.Name = "SPT";
            this.Text = "Serial COM Port Terminal with LRF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTerminal_FormClosing);
            this.Shown += new System.EventHandler(this.FrmTerminal_Shown);
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxLRF.ResumeLayout(false);
            this.groupBoxLRF.PerformLayout();
            this.groupBoxRangeMin.ResumeLayout(false);
            this.groupBoxRangeMin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfTerminal;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.GroupBox gbPortSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCD;
        private System.Windows.Forms.CheckBox chkDSR;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkClearOnOpen;
        private System.Windows.Forms.CheckBox chkClearWithDTR;
        private System.Windows.Forms.Timer tmrCheckComPorts;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnFillC;
        private System.Windows.Forms.Button btnFIRE;
        private System.Windows.Forms.GroupBox groupBoxLRF;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnCancelRmin;
        private System.Windows.Forms.TextBox txtBxR1;
        private System.Windows.Forms.Label lblRanges;
        private System.Windows.Forms.TextBox txtBxR2;
        private System.Windows.Forms.TextBox txtBxR3;
        private System.Windows.Forms.TextBox txtBxRminStatus;
        private System.Windows.Forms.TextBox txtBxLRFStatus;
        private System.Windows.Forms.TextBox txtBxDistanceStatus;
        private System.Windows.Forms.Label lblStatusi;
        private System.Windows.Forms.Button btnReadStatus;
        private System.Windows.Forms.TextBox txtRmin;
        private System.Windows.Forms.Button btnSetRmin;
        private System.Windows.Forms.GroupBox groupBoxRangeMin;
    }
}

