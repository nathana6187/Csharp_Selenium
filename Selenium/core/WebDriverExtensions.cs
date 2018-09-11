using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Selenium.core
{
	public static class WebDriverExtensions
	{
		/// <summary>
		/// Extends FindElement to include a wait for element.
		/// </summary>
		public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				return wait.Until(drv => drv.FindElement(by));
			}
			return driver.FindElement(by);
		}

		/// <summary>
		/// Executes javascript and waits for document to be in ready state complete.
		/// </summary>
		public static void WaitReadyState(this IWebDriver driver, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(drv => (bool)((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState == 'complete'"));
			}
		}

		/// <summary>
		/// Executes javascript and waits for active jQuery to be 0.
		/// </summary>
		public static void WaitAjax(this IWebDriver driver, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(drv => (bool)((IJavaScriptExecutor)drv).ExecuteScript("return jQuery.active == 0"));
			}
		}

		/// <summary>
		/// Extends click method to click on element by search criteria with timeout to wait for ajax to complete.
		/// </summary>
		public static void Click(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			driver.FindElement(by).Click();
			if (timeoutInSeconds > 0)
			{
				driver.WaitAjax(timeoutInSeconds);
			}
		}

		/// <summary>
		/// Waits for element to no longer be displayed
		/// </summary>
		public static void WaitForElementToDisappear(this IWebDriver driver, IWebElement webElement, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(condition =>
				{
					try
					{
						return !webElement.Displayed;
					}
					catch (StaleElementReferenceException)
					{
						return true;
					}
					catch (NoSuchElementException)
					{
						return true;
					}
				});
			}
		}

		/// <summary>
		/// Waits for elements in list to no longer be displayed
		/// </summary>
		public static void WaitForElementsToDisappear(this IWebDriver driver, List<IWebElement> webElements, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0 && webElements.Count > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(condition =>
				{
					foreach (IWebElement el in webElements)
					{
						try
						{
							if(el.Displayed)
							{
								return false;
							}
						}
						catch (StaleElementReferenceException)
						{/*Not displayed if no longer on DOM*/}
						catch (NoSuchElementException)
						{/*Not displayed if not found*/}
					}
					//all not displayed if hit this point
					return true;
				});
			}
		}

		/// <summary>
		/// Waits for element found by search criteria to no longer be displayed
		/// </summary>
		public static void WaitForElementToDisappear(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			WaitForElementToDisappear(driver, driver.FindElement(by), timeoutInSeconds);
		}

		/// <summary>
		/// Waits for elements found by search criteria to no longer be displayed
		/// </summary>
		public static void WaitForElementsToDisappear(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			WaitForElementsToDisappear(driver, driver.FindElements(by).ToList(), timeoutInSeconds);
		}

	}
}