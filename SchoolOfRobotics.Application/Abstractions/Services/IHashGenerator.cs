namespace SchoolOfRobotics.Application.Abstractions.Services
{
	public interface IHashGenerator
	{
		byte[] GetPasswordHash(string password);
	}
}
