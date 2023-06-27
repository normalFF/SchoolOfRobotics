using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.CoursesGroups.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Groups;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
    internal class GroupListenerConfiguration : IEntityTypeConfiguration<GroupListener>
	{
		public void Configure(EntityTypeBuilder<GroupListener> builder)
		{
			builder.ToTable("Groups");
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.ListenersCount)
				.HasColumnName("ListenersCount")
				.IsRequired();

			builder.Property(p => p.CourseId)
				.HasConversion(
					courseId => courseId.Id,
					value => new(value))
				.HasColumnName("CourseId")
				.IsRequired();

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => GroupStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.Property(p => p.MinAge)
				.HasColumnName("MinAge")
				.IsRequired();

			builder.Property(p => p.MaxAge)
				.HasColumnName("MaxAge")
				.IsRequired();

			builder.Property(p => p.MinClassNumber)
				.HasConversion(
					value => value.Value,
					value => ClassNumberEnum.FromValue(value)!)
				.HasColumnName("MinClassNumber")
				.IsRequired();

			builder.Property(p => p.MaxClassNumber)
				.HasConversion(
					value => value.Value,
					value => ClassNumberEnum.FromValue(value)!)
				.HasColumnName("MaxClassNumber")
				.IsRequired();

			builder.Property(p => p.RecruitmentStartDate)
				.HasColumnName("RecruitmentStartDate")
				.IsRequired();

			builder.Property(p => p.EnrollmentEndDate)
				.HasColumnName("EnrollmentEndDate")
				.IsRequired();

			builder.HasOne<Group>()
				.WithOne()
				.HasForeignKey<GroupListener>(i => i.Id)
				.HasPrincipalKey<Group>(k => k.Id)
				.IsRequired()
				.Metadata.IsRequiredDependent = true;

			builder.HasMany(l => l.Listeners)
				.WithOne()
				.HasForeignKey(k => k.GroupId)
				.HasPrincipalKey(i => i.Id)
				.HasConstraintName("GroupId")
				.IsRequired();
		}
	}
}
