using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace AuthApiTester
{
	[TestClass]
	public class UserClientTester
	{
		private static HttpClient apiClient;

		private const string clientId = "fb6f3521-7b84-4b35-94ed-db9f453b0572";

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			Console.WriteLine(string.Format("Initializing with User client {{{0}}}", clientId));
			var token = AuthHelper.GetClientToken(clientId);
			apiClient = new HttpClient();
			apiClient.SetBearerToken(token.AccessToken);
			apiClient.BaseAddress = new Uri("http://localhost:1912");
		}

		[TestMethod]
		public void UserClient_ControlServicePingTest()
		{
			Console.WriteLine(string.Format("Requesting '{0}test'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/test").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void UserClient_GetUserById()
		{
			Console.WriteLine(string.Format("Requesting '{0}users/d70d5ba5-7469-409c-a9f0-d6987d9b3f36'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/users/d70d5ba5-7469-409c-a9f0-d6987d9b3f36").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void UserClient_GetUserByName()
		{
			Console.WriteLine(string.Format("Requesting '{0}users/Turner'", apiClient.BaseAddress));
			var result = apiClient.GetStringAsync("/users/Turner").Result;
			Console.WriteLine(result);
		}

		[TestMethod]
		public void UserClient_GetPoliciesByUserName()
		{
			try
			{
				Console.WriteLine(string.Format("Requesting '{0}users/Turner/policies'", apiClient.BaseAddress));
				var result = apiClient.GetStringAsync("/users/Turner/policies").Result;
				Console.WriteLine(result);
				Assert.Fail();
			}
			catch (AggregateException e)
			{
				Assert.IsNotNull(e.InnerException, string.Format("Unexpected Exception: {0} - {1}", e.GetType().Name, e.Message));
				Assert.IsInstanceOfType(e.InnerException, typeof(HttpRequestException), string.Format("Unexpected Inner Exception: {0} - {1}", e.InnerException.GetType().Name, e.InnerException.Message));
				Assert.IsTrue(e.InnerException.Message.Contains("401"));
				Console.WriteLine("User Not Authorized to access this Method");
			}
			catch (Exception e)
			{
				Assert.Fail(string.Format("Unexpected Exception: {0} - {1}", e.GetType().Name, e.Message));
			}
		}

		[TestMethod]
		public void UserClient_GetUserLinkedToPolicy()
		{
			try
			{
				Console.WriteLine(string.Format("Requesting '{0}policies/7b624ed3-00d5-4c1b-9ab8-c265067ef58b/user'", apiClient.BaseAddress));
				var result = apiClient.GetStringAsync("/policies/7b624ed3-00d5-4c1b-9ab8-c265067ef58b/user").Result;
				Console.WriteLine(result);
				Assert.Fail("Access to method incorrectly allowed.");
			}
			catch (AggregateException e)
			{
				Assert.IsNotNull(e.InnerException, string.Format("Unexpected Exception: {0} - {1}", e.GetType().Name, e.Message));
				Assert.IsInstanceOfType(e.InnerException, typeof(HttpRequestException), string.Format("Unexpected Inner Exception: {0} - {1}", e.InnerException.GetType().Name, e.InnerException.Message));
				Assert.IsTrue(e.InnerException.Message.Contains("401"));
				Console.WriteLine("User Not Authorized to access this Method");
			}
			catch (Exception e)
			{
				Assert.Fail(string.Format("Unexpected Exception: {0} - {1}", e.GetType().Name, e.Message));
			}
		}

		[ClassCleanup]
		public static void TearDown()
		{
			apiClient.Dispose();
			GC.SuppressFinalize(apiClient);
		}
	}
}
