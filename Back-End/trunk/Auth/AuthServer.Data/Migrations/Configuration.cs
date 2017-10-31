using Allotasoft.EntityFramework.Extension;
using AuthServer.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace AuthServer.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<AuthServerDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			ContextKey = "AuthServerDb.Entities";
		}

		protected override void Seed(AuthServerDbContext context)
		{
			System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256.Create();

			var clients = new List<Client>
			{
				new Client
				{
					Id = "197BD9C4-7504-4776-B3BD-B15B6F5CD43B",
					Name="ApiServer",
					SecretHash = System.Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes("F621F470-9731-4A25-80EF-67A6F7C5F4B8")))
				}
			};

			clients.ForEach(s => context.Clients.AddIfNotExists(s, x => x.Id == s.Id));
			context.SaveChanges();
		}
	}
}
