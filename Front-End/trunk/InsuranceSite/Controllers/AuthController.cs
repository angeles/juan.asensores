using InsuranceSite.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsuranceSite.Controllers
{
	public class AuthController : BaseApiController
	{
		[HttpPost]
		public HttpResponseMessage Login([FromBody] LoginData login)
		{
			var data = _service.GetClients().SingleOrDefault(x => x.Email == login.Username);
			if (data == null)
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			return ToJson(data);
		}
	}
}
