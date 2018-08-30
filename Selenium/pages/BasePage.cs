using OpenQA.Selenium;
using Selenium.core;

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

		/// <summary>
		/// Goes to the url specified by page class
		/// </summary>
		public void GoTo()
		{
			Driver.Navigate().GoToUrl(Url);
		}
		/// <summary>
		/// Sends keys to specified element
		/// </summary>
		public void EnterText(By by, string text)
		{
			Driver.FindElement(by).SendKeys(text);
		}

		/// <summary>
		/// Clicks specified element
		/// </summary>
		public void Click(By by)
		{
			Driver.FindElement(by).Click();
		}
	}
}