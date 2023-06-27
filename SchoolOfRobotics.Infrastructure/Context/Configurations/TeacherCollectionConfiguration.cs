using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.CoursesTeachers;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations;

internal class TeacherCollectionConfiguration : IEntityTypeConfiguration<TeacherCollection>
{
	public void Configure(EntityTypeBuilder<TeacherCollection> builder)
	{
		builder.ToTable("Courses");
		builder.HasKey(x => x.Id);
		builder.Property(p => p.Id)
			.HasConversion(
				courseId => courseId.Id,
				value => new(value))
			.HasColumnName("Id");

		builder.HasMany(p => p.Teachers)
			.WithOne()
			.HasForeignKey(k => k.CourseId)
			.HasPrincipalKey(k => k.Id)
			.IsRequired();

		builder.HasOne<Course>()
			.WithOne()
			.HasForeignKey<TeacherCollection>(i => i.Id)
			.HasPrincipalKey<Course>(k => k.Id)
			.IsRequired()
			.Metadata.IsRequiredDependent = true;
	}
}
