using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Text;

namespace AuthApiTester
{
	[TestClass]
	public class AdminClientTester
	{
		private static HttpClient apiClient;

		private const string clientId = "197BD9C4-7504-4776-B3BD-B15B6F5CD43B";

		private const string userName = "britneyblankenship@quotezart.com";

		private const string userPassword = "Ab23$gH";

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			Console.WriteLine(string.Format("Initializing with Admin client {{{0}}}", clientId));
			var client = AuthHelper.GetClientToken(clientId);
			apiClient = new HttpClient();
			var token = client.GetUserToken(userName, userPassword);
			apiClient.SetBearerToken(token.AccessToken);
			apiClient.BaseAddress = new Uri("http://localhost:1912");
		}

		[TestMethod]
		public void AdminClient_RegisterOk()
		{
			var registerClient = new HttpClient();

			registerClient.BaseAddress = new Uri("http://localhost:5000");

			string obj = "{'userName':'" + userName + "', 'password':'" + userPassword + "' }";

			var content = new StringContent(obj, Encoding.UTF8, "application/json");
			var result = registerClient.PostAsync("/register", content).Result;
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
			var result2 = apiClient.GetStringAsync("/policies/?userName=Turner").Result;
			Assert.AreEqual(result, result2);
			Console.WriteLine(result);
		}

		[TestMethod]
		public void AdminClient_GetUserLinkedToPolicy()
		{
			Console.WriteLine(string.Format("Requesting '{0}policies/7b624ed3-00d5-4c1b-9ab8-c265067ef58b/client'", apiClient.BaseAddress));
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
