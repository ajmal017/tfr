using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;

namespace Mail
{
	class Program
	{
		static void Main(string[] args)
		{

		
			// Command line argument must the the SMTP host.
			SmtpClient client = new SmtpClient();
			client.Port = 455;
			client.Host = "smtp.yandex.ru";
			client.EnableSsl = true;
			client.Timeout = 10000;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential("nextbb@yandex.ru", "baxgdl_123_!");

			MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
			mm.BodyEncoding = UTF8Encoding.UTF8;
			mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

			client.Send(mm);



		}
	}
}
