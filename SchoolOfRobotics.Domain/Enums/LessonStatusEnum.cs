using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
	public class LessonStatusEnum : Enumeration<LessonStatusEnum>
	{
		public static readonly LessonStatusEnum Expected = new(0, "Ожидается");
		public static readonly LessonStatusEnum Done = new(1, "Проведён");
		public static readonly LessonStatusEnum Сanceled = new(2, "Отменён");

		public LessonStatusEnum(int value, string name)
			: base(value, name)
		{
		}
	}
}
