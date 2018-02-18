using System;
using System.Drawing;
using System.Windows.Forms;

namespace TFR_form_app
{
	class ListViewLogging
	{
		//public static void log_add(Form1 form, string log_source, string log_message, System.Drawing.Color color) // метод добавления записи в окно логов
		public static void log_add(Form1 form, string log_source, string log_message, string color) // метод добавления записи в окно логов
		{
			DateTime time = DateTime.Now; // создали переменную для времени

			form.BeginInvoke(new Action(delegate()
			{
				form.listView1.Items.Add(time.ToString("HH: mm.ss")); // "HH: mm.ss" - шаблон вывода формата времени и даты
				form.listView1.Items[form.listView1.Items.Count - 1].SubItems.Add(log_source);
				form.listView1.Items[form.listView1.Items.Count - 1].SubItems.Add(log_message);
				form.listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); // авто сайз колонки по ее содержимому
				form.listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent); // авто сайз колонки по ее содержимому


				switch (color) // расскарска строчек разными цветами
				{
					case "white":
						form.listView1.Items[form.listView1.Items.Count - 1].BackColor = Color.White;
						break;

					case "green":
						form.listView1.Items[form.listView1.Items.Count - 1].BackColor = Color.Chartreuse;
						break;

					case "yellow":
						form.listView1.Items[form.listView1.Items.Count - 1].BackColor = Color.Yellow;
						break;

					case "red":
						form.listView1.Items[form.listView1.Items.Count - 1].BackColor = Color.Red;
						break;
				}


				form.listView1.EnsureVisible(form.listView1.Items.Count - 1); // авто скрол


				if (form.listView1.Items.Count.ToString() == "100") // подрезка количества записаей
				{
					form.listView1.Items.RemoveAt(0);
				}

			})); // Invoke

		}
	}
}
