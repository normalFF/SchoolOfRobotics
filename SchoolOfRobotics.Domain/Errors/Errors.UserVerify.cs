using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors
{
	public static partial class Errors
	{
		public static class UserVerify
		{
			public static Error IncorrectPinCode => Error.Failure(
				code: "PinCode.FirstName.Empty",
				description: "Неверный пинкод");

			public static Error PinCodeIncorrectLength(int length) => Error.Validation(
				code: "PinCode.Length",
				description: $"Длина пин-кода должна составлять {length} символов");

			public static Error PinCodeEmpty => Error.Validation(
				code: "PinCode.Empty",
				description: "Не указан пин код");

			public static Error IncorrectUserRole => Error.Failure(
				code: "UserVerify.IncorrectUserRole",
				description: "Недопустимый уровень доступа пользователя");
		}
	}
}
