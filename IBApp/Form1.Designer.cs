namespace IBApp
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.host_CT = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.port_CT = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.clientid_CT = new System.Windows.Forms.TextBox();
			this.messageBox = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.status_CT = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.contractDetailsGroupBox = new System.Windows.Forms.GroupBox();
			this.searchContractDetails = new System.Windows.Forms.Button();
			this.conDetSymbolLabel = new System.Windows.Forms.Label();
			this.conDetRightLabel = new System.Windows.Forms.Label();
			this.conDetStrikeLabel = new System.Windows.Forms.Label();
			this.conDetRight = new System.Windows.Forms.ComboBox();
			this.conDetLastTradeDateLabel = new System.Windows.Forms.Label();
			this.conDetSecType = new System.Windows.Forms.ComboBox();
			this.conDetMultiplierLabel = new System.Windows.Forms.Label();
			this.conDetSecTypeLabel = new System.Windows.Forms.Label();
			this.conDetLocalSymbolLabel = new System.Windows.Forms.Label();
			this.conDetExchangeLabel = new System.Windows.Forms.Label();
			this.conDetExchange = new System.Windows.Forms.TextBox();
			this.conDetLocalSymbol = new System.Windows.Forms.TextBox();
			this.conDetMultiplier = new System.Windows.Forms.TextBox();
			this.conDetCurrencyLabel = new System.Windows.Forms.Label();
			this.conDetCurrency = new System.Windows.Forms.TextBox();
			this.conDetLastTradeDateOrContractMonth = new System.Windows.Forms.TextBox();
			this.conDetStrike = new System.Windows.Forms.TextBox();
			this.conDetSymbol = new System.Windows.Forms.TextBox();
			this.contractInfoTab = new System.Windows.Forms.TabControl();
			this.contractDetailsPage = new System.Windows.Forms.TabPage();
			this.contractDetailsGrid = new System.Windows.Forms.DataGridView();
			this.conResSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResLocalSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResSecType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResPrimaryExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conResConId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fundamentalsPage = new System.Windows.Forms.TabPage();
			this.fundamentalsOutput = new System.Windows.Forms.TextBox();
			this.optionChainPage = new System.Windows.Forms.TabPage();
			this.optionChainCallGroup = new System.Windows.Forms.GroupBox();
			this.optionChainCallGrid = new System.Windows.Forms.DataGridView();
			this.callLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callImpliedVolatility = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callGamma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callVega = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callTheta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.optionChainPutGroup = new System.Windows.Forms.GroupBox();
			this.optionChainPutGrid = new System.Windows.Forms.DataGridView();
			this.putLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putImpliedVolatility = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putGamma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putVega = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.putTheta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.optionParametersPage = new System.Windows.Forms.TabPage();
			this.listViewOptionParams = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.contractDetailsGroupBox.SuspendLayout();
			this.contractInfoTab.SuspendLayout();
			this.contractDetailsPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).BeginInit();
			this.fundamentalsPage.SuspendLayout();
			this.optionChainPage.SuspendLayout();
			this.optionChainCallGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.optionChainCallGrid)).BeginInit();
			this.optionChainPutGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.optionChainPutGrid)).BeginInit();
			this.optionParametersPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(496, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// host_CT
			// 
			this.host_CT.Location = new System.Drawing.Point(48, 12);
			this.host_CT.Name = "host_CT";
			this.host_CT.Size = new System.Drawing.Size(100, 20);
			this.host_CT.TabIndex = 1;
			this.host_CT.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Host:";
			// 
			// port_CT
			// 
			this.port_CT.Location = new System.Drawing.Point(197, 12);
			this.port_CT.Name = "port_CT";
			this.port_CT.Size = new System.Drawing.Size(100, 20);
			this.port_CT.TabIndex = 3;
			this.port_CT.Text = "7496";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(163, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Host:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(315, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Client ID:";
			// 
			// clientid_CT
			// 
			this.clientid_CT.Location = new System.Drawing.Point(371, 12);
			this.clientid_CT.Name = "clientid_CT";
			this.clientid_CT.Size = new System.Drawing.Size(100, 20);
			this.clientid_CT.TabIndex = 6;
			this.clientid_CT.Text = "1";
			// 
			// messageBox
			// 
			this.messageBox.Location = new System.Drawing.Point(16, 177);
			this.messageBox.Multiline = true;
			this.messageBox.Name = "messageBox";
			this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.messageBox.Size = new System.Drawing.Size(678, 114);
			this.messageBox.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(704, 239);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(98, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "send message";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// status_CT
			// 
			this.status_CT.AutoSize = true;
			this.status_CT.Location = new System.Drawing.Point(632, 15);
			this.status_CT.Name = "status_CT";
			this.status_CT.Size = new System.Drawing.Size(35, 13);
			this.status_CT.TabIndex = 9;
			this.status_CT.Text = "label4";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(591, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Status:";
			// 
			// contractDetailsGroupBox
			// 
			this.contractDetailsGroupBox.Controls.Add(this.searchContractDetails);
			this.contractDetailsGroupBox.Controls.Add(this.conDetSymbolLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetRightLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetStrikeLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetRight);
			this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetSecType);
			this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplierLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetSecTypeLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbolLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetExchangeLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetExchange);
			this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbol);
			this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplier);
			this.contractDetailsGroupBox.Controls.Add(this.conDetCurrencyLabel);
			this.contractDetailsGroupBox.Controls.Add(this.conDetCurrency);
			this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateOrContractMonth);
			this.contractDetailsGroupBox.Controls.Add(this.conDetStrike);
			this.contractDetailsGroupBox.Controls.Add(this.conDetSymbol);
			this.contractDetailsGroupBox.Location = new System.Drawing.Point(704, 60);
			this.contractDetailsGroupBox.Name = "contractDetailsGroupBox";
			this.contractDetailsGroupBox.Size = new System.Drawing.Size(399, 173);
			this.contractDetailsGroupBox.TabIndex = 34;
			this.contractDetailsGroupBox.TabStop = false;
			this.contractDetailsGroupBox.Text = "Contract details";
			// 
			// searchContractDetails
			// 
			this.searchContractDetails.Location = new System.Drawing.Point(309, 144);
			this.searchContractDetails.Name = "searchContractDetails";
			this.searchContractDetails.Size = new System.Drawing.Size(75, 23);
			this.searchContractDetails.TabIndex = 34;
			this.searchContractDetails.Text = "Search";
			this.searchContractDetails.UseVisualStyleBackColor = true;
			this.searchContractDetails.Click += new System.EventHandler(this.searchContractDetails_Click_1);
			// 
			// conDetSymbolLabel
			// 
			this.conDetSymbolLabel.AutoSize = true;
			this.conDetSymbolLabel.Location = new System.Drawing.Point(20, 26);
			this.conDetSymbolLabel.Name = "conDetSymbolLabel";
			this.conDetSymbolLabel.Size = new System.Drawing.Size(41, 13);
			this.conDetSymbolLabel.TabIndex = 17;
			this.conDetSymbolLabel.Text = "Symbol";
			// 
			// conDetRightLabel
			// 
			this.conDetRightLabel.AutoSize = true;
			this.conDetRightLabel.Location = new System.Drawing.Point(16, 127);
			this.conDetRightLabel.Name = "conDetRightLabel";
			this.conDetRightLabel.Size = new System.Drawing.Size(45, 13);
			this.conDetRightLabel.TabIndex = 59;
			this.conDetRightLabel.Text = "Put/Call";
			// 
			// conDetStrikeLabel
			// 
			this.conDetStrikeLabel.AutoSize = true;
			this.conDetStrikeLabel.Location = new System.Drawing.Point(234, 91);
			this.conDetStrikeLabel.Name = "conDetStrikeLabel";
			this.conDetStrikeLabel.Size = new System.Drawing.Size(34, 13);
			this.conDetStrikeLabel.TabIndex = 21;
			this.conDetStrikeLabel.Text = "Strike";
			// 
			// conDetRight
			// 
			this.conDetRight.FormattingEnabled = true;
			this.conDetRight.Location = new System.Drawing.Point(86, 127);
			this.conDetRight.Name = "conDetRight";
			this.conDetRight.Size = new System.Drawing.Size(100, 21);
			this.conDetRight.TabIndex = 58;
			// 
			// conDetLastTradeDateLabel
			// 
			this.conDetLastTradeDateLabel.Location = new System.Drawing.Point(192, 51);
			this.conDetLastTradeDateLabel.Name = "conDetLastTradeDateLabel";
			this.conDetLastTradeDateLabel.Size = new System.Drawing.Size(86, 33);
			this.conDetLastTradeDateLabel.TabIndex = 20;
			this.conDetLastTradeDateLabel.Text = "Last trade date / contract month";
			// 
			// conDetSecType
			// 
			this.conDetSecType.FormattingEnabled = true;
			this.conDetSecType.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
			this.conDetSecType.Location = new System.Drawing.Point(86, 48);
			this.conDetSecType.Name = "conDetSecType";
			this.conDetSecType.Size = new System.Drawing.Size(100, 21);
			this.conDetSecType.TabIndex = 18;
			this.conDetSecType.Text = "STK";
			// 
			// conDetMultiplierLabel
			// 
			this.conDetMultiplierLabel.AutoSize = true;
			this.conDetMultiplierLabel.Location = new System.Drawing.Point(220, 26);
			this.conDetMultiplierLabel.Name = "conDetMultiplierLabel";
			this.conDetMultiplierLabel.Size = new System.Drawing.Size(48, 13);
			this.conDetMultiplierLabel.TabIndex = 22;
			this.conDetMultiplierLabel.Text = "Multiplier";
			// 
			// conDetSecTypeLabel
			// 
			this.conDetSecTypeLabel.AutoSize = true;
			this.conDetSecTypeLabel.Location = new System.Drawing.Point(11, 48);
			this.conDetSecTypeLabel.Name = "conDetSecTypeLabel";
			this.conDetSecTypeLabel.Size = new System.Drawing.Size(50, 13);
			this.conDetSecTypeLabel.TabIndex = 19;
			this.conDetSecTypeLabel.Text = "SecType";
			// 
			// conDetLocalSymbolLabel
			// 
			this.conDetLocalSymbolLabel.AutoSize = true;
			this.conDetLocalSymbolLabel.Location = new System.Drawing.Point(198, 117);
			this.conDetLocalSymbolLabel.Name = "conDetLocalSymbolLabel";
			this.conDetLocalSymbolLabel.Size = new System.Drawing.Size(70, 13);
			this.conDetLocalSymbolLabel.TabIndex = 25;
			this.conDetLocalSymbolLabel.Text = "Local Symbol";
			// 
			// conDetExchangeLabel
			// 
			this.conDetExchangeLabel.AutoSize = true;
			this.conDetExchangeLabel.Location = new System.Drawing.Point(6, 101);
			this.conDetExchangeLabel.Name = "conDetExchangeLabel";
			this.conDetExchangeLabel.Size = new System.Drawing.Size(55, 13);
			this.conDetExchangeLabel.TabIndex = 23;
			this.conDetExchangeLabel.Text = "Exchange";
			// 
			// conDetExchange
			// 
			this.conDetExchange.Location = new System.Drawing.Point(86, 101);
			this.conDetExchange.Name = "conDetExchange";
			this.conDetExchange.Size = new System.Drawing.Size(100, 20);
			this.conDetExchange.TabIndex = 27;
			this.conDetExchange.Text = "SMART";
			// 
			// conDetLocalSymbol
			// 
			this.conDetLocalSymbol.Location = new System.Drawing.Point(284, 117);
			this.conDetLocalSymbol.Name = "conDetLocalSymbol";
			this.conDetLocalSymbol.Size = new System.Drawing.Size(100, 20);
			this.conDetLocalSymbol.TabIndex = 31;
			// 
			// conDetMultiplier
			// 
			this.conDetMultiplier.Location = new System.Drawing.Point(284, 19);
			this.conDetMultiplier.Name = "conDetMultiplier";
			this.conDetMultiplier.Size = new System.Drawing.Size(100, 20);
			this.conDetMultiplier.TabIndex = 28;
			// 
			// conDetCurrencyLabel
			// 
			this.conDetCurrencyLabel.AutoSize = true;
			this.conDetCurrencyLabel.Location = new System.Drawing.Point(12, 75);
			this.conDetCurrencyLabel.Name = "conDetCurrencyLabel";
			this.conDetCurrencyLabel.Size = new System.Drawing.Size(49, 13);
			this.conDetCurrencyLabel.TabIndex = 24;
			this.conDetCurrencyLabel.Text = "Currency";
			// 
			// conDetCurrency
			// 
			this.conDetCurrency.Location = new System.Drawing.Point(86, 75);
			this.conDetCurrency.Name = "conDetCurrency";
			this.conDetCurrency.Size = new System.Drawing.Size(100, 20);
			this.conDetCurrency.TabIndex = 26;
			this.conDetCurrency.Text = "USD";
			// 
			// conDetLastTradeDateOrContractMonth
			// 
			this.conDetLastTradeDateOrContractMonth.Location = new System.Drawing.Point(284, 58);
			this.conDetLastTradeDateOrContractMonth.Name = "conDetLastTradeDateOrContractMonth";
			this.conDetLastTradeDateOrContractMonth.Size = new System.Drawing.Size(100, 20);
			this.conDetLastTradeDateOrContractMonth.TabIndex = 30;
			// 
			// conDetStrike
			// 
			this.conDetStrike.Location = new System.Drawing.Point(284, 91);
			this.conDetStrike.Name = "conDetStrike";
			this.conDetStrike.Size = new System.Drawing.Size(100, 20);
			this.conDetStrike.TabIndex = 29;
			this.conDetStrike.Text = "10";
			// 
			// conDetSymbol
			// 
			this.conDetSymbol.Location = new System.Drawing.Point(86, 23);
			this.conDetSymbol.Name = "conDetSymbol";
			this.conDetSymbol.Size = new System.Drawing.Size(100, 20);
			this.conDetSymbol.TabIndex = 16;
			this.conDetSymbol.Text = "IBKR";
			// 
			// contractInfoTab
			// 
			this.contractInfoTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contractInfoTab.Controls.Add(this.contractDetailsPage);
			this.contractInfoTab.Controls.Add(this.fundamentalsPage);
			this.contractInfoTab.Controls.Add(this.optionChainPage);
			this.contractInfoTab.Controls.Add(this.optionParametersPage);
			this.contractInfoTab.Location = new System.Drawing.Point(12, 38);
			this.contractInfoTab.Name = "contractInfoTab";
			this.contractInfoTab.SelectedIndex = 0;
			this.contractInfoTab.Size = new System.Drawing.Size(686, 133);
			this.contractInfoTab.TabIndex = 35;
			// 
			// contractDetailsPage
			// 
			this.contractDetailsPage.BackColor = System.Drawing.Color.LightGray;
			this.contractDetailsPage.Controls.Add(this.contractDetailsGrid);
			this.contractDetailsPage.Location = new System.Drawing.Point(4, 22);
			this.contractDetailsPage.Name = "contractDetailsPage";
			this.contractDetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.contractDetailsPage.Size = new System.Drawing.Size(678, 107);
			this.contractDetailsPage.TabIndex = 0;
			this.contractDetailsPage.Text = "Contract Details";
			// 
			// contractDetailsGrid
			// 
			this.contractDetailsGrid.AllowUserToAddRows = false;
			this.contractDetailsGrid.AllowUserToDeleteRows = false;
			this.contractDetailsGrid.AllowUserToOrderColumns = true;
			this.contractDetailsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contractDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.contractDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conResSymbol,
            this.conResLocalSymbol,
            this.conResSecType,
            this.conResCurrency,
            this.conResExchange,
            this.conResPrimaryExch,
            this.conResLastTradeDate,
            this.conResMultiplier,
            this.conResStrike,
            this.conResRight,
            this.conResConId});
			this.contractDetailsGrid.Location = new System.Drawing.Point(6, 6);
			this.contractDetailsGrid.Name = "contractDetailsGrid";
			this.contractDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.contractDetailsGrid.Size = new System.Drawing.Size(666, 95);
			this.contractDetailsGrid.TabIndex = 0;
			// 
			// conResSymbol
			// 
			this.conResSymbol.HeaderText = "Symbol";
			this.conResSymbol.Name = "conResSymbol";
			this.conResSymbol.ReadOnly = true;
			// 
			// conResLocalSymbol
			// 
			this.conResLocalSymbol.HeaderText = "Local Symbol";
			this.conResLocalSymbol.Name = "conResLocalSymbol";
			this.conResLocalSymbol.ReadOnly = true;
			// 
			// conResSecType
			// 
			this.conResSecType.HeaderText = "Type";
			this.conResSecType.Name = "conResSecType";
			this.conResSecType.ReadOnly = true;
			// 
			// conResCurrency
			// 
			this.conResCurrency.HeaderText = "Currency";
			this.conResCurrency.Name = "conResCurrency";
			this.conResCurrency.ReadOnly = true;
			// 
			// conResExchange
			// 
			this.conResExchange.HeaderText = "Exchange";
			this.conResExchange.Name = "conResExchange";
			this.conResExchange.ReadOnly = true;
			// 
			// conResPrimaryExch
			// 
			this.conResPrimaryExch.HeaderText = "Primary Exch.";
			this.conResPrimaryExch.Name = "conResPrimaryExch";
			this.conResPrimaryExch.ReadOnly = true;
			// 
			// conResLastTradeDate
			// 
			this.conResLastTradeDate.HeaderText = "lastTradeDate";
			this.conResLastTradeDate.Name = "conResLastTradeDate";
			this.conResLastTradeDate.ReadOnly = true;
			// 
			// conResMultiplier
			// 
			this.conResMultiplier.HeaderText = "Multiplier";
			this.conResMultiplier.Name = "conResMultiplier";
			this.conResMultiplier.ReadOnly = true;
			// 
			// conResStrike
			// 
			this.conResStrike.HeaderText = "Strike";
			this.conResStrike.Name = "conResStrike";
			this.conResStrike.ReadOnly = true;
			// 
			// conResRight
			// 
			this.conResRight.HeaderText = "P/C";
			this.conResRight.Name = "conResRight";
			this.conResRight.ReadOnly = true;
			// 
			// conResConId
			// 
			this.conResConId.HeaderText = "ConId";
			this.conResConId.Name = "conResConId";
			this.conResConId.ReadOnly = true;
			// 
			// fundamentalsPage
			// 
			this.fundamentalsPage.BackColor = System.Drawing.Color.LightGray;
			this.fundamentalsPage.Controls.Add(this.fundamentalsOutput);
			this.fundamentalsPage.Location = new System.Drawing.Point(4, 22);
			this.fundamentalsPage.Name = "fundamentalsPage";
			this.fundamentalsPage.Padding = new System.Windows.Forms.Padding(3);
			this.fundamentalsPage.Size = new System.Drawing.Size(678, 107);
			this.fundamentalsPage.TabIndex = 1;
			this.fundamentalsPage.Text = "Fundamentals";
			// 
			// fundamentalsOutput
			// 
			this.fundamentalsOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fundamentalsOutput.Location = new System.Drawing.Point(6, 6);
			this.fundamentalsOutput.Multiline = true;
			this.fundamentalsOutput.Name = "fundamentalsOutput";
			this.fundamentalsOutput.ReadOnly = true;
			this.fundamentalsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.fundamentalsOutput.Size = new System.Drawing.Size(1216, 231);
			this.fundamentalsOutput.TabIndex = 0;
			// 
			// optionChainPage
			// 
			this.optionChainPage.BackColor = System.Drawing.Color.LightGray;
			this.optionChainPage.Controls.Add(this.optionChainCallGroup);
			this.optionChainPage.Controls.Add(this.optionChainPutGroup);
			this.optionChainPage.Location = new System.Drawing.Point(4, 22);
			this.optionChainPage.Name = "optionChainPage";
			this.optionChainPage.Padding = new System.Windows.Forms.Padding(3);
			this.optionChainPage.Size = new System.Drawing.Size(678, 107);
			this.optionChainPage.TabIndex = 2;
			this.optionChainPage.Text = "Options chain";
			// 
			// optionChainCallGroup
			// 
			this.optionChainCallGroup.Controls.Add(this.optionChainCallGrid);
			this.optionChainCallGroup.Location = new System.Drawing.Point(6, 6);
			this.optionChainCallGroup.Name = "optionChainCallGroup";
			this.optionChainCallGroup.Size = new System.Drawing.Size(590, 231);
			this.optionChainCallGroup.TabIndex = 43;
			this.optionChainCallGroup.TabStop = false;
			this.optionChainCallGroup.Text = "Calls";
			// 
			// optionChainCallGrid
			// 
			this.optionChainCallGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.optionChainCallGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callLastTradeDate,
            this.callStrike,
            this.callBid,
            this.callAsk,
            this.callImpliedVolatility,
            this.callDelta,
            this.callGamma,
            this.callVega,
            this.callTheta});
			this.optionChainCallGrid.Location = new System.Drawing.Point(6, 19);
			this.optionChainCallGrid.Name = "optionChainCallGrid";
			this.optionChainCallGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.optionChainCallGrid.Size = new System.Drawing.Size(576, 206);
			this.optionChainCallGrid.TabIndex = 40;
			// 
			// callLastTradeDate
			// 
			this.callLastTradeDate.HeaderText = "lastTradeDate";
			this.callLastTradeDate.Name = "callLastTradeDate";
			this.callLastTradeDate.Width = 70;
			// 
			// callStrike
			// 
			this.callStrike.HeaderText = "Strike";
			this.callStrike.Name = "callStrike";
			this.callStrike.Width = 50;
			// 
			// callBid
			// 
			this.callBid.HeaderText = "Bid";
			this.callBid.Name = "callBid";
			this.callBid.ReadOnly = true;
			this.callBid.Width = 50;
			// 
			// callAsk
			// 
			this.callAsk.HeaderText = "Ask";
			this.callAsk.Name = "callAsk";
			this.callAsk.ReadOnly = true;
			this.callAsk.Width = 50;
			// 
			// callImpliedVolatility
			// 
			this.callImpliedVolatility.HeaderText = "Imp. Vol.";
			this.callImpliedVolatility.Name = "callImpliedVolatility";
			this.callImpliedVolatility.ReadOnly = true;
			this.callImpliedVolatility.Width = 80;
			// 
			// callDelta
			// 
			this.callDelta.HeaderText = "Delta";
			this.callDelta.Name = "callDelta";
			this.callDelta.ReadOnly = true;
			this.callDelta.Width = 50;
			// 
			// callGamma
			// 
			this.callGamma.HeaderText = "Gamma";
			this.callGamma.Name = "callGamma";
			this.callGamma.ReadOnly = true;
			this.callGamma.Width = 50;
			// 
			// callVega
			// 
			this.callVega.HeaderText = "Vega";
			this.callVega.Name = "callVega";
			this.callVega.ReadOnly = true;
			this.callVega.Width = 50;
			// 
			// callTheta
			// 
			this.callTheta.HeaderText = "Theta";
			this.callTheta.Name = "callTheta";
			this.callTheta.ReadOnly = true;
			this.callTheta.Width = 50;
			// 
			// optionChainPutGroup
			// 
			this.optionChainPutGroup.Controls.Add(this.optionChainPutGrid);
			this.optionChainPutGroup.Location = new System.Drawing.Point(622, 6);
			this.optionChainPutGroup.Name = "optionChainPutGroup";
			this.optionChainPutGroup.Size = new System.Drawing.Size(591, 231);
			this.optionChainPutGroup.TabIndex = 42;
			this.optionChainPutGroup.TabStop = false;
			this.optionChainPutGroup.Text = "Puts";
			// 
			// optionChainPutGrid
			// 
			this.optionChainPutGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.optionChainPutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.putLastTradeDate,
            this.putStrike,
            this.putBid,
            this.putAsk,
            this.putImpliedVolatility,
            this.putDelta,
            this.putGamma,
            this.putVega,
            this.putTheta});
			this.optionChainPutGrid.Location = new System.Drawing.Point(6, 19);
			this.optionChainPutGrid.Name = "optionChainPutGrid";
			this.optionChainPutGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.optionChainPutGrid.Size = new System.Drawing.Size(579, 206);
			this.optionChainPutGrid.TabIndex = 41;
			// 
			// putLastTradeDate
			// 
			this.putLastTradeDate.HeaderText = "lastTradeDate";
			this.putLastTradeDate.Name = "putLastTradeDate";
			this.putLastTradeDate.Width = 70;
			// 
			// putStrike
			// 
			this.putStrike.HeaderText = "Strike";
			this.putStrike.Name = "putStrike";
			this.putStrike.Width = 50;
			// 
			// putBid
			// 
			this.putBid.HeaderText = "Bid";
			this.putBid.Name = "putBid";
			this.putBid.ReadOnly = true;
			this.putBid.Width = 50;
			// 
			// putAsk
			// 
			this.putAsk.HeaderText = "Ask";
			this.putAsk.Name = "putAsk";
			this.putAsk.ReadOnly = true;
			this.putAsk.Width = 50;
			// 
			// putImpliedVolatility
			// 
			this.putImpliedVolatility.HeaderText = "Imp. Vol.";
			this.putImpliedVolatility.Name = "putImpliedVolatility";
			this.putImpliedVolatility.ReadOnly = true;
			this.putImpliedVolatility.Width = 80;
			// 
			// putDelta
			// 
			this.putDelta.HeaderText = "Delta";
			this.putDelta.Name = "putDelta";
			this.putDelta.ReadOnly = true;
			this.putDelta.Width = 50;
			// 
			// putGamma
			// 
			this.putGamma.HeaderText = "Gamma";
			this.putGamma.Name = "putGamma";
			this.putGamma.ReadOnly = true;
			this.putGamma.Width = 50;
			// 
			// putVega
			// 
			this.putVega.HeaderText = "Vega";
			this.putVega.Name = "putVega";
			this.putVega.ReadOnly = true;
			this.putVega.Width = 50;
			// 
			// putTheta
			// 
			this.putTheta.HeaderText = "Theta";
			this.putTheta.Name = "putTheta";
			this.putTheta.ReadOnly = true;
			this.putTheta.Width = 50;
			// 
			// optionParametersPage
			// 
			this.optionParametersPage.Controls.Add(this.listViewOptionParams);
			this.optionParametersPage.Location = new System.Drawing.Point(4, 22);
			this.optionParametersPage.Name = "optionParametersPage";
			this.optionParametersPage.Size = new System.Drawing.Size(678, 107);
			this.optionParametersPage.TabIndex = 3;
			this.optionParametersPage.Text = "Option parameters";
			this.optionParametersPage.UseVisualStyleBackColor = true;
			// 
			// listViewOptionParams
			// 
			this.listViewOptionParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listViewOptionParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewOptionParams.Location = new System.Drawing.Point(0, 0);
			this.listViewOptionParams.Name = "listViewOptionParams";
			this.listViewOptionParams.Size = new System.Drawing.Size(678, 107);
			this.listViewOptionParams.TabIndex = 0;
			this.listViewOptionParams.UseCompatibleStateImageBehavior = false;
			this.listViewOptionParams.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Expirations";
			this.columnHeader1.Width = 141;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Strikes";
			this.columnHeader2.Width = 71;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(817, 239);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(98, 23);
			this.button3.TabIndex = 36;
			this.button3.Text = "Test contract";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(704, 268);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(98, 23);
			this.button4.TabIndex = 37;
			this.button4.Text = "Buy";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1115, 303);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.contractInfoTab);
			this.Controls.Add(this.contractDetailsGroupBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.status_CT);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.messageBox);
			this.Controls.Add(this.clientid_CT);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.port_CT);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.host_CT);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.contractDetailsGroupBox.ResumeLayout(false);
			this.contractDetailsGroupBox.PerformLayout();
			this.contractInfoTab.ResumeLayout(false);
			this.contractDetailsPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).EndInit();
			this.fundamentalsPage.ResumeLayout(false);
			this.fundamentalsPage.PerformLayout();
			this.optionChainPage.ResumeLayout(false);
			this.optionChainCallGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.optionChainCallGrid)).EndInit();
			this.optionChainPutGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.optionChainPutGrid)).EndInit();
			this.optionParametersPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.TextBox host_CT;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox port_CT;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox clientid_CT;
		private System.Windows.Forms.TextBox messageBox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label status_CT;
		private System.Windows.Forms.GroupBox contractDetailsGroupBox;
		private System.Windows.Forms.Button searchContractDetails;
		private System.Windows.Forms.Label conDetSymbolLabel;
		private System.Windows.Forms.Label conDetRightLabel;
		private System.Windows.Forms.Label conDetStrikeLabel;
		private System.Windows.Forms.ComboBox conDetRight;
		private System.Windows.Forms.Label conDetLastTradeDateLabel;
		private System.Windows.Forms.ComboBox conDetSecType;
		private System.Windows.Forms.Label conDetMultiplierLabel;
		private System.Windows.Forms.Label conDetSecTypeLabel;
		private System.Windows.Forms.Label conDetLocalSymbolLabel;
		private System.Windows.Forms.Label conDetExchangeLabel;
		private System.Windows.Forms.TextBox conDetExchange;
		private System.Windows.Forms.TextBox conDetLocalSymbol;
		private System.Windows.Forms.TextBox conDetMultiplier;
		private System.Windows.Forms.Label conDetCurrencyLabel;
		private System.Windows.Forms.TextBox conDetCurrency;
		private System.Windows.Forms.TextBox conDetLastTradeDateOrContractMonth;
		private System.Windows.Forms.TextBox conDetStrike;
		private System.Windows.Forms.TextBox conDetSymbol;
		private System.Windows.Forms.TabControl contractInfoTab;
		private System.Windows.Forms.TabPage contractDetailsPage;
		private System.Windows.Forms.DataGridView contractDetailsGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResSymbol;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResLocalSymbol;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResSecType;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResCurrency;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResExchange;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResPrimaryExch;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResLastTradeDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResMultiplier;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResStrike;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResRight;
		private System.Windows.Forms.DataGridViewTextBoxColumn conResConId;
		private System.Windows.Forms.TabPage fundamentalsPage;
		private System.Windows.Forms.TextBox fundamentalsOutput;
		private System.Windows.Forms.TabPage optionChainPage;
		private System.Windows.Forms.GroupBox optionChainCallGroup;
		private System.Windows.Forms.DataGridView optionChainCallGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn callLastTradeDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn callStrike;
		private System.Windows.Forms.DataGridViewTextBoxColumn callBid;
		private System.Windows.Forms.DataGridViewTextBoxColumn callAsk;
		private System.Windows.Forms.DataGridViewTextBoxColumn callImpliedVolatility;
		private System.Windows.Forms.DataGridViewTextBoxColumn callDelta;
		private System.Windows.Forms.DataGridViewTextBoxColumn callGamma;
		private System.Windows.Forms.DataGridViewTextBoxColumn callVega;
		private System.Windows.Forms.DataGridViewTextBoxColumn callTheta;
		private System.Windows.Forms.GroupBox optionChainPutGroup;
		private System.Windows.Forms.DataGridView optionChainPutGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn putLastTradeDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn putStrike;
		private System.Windows.Forms.DataGridViewTextBoxColumn putBid;
		private System.Windows.Forms.DataGridViewTextBoxColumn putAsk;
		private System.Windows.Forms.DataGridViewTextBoxColumn putImpliedVolatility;
		private System.Windows.Forms.DataGridViewTextBoxColumn putDelta;
		private System.Windows.Forms.DataGridViewTextBoxColumn putGamma;
		private System.Windows.Forms.DataGridViewTextBoxColumn putVega;
		private System.Windows.Forms.DataGridViewTextBoxColumn putTheta;
		private System.Windows.Forms.TabPage optionParametersPage;
		private System.Windows.Forms.ListView listViewOptionParams;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

