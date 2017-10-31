using IdentityModel.Client;

namespace AuthApiTester
{
	public static class AuthHelper
	{
		public static TokenClient GetClientToken(string clientId)
		{
			return new TokenClient(
				"http://localhost:5000/identity/connect/token",
				clientId,
				"F621F470-9731-4A25-80EF-67A6F7C5F4B8");
		}

		public static TokenResponse GetUserToken(this TokenClient client, string user, string password)
		{
			return client.RequestResourceOwnerPasswordAsync(user, password, "AuthApi").Result;
		}
	}
}
