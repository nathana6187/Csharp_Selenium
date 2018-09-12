using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.core
{
	public static class WebElementExtensions
	{
		/// <summary>
		/// Extends click method with option to wait for ajax to complete after clicking.
		/// </summary>
		public static void Click(this IWebElement webElement, int timeoutInSeconds)
		{
			webElement.Click();
			RemoteWebElement remoteElement = webElement as RemoteWebElement;
			if (timeoutInSeconds > 0 && remoteElement != null)
			{
				remoteElement.WrappedDriver.WaitAjax(timeoutInSeconds);
			}
		}

		/// <summary>
		/// Gets "value" attribute from element.
		/// </summary>
		public static string GetValue(this IWebElement webElement)
		{
			return webElement.GetAttribute("value");
		}

		/// <summary>
		/// Simulates typing text to an element with option to clear before typing.
		/// </summary>
		public static void SendKeys(this IWebElement webElement, string text, bool clear)
		{
			if (clear)
			{
				webElement.Clear();
			}
			webElement.SendKeys(text);
		}

		/// <summary>
		/// Gets parent element.
		/// </summary>
		public static IWebElement GetParent(this IWebElement webElement)
		{
			return webElement.FindElement(By.XPath(".."));
		}

		/// <summary>
		/// Gets all children of element.
		/// </summary>
		public static List<IWebElement> GetChildren(this IWebElement webElement)
		{
			return webElement.FindElements(By.XPath(".//*")).ToList();
		}
	}
}