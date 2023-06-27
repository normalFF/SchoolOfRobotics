using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users;
using SchoolOfRobotics.Domain.UserVerify.Aggregates;
using SchoolOfRobotics.Domain.UserVerify.ValueObjects;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
    internal class VerifyUserConfiguration : IEntityTypeConfiguration<VerifyUser>
	{
		public void Configure(EntityTypeBuilder<VerifyUser> builder)
		{
			builder.ToTable("VerifyUsers");
			builder.HasKey(x => x.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					userId => userId.Id,
					id => new UserId(id))
				.HasColumnName("Id");

			builder.HasOne<User>().WithOne().HasForeignKey<VerifyUser>(i => i.Id);

			builder.Property(p => p.PinCode).HasConversion(
				code => code.Value,
				value => PinCode.Create(value).Value)
			.HasMaxLength(PinCode.PinCodeLength)
			.HasColumnName("PinCode");

			builder.Property(p => p.UserCreateDate).HasColumnName("UserCreateDate");
			builder.Property(p => p.UserRemoveDate).HasColumnName("RemoveCreateDate");
		}
	}
}
