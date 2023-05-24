using SchoolOfRobotics.Application.Abstractions.Services;
using System.Security.Cryptography;
using System.Text;

namespace SchoolOfRobotics.Infrastructure.Authentication;

public class HashCodeGenerator : IHashGenerator
{
	public byte[] GetPasswordHash(string password)
	{
		byte[] bytesResult = Encoding.UTF8.GetBytes(password);

		using (SHA256 sha = SHA256.Create())
		{
			bytesResult = sha.ComputeHash(bytesResult);
		}
		return bytesResult;
	}
}
