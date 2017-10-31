using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Data.Entities
{
	public class User : IdentityUser
	{
		[Required]
		[MaxLength(128)]
		public string ExternalId { get; set; }

		[MaxLength(256)]
		public string Name { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

			return userIdentity;
		}
	}
}
