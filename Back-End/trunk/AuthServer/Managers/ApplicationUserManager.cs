using AuthServer.Data;
using AuthServer.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MockClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Managers
{
	public class ApplicationUserManager : UserManager<User>
	{
		private IOwinContext _context;

		public ApplicationUserManager(IUserStore<User> store) : base(store)
		{
		}

		private ApplicationUserManager(IUserStore<User> store, IOwinContext context)
			: base(store)
		{
			_context = context;
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var manager = new ApplicationUserManager(new UserStore<User>(context.Get<AuthServerDbContext>()), context);

			manager.UserValidator = new UserValidator<User>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("AuthServer Identity"));
			}

			return manager;
		}

		public override async Task<IdentityResult> CreateAsync(User user, string password)
		{
			List<CompanyClient> users = (new MockClient.MockClient()).GetClients();

			var client = users.SingleOrDefault(x => x.Email == user.UserName);

			if (client == null)
			{
				return await Task.FromResult(new IdentityResult("User not found in authorized client list"));
			}

			user.Email = client.Email;
			user.ExternalId = client.Id.ToString();

			var userResult = await base.CreateAsync(user, password);

			if (!userResult.Succeeded)
			{
				return await Task.FromResult(userResult);
			}

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context.Get<AuthServerDbContext>()));

			IdentityResult roleResult;
			bool adminRoleExists = await roleManager.RoleExistsAsync(client.Role);
			if (!adminRoleExists)
			{
				roleResult = await roleManager.CreateAsync(new IdentityRole(client.Role));
				if (!roleResult.Succeeded)
				{
					this.Delete(user); //rollback user creation
					return await Task.FromResult(roleResult);
				}
			}

			var addToRoleResult = await AddToRoleAsync(user.Id, client.Role);

			if (!addToRoleResult.Succeeded)
			{
				this.Delete(user); //rollback user creation
				return await Task.FromResult(addToRoleResult);
			}

			return await Task.FromResult(new IdentityResult());
		}
	}
}
