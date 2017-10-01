using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MockClient
{
	public class MockClient : IDisposable
	{
		public const string ServiceURLDefault = "http://www.mocky.io/v2/";

		private HttpClient client = new HttpClient();

		public MockClient() : this(ServiceURLDefault)
		{
		}

		public MockClient(string endpoint)
		{
			client.BaseAddress = new Uri(endpoint);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public List<CompanyClient> GetClients()
		{
			HttpResponseMessage response = client.GetAsync("5808862710000087232b75ac").Result;
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsAsync<CompanyClients>().Result.Clients;
			}
			else
			{
				throw new HttpRequestException();
			}
		}

		public List<CompanyPolicy> GetPolicies()
		{
			HttpResponseMessage response = client.GetAsync("580891a4100000e8242b75c5").Result;
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsAsync<CompanyPolicies>().Result.Policies;
			}
			else
			{
				throw new HttpRequestException();
			}
		}

		public void Dispose()
		{
			client.Dispose();
			GC.SuppressFinalize(client);
		}
	}
}
