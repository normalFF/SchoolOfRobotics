using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors;

public static partial class Errors
{
	public static class News
	{
		public static Error NewsNameEmpty => Error.Validation(
			code: "NewsName.Empty",
			description: "Название новости не может быть пустым значением");

		public static Error NewsDescriptionEmpty => Error.Validation(
			code: "NewsDescription.Empty",
			description: "Описание новости не может быть пустым значением");
	}
}
