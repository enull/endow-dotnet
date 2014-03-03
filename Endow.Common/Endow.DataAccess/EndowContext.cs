using System.Data.Entity;
using Endow.DataAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Endow.DataAccess
{
	public class EndowContext : DbContext
	{
		public EndowContext()
			: base("EndowContext") 
		{
			//Database.SetInitializer<EndowContext>(new CreateDatabaseIfNotExists<EndowContext>());
			//Database.SetInitializer<EndowContext>(new DropCreateDatabaseIfModelChanges<EndowContext>());
			Database.SetInitializer<EndowContext>(new EndowDbInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Change the name of the table to be Users instead of AspNetUsers
			modelBuilder.Entity<IdentityUser>()
				.ToTable("AppUser");
			//modelBuilder.Entity<User>()
			//	.ToTable("AppUser");



			//EntityTypeConfiguration<Alarm> alarmConfig = modelBuilder.Entity<Alarm>();

			//alarmConfig.ToTable("Alarm")
			//	.HasKey(t => new { t.AlarmId });
				

			//alarmConfig.Property(t => t.AlarmId)
			//		.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); //No autogeneration

			//alarmConfig.Property(t => t.Title)
			//	.IsRequired()
			//	.HasMaxLength(100);

			//alarmConfig.Property(t => t.Description)
			//	.IsOptional()
			//	.HasMaxLength(2000);

			//alarmConfig.HasRequired(a => a.User)
			//	.WithMany(u => u.CreatedAlarms)
			//	.HasForeignKey(a => a.CreatedBy);

			modelBuilder.Entity<IdentityUserLogin>()
				.HasKey<string>(l => l.UserId);
			modelBuilder.Entity<IdentityRole>()
				.HasKey<string>(r => r.Id);
			modelBuilder.Entity<IdentityUserRole>()
				.HasKey(r => new { r.RoleId, r.UserId });

		}


		public DbSet<User> Users { get; set; }
		public DbSet<Alarm> Alarms { get; set; }
	}
}
