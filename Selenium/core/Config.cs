using Microsoft.Extensions.Configuration;
using System;
using Selenium.core.browsers;

namespace Selenium.core
{
	public class Config
	{
		public static BrowserType Browser
			=> (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"), true);
		public static string FireFoxBinary => GetValue("FireFoxBinary");

		public static string Platform => GetValue("Platform");
		public static string BaseUrl => GetValue("BaseUrl");
		public static string Username => GetValue("Username");

		public static string Password => GetValue("Password");

		private static string GetValue(string value)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json");
			return builder.Build()[value];
		}
	}
}