using ApiServer.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ApiServer.Filters
{
	public class LocalExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			HttpResponseMessage response = null;

			//Check the Exception Type
			if (actionExecutedContext.Exception is ElementNotFoundException)
			{
				//Define the Response Message
				response = new HttpResponseMessage(HttpStatusCode.NotFound);
			}
			else if (actionExecutedContext.Exception is ApiServerException)
			{
				//Define the Response Message
				response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
			}

			if (response != null)
			{
				var res = actionExecutedContext.Exception.Message;

				response.Content = new StringContent(res);
				response.ReasonPhrase = res;

				actionExecutedContext.Response = response;
			}
		}
	}
}