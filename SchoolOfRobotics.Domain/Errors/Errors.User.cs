using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors;

public static partial class Errors
{
	public static class User
    {
		public static Error UserNotFound => Error.NotFound(
			code: "UserNotFound",
			description: "Пользователь не найден");

		public static Error UserUndefined => Error.Failure(
			code: "UserUndefined",
			description: "Пользователь неопределён");

        public static Error DublicateEmail => Error.Conflict(
			code: "User.DuplicateEmail", 
			description: "Пользователь с данной почтой уже существует");

        public static Error EmptyFirstName => Error.Validation(
			code: "User.FirstName.Empty", 
			description: "Не указано имя");

        public static Error MaxLengthFirstName(int maxLength) => Error.Validation(
			code: "User.FirstName.MaxLength", 
			description: $"Длина не может быть более {maxLength} символов");

		public static Error EmptyLastName => Error.Validation(
			code: "User.LastName.Empty", 
			description: "Не указана фамилия");

		public static Error MaxLengthLastName(int maxLength) => Error.Validation(
			code: "User.LastName.MaxLength", 
			description: $"Длина не может быть более {maxLength} символов");

		public static Error EmptyPatronymic => Error.Validation(
			code: "User.Patronymic.Empty", 
			description: "Не указано отчество");
		
		public static Error MaxLengthPatronymic(int maxLength) => Error.Validation(
			code: "User.Patronymic.MaxLength", 
			description: $"Длина не может быть более {maxLength} символов");

		public static Error EmptyEmail => Error.Validation(
			code: "User.Email.Empty",
			description: "Не указан email");

        public static Error MaxLengthEmail(int maxLength) => Error.Validation(
			code: "User.Email.MaxLength", 
			description: $"Длина не может быть более {maxLength} символов");

        public static Error PasswordEmpty => Error.Validation(
			code: "Password.Empty", 
			description: "Не указан пароль");

		public static Error UnconfirmedRole => Error.Failure(
			code: "User.Role.Unconfirmed",
			description: "Статус Unconfirmed присваивается пользователям не прошедшим верификацию");
	}
}