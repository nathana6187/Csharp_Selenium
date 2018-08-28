using Selenium.core.browsers;
using System;

namespace Selenium.pages
{
	public class HomePage : BasePage
	{
		public HomePage(IBrowser browser, string url = "") : base(browser, url)
		{}

		public RegisterPage Register()
		{
			Console.WriteLine("Navigating to Register page");
			Driver.Page.GoToUrl("http://www.google.com");
			return new RegisterPage(Driver, Url);
		}

		public RegisterPage OpenYahooPage()
		{
			Console.WriteLine("Navigating to Yahoo page");
			Driver.Page.GoToUrl("http://www.yahoo.com");
			return new RegisterPage(Driver, Url);
		}

		public RegisterPage OpenGooglePage()
		{
			Console.WriteLine("Navigating to Google page");
			Driver.Page.GoToUrl("http://www.google.com");
			return new RegisterPage(Driver, Url);
		}

		public RegisterPage OpenGithubPage()
		{
			Console.WriteLine("Navigating to Github page");
			Driver.Page.GoToUrl("http://www.github.com");
			return new RegisterPage(Driver, Url);
		}
	}
}