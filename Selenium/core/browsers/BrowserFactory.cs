using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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
					driver = new ChromeDriver(AppContext.BaseDirectory);
					break;
				case BrowserType.Firefox:
					var service = FirefoxDriverService.CreateDefaultService(AppContext.BaseDirectory);
					service.FirefoxBinaryPath = Config.FireFoxBinary;
					driver = new FirefoxDriver(service);
					break;
				case BrowserType.IE:
					driver = new InternetExplorerDriver(AppContext.BaseDirectory);
					break;
				default:
					driver = new ChromeDriver(AppContext.BaseDirectory);
					break;
			}
			return driver;
		}
	}
}