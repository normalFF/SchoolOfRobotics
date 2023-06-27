using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Commands.ParentRegistration;

public class ParentRegistrationHandler : ICommandHandler<ParentRegistrationCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserRepository _userRepository;
	private readonly IHashGenerator _hashPasswordGeneratorService;

	public ParentRegistrationHandler(
		IUnitOfWork unitOfWork,
		IUserRepository userRepository,
		IHashGenerator hashPasswordGeneratorService)
	{
		_unitOfWork = unitOfWork;
		_userRepository = userRepository;
		_hashPasswordGeneratorService = hashPasswordGeneratorService;
	}

	public async Task<Result> Handle(ParentRegistrationCommand request, CancellationToken cancellationToken)
	{
		Result<Email> emailResult = Email.Create(request.Email);

		if (emailResult.IsFailure)
		{
			return emailResult.Error;
		}
		else
		{
			User? userByEmail = await _userRepository.GetUserByEmailAsync(emailResult.Value, cancellationToken);

			if (userByEmail is not null)
			{
				return Errors.User.DublicateEmail;
			}
			else
			{
				var newUser = User.CreateParent(
					request.FirstName,
					request.LastName,
					request.Patronymic,
					request.Email,
					_hashPasswordGeneratorService.GetPasswordHash(request.Password));

				if (newUser.IsFailure) return newUser.Error;
				else
				{
					_userRepository.CreateUser(newUser.Value);
					await _unitOfWork.SaveChangesAsync(cancellationToken);
					return Result.Success();
				}
			}
		}
	}
}
