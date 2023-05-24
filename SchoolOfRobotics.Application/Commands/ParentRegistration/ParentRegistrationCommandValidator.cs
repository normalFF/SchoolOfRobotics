using FluentValidation;
using SchoolOfRobotics.Domain.Users.ValueObjects;

namespace SchoolOfRobotics.Application.Commands.ParentRegistration
{
	public class ParentRegistrationCommandValidator : AbstractValidator<ParentRegistrationCommand>
	{
		public ParentRegistrationCommandValidator() 
		{
			RuleFor(x => x.FirstName).NotEmpty().MaximumLength(FullName.FirstNameMaxLength);
			RuleFor(x => x.LastName).NotEmpty().MaximumLength(FullName.LastNameMaxLength);
			RuleFor(x => x.Patronymic).MaximumLength(FullName.PatronymicMaxLength);
			RuleFor(x => x.Email).NotEmpty().MaximumLength(Email.MaxLength);
			RuleFor(x => x.Password).NotEmpty().MinimumLength(Password.PasswordMinLength);
		}
	}
}
