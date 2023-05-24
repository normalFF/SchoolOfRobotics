using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors;

public static partial class Errors
{
	public static class Attendance
	{
		public static Error MarkStatusError => Error.Failure(
			code: "Attendance.MarkVisitListeners.StatusError",
			description: "Внести изменения в журнал можно только у открытой группы");

		public static Error MarkLessonStatusError => Error.Failure(
			code: "Attendance.MarkVisitListeners.LessonStatus.Сanceled",
			description: $"Нельзя внести изменения в занятие со статусом \"Отменён\"");
	}
}
