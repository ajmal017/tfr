using System;
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;

namespace Anticaptcha_example
{
    public class Program
    {
        private static void Main()
        {
            ExampleGetBalance();
            //ExampleImageToText();
            ExampleNoCaptchaProxyless();
            //ExampleNoCaptcha();


            Console.ReadKey();
        }

        public static void ExampleGetBalance()
        {
            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "9ec539ed2708163fedbceb896bb1ba5f"
			};

            var balance = api.GetBalance();

            if (balance == null)
            {
                DebugHelper.Out("GetBalance() failed. " + api.ErrorMessage ?? "", DebugHelper.Type.Error);
            }
            else
            {
                DebugHelper.Out("Balance: " + balance, DebugHelper.Type.Success);
            }
        }

        private static void ExampleImageToText()
        {
            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "1234567890123456789012",
                FilePath = "captcha.jpg"
            };

            if (!api.CreateTask())
            {
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage ?? "", DebugHelper.Type.Error);
            }
            else if (!api.WaitForResult())
            {
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            }
            else
            {
                DebugHelper.Out("Result: " + api.GetTaskSolution(), DebugHelper.Type.Success);
            }
        }

		//public static void ExampleNoCaptchaProxyless()
		public static string ExampleNoCaptchaProxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new NoCaptchaProxyless
            {
                ClientKey = "9ec539ed2708163fedbceb896bb1ba5f",
                WebsiteUrl = new Uri("https://profit.ly/login"),
                WebsiteKey = "6LcZXwkTAAAAAGa2Gk8w1CcQQzL2zyVs7p_bEvyC"
			};

            if (!api.CreateTask())
            {
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
				System.Threading.Thread.Sleep(5000); // Wait 5 sec
				ExampleNoCaptchaProxyless(); // If error - call itself again. Reason: no idle worker availible. Endless cycle
				
				return "0";
			}
            else if (!api.WaitForResult())
            {
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
				return "1";
            }
            else
            {
                //DebugHelper.Out("Result: " + api.GetTaskSolution(), DebugHelper.Type.Success);
				return api.GetTaskSolution();
            }
        }

        private static void ExampleNoCaptcha()
        {
            DebugHelper.VerboseMode = true;

            var api = new NoCaptcha
            {
                ClientKey = "1234567890123456789012",
                WebsiteUrl = new Uri("http://http.myjino.ru/recaptcha/test-get.php"),
                WebsiteKey = "6Lc_aCMTAAAAABx7u2W0WPXnVbI_v6ZdbM6rYf16",
                UserAgent =
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
                // proxy access parameters
                ProxyType = NoCaptcha.ProxyTypeOption.Http,
                ProxyAddress = "xx.xx.xx.xx",
                ProxyPort = 8282,
                ProxyLogin = "123",
                ProxyPassword = "456"
            };


            if (!api.CreateTask())
            {
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            }
            else if (!api.WaitForResult())
            {
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            }
            else
            {
                DebugHelper.Out("Result: " + api.GetTaskSolution(), DebugHelper.Type.Success);
            }
        }
    }
}