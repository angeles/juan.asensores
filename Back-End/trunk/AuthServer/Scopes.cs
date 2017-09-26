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
					Name = "AuthApi"
				}
			};
		}
	}
}
