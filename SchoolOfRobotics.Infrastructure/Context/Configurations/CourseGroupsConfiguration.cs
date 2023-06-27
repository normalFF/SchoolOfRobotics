using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Courses;
using SchoolOfRobotics.Domain.CoursesGroups;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
    internal class CourseGroupsConfiguration : IEntityTypeConfiguration<CourseGroups>
	{
		public void Configure(EntityTypeBuilder<CourseGroups> builder)
		{
			builder.ToTable("Courses");
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => CourseStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.HasOne<Course>()
				.WithOne()
				.HasForeignKey<CourseGroups>(i => i.Id)
				.IsRequired()
				.Metadata.IsRequiredDependent = true;

			builder.HasMany(g => g.Groups)
				.WithOne()
				.HasForeignKey(g => g.CourseId)
				.HasPrincipalKey(k => k.Id)
				.HasConstraintName("CourseId")
				.IsRequired();
		}
	}
}
