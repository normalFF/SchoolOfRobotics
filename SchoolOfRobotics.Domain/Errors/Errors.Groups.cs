using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors
{
	public static partial class Errors
	{
		public static class Groups
		{
			public static Error MinListenersCount(int count) => Error.Validation(
				code: "Group.ListenersCount.MinimalCount",
				description: $"Минимальное количество слушателей не может быть меньше {count}");

			public static Error AgeCannotBeNegative => Error.Validation(
				code: "Group.Age.Negative",
				description: "Значение возраста не может быть минимальным");

			public static Error MinAgeMoreMaxAge => Error.Validation(
				code: "Group.MaxAge.Invalid",
				description: "Максимальный возраст не может быть меньше минимального");

			public static Error MinClassNumberMoreMaxClassNumber => Error.Validation(
				code: "Group.MaxClassNumber.Invalid", 
				description: "Максимальный номер класса не может быть меньше минимального номера класса");

			public static Error EmptyGroupName => Error.Validation(
				code: "Group.Name.Empty", 
				description: $"Не указано название группы");

			public static Error MaxLengthGroupName(int maxLength) => Error.Validation(
				code: "Group.Name.MaxLengthInvalid", 
				description: $"Название группы не может быть более {maxLength} символов");

			public static Error SetStatusInvalid => Error.Failure(
				code: "Group.Status.Invalid",
				description: "Ошибка изменения статуса группы");

			public static Error DateTimeDiapasonInvalid => Error.Validation(
				code: "Group.DateDiapasonInvalid",
				description: "Указан некорректный диапазон даты");

			public static Error SetDateTimeInvalid => Error.Validation(
				code: "Group.DateTime.Invalid",
				description: $"Ошибка изменения диапазона даты набора слушателей для группы");

			public static Error SetDateCompletedCourse => Error.Failure(
				code: "Group.SetDateTime.Invalid",
				description: "Нельзя изменить диапазон даты набора слушателей для группы, завершившей обучение");

			public static Error ChildrenAlreadyExist => Error.Failure(
				code: "CourseGroups.GroupListeners.ChildrenAlreadyExist",
				description: "Ребёнок уже состоит в данной группе");

			public static Error ChildrenAlreadyExistOtherGroup => Error.Failure(
				code: "CourseGroups.GroupListeners.ChildrenAlreadyExistOtherGroup",
				description: "Ребёнок уже состоит в другой группе");

			public static Error IncorrectListenersCount => Error.Failure(
				code: "Course.ListenersCount.Incorrect",
				description: "Недопустимое количество слушателей");

			public static Error MaxListenersCount => Error.Failure(
				code: "CourseGroups.GroupListeners.MaxListenersCount",
				description: "Достигнуто максимальное количество слушателей в группе");

			public static Error ListenerDoesNotMatchGroupConstraint => Error.Failure(
				code: "CourseGroups.ListenerAddGroupInvalid",
				description: "Ребёнок не соответствует требованиям группы");

			public static Error ListenerNotFound => Error.Failure(
				code: "CourseGroups.ListenerNotFound",
				description: "Ребёнок не найден в группе");

			public static Error GroupNotFound => Error.Failure(
				code: "Course.GroupNotFound",
				description: "Группа не найдена");

			public static Error IncorrectClassStatusEnumValue => Error.Validation(
				code: "ClassNumberEnum.Incorrect",
				description: "Недопустимое значение класса");
		}
	}
}
