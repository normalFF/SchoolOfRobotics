using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
    public class CourseStatusEnum : Enumeration<CourseStatusEnum>
    {
        public static readonly CourseStatusEnum Close = new(0, "Закрыт");
        public static readonly CourseStatusEnum Open = new(1, "Открыт");

        public CourseStatusEnum(int value, string name)
            : base(value, name)
        {

        }
    }
}
