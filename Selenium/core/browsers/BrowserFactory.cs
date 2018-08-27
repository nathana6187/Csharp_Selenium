using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace Selenium.core.browsers
{
	public sealed class BrowserFactory :
		AbstractFactory,
		IBrowserWebDriver<FirefoxDriver>,
		IBrowserWebDriver<ChromeDriver>,
		IBrowserWebDriver<RemoteWebDriver>
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

		IBrowser<RemoteWebDriver> IBrowserWebDriver<RemoteWebDriver>.Create()
		{
			DesiredCapabilities capabilities;
			var gridUrl = Config.GridHubUri;

			switch (Config.Browser)
			{
				case BrowserType.Chrome:
					capabilities = DesiredCapabilities.Chrome();
					break;
				case BrowserType.Firefox:
					capabilities = DesiredCapabilities.Firefox();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			if (Config.RemoteBrowser && Config.UseSauceLabs)
			{
				capabilities.SetCapability(CapabilityType.Version, "50");
				capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
				capabilities.SetCapability("username", Config.SauceLabsUsername);
				capabilities.SetCapability("accessKey", Config.SauceLabsAccessKey);
				gridUrl = Config.SauceLabsHubUri;
			}
			else if (Config.RemoteBrowser && Config.UseBrowserstack)
			{
				capabilities.SetCapability(CapabilityType.Version, "50");
				capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
				capabilities.SetCapability("username", Config.BrowserStackUsername);
				capabilities.SetCapability("accessKey", Config.BrowserStackAccessKey);
				gridUrl = Config.BrowserStackHubUrl;
			}

			return
				new BrowserAdapter<RemoteWebDriver>(
					new RemoteWebDriver(new Uri(gridUrl), capabilities), BrowserType.Remote);
		}
	}
}