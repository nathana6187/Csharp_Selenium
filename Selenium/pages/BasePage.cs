using OpenQA.Selenium;
using Selenium.core.browsers;

namespace Selenium.pages
{
	public class BasePage
	{
		public IWebDriver Driver { get; set; }
		public string Url { get; set; }

		public BasePage(IWebDriver driver, string url)
		{
			Driver = driver;
			Url = url;
		}

		public void GoTo()
		{
			Driver.Navigate().GoToUrl(Url);
		}

		public void EnterText(By by, string text)
		{
			Driver.FindElement(by).SendKeys(text);
		}

		public void Click(By by)
		{
			Driver.FindElement(by).Click();
		}
	}
}