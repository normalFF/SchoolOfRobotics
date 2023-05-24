using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Childrens.Entities;
using SchoolOfRobotics.Domain.Childrens.ValueObjects;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class ChildrenConfiguration : IEntityTypeConfiguration<Children>
	{
		public void Configure(EntityTypeBuilder<Children> builder)
		{
			builder.ToTable("Childrens");
			builder.HasKey(x => x.Id);
			builder.Property(k => k.Id)
				.HasConversion(
					childId => childId.Id, 
					id => new(id))
				.HasColumnName("Id")
				.IsRequired();

			builder.Property(p => p.UserId)
				.HasConversion(
					userId => userId.Id,
					id => new(id))
				.HasColumnName("UserId")
				.IsRequired();

			builder.OwnsOne(p => p.Name, ownConf =>
			{
				ownConf.Property(p => p.FirstName)
					.HasMaxLength(Name.FirstNameMaxLength)
					.HasColumnName("FirstName")
					.IsRequired();

				ownConf.Property(p => p.LastName)
					.HasMaxLength(Name.LastNameMaxLength)
					.HasColumnName("LastName")
					.IsRequired();
			});

			builder.Property(p => p.DateOfBirth)
				.HasConversion(
					date => date.Value,
					value => DateOfBirth.Create(value).Value)
				.HasColumnName("DateOfBirth")
				.IsRequired();

			builder.Property(p => p.ClassNumber)
				.HasConversion(
					classNumber => classNumber.Value,
					value => ClassNumberEnum.FromValue(value)!)
				.HasColumnName("ClassNumber")
				.IsRequired();
		}
	}
}
