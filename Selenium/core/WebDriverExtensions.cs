using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
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
				wait.Until(condition =>
				{
					try
					{
						var elementToBeDisplayed = driver.FindElement(by);
						return elementToBeDisplayed.Displayed;
					}
					catch (StaleElementReferenceException)
					{
						return false;
					}
					catch (NoSuchElementException)
					{
						return false;
					}
				});
			}
			return driver.FindElement(by);
		}

		/// <summary>
		/// Executes javascript with given script.
		/// </summary>
		public static T Execute<T>(this IWebDriver driver, string script)
		{
			return (T)((IJavaScriptExecutor)driver).ExecuteScript(script);
		}

		/// <summary>
		/// Executes javascript and waits for document to be in ready state complete.
		/// </summary>
		public static void WaitReadyState(this IWebDriver driver, int timeoutInSeconds)
		{
			if (timeoutInSeconds > 0)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(drv => drv.Execute<bool>("return document.readyState == 'complete'"));
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
				wait.Until(drv => drv.Execute<bool>("return jQuery.active == 0"));
			}
		}

		/// <summary>
		/// Waits for element to no longer be displayed.
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
		/// Waits for elements in list to no longer be displayed.
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
		/// Waits for element found by search criteria to no longer be displayed.
		/// </summary>
		public static void WaitForElementToDisappear(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			WaitForElementToDisappear(driver, driver.FindElement(by), timeoutInSeconds);
		}

		/// <summary>
		/// Waits for elements found by search criteria to no longer be displayed.
		/// </summary>
		public static void WaitForElementsToDisappear(this IWebDriver driver, By by, int timeoutInSeconds)
		{
			WaitForElementsToDisappear(driver, driver.FindElements(by).ToList(), timeoutInSeconds);
		}

		/// <summary>
		/// Drag and drop action from specified element to another.
		/// </summary>
		public static void DragAndDrop(this IWebDriver driver, By from, By to)
		{
			Actions action = new Actions(driver);
			action.DragAndDrop(driver.FindElement(from), driver.FindElement(to));
			action.Build().Perform();
		}

	}
}