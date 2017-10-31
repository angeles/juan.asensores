using AuthServer.Data;
using AuthServer.Data.Entities;
using AuthServer.Managers;
using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AuthServer
{
	public class IdentityServerConfig
	{
		public static void Register(IdentityServerOptions options)
		{
			options.Factory = new IdentityServerServiceFactory().UseInMemoryScopes(Scopes.Get());

			options.RequireSsl = false;

			options.Factory.ClientStore = new Registration<IClientStore, ClientService>();

			options.Factory.Register(new Registration<DbContext, AuthServerDbContext>());
			options.Factory.Register(new Registration<IUserStore<User>, UserStore<User>>());
			options.Factory.Register(new Registration<UserManager<User, string>, ApplicationUserManager>());

			options.Factory.UserService = new Registration<IUserService, AspNetIdentityUserService<User, string>>();

			options.LoggingOptions = new LoggingOptions
			{
				EnableHttpLogging = true,
				EnableKatanaLogging = true,
				EnableWebApiDiagnostics = true,
				WebApiDiagnosticsIsVerbose = false
			};
		}
	}
}
