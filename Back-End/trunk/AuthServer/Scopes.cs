using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace AuthServer
{
	public static class Scopes
	{
		public static List<Scope> Get()
		{
			return new List<Scope>
			{
				new Scope
				{
					Name = "AuthApi",
					Claims = new List<ScopeClaim>()
						{
                                // List of user claims that should be included in the access token
                                new ScopeClaim() { Name = Constants.ClaimTypes.Name, AlwaysIncludeInIdToken = true },
								new ScopeClaim() { Name = Constants.ClaimTypes.Role, AlwaysIncludeInIdToken = true },
						},
				}
			};
		}
	}
}
