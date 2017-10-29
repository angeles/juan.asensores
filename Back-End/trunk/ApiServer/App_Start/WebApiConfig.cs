using System.Web.Http;

namespace ApiServer
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();
		}
	}
}
