using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.GroupLessons.Entities;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class LessonDateConfiguration : IEntityTypeConfiguration<LessonDate>
	{
		public void Configure(EntityTypeBuilder<LessonDate> builder)
		{
			builder.ToTable("Lessons");
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("id");

			builder.Property(p => p.GroupId)
				.HasConversion(
					groupId => groupId.Id,
					id => new(id))
				.HasColumnName("GroupId")
				.IsRequired();

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => LessonStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.OwnsOne(p => p.Time, ownsConfig =>
			{
				ownsConfig.Property(p => p.BeginDate).HasColumnName("BeginDate").IsRequired();
				ownsConfig.Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
			});

			builder.Property(p => p.TeacherId)
				.HasConversion(
					id => id == null ? Guid.Empty : id.Id,
					value => value == Guid.Empty ? null : new(value))
				.HasColumnName("TeacherId")
				.IsRequired();
		}
	}
}
