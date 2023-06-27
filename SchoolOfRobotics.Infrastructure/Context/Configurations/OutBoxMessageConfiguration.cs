using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.OutBoxMessages;
using System.Security.Cryptography.X509Certificates;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
    internal class OutBoxMessageConfiguration : IEntityTypeConfiguration<OutBoxMessage>
	{
		public void Configure(EntityTypeBuilder<OutBoxMessage> builder)
		{
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.IsRequired();

			builder.Property(p => p.Content)
				.HasColumnName("Content")
				.IsRequired();

			builder.Property(p => p.Type)
				.HasColumnName("Type")
				.IsRequired();

			builder.Property(p => p.OccurredDate)
				.HasColumnName("OccurredDate")
				.IsRequired();

			builder.Property(p => p.ExecuteDate)
				.HasColumnName("ExecuteDate");

			builder.Property(p => p.ProcessedDate)
				.HasColumnName("ProcessedDate");

			builder.Property(p => p.Error)
				.HasColumnName("Error");
		}
	}
}
