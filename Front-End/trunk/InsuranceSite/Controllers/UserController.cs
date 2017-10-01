using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace InsuranceSite.Controllers
{
	public class UserController : BaseApiController
	{
		[HttpGet]
		public HttpResponseMessage List()
		{
			var data = _service.GetClients();

			return ToJson(data);
		}

		[HttpGet]
		public HttpResponseMessage GetUser(Guid id)
		{
			var data = _service.GetClients().SingleOrDefault(x => x.Id == id);
			if (data == null)
				return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

			return ToJson(data);
		}
	}
}