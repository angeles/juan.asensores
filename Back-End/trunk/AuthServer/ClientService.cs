using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using MockClient;
using System.Security.Claims;
using IdentityServer3.Core;

namespace AuthServer
{
	public class ClientService : IClientStore
	{
		public Task<Client> FindClientByIdAsync(string clientId)
		{
			List<CompanyClient> users = (new MockClient.MockClient()).GetClients();

			var user = users.SingleOrDefault(x => x.Id.ToString() == clientId);

			var client = new Client()
			{
				ClientName = user.Name,
				ClientId = user.Id.ToString(),
				Enabled = true,
				AccessTokenType = AccessTokenType.Reference,

				Flow = Flows.ClientCredentials,

				ClientSecrets = new List<Secret>
				{
					new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
				},

				Claims = new List<Claim>()
				{
					new Claim(Constants.ClaimTypes.Email, user.Email),
					new Claim(Constants.ClaimTypes.Role, user.Role)
				},

				AllowedScopes = new List<string>
				{
					"AuthApi"
				}
			};

			return Task.FromResult(client);
		}
	}
}
