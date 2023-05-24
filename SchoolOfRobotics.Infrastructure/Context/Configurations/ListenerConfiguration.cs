using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using SchoolOfRobotics.Domain.Childrens.Entities;
using SchoolOfRobotics.Domain.CoursesGroups.Entities;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class ListenerConfiguration : IEntityTypeConfiguration<Listener>
	{
		public void Configure(EntityTypeBuilder<Listener> builder)
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

			builder.Property(p => p.StatusUpdateDate)
				.HasColumnName("StatusUpdateDate")
				.IsRequired();

			builder.Property(p => p.CreateDate)
				.HasColumnName("CreateDate")
				.IsRequired();

			builder.Property(p => p.GroupId)
				.HasConversion(
					value => value.Id,
					id => new(id))
				.HasColumnName("GroupId")
				.IsRequired();

			builder.Property(p => p.ChildrenId)
				.HasConversion(
					value => value.Id,
					id => new(id))
				.HasColumnName("ChildrenId")
				.IsRequired();

			builder.HasOne<Children>()
				.WithMany()
				.HasForeignKey(p => p.ChildrenId)
				.HasPrincipalKey(k => k.Id)
				.IsRequired();
		}
	}
}
