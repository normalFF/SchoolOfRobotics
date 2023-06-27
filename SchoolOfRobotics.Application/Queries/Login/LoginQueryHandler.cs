using MediatR;
using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Queries.Login;

public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginQueryResponce>
{
    private readonly IRequestContext _requestContext;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public LoginQueryHandler(IRequestContext requestContext, IUserRepository userRepository, IJwtTokenGenerator tokenGenerator)
    {
        _requestContext = requestContext;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

	public async Task<Result<LoginQueryResponce>> Handle(LoginQuery request, CancellationToken cancellationToken)
	{
		var currentUserContext = _requestContext.GetCurrentUser();
		if (currentUserContext is not null)
		{
			return Errors.Shared.UserAlreadyLogged;
		}
		else
		{
			var userEmail = Email.Create(request.Email);
			if (userEmail.IsFailure)
			{
				return userEmail.Error;
			}
			else
			{
				currentUserContext = await _userRepository.GetUserByEmailAsync(userEmail.Value, cancellationToken);

				if (currentUserContext is null || currentUserContext.Role == Domain.Enums.UserRoleEnum.Unconfirmed)
				{
					return Errors.User.UserNotFound;
				}
				else
				{
					return new LoginQueryResponce(_tokenGenerator.GenerateToken(currentUserContext));
				}
			}
		}
	}
}
