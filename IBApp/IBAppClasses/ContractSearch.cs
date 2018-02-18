using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBSampleApp;
using IBSampleApp.types;
using IBApi;


namespace IBApp.IBAppClasses
{
	public class ContractSearch
	{
		// Variables
		private IBClient ibClient;
		public const int CONTRACT_ID_BASE = 60000000;
		public const int CONTRACT_DETAILS_ID = CONTRACT_ID_BASE + 1; // The unique request identifier

		private Contract contract;

		public ContractSearch(IBClient ibClient) // Class constructor. Takes only ibClient instance into the constructor
		{
			IbClient = ibClient;

			contract = new Contract(); // New instance of the contract class

			//contract.Symbol = "AAPL";
			contract.SecType = "STK";
			contract.Exchange = "SMART";
			contract.Currency = "USD";
			//contract.LastTradeDateOrContractMonth = this.conDetLastTradeDateOrContractMonth.Text;
			contract.Strike = 10;
			//contract.Multiplier = this.conDetMultiplier.Text;
			contract.LocalSymbol = "";

		}

		public void SearchContract(string contractName) // Only the name of the contract is required for the search
		{
			contract.Symbol = contractName; // AAPL
			ibClient.ClientSocket.reqContractDetails(CONTRACT_DETAILS_ID, contract); // https://interactivebrokers.github.io/tws-api/classIBApi_1_1EClient.html#ade440c6db838b548594981d800ea5ca9

		}


		public IBClient IbClient // Getter and setter
		{
			get { return ibClient; }
			set { ibClient = value; }
		}
	}
}
