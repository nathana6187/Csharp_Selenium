using Microsoft.Extensions.Configuration;
using System;

namespace Database.core
{
	public class Config
	{
		public static string ConnectionString => GetValue("ConnectionString");
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