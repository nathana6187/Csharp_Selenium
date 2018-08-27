﻿using Microsoft.Extensions.Configuration;
using System;

namespace Selenium.core.browsers
{
	public class Config
	{
		public static bool RemoteBrowser => bool.Parse(GetValue("RemoteBrowser"));

		public static BrowserType Browser
			=> (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"));

		public static string Platform => GetValue("Platform");
		public static string BaseUrl => GetValue("BaseUrl");
		public static string Username => GetValue("Username");
		public static string Password => GetValue("Password");

		public static bool UseSeleniumGrid => bool.Parse(GetValue("UseSeleniumGrid"));
		public static string GridHubUri => GetValue("GridHubUrl");

		public static bool UseSauceLabs => bool.Parse(GetValue("UseSauceLabs"));
		public static string SauceLabsHubUri => GetValue("SauceLabsHubUrl");
		public static string SauceLabsUsername => GetValue("SauceLabsUsername");
		public static string SauceLabsAccessKey => GetValue("SauceLabsAccessKey");

		public static bool UseBrowserstack => bool.Parse(GetValue("BrowserStack"));
		public static string BrowserStackHubUrl => GetValue("BrowserStackHubUrl");
		public static string BrowserStackUsername => GetValue("BrowserStackUsername");
		public static string BrowserStackAccessKey => GetValue("BrowserStackAccessKey");

		private static string GetValue(string value)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json");
			return builder.Build()[value];
		}
	}
}