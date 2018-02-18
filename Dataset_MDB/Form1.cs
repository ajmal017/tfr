using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataset_MDB
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'tfr_dbDataSet1.tfr_account_statement' table. You can move, or remove it, as needed.
			this.tfr_account_statementTableAdapter.Fill(this.tfr_dbDataSet1.tfr_account_statement);

		}

		private void tfr_account_statementBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.tfr_account_statementBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.tfr_dbDataSet1);

			// added this line. data load
			this.tfr_account_statementTableAdapter.Fill(this.tfr_dbDataSet1.tfr_account_statement);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.tfr_account_statementTableAdapter.Fill(this.tfr_dbDataSet1.tfr_account_statement);
		}

		private void tfr_account_statementBindingNavigator_RefreshItems(object sender, EventArgs e)
		{

		}
	}
}
