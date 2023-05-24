using SchoolOfRobotics.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users.Aggregates;
using SchoolOfRobotics.Domain.Users.ValueObjects;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)  
		{
			builder.ToTable("Users");
			builder.HasKey(k => k.Id);
			builder.Property(k => k.Id)
				.HasConversion(
					userId => userId.Id, 
					id => new UserId(id))
				.HasColumnName("Id")
				.IsRequired();
			
			builder.HasIndex(i => i.Email).IsUnique();
			builder.Property(p => p.Email)
				.HasConversion(
					userEmail => userEmail.Value,
					value => Email.Create(value).Value)
				.HasMaxLength(Email.MaxLength)
				.HasColumnName("Email")
				.IsRequired();

			builder.Property(p => p.Password)
				.HasConversion(
					userPassword => userPassword.Value,
					value => Password.Create(value).Value)
				.HasMaxLength(Password.HashLength)
				.HasColumnName("Password")
				.IsRequired();

			builder.OwnsOne(o => o.Name, nameBuilder =>
			{
				nameBuilder.Property(p => p.FirstName)
						.HasMaxLength(FullName.FirstNameMaxLength)
						.HasColumnName("FirstName")
						.IsRequired();

				nameBuilder.Property(p => p.LastName)
						.HasMaxLength(FullName.LastNameMaxLength)
						.HasColumnName("LastName")
						.IsRequired();

				nameBuilder.Property(p => p.Patronymic)
						.HasMaxLength(FullName.PatronymicMaxLength)
						.HasColumnName("Patronymic")
						.IsRequired();
			});

			builder.Property(i => i.Role)
				.HasConversion(
					role => role.Value,
					value => UserRoleEnum.FromValue(value)!)
				.HasColumnName("Role")
				.IsRequired();
		}
	}
}
