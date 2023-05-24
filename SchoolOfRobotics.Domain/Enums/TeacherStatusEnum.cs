using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
	public class TeacherStatusEnum : Enumeration<TeacherStatusEnum>
	{
		public static readonly TeacherStatusEnum Included = new(0, "Включён");
		public static readonly TeacherStatusEnum Excluded = new(1, "Исключён");

		private TeacherStatusEnum(int value, string name)
			: base(value, name) 
		{
		}
	}
}
