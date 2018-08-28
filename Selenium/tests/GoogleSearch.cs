using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.core;
using Selenium.pages;

namespace Selenium.tests
{
	[TestFixture]
	[Parallelizable]
	public class GoogleSearch : TestBase
	{
		[Test]
		public void TestMethod()
		{
			var gp = new GooglePage(Driver);
			gp.GoTo();
			gp.Search("stuff");
		}
	}
}