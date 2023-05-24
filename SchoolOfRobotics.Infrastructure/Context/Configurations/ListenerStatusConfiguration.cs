using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Attendances.Entities;
using SchoolOfRobotics.Domain.CoursesGroups.Entities;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class ListenerStatusConfiguration : IEntityTypeConfiguration<ListenerStatus>
	{
		public void Configure(EntityTypeBuilder<ListenerStatus> builder)
		{
			builder.ToTable("Listeners");
			builder.HasKey(e => e.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.Property(p => p.Status)
				.HasConversion(
					status => status.Value,
					value => ListenerStatusEnum.FromValue(value)!)
				.HasColumnName("Status")
				.IsRequired();

			builder.Property(p => p.GroupId)
				.HasConversion(
					value => value.Id,
					id => new(id))
				.HasColumnName("GroupId")
				.IsRequired();

			builder.HasOne<Listener>()
				.WithOne()
				.HasForeignKey<ListenerStatus>(i => i.Id)
				.IsRequired()
				.Metadata.IsRequiredDependent = true;
		}
	}
}
