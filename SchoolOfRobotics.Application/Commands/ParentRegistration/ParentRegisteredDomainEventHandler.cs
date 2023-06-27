using MediatR;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Commands.ParentRegistration
{
    internal sealed class ParentRegisteredDomainEventHandler
		: INotificationHandler<ParentRegisteredDomainEvent>
	{
		private readonly IEmailService _emailService;
		private readonly IUserRepository _userRepository;
		public ParentRegisteredDomainEventHandler(IEmailService emailService, IUserRepository userRepository)
		{
			_emailService = emailService;
			_userRepository = userRepository;
		}

		public async Task Handle(ParentRegisteredDomainEvent notification, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetUserByIdAsync(notification.Id, cancellationToken);

			if (user is null || user.Role != UserRoleEnum.Unconfirmed)
			{
				return;
			}

		}
	}
}