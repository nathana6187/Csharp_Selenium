using Microsoft.Extensions.Configuration;
using System;

namespace Selenium.core.browsers
{
	public class Config
	{
		public static BrowserType Browser
			=> (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"));

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