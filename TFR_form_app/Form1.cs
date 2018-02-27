using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using OpenQA.Selenium.Chrome; // Chrome driver for parsing
using OpenQA.Selenium;

using System.Globalization;
using System.Threading;

using IBSampleApp.messages; // Linked namespaces from IB Sample app
using IBApi; // https://interactivebrokers.github.io/tws-api/interfaceIBApi_1_1EWrapper.html#ae9114b5146bb8f32796f9b9d21569d7c 
using IBSampleApp.ui;
using IBSampleApp.types;
using IBSampleApp;



namespace TFR_form_app
{
	public  partial class Form1 : Form // Main class
	{
		// Parser 
		public static ChromeDriver ChromeDriver = new ChromeDriver();
		public static IJavaScriptExecutor js = (IJavaScriptExecutor)ChromeDriver; // Make JS instance for JS execution

		public static Thread MessageTrackingThread;

		// Broker connector
		delegate void MessageHandlerDelegate(IBMessage message); // Delegate for mesage handling
		protected IBClient ibClient; // Realises interface EWrapper
		private EReaderMonitorSignal signal = new EReaderMonitorSignal(); // Signal for web socket connection
		//private ContractManager contractManager; // The class which descrbes a contract details
		private const int MAX_LINES_IN_MESSAGE_BOX = 200; // Variables for message windows
		private const int REDUCED_LINES_IN_MESSAGE_BOX = 100;
		private int numberOfLinesInMessageBox = 0;
		private List<string> linesInMessageBox = new List<string>(MAX_LINES_IN_MESSAGE_BOX);
		private bool isConnected = false;

		// Find, place oerder at the exchange
		public IBApp.IBAppClasses.ContractSearch contractSearch; // Contract search class from IBApp project. ContractSearch class instance. Used for contract find before order execution
		public IBApp.IBAppClasses.PlaceOrder placeOrder; // Place orderclass





		public Form1()
		{
			InitializeComponent();

			ChromeDriver.Navigate().GoToUrl("https://profit.ly/profiding"); // Go to URL file:///D:/1/profitly.html https://profit.ly/profiding

			// listView1 setyp
			listView1.View = View.Details;
			listView1.GridLines = true; // Horizoltal lines
			listView1.Columns.Add("Time:");
			listView1.Columns[0].Width = 60;
			listView1.Columns.Add("Source:", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Message:");
			listView1.Columns[2].Width = 400;

			// listView2 setyp
			listView2.View = View.Details;
			listView2.GridLines = true; // Horizoltal lines
			listView2.Columns.Add("Time:");
			listView2.Columns[0].Width = 60;
			listView2.Columns.Add("Source:", -2, HorizontalAlignment.Left);
			listView2.Columns.Add("Message:");
			listView2.Columns[2].Width = 400;

			// Broker connector
			ibClient = new IBClient(signal);
			//contractManager = new ContractManager(ibClient, fundamentalsOutput, contractDetailsGrid);
			contractSearch = new IBApp.IBAppClasses.ContractSearch(ibClient); // The class which search for the given contract
			placeOrder = new IBApp.IBAppClasses.PlaceOrder(ibClient);

			// Event handlers
			ibClient.Error += ibClient_Error;
			ibClient.ContractDetails += (reqId, contractDetails) => HandleMessage(new ContractDetailsMessage(reqId, contractDetails)); //  Request contract details https://interactivebrokers.github.io/tws-api/contract_details.html#gsc.tab=0
			ibClient.ConnectionClosed += ibClient_ConnectionClosed; // Update UI when disconnect button is clicked

			// Order events
			ibClient.NextValidId += ibClient_NextValidId; // Receives next valid order id. Will be invoked automatically upon successfull API client connection. Used for sending connection status
			ibClient.OrderStatus += (orderId, status, filled, remaining, avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld) =>
			 HandleMessage(new OrderStatusMessage(orderId, status, filled, remaining, avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld));
			ibClient.OpenOrder += (orderId, contract, order, orderState) => HandleMessage(new OpenOrderMessage(orderId, contract, order, orderState));
			ibClient.OpenOrderEnd += () => HandleMessage(new OpenOrderEndMessage());
			ibClient.ContractDetails += (reqId, contractDetails) => HandleMessage(new ContractDetailsMessage(reqId, contractDetails));
			ibClient.ContractDetailsEnd += (reqId) => HandleMessage(new ContractDetailsEndMessage());
			ibClient.ExecDetails += (reqId, contract, execution) => HandleMessage(new ExecutionMessage(reqId, contract, execution));
			ibClient.ExecDetailsEnd += reqId => addTextToBox("ExecDetailsEnd. " + reqId + "\n");
			ibClient.CommissionReport += commissionReport => HandleMessage(new CommissionMessage(commissionReport));
			ibClient.FundamentalData += (reqId, data) => HandleMessage(new FundamentalsMessage(data));
			ibClient.HistoricalData += (reqId, date, open, high, low, close, volume, count, WAP, hasGaps) =>
				HandleMessage(new HistoricalDataMessage(reqId, date, open, high, low, close, volume, count, WAP, hasGaps));

			ibClient.Position += (account, contract, pos, avgCost) => HandleMessage(new PositionMessage(account, contract, pos, avgCost));





		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "Current culture:" + CultureInfo.CurrentCulture.Name, "white");
			ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "Version: 02/26/2018 01:33PM", "white");


			//var chromeDriverService = ChromeDriverService.CreateDefaultService();
			//chromeDriverService.HideCommandPromptWindow = true;
			//var driver = new ChromeDriver(chromeDriverService, new ChromeOptions());

			//ChromeDriver.Navigate().GoToUrl("https://profit.ly/profiding2222"); // Go to URL file:///D:/1/profitly.html https://profit.ly/profiding
			
		}


		#region // Parser. Form control events

		private void button3_Click(object sender, EventArgs e) // Ingect bought message
		{
			InjectTestMessage.InjectMsg("bought", this);
		}

		private void button4_Click(object sender, EventArgs e) // Inject sold message
		{
			InjectTestMessage.InjectMsg("sold", this);
		}

		private void button5_Click(object sender, EventArgs e) // Inject else message
		{
			InjectTestMessage.InjectMsg("else", this); 
		}

		private void button9_Click(object sender, EventArgs e) // New DB
		{
			DataBase.DropTable();
			DataBase.DBStructCreate();
			DataBase.DBInsertStartingBalance(0);

		}

		private void button7_Click(object sender, EventArgs e) // Brand new DB
		{
			DataBase.DBCreate();
		}

		private void button1_Click_1(object sender, EventArgs e) // Start bot
		{
			//GetAndTrackMMessages.startTracking = true;

			MessageTrackingThread = new Thread(new ThreadStart(DelegateMethod)); // A thread for message tracking. Message tracking exist in a parralell thread
			MessageTrackingThread.IsBackground = true; // https://stackoverflow.com/questions/3360555/how-to-pass-parameters-to-threadstart-method-in-thread
			MessageTrackingThread.Name = "MessageTrackingThread";
			MessageTrackingThread.Start();

		}

		private void DelegateMethod() // new ThreadStart does not take any arguments this i call local method which passes the parameter - from
		{
			GetAndTrackMMessages.MessageSearch(this);
		}

		#endregion

		#region // Broker connector. Event handlers

		// ibClient event handlers

		void ibClient_NextValidId(int orderId)
		{
			IsConnected = true;
			HandleMessage(new ConnectionStatusMessage(true));
			//ShowMessageOnPanel("void ibClient_NextValidId(int orderId): " + orderId); // Does not work. Invoke required
			ListViewLogging.log_add(this, "parserListBox","void ibClient_NextValidId(int orderId)", "ibClient_NextValidId: " + orderId, "white");


		}

		void ibClient_Error(int id, int errorCode, string str, Exception ex)
		{
			if (ex != null)
			{
				addTextToBox("Error: " + ex); // Make error message

				return;
			}

			if (id == 0 || errorCode == 0)
			{
				addTextToBox("Error: " + str + "\n");

				return;
			}

			HandleMessage(new ErrorMessage(id, errorCode, str));
		}

		void ibClient_ConnectionClosed()
		{
			IsConnected = false;
			HandleMessage(new ConnectionStatusMessage(false));
		}

		// Methods and variables
		private void addTextToBox(string text) // Error message
		{
			HandleMessage(new ErrorMessage(-1, -1, text));
		}

		public void HandleMessage(IBMessage message) //This is the "UI entry point" and as such will handle the UI update by another thread
		{
			if (this.InvokeRequired)
			{
				MessageHandlerDelegate callback = new MessageHandlerDelegate(HandleMessage);
				this.Invoke(callback, new object[] { message });
			}
			else
			{
				UpdateUI(message);
			}
		}

		private void UpdateUI(IBMessage message)
		{
			// http://nlog-project.org/download/ Logging lib
			ShowMessageOnPanel("(UpdateUI) Message type: " + message.Type.ToString());

			//ListViewLogging.log_add(this, "brokerListBox", "Form1.cs ShowMessageOnPanel", message.Type.ToString(), "white");


			switch (message.Type)
			{
				case MessageType.ConnectionStatus:
					{
						ConnectionStatusMessage statusMessage = (ConnectionStatusMessage)message;
						if (statusMessage.IsConnected)
						{

							status_CT.Text = "Connected";
							button13.Text = "Disconnect";
						}
						else
						{
							status_CT.Text = "Disconnected...";
							button13.Text = "Connect";
						}
						break;
					}
				case MessageType.Error:
					{
						ErrorMessage error = (ErrorMessage)message;
						ShowMessageOnPanel("Request " + error.RequestId + ", Code: " + error.ErrorCode + " - " + error.Message);
						HandleErrorMessage(error);
						break;
					}
				case MessageType.TickOptionComputation:
				case MessageType.TickPrice:
				case MessageType.TickSize:
					{
						//HandleTickMessage((MarketDataMessage)message);
						break;
					}
				case MessageType.MarketDepth:
				case MessageType.MarketDepthL2:
					{
						//deepBookManager.UpdateUI(message);
						break;
					}
				case MessageType.HistoricalData:
				case MessageType.HistoricalDataEnd:
					{
						//historicalDataManager.UpdateUI(message);
						break;
					}
				case MessageType.RealTimeBars:
					{
						//realTimeBarManager.UpdateUI(message);
						break;
					}
				case MessageType.ScannerData:
				case MessageType.ScannerParameters:
					{
						//scannerManager.UpdateUI(message);
						break;
					}
				case MessageType.OpenOrder:
				case MessageType.OpenOrderEnd:
				case MessageType.OrderStatus:
				case MessageType.ExecutionData:
				case MessageType.CommissionsReport:
					{
						//orderManager.UpdateUI(message);
						placeOrder.UpdateUI(message);
						break;
					}
				case MessageType.ManagedAccounts:
					{
						MessageBox.Show("case MessageType.ManagedAccounts: no message");
						//orderManager.ManagedAccounts = ((ManagedAccountsMessage)message).ManagedAccounts;
						//accountManager.ManagedAccounts = ((ManagedAccountsMessage)message).ManagedAccounts;
						//exerciseAccount.Items.AddRange(((ManagedAccountsMessage)message).ManagedAccounts.ToArray());
						break;
					}
				case MessageType.AccountSummaryEnd:
					{
						//accSummaryRequest.Text = "Request";
						//accountManager.UpdateUI(message);
						break;
					}
				case MessageType.AccountDownloadEnd:
					{
						break;
					}
				case MessageType.AccountUpdateTime:
					{
						//accUpdatesLastUpdateValue.Text = ((UpdateAccountTimeMessage)message).Timestamp;
						break;
					}
				case MessageType.PortfolioValue:
					{
						//accountManager.UpdateUI(message);
						//if (exerciseAccount.SelectedItem != null)
						//	optionsManager.HandlePosition((UpdatePortfolioMessage)message);
						break;
					}
				case MessageType.AccountSummary:
				case MessageType.AccountValue:
				case MessageType.Position:
				case MessageType.PositionEnd:
					{
						//accountManager.UpdateUI(message);
						break;
					}
				case MessageType.ContractDataEnd:
					{
						//searchContractDetails.Enabled = true;
						//contractManager.UpdateUI(message);
						break;
					}
				case MessageType.ContractData:
					{
						HandleContractDataMessage((ContractDetailsMessage)message); // Type cast
						var z = (ContractDetailsMessage)message;
						ShowMessageOnPanel("SYMBOL: " + z.ContractDetails.Summary.Symbol + " successfully found at: " + z.ContractDetails.Summary.PrimaryExch + " exchange");
						break;
					}
				case MessageType.FundamentalData:
					{
						//fundamentalsQueryButton.Enabled = true;
						//contractManager.UpdateUI(message);
						break;
					}
				case MessageType.ReceiveFA:
					{
						//advisorManager.UpdateUI((AdvisorDataMessage)message);
						break;
					}
				case MessageType.PositionMulti:
				case MessageType.AccountUpdateMulti:
				case MessageType.PositionMultiEnd:
				case MessageType.AccountUpdateMultiEnd:
					{
						//acctPosMultiManager.UpdateUI(message);
						break;
					}

				case MessageType.SecurityDefinitionOptionParameter:
				case MessageType.SecurityDefinitionOptionParameterEnd:
					{
						//optionsManager.UpdateUI(message);
						break;
					}
				case MessageType.SoftDollarTiers:
					{
						//MessageBox.Show("SoftDollarTiers + orderManager.UpdateUI(message)");
						//orderManager.UpdateUI(message);
						placeOrder.UpdateUI(message);
						break;
					}

				default:
					{
						HandleMessage(new ErrorMessage(-1, -1, message.ToString()));
						break;
					}
			}
		}

		private void ShowMessageOnPanel(string message)
		{
			ListViewLogging.log_add(this, "brokerListBox", "Form1.cs ShowMessageOnPanel", message, "white");

			message = ensureMessageHasNewline(message);

			if (numberOfLinesInMessageBox >= MAX_LINES_IN_MESSAGE_BOX)
			{
				linesInMessageBox.RemoveRange(0, MAX_LINES_IN_MESSAGE_BOX - REDUCED_LINES_IN_MESSAGE_BOX);
				messageBox.Lines = linesInMessageBox.ToArray();
				numberOfLinesInMessageBox = REDUCED_LINES_IN_MESSAGE_BOX;
			}

			linesInMessageBox.Add(message);
			numberOfLinesInMessageBox += 1;

			this.messageBox.AppendText(message);

		}

		private string ensureMessageHasNewline(string message)
		{
			if (message.Substring(message.Length - 1) != "\n")
			{
				return message + "\n";
			}
			else
			{
				return message;
			}
		}

		private void HandleErrorMessage(ErrorMessage message)
		{

			if (message.RequestId > MarketDataManager.TICK_ID_BASE && message.RequestId < DeepBookManager.TICK_ID_BASE)
				MessageBox.Show("zzxxcc");
			//marketDataManager.NotifyError(message.RequestId);
			else if (message.RequestId > DeepBookManager.TICK_ID_BASE && message.RequestId < HistoricalDataManager.HISTORICAL_ID_BASE)
				MessageBox.Show("ccvc");
			//deepBookManager.NotifyError(message.RequestId);
			else if (message.RequestId == ContractManager.CONTRACT_DETAILS_ID)
			{
				//contractManager.HandleRequestError(message.RequestId);
				//searchContractDetails.Enabled = true;
			}
			else if (message.RequestId == ContractManager.FUNDAMENTALS_ID)
			{
				//contractManager.HandleRequestError(message.RequestId);
				//fundamentalsQueryButton.Enabled = true;
			}
			else if (message.RequestId == OptionsManager.OPTIONS_ID_BASE)
			{
				//optionsManager.Clear();
				//queryOptionChain.Enabled = true;
			}
			else if (message.RequestId > OptionsManager.OPTIONS_ID_BASE)
			{
				//queryOptionChain.Enabled = true;
			}
			if (message.ErrorCode == 202)
			{
				MessageBox.Show("Form1.cs; HandleErrorMessage; message.ErrorCode == 202");
			}
		}

		private double stringToDouble(string number)
		{
			if (number != null && !number.Equals(""))
				return Double.Parse(number);
			else
				return 0;
		}

		private void HandleContractDataMessage(ContractDetailsMessage message)
		{
			if (message.RequestId > ContractManager.CONTRACT_ID_BASE && message.RequestId < OptionsManager.OPTIONS_ID_BASE)
			{
				//contractManager.UpdateUI(message);
			}
			else if (message.RequestId >= OptionsManager.OPTIONS_ID_BASE)
			{
				//optionsManager.UpdateUI(message);
			}
		}

		public bool IsConnected // Connection flag
		{
			get { return isConnected; }
			set { isConnected = value; }
		}

		// Control events handlers. Button clicks etc.

		private void connect_Button(object sender, EventArgs e) // Connect button click
		{

			if (!IsConnected) // False on startup
			{
				ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "Connect button clicked", "white");

				int port;
				string host = "127.0.0.1";

				if (host == null || host.Equals(""))
					host = "127.0.0.1";
				try
				{
					port = 4002; // 7496 - TWS. 4002 - IB Gateway
					ibClient.ClientId = 1;
					ibClient.ClientSocket.eConnect(host, port, ibClient.ClientId); // Connection

					var reader = new EReader(ibClient.ClientSocket, signal); // Put the websocket stream to the reader variable

					reader.Start();

					new Thread(() => { while (ibClient.ClientSocket.IsConnected()) { signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();  // https://interactivebrokers.github.io/tws-api/connection.html#gsc.tab=0
				}
				catch (Exception)
				{
					ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "Please check your connection attributes", "white");
				}
			}
			else
			{
				IsConnected = false;
				ibClient.ClientSocket.eDisconnect();
				ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "Connect button clicked while connection establichet - disconnect", "white");
			}
		}

		private void search_Button(object sender, EventArgs e) // Search button click
		{
			contractSearch.SearchContract(textBox1.Text);
			contractSearch.SearchContract("AAPL");
		}

		private void button10_Click(object sender, EventArgs e) // Buy button click
		{
			//Contract contract = GetOrderContract();
			//Order order = GetOrder();
			//orderManager.PlaceOrder(contract, order);

			ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "placeOrder.SendOrder('buy')", "green");
			placeOrder.SendOrder("buy");

		}

		private void button11_Click(object sender, EventArgs e) // Sell button click
		{
			ListViewLogging.log_add(this, "parserListBox", "Form1.cs", "placeOrder.SendOrder('sell')", "red");
			placeOrder.SendOrder("sell");
		}

		private void label5_Click(object sender, EventArgs e)
		{
			listView2.Items.Clear();
			messageBox.Clear();
		}






		#endregion


	}
}
