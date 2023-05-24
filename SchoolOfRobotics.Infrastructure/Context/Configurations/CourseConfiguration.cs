using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.Courses.ValueObjects;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.ToTable("Courses");
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					courseId => courseId.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.Description)
				.HasConversion(
					desc => desc.Value,
					value => CourseDescription.Create(value).Value)
				.HasMaxLength(CourseDescription.MaxLength)
				.HasColumnName("Description")
				.IsRequired();

			builder.Property(p => p.Name)
				.HasConversion(
					n => n.Value,
					value => CourseName.Create(value).Value)
				.HasMaxLength(CourseName.MaxLength)
				.HasColumnName("Name")
				.IsRequired();

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => CourseStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();
		}
	}
}
