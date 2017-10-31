using AuthServer.Data;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Managers
{
	public class ClientService : IClientStore
	{
		public Task<Client> FindClientByIdAsync(string clientId)
		{
			using (var context = new AuthServerDbContext())
			{
				var client = context.Clients.SingleOrDefault(x => x.Id == clientId);

				var result = new Client()
				{
					ClientName = client.Name,
					ClientId = client.Id.ToString(),
					Enabled = true,
					AccessTokenType = AccessTokenType.Reference,

					Flow = Flows.ResourceOwner,

					ClientSecrets = new List<Secret>
					{
						new Secret(client.SecretHash)
					},

					AllowedScopes = new List<string>
					{
						"AuthApi"
					}
				};

				return Task.FromResult(result);
			}
		}
	}
}
