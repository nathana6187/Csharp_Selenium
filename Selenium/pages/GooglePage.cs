using OpenQA.Selenium;
using Selenium.core.browsers;
using Selenium.core;
using System;

namespace Selenium.pages
{
	public class GooglePage : BasePage
	{
		private readonly By searchBox = By.Name("q");
		private readonly By searchButton = By.CssSelector("input[value='Google Search']");
		private readonly By resultStats = By.Id("resultStats");

		public GooglePage(IBrowser driver, string url = "https://www.google.com") : base(driver, url)
		{}

		public void Search(string content)
		{
			EnterText(searchBox, content);
			Click(searchButton);
			Driver.Page.FindElement(resultStats, 5);
		}
	}
}