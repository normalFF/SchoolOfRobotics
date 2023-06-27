using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Attendances.Entities;
using SchoolOfRobotics.Domain.CoursesGroups.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.GroupLessons;
using SchoolOfRobotics.Domain.Groups;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
    internal class MarkConfiguration : IEntityTypeConfiguration<Mark>
	{
		public void Configure(EntityTypeBuilder<Mark> builder)
		{
			builder.ToTable("Marks");
			builder.HasKey(x => x.Id);
			builder.Property(i => i.Id)
				.HasConversion(
					value => value.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.Status)
				.HasConversion(
					value => value.Value,
					value => MarkStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.HasOne<Listener>()
				.WithMany()
				.HasForeignKey(i => i.ListenerId)
				.HasPrincipalKey(i => i.Id)
				.IsRequired();

			builder.HasOne<Group>()
				.WithMany()
				.HasForeignKey(i => i.GroupId)
				.HasPrincipalKey(i => i.Id)
				.IsRequired();

			builder.HasOne<LessonDate>()
				.WithMany()
				.HasForeignKey(i => i.LessonId)
				.HasPrincipalKey(i => i.Id)
				.IsRequired();
		}
	}
}
