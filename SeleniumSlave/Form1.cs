using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SeleniumSlave
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e) // Add bought
		{
			//int MessagesOnThePage = TFR_cons.Program.ChromeDriver.FindElementsByClassName("GLS-JUXDKAD").Count;
			int MessagesOnThePage = TFR_cons.CountMessages.Count();
			MessageBox.Show("Elements found: " + MessagesOnThePage);
		}
	}
}
