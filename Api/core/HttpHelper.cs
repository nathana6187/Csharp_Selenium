using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Api.core
{
	public static class HttpHelper
	{
		public async static Task<HttpResponseMessage> Get(Uri baseUri, string endPoint)
		{
			using (HttpClient client = new HttpClient { BaseAddress = baseUri })
			{
				return await client.GetAsync(endPoint);
			}
		}

		public async static Task<HttpResponseMessage> Put<T>(Uri baseUri, string endPoint, T json)
		{
			using (var client = new HttpClient { BaseAddress = baseUri })
			using (var content = StringContent(json))
			{
				return await client.PutAsync(endPoint, content);
			}
		}

		public async static Task<HttpResponseMessage> Post<T>(Uri baseUri, string endPoint, T json)
		{
			using (var client = new HttpClient { BaseAddress = baseUri })
			using (var content = StringContent(json))
			{
				return await client.PostAsync(endPoint, content);
			}
		}

		public async static Task<HttpResponseMessage> Delete(Uri baseUri, string endPoint)
		{
			using (var client = new HttpClient { BaseAddress = baseUri })
			{
				return await client.DeleteAsync(endPoint);
			}
		}

		private static StringContent StringContent<T>(T json)
		{
			return new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
		}
	}
}
