using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors;

public static partial class Errors
{
	public static class Shared
	{
		public static Error UserAlreadyLogged => Error.Failure(
			code: "UserAlreadyLogged",
			description: "Пользователь уже авторизован");
	}
}
