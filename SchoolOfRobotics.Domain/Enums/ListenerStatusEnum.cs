using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
    public class ListenerStatusEnum : Enumeration<ListenerStatusEnum>
    {
        public static readonly ListenerStatusEnum Added = new ListenerStatusEnum(0, "Добавлен");
        public static readonly ListenerStatusEnum Removed = new ListenerStatusEnum(1, "Удалён");

        public ListenerStatusEnum(int value, string name)
            : base(value, name)
        {
        }
    }
}
