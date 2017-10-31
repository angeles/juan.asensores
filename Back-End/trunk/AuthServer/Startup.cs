using AuthServer.Data;
using AuthServer.Managers;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(AuthServer.Startup))]
namespace AuthServer
{
	class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.CreatePerOwinContext(AuthServerDbContext.Create);
			app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

			app.Map("/identity", idsrvApp =>
			{
				var options = new IdentityServerOptions();

				IdentityServerConfig.Register(options);

				idsrvApp.UseIdentityServer(options);
			});

			HttpConfiguration httpConfiguration = new HttpConfiguration();

			WebApiConfig.Register(httpConfiguration);

			app.UseWebApi(httpConfiguration);
		}
	}
}
