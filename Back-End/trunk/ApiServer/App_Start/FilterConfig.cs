using ApiServer.Filters;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ApiServer
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(HttpFilterCollection filters)
		{
			// require authentication for all controllers
			filters.Add(new AuthorizeAttribute());
			// add ExceptionHandler.
			filters.Add(new LocalExceptionFilterAttribute());
		}
	}
}
