using AuthServer.Data.Entities;
using AuthServer.Managers;
using AuthServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace AuthServer.Controllers
{
	public class AccountController : ApiController
	{
		public AccountController()
		{
		}

		public AccountController(ApplicationUserManager userManager)
		{
			UserManager = userManager;
		}

		private ApplicationUserManager _userManager;

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		[Route("register")]
		[AllowAnonymous]
		[HttpPost]
		public IHttpActionResult Register(RegisterUserModel model)
		{
			if(UserManager.FindByName(model.UserName) != null)
			{
				return BadRequest("User Already Exists");
			}

			var user = new User { UserName = model.UserName };
			
			var result = UserManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{
				return Ok();
			}
			else
			{
				return GetErrorResult(result);
			}
		}

		private IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					return BadRequest();
				}
				return BadRequest(ModelState);
			}
			return null;
		}
	}
}
