using System.Linq;
using System.Net;
using System.Web.Http;
using ServiceClient = MockClient.MockClient;

namespace ApiServer.Controllers
{
	public class PolicyController : ApiController
	{
		[Route("users/{name}/policies")]
		[Authorize(Roles = "admin")]
		public IHttpActionResult GetByName(string name)
		{
			var service = new ServiceClient();

			var client = service.GetClients().FirstOrDefault(x => x.Name == name);
			if (client == null)
				return Content(HttpStatusCode.NotFound, "User Name does not exist.");

			var policies = service.GetPolicies().Where(x => x.ClientId == client.Id);

			return Json(policies);
		}
	}
}
