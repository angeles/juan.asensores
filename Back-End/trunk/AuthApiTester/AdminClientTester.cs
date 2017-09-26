using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace AuthApiTester
{
	[TestClass]
	public class AdminClientTester
	{
		private static HttpClient apiClient;

		private const string clientId = "d70d5ba5-7469-409c-a9f0-d6987d9b3f36";

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			Console.WriteLine(string.Format("Initializing with Admin client {{{0}}}", clientId));
			var token = AuthHelper.GetClientToken(clientId);
			apiClient = new HttpClient();
			apiClient.SetBearerToken(token.AccessToken);
			apiClient.BaseAddress = new Uri("http://localhost:1912");
		}

		[TestMethod]
		public void AdminClient_ControlServicePingTest()
		{
			Console.WriteLine(string.Format("Requesting '{0}test'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/test").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void AdminClient_GetUserById()
		{
			Console.WriteLine(string.Format("Requesting '{0}users/d70d5ba5-7469-409c-a9f0-d6987d9b3f36'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/users/d70d5ba5-7469-409c-a9f0-d6987d9b3f36").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void AdminClient_GetUserByName()
		{
			Console.WriteLine(string.Format("Requesting '{0}users/Turner'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/users/Turner").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void AdminClient_GetPoliciesByUserName()
		{
			Console.WriteLine(string.Format("Requesting '{0}users/Turner/policies'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/users/Turner/policies").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void AdminClient_GetUserLinkedToPolicy()
		{
			Console.WriteLine(string.Format("Requesting '{0}policies/7b624ed3-00d5-4c1b-9ab8-c265067ef58b/user'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/policies/7b624ed3-00d5-4c1b-9ab8-c265067ef58b/user").Result;
			Console.WriteLine(result);
		}

		[ClassCleanup]
		public static void TearDown()
		{
			apiClient.Dispose();
			GC.SuppressFinalize(apiClient);
		}
	}
}
