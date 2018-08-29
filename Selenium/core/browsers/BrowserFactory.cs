using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace Selenium.core.browsers
{
	public sealed class BrowserFactory
	{
		public IWebDriver Init(BrowserType browserType)
		{
			IWebDriver driver = null;
			switch(browserType)
			{
				case BrowserType.Chrome:
					driver = new ChromeDriver(Path.Combine(AppContext.BaseDirectory, "libs"));
					break;
				case BrowserType.Firefox:
					var service = FirefoxDriverService.CreateDefaultService(Path.Combine(AppContext.BaseDirectory, "libs"));
					service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
					driver = new FirefoxDriver(service);
					break;
				default:
					driver = new ChromeDriver();
					break;
			}
			return driver;
		}
	}
}