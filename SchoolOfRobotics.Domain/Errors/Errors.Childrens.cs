using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors
{
	public static partial class Errors
	{
		public static class Children
		{
			public static Error EmptyFirstName => Error.Validation(
				code: "Children.FirstName.Empty", 
				description: "Не указано имя");

			public static Error MaxLengthFirstName(int maxLength) => Error.Validation(
				code: "Children.FirstName.MaxLength", 
				description: $"Длина имени не может быть более {maxLength} символов");

			public static Error EmptyLastName => Error.Validation(
				code: "Children.LastName.Empty", 
				description: "Не указана фамилия");

			public static Error MaxLengthLastName(int maxLength) => Error.Validation(
				code: "Children.LastName.MaxLength", 
				description: $"Длина фамилии не может быть более {maxLength} символов");

			public static Error ChildrenNotFound => Error.NotFound(
				code: "Children.NotFound",
				description: "Ребёнок не найден");
			
			public static Error ChildrenNameAlreadyExist => Error.Conflict(
				code: "Children.AlreadyExist", 
				description: "Ребёнок с такими данными уже существует");

			public static Error IncorrectChildrenAge(int minAge, int maxAge) => Error.Failure(
				code: "Children.Age.Incorrect",
				description: $"Возраст ребёнка должен быть от {minAge} до {maxAge} лет");

			public static Error IncorrectUserRole => Error.Failure(
				code: "Children.IncorrectUserRole",
				description: "Регистрировать детей могут только родители");
		}
	}
}
