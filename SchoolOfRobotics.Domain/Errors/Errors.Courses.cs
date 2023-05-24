using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors
{
	public static partial class Errors
	{
		public static class Course
		{
			public static Error InvalidStatus => Error.Validation(
				code: "Course.Status.Invalid",
				description: "Некорректное значение статуса");

			public static Error CourseNotFound => Error.Failure(
				code: "Course.NotFound",
				description: "Курс не найден");

			public static Error EmptyCourseDescription => Error.Validation(
				code: "Course.Description.Empty",
				description: "Отсутствует описание курса");

			public static Error CourseDescriptionMaxLength(int maxLength) => Error.Validation(
				code: "Course.Description.MaxLength",
				description: $"Максимальная длина описания курса состовляет {maxLength} символов");

			public static Error CourseNameAlreabyExist => Error.Conflict(
				code: "Course.Name.AlreabyExist",
				description: "Курс с таким названием уже существует");

			public static Error EmptyCourseName => Error.Validation(
				code: "Course.Description.Empty",
				description: "Отсутствует описание курса");

			public static Error CourseNameMaxLength(int maxLength) => Error.Validation(
				code: "Course.Name.MaxLength",
				description: $"Максимальная длина названия курса состовляет {maxLength} символов");

			public static Error IncorrectTeacherRole => Error.Validation(
				code: "Teacher.Role.Incorrect",
				description: "Пользователь с данным уровнем не может быть преподавателем");

			public static Error TeacherNotFound => Error.Failure(
				code: "Teacher.NotFound",
				description: "Преподаватель с данным идентификатором не найден");

			public static Error CourseClosed => Error.Failure(
				code: "Course.Closed",
				description: "Операция невозможна так как курс закрыт");
		}
	}
}
