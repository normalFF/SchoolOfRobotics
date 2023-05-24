using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Childrens.Aggregates;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users.Aggregates;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class ChildrenCollectionConfiguration : IEntityTypeConfiguration<ChildrenCollection>
	{
		public void Configure(EntityTypeBuilder<ChildrenCollection> builder)
		{
			builder.ToTable("Users");
			builder.HasKey(x => x.Id);
			builder.Property(k => k.Id)
				.HasConversion(
					userId => userId.Id,
					id => new UserId(id))
				.HasColumnName("Id");

			builder.Property(i => i.Role)
				.HasConversion(
					role => role.Value,
					value => UserRoleEnum.FromValue(value)!)
				.HasColumnName("Role")
				.IsRequired();

			builder.HasOne<User>()
				.WithOne()
				.HasForeignKey<ChildrenCollection>(i => i.Id)
				.HasPrincipalKey<User>(k => k.Id)
				.IsRequired()
				.Metadata.IsRequiredDependent = true;

			builder.HasMany(i => i.Childrens)
				.WithOne()
				.HasForeignKey(i => i.UserId)
				.HasPrincipalKey(i => i.Id)
				.IsRequired();
		}
	}
}
