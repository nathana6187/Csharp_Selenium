using Selenium.core.browsers;
using System;

namespace Selenium.pages
{
	public class RegisterPage : BasePage
	{
		public RegisterPage(IBrowser browser, string url = "") : base(browser, url)
		{}

		public void CreateSomething()
		{
			Console.WriteLine("Creating an account");
		}
	}
}