using AuthServer.Data.Entities;
using AuthServer.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuthServer.Data
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class AuthServerDbContext : IdentityDbContext
	{
		public AuthServerDbContext() : base("AuthDbEntities")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthServerDbContext, Configuration>());
			this.Configuration.LazyLoadingEnabled = true;
		}

		public AuthServerDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthServerDbContext, Configuration>());
			this.Configuration.LazyLoadingEnabled = true;
		}

		public DbSet<Client> Clients { get { return Set<Client>(); } }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUser>().ToTable("Users");
			modelBuilder.Entity<IdentityRole>().ToTable("Roles");
			modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
			modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
		}

		public static AuthServerDbContext Create()
		{
			return new AuthServerDbContext();
		}
	}
}
