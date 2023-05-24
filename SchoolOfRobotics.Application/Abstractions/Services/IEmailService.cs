namespace SchoolOfRobotics.Application.Abstractions.Services
{
	public interface IEmailService
	{
		Task SendParentRegistrationEmailPinCode(string email, string pinCode);
	}
}
