using FluentValidation;
using SchoolOfRobotics.Domain.Groups;

namespace SchoolOfRobotics.Application.Commands.CreateGroup;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
	public CreateGroupCommandValidator()
	{
		RuleFor(p => p.GroupName).MaximumLength(GroupName.MaxNameLength).NotEmpty().NotNull();
	}
}
