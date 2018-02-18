using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Ole DB 
using oledb = System.Data.OleDb; // Short link

namespace DataGridDB
{
	public partial class Form1 : Form
	{

		private static string DBLocationPath = @"c:\1\";
		private static string DBFileName = "tfr_db_c.mdb";

		// Path to mdb file location. Source=.. means that we creat a DB file at the same location where exe is located
		public static oledb.OleDbConnection connect = new oledb.OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + DBLocationPath + DBFileName);


		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (TFR_cons.DataBase.connect.State == System.Data.ConnectionState.Closed) // If no connection to DB
			{

				try
				{
					connect.Open(); // DB connect
					MessageBox.Show("Connection to DB established");

					OleDbCommand command = new OleDbCommand();
					command.Connection = connect;
					string query = "select * from tfr_account_statement";
					command.CommandText = query;

					OleDbDataAdapter da = new OleDbDataAdapter(command);
					DataTable dt = new DataTable();
					da.Fill(dt);
					dataGridView1.DataSource = dt;

					connect.Close();
				}

				catch (Exception err)
				{
					MessageBox.Show("DB Error: " + err);
				}

			}

		}
	}
}
