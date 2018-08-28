using OpenQA.Selenium;
using Selenium.core.browsers;

namespace Selenium.pages
{
	public class BasePage
	{
		public IBrowser Driver { get; set; }
		public string Url { get; set; }

		public BasePage(IBrowser driver, string url)
		{
			Driver = driver;
			Url = url;
		}

		public void GoTo()
		{
			Driver.Page.GoToUrl(Url);
		}

		public void EnterText(By by, string text)
		{
			Driver.Page.FindElement(by).SendKeys(text);
		}

		public void Click(By by)
		{
			Driver.Page.FindElement(by).Click();
		}
	}
}