using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ApiServer.Filters
{
	public class ApiAuthorizeAttribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
		{

			if (filterContext.RequestContext.Principal.Identity.IsAuthenticated)
				filterContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
			else
				filterContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
		}
	}
}