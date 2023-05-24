using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors
{
	public static partial class Errors
	{
		public static class Lessons
		{
			public static Error LessonTimeInvalid => Error.Validation(
				code: "LessonTimeInvalid",
				description: "Некорректный диапазон даты занятия");

			public static Error LessonTimeMaxValue(int maxValue) => Error.Failure(
				code: "LessonTimeMaxValue",
				description: $"Максимальная продолжительность занятия не должна превышать {maxValue} минут");
			
			public static Error SetLessonStatus => Error.Failure(
				code: "LessonStatusInvalid",
				description: "Ошибка изменения статуса занятия");

			public static Error LessonNotFound => Error.Failure(
				code: "LessonNotFound",
				description: "Занятие не найдено");
		}
	}
}
