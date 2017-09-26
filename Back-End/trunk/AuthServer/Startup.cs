using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(AuthServer.Startup))]
namespace AuthServer
{
	class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var options = new IdentityServerOptions
			{
				Factory = new IdentityServerServiceFactory()
							.UseInMemoryScopes(Scopes.Get())
							.UseInMemoryUsers(new List<InMemoryUser>()),

				RequireSsl = false
			};

			options.Factory.ClientStore = new Registration<IClientStore, ClientService>();
			app.UseIdentityServer(options);
		}
	}
}
