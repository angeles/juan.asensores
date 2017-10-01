using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace InsuranceSite
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest()
		{
			var context = new HttpContextWrapper(Context);
		}

		protected void Application_PostAuthorizeRequest()
		{
			if (IsWebApiRequest())
				HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
		}

		private static bool IsWebApiRequest()
		{
			return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(@"~/api");
		}
	}
}