using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ServiceClient = MockClient.MockClient;

namespace InsuranceSite.Controllers
{
	public class BaseApiController : ApiController
	{
		protected ServiceClient _service { get { return new ServiceClient(); } }

		protected HttpResponseMessage ToJson(dynamic obj)
		{
			var response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
			return response;
		}
	}
}
