using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Attendances.Aggregates;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Groups.Aggregates;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
	{
		public void Configure(EntityTypeBuilder<Attendance> builder)
		{
			builder.ToTable("Attendances");
			builder.HasKey(x => x.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.Status)
				.HasConversion(
					value => value.Value,
					value => GroupStatusEnum.FromValue(value)!)
				.HasColumnName("Status");

			builder.Property(p => p.CourseId)
				.HasConversion(
					courseId => courseId.Id,
					value => new(value))
				.HasColumnName("CourseId")
				.IsRequired();

			builder.HasOne<Group>()
				.WithOne()
				.HasForeignKey<Attendance>(i => i.Id);

			builder.HasMany(i => i.Teachers)
				.WithOne()
				.HasForeignKey(t => t.CourseId)
				.HasPrincipalKey(k => k.CourseId)
				.IsRequired();

			builder.HasMany(i => i.Lessons)
				.WithOne()
				.HasForeignKey(l => l.GroupId)
				.HasPrincipalKey(k => k.Id)
				.IsRequired();

			builder.HasMany(i => i.Listeners)
				.WithOne()
				.HasForeignKey(l => l.GroupId)
				.HasPrincipalKey(k => k.Id)
				.IsRequired();

			builder.HasMany(i => i.Marks)
				.WithOne()
				.HasForeignKey(l => l.GroupId)
				.HasPrincipalKey(k => k.Id)
				.IsRequired();
		}
	}
}
