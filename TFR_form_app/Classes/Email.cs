using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using MailKit.Net.Smtp; // Smtp https://github.com/jstedfast/MailKit 
using MailKit;
using MimeKit;

namespace TFR_form_app
{
	class Email
	{

		public static void Send(string emailBody) {

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Boris B", "nextbb@yandex.ru"));
			message.To.Add(new MailboxAddress("Boris", "nextbb@yandex.ru"));
			message.To.Add(new MailboxAddress("Hunter", "hunterhpm@gmail.com"));

			message.Subject = "TFR BOT Message";

			message.Body = new TextPart("plain")
			{
				Text = emailBody
			};

			using (var client = new SmtpClient())
			{
				// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;

				client.Connect("smtp.yandex.ru", 25, false);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate("nextbb", "baxgdl_123_!");

				client.Send(message);
				client.Disconnect(true);
			}
		}

	}
}
