using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.CoursesTeachers;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations;

internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder.ToTable("Teachers");
		
		builder.HasKey(x => x.Id);
		builder.Property(p => p.Id)
			.HasConversion(
				id => id.Id,
				value => new(value))
			.HasColumnName("Id");

		builder.Property(p => p.UserId)
			.HasConversion(
				userId => userId.Id,
				value => new(value))
			.HasColumnName("UserId")
			.IsRequired();

		builder.Property(p => p.CourseId)
			.HasConversion(
				groupId => groupId.Id,
				value => new(value))
			.HasColumnName("CourseId")
			.IsRequired();

		builder.Property(p => p.Status)
			.HasConversion(
				status => status.Value,
				value => TeacherStatusEnum.FromValue(value)!)
			.HasColumnName("Status")
			.IsRequired();

		builder.Property(p => p.UpdateStatusDate)
			.HasColumnName("UpdateStatusDate")
			.IsRequired();

		builder.HasOne<User>()
			.WithMany()
			.HasForeignKey(k => k.UserId)
			.HasPrincipalKey(k => k.Id)
			.IsRequired();
	}
}
