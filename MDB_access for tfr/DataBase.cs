using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; // Ole DB 
using oledb = System.Data.OleDb; // Short link
using ADOX; // In reference explorer add  Microsoft ADO Ext. 2.7 for DDL and Security
using System.IO; // For file existance check



namespace TFR_cons // MDB_access 
{
	public static class DataBase
	{
	
		private static string DBLocationPath = @"c:\1\"; // @ is needed for using \ in the path
		private static string DBFileName = "tfr_db_c.mdb";

		// Path to mdb file location. Source=.. means that we creat a DB file at the same location where exe is located
		public static oledb.OleDbConnection connect = new oledb.OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + DBLocationPath + DBFileName);

		// Create DB method
		public static void DBCreate()
		{

			if (File.Exists(DBFileName))
				Console.WriteLine("BD file is already exists. No need to create ");
			else
			{
				Console.WriteLine("DB file does not exist. Creating a DB file");

				ADOX.Catalog cat = new ADOX.Catalog();
				try
				{
					// Name and source of MDB file
					cat.Create("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + DBLocationPath + DBFileName); // Source=D:\\db_graph.mdb or other location
					Console.WriteLine("BDCreate succeeded! ");
				}

				catch (System.Runtime.InteropServices.COMException Ex)
				{
					Console.WriteLine("BDCreate error: " + Ex);
					cat = null;
				}

				DBConnect();
				DBStructCreate();
			}
		}

		// DB Structure creation method 
		public static void DBStructCreate()
		{

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			int z = 1; // Query counter
			string[] SqlQuery = new string[] // Sql query array
				{
				"CREATE TABLE [tfr_account_statement] ([id] counter, [stock_ticker] string, [trade_status] string, [trade_direction] string, [trade_opend_date] date, [trade_open_price] double, [trade_closed_date] date, [stock_quantity] int, [trade_close_price] double, [profit_per_stock] double, [profit_per_quantity] double, [account_balance] double, [trade_profit_prcnt] double, [accumulated_sum_prcnt] string, [open_message] string, [close_message] string)"
				};

			foreach (string i in SqlQuery)
			{
				Console.WriteLine("DB create structure. Query №: " + z);
				var command = new oledb.OleDbCommand(i, connect);
				try
				{
					command.ExecuteNonQuery(); // Execute query
					Console.WriteLine("DB create structure. Table created! ");
				}

				catch (Exception err)
				{
					Console.WriteLine("DB create structure. Table is not created! " + err);
				}

				z++; // Increase counter

			}

		}

		// DB connection method
		public static void DBConnect() 
		{
			try
			{
				connect.Open(); // DB connect
				Console.WriteLine("Connection to DB established");
			}

			catch (Exception err)
			{
				Console.WriteLine("Error connectiong to DB!" + err);
			}

		}

		public static void DBInserRecord(string table_name, string ticker, DateTime z, double price)
		{

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("INSERT INTO ["+ table_name +"] (ticker, tick_time, price) VALUES ('" + ticker + "','" + DateTime.Now+"','" + price + "')");

			command.Connection = connect;
			
			try // выполнение комманды sql
			{
				command.ExecuteNonQuery(); // выпняем запрос
				//Console.WriteLine("Insert record to BD successful");
			}

			catch (Exception err)
			{
				Console.WriteLine("Insert record to DB error. " + err);
			}

		}


		public static void DBInsertStartingBalance(double starting_balance)
		{

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("INSERT INTO [tfr_account_statement] (account_balance, accumulated_sum_prcnt) VALUES ('" + starting_balance + "', 0)");
			command.Connection = connect;
			
			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Starting balance added to DB successfully");	
				//Properties.Settings.Default.dbCreated = true;
				//TFR_cons.Properties.Settings.Default.dbCreated = true;
			}
			catch (Exception err)
			{ Console.WriteLine("Insert record to DB error. " + err); }

		}


		// Update last record in DB. Insert close position info 
		public static void UpdateRecordClosePosition(DateTime trade_closed_date, int stock_quantity, double trade_close_price, string close_message) 
		{
			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET trade_status = 'close', trade_closed_date = '" + trade_closed_date + "', stock_quantity = '" + stock_quantity + "', trade_close_price = '" + trade_close_price + "', close_message = '" + close_message + "' WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. Add close position info");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. Add close position info " + err); }
		}


		// Update last record in DB. Insert open position info 
		public static void UpdateRecordOpenPosition(string trade_status, string trade_direction, DateTime trade_opend_date, double trade_open_price, double profit_per_stock, double profit_per_quantity, double account_balance, double trade_profit_prcnt, double accumulated_sum_prcnt, string open_message)
		{
			// trade_opend_date	 trade_open_price  profit_per_stock  	profit_per_quantity 	account_balance 	trade_profit_prcnt  	accumulated_sum_prcnt   	open_message

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET trade_status = '" + trade_status + "', trade_direction = '" + trade_direction + "', trade_opend_date = '" + trade_opend_date + "', trade_open_price = '" + trade_open_price + "', profit_per_stock = '" + profit_per_stock + "', trade_profit_prcnt = '" + trade_profit_prcnt + "', accumulated_sum_prcnt = '" + accumulated_sum_prcnt + "', open_message = '" + open_message + "'   WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. Add open position info");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. Add open position info " + err); }

		}




		public static void UpdateProfit() // Updates last record in DB. Calculates position profit, accumulated profit etc. Done in few queries
		{
	
			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			// Get the value of account_balance from the previous record using nested query
			var command1 = new oledb.OleDbCommand("SELECT account_balance FROM [tfr_account_statement] WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement]) - 1"); 
			command1.Connection = connect;

			try // Run sql command
			{
				command1.ExecuteNonQuery();
				Console.WriteLine("get previous record. " + Convert.ToDouble(command1.ExecuteScalar()));
			}
			catch (Exception err)
			{ Console.WriteLine("Error while getting previous record " + err); }



			// profit_per_stock, profit_per_quantity
			var command2 = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET profit_per_stock = trade_close_price - trade_open_price, profit_per_quantity = (trade_close_price - trade_open_price) * stock_quantity WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command2.Connection = connect;

			try // Run sql command
			{
				command2.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. Calculate frofit 1st query");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. Calculate profit 1st query " + err); }




			// account_balance = Previous account_balance + profit_per_quantity 
			var command3 = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET account_balance = '" + Convert.ToDouble(command1.ExecuteScalar()) + "' + profit_per_quantity WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command3.Connection = connect;

			try // Run sql command
			{
				command3.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. Calculate profit 2nd query");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. Calculate profit 2nd query " + err); }



			// Update trade_profit_prcnt
			var command4 = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET trade_profit_prcnt = 100 * profit_per_quantity / (stock_quantity * trade_open_price) WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command4.Connection = connect;

			try // Run sql command
			{
				command4.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. Calculate profit 3rd query");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. Calculate profit 3rd query " + err); }



			// Get the value of accumulated_sum_prcnt from the previous record then it will be used in a second query
			var command5 = new oledb.OleDbCommand("SELECT accumulated_sum_prcnt FROM [tfr_account_statement] WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement]) - 1");
			command5.Connection = connect;
			try // Run sql command
			{
				command5.ExecuteNonQuery();
				Console.WriteLine("Get the value of accumulated_sum_prcnt from the previous record. " + Convert.ToDouble(command5.ExecuteScalar()));
			}
			catch (Exception err)
			{ Console.WriteLine("Error while getting the value of accumulated_sum_prcnt from the previous record " + err); }



			// accumulated_sum_prcnt = Previous accumulated_sum_prcnt + trade_profit_prcnt
			var command6 = new oledb.OleDbCommand("UPDATE [tfr_account_statement] SET accumulated_sum_prcnt = '" + Convert.ToDouble(command5.ExecuteScalar()) + "' + trade_profit_prcnt WHERE [id] = (SELECT COUNT (*) FROM [tfr_account_statement])");
			command6.Connection = connect;

			try // Run sql command
			{
				command6.ExecuteNonQuery();
				Console.WriteLine("Update record in DB. accumulated_sum_prcnt query");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while updating record. accumulated_sum_prcnt query " + err); }

		}







		public static void InsertTicker(string stock_ticker)// Add only ticker to a table. Then open and close position info will be inserted into the same row
		{
			// stock_ticker	trade_status	trade_direction trade_closed_date	stock_quantity	trade_close_price close_message

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("INSERT INTO [tfr_account_statement] (stock_ticker) VALUES ('" + stock_ticker + "')");
			//var command = new oledb.OleDbCommand("INSERT INTO [tfr_account_statement] (account_balance) VALUES (0)");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Ticker added to DB");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while adding ticker info to DB. " + err); }

		}

		public static void DBaddClosePosition(string stock_ticker, string trade_status, string trade_direction, DateTime trade_closed_date, int stock_quantity, double trade_close_price, string close_message) // Add info about closed position 
		{
			// stock_ticker	trade_status	trade_direction trade_closed_date	stock_quantity	trade_close_price close_message

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("INSERT INTO [tfr_account_statement] (stock_ticker, trade_status, trade_direction, trade_closed_date, stock_quantity, trade_close_price, close_message) VALUES ('" + stock_ticker + "','" + trade_status + "','" + trade_direction + "','" + trade_closed_date + "','" + stock_quantity + "','" + trade_close_price + "','" + close_message + "')");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Closed position info added to DB");
				//Properties.Settings.Default.dbCreated = true;
				//TFR_cons.Properties.Settings.Default.dbCreated = true;
			}
			catch (Exception err)
			{ Console.WriteLine("Error while adding closed position info to DB. " + err); }

		}


		//var command2 = new oledb.OleDbCommand("UPDATE [trades_table] SET date_out = '" + tick_time + "', price_out_bidask = '" + price_out_bidask + "', comment = '" + comment + "' WHERE [number]= (SELECT COUNT (*) FROM [trades_table])"); //работает. в последних круглых скобках вычисляем кол-во записей в таблице при помощи еще одного запроса, что бы не городить дополнительных переменных

		public static void DBaddOpenPosition(string stock_ticker, string trade_status, string trade_direction, DateTime trade_closed_date, int stock_quantity, double trade_close_price, string close_message) // Add info about closed position 
		{
			// stock_ticker	trade_status	trade_direction trade_closed_date	stock_quantity	trade_close_price close_message

			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			var command = new oledb.OleDbCommand("INSERT INTO [tfr_account_statement] (stock_ticker, trade_status, trade_direction, trade_closed_date, stock_quantity, trade_close_price, close_message) VALUES ('" + stock_ticker + "','" + trade_status + "','" + trade_direction + "','" + trade_closed_date + "','" + stock_quantity + "','" + trade_close_price + "','" + close_message + "')");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Closed position info added to DB");
				//Properties.Settings.Default.dbCreated = true;
				//TFR_cons.Properties.Settings.Default.dbCreated = true;
			}
			catch (Exception err)
			{ Console.WriteLine("Error while adding closed position info to DB. " + err); }

		}


		public static void DropDB() // Drop DB NOT WORKING! 
		{
			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			// INSERT INTO ["+ table_name +"]
			var command = new oledb.OleDbCommand("DROP DATABASE [tfr_db]");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("DB droped successfully");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while droping DB: " + err); }
		}


		public static void DropTable() // Drop table 
		{
			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("No DB connection! Connecting");
				DBConnect();
			}

			// INSERT INTO ["+ table_name +"]
			var command = new oledb.OleDbCommand("DROP TABLE tfr_account_statement");
			command.Connection = connect;

			try // Run sql command
			{
				command.ExecuteNonQuery();
				Console.WriteLine("Table droped successfully");
			}
			catch (Exception err)
			{ Console.WriteLine("Error while droping Table: " + err); }
		}


		public static void DBReadTable()
		{
			if (connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{
				Console.WriteLine("DBReadTable(). No DB connection! Connecting");
				DBConnect();
			}

			string[] SqlQuery = new string[] // Sql query array
			{
				"SELECT id, ticker, tick_time, price FROM stock_ticks",
				"SELECT number, ticker, tick_time, price FROM futures_ticks"
			};

			
			for(int z = 0; z <=1; z++) // Run cycle two times for stock and future tables
			{

				//string queryString = "SELECT id, ticker, tick_time, price FROM stock_ticks";
				
				var command = new oledb.OleDbCommand(SqlQuery[z], connect);

				OleDbDataReader reader;
				reader = command.ExecuteReader();

				
				int i = 0;
				while (reader.Read() && (i < 40)) // Always call Read before accessing data
				{
					//double zz = Convert.ToDouble(reader.GetString(3)) + 100;
					if (z == 0) // stock_ticks has price in string format by the misstake
					{
						//Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetDateTime(2) + " " + reader.GetString(3));
						ArraySync.list1.Add(reader.GetDateTime(2));
					}
					else // futures_ticks has price in double
					{
						//Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetDateTime(2) + " " + reader.GetDouble(3));
						ArraySync.list2.Add(reader.GetDateTime(2));
					}
					i++;
				}
				Console.WriteLine("***************************");
				reader.Close(); // Always call Close when done reading
				
				
			}

		}


	}

}
