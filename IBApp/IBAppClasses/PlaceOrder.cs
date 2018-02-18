using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IBSampleApp;
using IBApi;

using IBSampleApp.messages; // For using class from IBSampleApp: OpenOrderMessage etc.

namespace IBApp.IBAppClasses
{
	public class PlaceOrder
	{
		// Variables declaration 
		private IBClient ibClient;
		private Contract contract;
		private Order order;

		public PlaceOrder(IBClient ibClient) // Constructor
		{
		
			this.ibClient = ibClient;

			contract = new Contract(); // New instance of the contract class
			contract.Symbol = "AAPL";
			contract.SecType = "STK";
			contract.Exchange = "SMART";
			contract.Currency = "USD";
			//contract.LastTradeDateOrContractMonth = this.conDetLastTradeDateOrContractMonth.Text;
			contract.Strike = 10;
			//contract.Multiplier = this.conDetMultiplier.Text;
			contract.LocalSymbol = "";


			order = new Order();

			//if (orderId != 0)
				order.OrderId = 1;
			//order.Action = "BUY"; // BUY
			order.OrderType = "MKT"; // MARKET
			//if (!lmtPrice.Text.Equals(""))
				//order.LmtPrice = Double.Parse(lmtPrice.Text); // Limit price
			//if (!quantity.Text.Equals(""))
				order.TotalQuantity = 1; // QUANTITY
			//order.Account = account.Text;
			//order.ModelCode = modelCode.Text;
			//order.Tif = timeInForce.Text; // TIME IN FORCE DAY
			//if (!auxPrice.Text.Equals(""))
				//order.AuxPrice = Double.Parse(auxPrice.Text);
			//if (!displaySize.Text.Equals(""))
				//order.DisplaySize = Int32.Parse(displaySize.Text);
		}

		public void SendOrder(string orderDirection)
		{
			Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; // Unix time in milleseconds is used as an order id
		
			if (orderDirection == "buy") {
				//MessageBox.Show("buy order received");
				order.Action = "BUY"; // BUY
				ibClient.ClientSocket.placeOrder(unixTimestamp, contract, order);
			}

			if (orderDirection == "sell")
			{
				//MessageBox.Show("sell order received");
				order.Action = "SELL"; // BUY
				ibClient.ClientSocket.placeOrder(unixTimestamp, contract, order);
			}
		}

		public void UpdateUI(IBMessage message)
		{
			switch (message.Type)
			{
				case MessageType.OpenOrder:
					handleOpenOrder((OpenOrderMessage)message);
					break;
				case MessageType.OpenOrderEnd:
					break;
				case MessageType.OrderStatus:
					handleOrderStatus((OrderStatusMessage)message);
					break;
				case MessageType.ExecutionData:
					HandleExecutionMessage((ExecutionMessage)message);
					break;
				case MessageType.CommissionsReport:
					HandleCommissionMessage((CommissionMessage)message);
					break;
				case MessageType.SoftDollarTiers:
					HandleSoftDollarTiers(message);
					break;
			}
		}

		private void handleOpenOrder(OpenOrderMessage openOrder)
		{
			/*
			if (openOrder.Order.WhatIf)
				//orderDialog.HandleIncomingMessage(openOrder);
				MessageBox.Show("openOrder.Order.WhatIf: " + openOrder.ToString());
			else
			{
				//UpdateLiveOrders(openOrder);
				//UpdateLiveOrdersGrid(openOrder);
				MessageBox.Show("ELSE. openOrder.Order.WhatIf: " + openOrder.ToString());
			}
			*/
		}

		private void handleOrderStatus(OrderStatusMessage statusMessage)
		{
			//MessageBox.Show("handleOrderStatus: " + statusMessage);
			/*
			for (int i = 0; i < liveOrdersGrid.Rows.Count; i++)
			{
				if (liveOrdersGrid[0, i].Value.Equals(statusMessage.PermId))
				{
					liveOrdersGrid[8, i].Value = statusMessage.Status;
					return;
				}
			}
			*/
		}

		private void HandleExecutionMessage(ExecutionMessage message)
		{
			//MessageBox.Show("handleOrderStatus: " + message);
			/*
			for (int i = 0; i < tradeLogGrid.Rows.Count; i++)
			{
				if (((string)tradeLogGrid[0, i].Value).Equals(message.Execution.ExecId))
				{
					PopulateTradeLog(i, message);
				}
			}
			tradeLogGrid.Rows.Add(1);
			PopulateTradeLog(tradeLogGrid.Rows.Count - 1, message);
			*/

			// Execution results. WORKS GOOD!
			MessageBox.Show("private void HandleExecutionMessage(ExecutionMessage message): " + message.Execution.OrderId + " orderRef: " + message.Execution.OrderRef + " price: " + message.Execution.Price + " time: " + message.Execution.Time + " accountNumber" + message.Execution.AcctNumber); 

		}

		private void HandleCommissionMessage(CommissionMessage message)
		{
			//MessageBox.Show("private void HandleCommissionMessage(CommissionMessage message): " + message);
			/*
			for (int i = 0; i < tradeLogGrid.Rows.Count; i++)
			{
				if (((string)tradeLogGrid[0, i].Value).Equals(message.CommissionReport.ExecId))
				{
					tradeLogGrid[8, i].Value = message.CommissionReport.Commission;
					tradeLogGrid[9, i].Value = message.CommissionReport.RealizedPNL;
				}
			}
			*/

			var z = (CommissionMessage)message;
			//MessageBox.Show("private void HandleCommissionMessage(CommissionMessage message): " + z.CommissionReport.Commission);

		}

		private void HandleSoftDollarTiers(IBMessage softDollarTiersMessage)
		{
			//orderDialog.HandleIncomingMessage(softDollarTiersMessage);

			var z = (ContractDetailsMessage)softDollarTiersMessage;
			//MessageBox.Show("private void HandleSoftDollarTiers(IBMessage softDollarTiersMessage): " + z.ContractDetails.Summary.Symbol + " successfully found at: " + z.ContractDetails.Summary.PrimaryExch + " exchange");
			
		}


	}
}
