using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Groups.Aggregates;
using SchoolOfRobotics.Domain.Groups.ValueObjects;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
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

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => GroupStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.Property(p => p.CourseId)
				.HasConversion(
					courseId => courseId.Id,
					value => new(value))
				.HasColumnName("CourseId")
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

			builder.Property(p => p.Name)
				.HasConversion(
					value => value.Value,
					value => GroupName.Create(value).Value)
				.HasColumnName("Name")
				.HasMaxLength(GroupName.MaxNameLength)
				.IsRequired();
		}
	}
}
