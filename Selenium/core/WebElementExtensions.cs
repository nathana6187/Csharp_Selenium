using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium.core
{
	public static class WebElementExtensions
	{
		/// <summary>
		/// Extends click method with option to wait for ajax to complete.
		/// </summary>
		public static void Click(this IWebElement webElement, IWebDriver driver, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				driver.WaitAjax(timeoutInSeconds);
			}
			webElement.Click();
		}
	}
}