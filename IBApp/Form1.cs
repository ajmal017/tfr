using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using IBSampleApp.messages; // Linked namespaces from IB Sample app
using IBApi; // https://interactivebrokers.github.io/tws-api/interfaceIBApi_1_1EWrapper.html#ae9114b5146bb8f32796f9b9d21569d7c 
using IBSampleApp.ui;
using IBSampleApp.types;
using System.Threading;
using IBSampleApp;



namespace IBApp
{
	public partial class Form1 : Form
	{
		// Variables declaration 
		delegate void MessageHandlerDelegate(IBMessage message); // Delegate for mesage handling
		protected IBClient ibClient; // Realises interface EWrapper
		private EReaderMonitorSignal signal = new EReaderMonitorSignal(); // Signal for web socket connection
		private ContractManager contractManager; // The class which descrbes a contract details

		private IBAppClasses.ContractSearch contractSearch; // Contract search class

		private const int MAX_LINES_IN_MESSAGE_BOX = 200; // Variables for message windows
		private const int REDUCED_LINES_IN_MESSAGE_BOX = 100;
		private int numberOfLinesInMessageBox = 0;
		private List<string> linesInMessageBox = new List<string>(MAX_LINES_IN_MESSAGE_BOX);

		private bool isConnected = false;

		// Order
		public IBApp.IBAppClasses.PlaceOrder placeOrder; // PlaceOrder class variable

		// Linking system events and handlers
		public Form1()
		{
			InitializeComponent(); // Form components init

			// Instances
			ibClient = new IBClient(signal);
			contractManager = new ContractManager(ibClient, fundamentalsOutput, contractDetailsGrid);
			contractSearch = new IBAppClasses.ContractSearch(ibClient);

			// Events
			ibClient.Error += ibClient_Error;
			ibClient.NextValidId += ibClient_NextValidId; // For log messages
			ibClient.ContractDetails += (reqId, contractDetails) => HandleMessage(new ContractDetailsMessage(reqId, contractDetails)); //  Request contract details https://interactivebrokers.github.io/tws-api/contract_details.html#gsc.tab=0
			ibClient.ConnectionClosed += ibClient_ConnectionClosed; // Update UI when disconnect button is clicked

			// Order
			placeOrder = new IBAppClasses.PlaceOrder(ibClient); // New instance

		}
		


		// ibClient events handlers

		void ibClient_NextValidId(int orderId)
		{
			IsConnected = true;
			HandleMessage(new ConnectionStatusMessage(true));

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
			// http://nlog-project.org/download/ A logging lib
			ShowMessageOnPanel("(UpdateUI) Message type: " + message.Type.ToString());
			
			switch (message.Type)
			{
				case MessageType.ConnectionStatus:
					{
						ConnectionStatusMessage statusMessage = (ConnectionStatusMessage)message;
						if (statusMessage.IsConnected)
						{
							
							status_CT.Text = "Connected! Your client Id: " + ibClient.ClientId;
							button1.Text = "Disconnect";
						}
						else
						{
							status_CT.Text = "Disconnected...";
							button1.Text = "Connect";
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
						break;
					}
				case MessageType.ManagedAccounts:
					{
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
						contractManager.UpdateUI(message);
						break;
					}
				case MessageType.ContractData:
					{
						HandleContractDataMessage((ContractDetailsMessage)message); // ***********************
						var z = (ContractDetailsMessage)message;
						ShowMessageOnPanel("SYMBOL: " + z.ContractDetails.Summary.Symbol + " successfully found at: " + z.ContractDetails.Summary.PrimaryExch + " exchange");
						break;
					}
				case MessageType.FundamentalData:
					{
						//fundamentalsQueryButton.Enabled = true;
						contractManager.UpdateUI(message);
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
						//orderManager.UpdateUI(message);
						break;
					}
				default:
					{
						HandleMessage(new ErrorMessage(-1, -1, message.ToString())); // Default message
						break;
					}
			}
		}

		private void ShowMessageOnPanel(string message)
		{
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
				MessageBox.Show("fzzx");
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
			}
		}

		private Contract GetConDetContract() // The form which contains contrac details
		{
			Contract contract = new Contract(); // New instance of contract class
			contract.Symbol = this.conDetSymbol.Text;
			contract.SecType = this.conDetSecType.Text;
			contract.Exchange = this.conDetExchange.Text;
			contract.Currency = this.conDetCurrency.Text;
			contract.LastTradeDateOrContractMonth = this.conDetLastTradeDateOrContractMonth.Text;
			contract.Strike = stringToDouble(this.conDetStrike.Text);
			contract.Multiplier = this.conDetMultiplier.Text;
			contract.LocalSymbol = this.conDetLocalSymbol.Text;

			if (!conDetRight.Text.Equals("") && !conDetRight.Text.Equals("None"))
				contract.Right = (string)((IBType)conDetRight.SelectedItem).Value;

			return contract;
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
				contractManager.UpdateUI(message);
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

		private void button1_Click(object sender, EventArgs e) // Connect button click
		{

			if (!IsConnected) // False on startup
			{
				HandleMessage(new ErrorMessage(0, 0, "Connect button clicked"));

				int port;
				string host = this.host_CT.Text;

				if (host == null || host.Equals(""))
					host = "127.0.0.1";
				try
				{
					port = Int32.Parse(this.port_CT.Text);
					ibClient.ClientId = Int32.Parse(this.clientid_CT.Text);
					ibClient.ClientSocket.eConnect(host, port, ibClient.ClientId); // Connection

					var reader = new EReader(ibClient.ClientSocket, signal); // Put the websocket stream to the reader variable

					reader.Start();

					new Thread(() => { while (ibClient.ClientSocket.IsConnected()) { signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();  // https://interactivebrokers.github.io/tws-api/connection.html#gsc.tab=0
				}
				catch (Exception)
				{
					HandleMessage(new ErrorMessage(-1, -1, "Please check your connection attributes."));
				}
			}
			else
			{
				IsConnected = false;
				ibClient.ClientSocket.eDisconnect();
				HandleMessage(new ErrorMessage(0, 0, "Connect button clicked while connection establichet - disconnect"));
			}
		}

		private void button2_Click(object sender, EventArgs e)  // Send message button to the log window (TEST)
		{
			HandleMessage(new ErrorMessage(-1, -1, "Please check your connection attributes."));
		}


		private void searchContractDetails_Click_1(object sender, EventArgs e)// Search contract button click
		{
			HandleMessage(new ErrorMessage(0, 0, "Search button clicked. searchContractDetails_Click_1"));
			//ShowTab(contractInfoTab, contractDetailsPage);
			Contract contract = GetConDetContract();
			//searchContractDetails.Enabled = false;
			contractManager.RequestContractDetails(contract);
		}

		private void button3_Click(object sender, EventArgs e) // Test contract button click
		{
			//Contract contract = GetConDetContract();
			//searchContractDetails.Enabled = false;
			//contractManager.RequestContractDetails(contract); // Call method from ContactManager class

			// I've tried the code below
			//ibClient.ClientSocket.reqContractDetails(60000000, contract); // This method will provide all the contracts matching the contract provided https://interactivebrokers.github.io/tws-api/classIBApi_1_1EClient.html#ade440c6db838b548594981d800ea5ca9

			
			contractSearch.SearchContract("AAPL");

		}

		private void button4_Click(object sender, EventArgs e) // Buy button click
		{
			placeOrder.SendOrder("buy", "PHOT");

		}
	}
}
