using IdentityModel.Client;

namespace AuthApiTester
{
	public static class AuthHelper
	{
		public static TokenResponse GetClientToken(string clientId)
		{
			var client = new TokenClient(
				"http://localhost:5000/connect/token",
				clientId,
				"F621F470-9731-4A25-80EF-67A6F7C5F4B8");

			return client.RequestClientCredentialsAsync("AuthApi").Result;
		}
	}
}
