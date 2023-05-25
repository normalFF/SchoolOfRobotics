using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Users.Aggregates;
using SchoolOfRobotics.Domain.Users.ValueObjects;
using SchoolOfRobotics.Domain.Errors;

namespace SchoolOfRobotics.Application.Commands.TeacherRegistration;

public class TeacherRegistrationCommandHandler : ICommandHandler<TeacherRegistrationCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserRepository _userRepository;
	private readonly IHashGenerator _hashPasswordGeneratorService;

	public TeacherRegistrationCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IHashGenerator hashPasswordGeneratorService)
	{
		_unitOfWork = unitOfWork;
		_userRepository = userRepository;
		_hashPasswordGeneratorService = hashPasswordGeneratorService;
	}

	public async Task<Result> Handle(TeacherRegistrationCommand request, CancellationToken cancellationToken)
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
				var newUser = User.CreateTeacher(
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
