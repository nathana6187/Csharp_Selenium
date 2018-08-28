using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace Selenium.core.browsers
{
	public sealed class BrowserFactory :
		AbstractFactory,
		IBrowserWebDriver<FirefoxDriver>,
		IBrowserWebDriver<ChromeDriver>
	{
		IBrowser<ChromeDriver> IBrowserWebDriver<ChromeDriver>.Create()
		{
			return new BrowserAdapter<ChromeDriver>(new ChromeDriver(Path.Combine(AppContext.BaseDirectory, "libs")), BrowserType.Chrome);
		}

		IBrowser<FirefoxDriver> IBrowserWebDriver<FirefoxDriver>.Create()
		{
			var service = FirefoxDriverService.CreateDefaultService(Path.Combine(AppContext.BaseDirectory, "libs"));
			service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
			return new BrowserAdapter<FirefoxDriver>(new FirefoxDriver(service), BrowserType.Firefox);
		}
	}
}