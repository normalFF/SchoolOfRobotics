using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
    public class UserRoleEnum : Enumeration<UserRoleEnum>
    {
        public static readonly UserRoleEnum Unconfirmed = new(0, nameof(Unconfirmed));
        public static readonly UserRoleEnum Parent = new(1, nameof(Parent));
        public static readonly UserRoleEnum Teacher = new(2, nameof(Teacher));
        public static readonly UserRoleEnum Administrator = new(3, nameof(Administrator));

        protected UserRoleEnum(int value, string name)
            : base(value, name)
        {

        }
    }
}
