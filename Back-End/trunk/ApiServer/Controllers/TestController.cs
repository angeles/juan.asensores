using System;
using System.Security.Claims;
using System.Web.Http;

namespace ApiServer.Controllers
{
	[Route("test")]
	public class TestController : ApiController
	{
		public IHttpActionResult Get()
		{
			var caller = User as ClaimsPrincipal;

			return Json(new
			{
				message = "OK",
				client = caller.FindFirst("client_id").Value,
				timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 'GMT'zzz")
			});
		}
	}
}