using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
	public class MarkStatusEnum : Enumeration<MarkStatusEnum>
	{
		public static readonly MarkStatusEnum Attended = new(0, "Был");
		public static readonly MarkStatusEnum Absent = new(1, "Отсутствовал");

		private MarkStatusEnum(int value, string name)
			: base(value, name) 
		{
		}
	}
}
