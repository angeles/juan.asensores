using ApiServer.Filters;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ApiServer.Startup))]
namespace ApiServer
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// accept access tokens from identityserver and require a scope of 'api1'
			app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
			{
				Authority = "http://localhost:5000/identity",
				ValidationMode = ValidationMode.ValidationEndpoint,
				//RoleClaimType = "client_role",
				
				RequiredScopes = new[] { "AuthApi" }
			});

			// configure web api
			var config = new HttpConfiguration();

			WebApiConfig.Register(config);
			UnityConfig.RegisterComponents(config);

			FilterConfig.RegisterGlobalFilters(config.Filters);

			app.UseWebApi(config);
		}
	}
}