using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfRobotics.Domain.GroupLessons.Aggregates;
using SchoolOfRobotics.Domain.Groups.Aggregates;

namespace SchoolOfRobotics.Infrastructure.Context.Configurations
{
	internal class GroupLessonConfiguration : IEntityTypeConfiguration<GroupLesson>
	{
		public void Configure(EntityTypeBuilder<GroupLesson> builder)
		{
			builder.ToTable("Groups");
			builder.HasKey(k => k.Id);
			builder.Property(p => p.Id)
				.HasConversion(
					id => id.Id,
					value => new(value))
				.HasColumnName("Id");

			builder.HasOne<Group>()
				.WithOne()
				.HasForeignKey<GroupLesson>(i => i.Id)
				.HasPrincipalKey<Group>(k => k.Id)
				.IsRequired()
				.Metadata.IsRequiredDependent = true;

			builder.HasMany(i => i.Lessons)
				.WithOne()
				.HasForeignKey(i => i.GroupId)
				.HasPrincipalKey(i => i.Id)
				.IsRequired();
		}
	}
}
