using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.jsonClasses;
using Api.core;

namespace Api.tests
{
	[TestClass]
	public class ToDoTests
	{
		private readonly Uri toDoUri = new Uri("https://jsonplaceholder.typicode.com/");
		
		[TestMethod]
		public async Task GetTodos()
		{
			using (var response = await HttpHelper.Get(toDoUri, "todos?id=1"))
			{
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Console.WriteLine(content);
				}
				else
				{
					Assert.Fail($"{response.StatusCode} {response.ReasonPhrase}");
				}
			}
		}

		[TestMethod]
		public async Task PutTodos()
		{
			var todo = new ToDo
			{
				id = 1,
				userId = 77,
				title = "updated test title",
				completed = true
			};

			using (var response = await HttpHelper.Put(toDoUri, "todos/1", todo))
			{
				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var temp = JsonConvert.DeserializeObject<ToDo>(responseContent);
					Assert.AreEqual(todo, temp);
					Console.Write(responseContent);
				}
				else
				{
					Assert.Fail($"{response.StatusCode} {response.ReasonPhrase}");
				}
			}
		}

		[TestMethod]
		public async Task PostTodos()
		{
			var todo = new ToDo
			{
				userId = 77,
				title = "test title",
				completed = false
			};

			using (var response = await HttpHelper.Post(toDoUri, "todos", todo))
			{
				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();					
					Console.Write(responseContent);
				}
				else
				{
					Assert.Fail($"{response.StatusCode} {response.ReasonPhrase}");
				}
			}
		}

		[TestMethod]
		public async Task DeleteTodos()
		{
			using (var response = await HttpHelper.Delete(toDoUri, "todos/1"))
			{
				if (!response.IsSuccessStatusCode)
				{
					Assert.Fail($"{response.StatusCode} {response.ReasonPhrase}");
				}
			}
		}
	}
}



