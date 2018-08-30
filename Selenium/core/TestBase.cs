using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.core.browsers;
using System;

namespace Selenium.core
{
	[SetUpFixture]
	public class TestBase
	{
		private readonly BrowserFactory _factory = new BrowserFactory();
		protected IWebDriver Driver;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Driver = _factory.Init(Config.Browser);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver?.Quit();
			Driver?.Dispose();
		}

		[SetUp]
		public void SetUp()
		{
			Driver.Manage().Cookies.DeleteAllCookies();
		}
	}
}