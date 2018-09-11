using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
	[TestFixture]
	[Parallelizable]
	public class GoogleSearch : TestBase
	{
		[Test]
		public void Search()
		{
			var gp = new GooglePage(Driver);
			gp.GoTo();
			gp.Search("stuff");
		}
	}
}