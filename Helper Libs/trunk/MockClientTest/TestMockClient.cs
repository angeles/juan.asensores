using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient = MockClient.MockClient;

namespace MockClientTest
{
	[TestClass]
	public class TestMockClient
	{
		private static ServiceClient client;

		[ClassInitialize]
		public static void StartUp(TestContext context)
		{
			client = new ServiceClient();
		}

		[TestMethod]
		public void GetClients()
		{
			var clientList = client.GetClients();
		}

		[TestMethod]
		public void GetPolicies()
		{
			var policies = client.GetPolicies();
		}

		[ClassCleanup]
		public static void TearDown()
		{
			client.Dispose();
		}
	}
}
