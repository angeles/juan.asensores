using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using ServiceClient = MockClient.MockClient;

namespace ApiServer.Controllers
{
	public class UserController : ApiController
	{
		[Route("users/{id:guid}")]
		[Authorize(Roles = "user,admin")]
		public IHttpActionResult Get(Guid id)
		{
			var service = new ServiceClient();
			var client = service.GetClients().FirstOrDefault(x => x.Id == id);

			if (client == null)
				return Content(HttpStatusCode.NotFound, "User Id does not exist.");

			return Json(client);
		}

		[Route("users/{name}")]
		[Authorize(Roles = "user,admin")]
		public IHttpActionResult GetByName(string name)
		{
			var service = new ServiceClient();

			var client = service.GetClients().FirstOrDefault(x => x.Name == name);

			if (client == null)
				return Content(HttpStatusCode.NotFound, "User Name does not exist.");

			return Json(client);
		}

		[Route("policies/{number:guid}/user")]
		[Authorize(Roles = "admin")]
		public IHttpActionResult GetByName(Guid number)
		{
			var service = new ServiceClient();
			var policy = service.GetPolicies().FirstOrDefault(x => x.Id == number);

			if (policy == null)
				return Content(HttpStatusCode.NotFound, "Policy does not exist.");

			var client = service.GetClients().FirstOrDefault(x => x.Id == policy.ClientId);

			if (client == null)
				return Content(HttpStatusCode.NotFound, "No user is assigned to this policy.");

			return Json(client);
		}
	}
}
