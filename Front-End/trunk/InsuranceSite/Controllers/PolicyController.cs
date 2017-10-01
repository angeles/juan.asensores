using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace InsuranceSite.Controllers
{
	public class PolicyController : BaseApiController
	{
		[HttpGet]
		public HttpResponseMessage List()
		{
			return ToJson(_service.GetPolicies());
		}

		[HttpGet]
		public HttpResponseMessage GetPolicy(Guid id)
		{
			var data = _service.GetPolicies().SingleOrDefault(x => x.Id == id);
			if (data == null)
				return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

			return ToJson(data);
		}

		[HttpGet]
		public HttpResponseMessage GetPoliciesByClient([FromUri]Guid clientId)
		{
			var data = _service.GetPolicies().Where(x => x.ClientId == clientId);
			if (data == null)
				return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

			return ToJson(data);
		}
	}
}