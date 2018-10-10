using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database.core;

namespace Database.tests
{
	[TestClass]
	public class DatabaseTests
	{
		[TestMethod]
		public void Query()
		{
			DBHelper.Exec("SELECT * FROM [dbo].[TestTable];");
		}

		[DataRow(0, 0)]
		[DataRow(1, 1)]
		[DataRow(2, 1)]
		[DataRow(4, 3)]
		[DataRow(80, 23416728348467685)]
		[DataTestMethod]
		public void GivenDataFibonacciReturnsResultsOk(int number, long result)
		{
			Assert.AreEqual(result, new Fib().Fibonacci(number));
		}


	}

	public class Fib
	{
		public long Fibonacci(int n)
		{
			long a = 0;
			long b = 1;
			for (int i = 0; i < n; i++)
			{
				long temp = a;
				a = b;
				b = temp + b;
			}
			return a;
		}
	}
}



