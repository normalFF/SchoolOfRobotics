using Microsoft.EntityFrameworkCore;
using SchoolOfRobotics.Domain.Childrens.Aggregates;
using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.Groups.Aggregates;
using SchoolOfRobotics.Domain.Users.Aggregates;

namespace SchoolOfRobotics.Infrastructure.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Group> Groups { get; set; } = null!;
		public DbSet<Course> Courses { get; set; } = null!;
		public DbSet<ChildrenCollection> ChildrenCollections { get; set; } = null!;

		public ApplicationDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql();
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
