using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
    public class GroupStatusEnum : Enumeration<GroupStatusEnum>
    {
        public static readonly GroupStatusEnum Closed = new(0, "Закрыта");
        public static readonly GroupStatusEnum Open = new(1, "Открыта");
        public static readonly GroupStatusEnum Completed = new(2, "Завершила курс");

        public GroupStatusEnum(int value, string name)
            : base(value, name)
        {
        }
    }
}
