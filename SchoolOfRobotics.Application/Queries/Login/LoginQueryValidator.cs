using FluentValidation;
using SchoolOfRobotics.Domain.Users.ValueObjects;

namespace SchoolOfRobotics.Application.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(p => p.Email).MaximumLength(Email.MaxLength).NotEmpty();
        RuleFor(p => p.Password).NotEmpty();
    }
}
