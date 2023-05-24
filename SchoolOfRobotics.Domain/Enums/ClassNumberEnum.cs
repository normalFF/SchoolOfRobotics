using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Enums
{
    public class ClassNumberEnum : Enumeration<ClassNumberEnum>
    {
        public static readonly ClassNumberEnum Preschooler = new(0, "Дошкальник");
        public static readonly ClassNumberEnum ClassOne = new(1, "1-ый класс");
        public static readonly ClassNumberEnum ClassTwo = new(2, "2-ой класс");
        public static readonly ClassNumberEnum ClassThree = new(3, "3-ий класс");
        public static readonly ClassNumberEnum ClassFour = new(4, "4-ый класс");
        public static readonly ClassNumberEnum ClassFive = new(5, "5-ый класс");
        public static readonly ClassNumberEnum ClassSix = new(6, "6-ой класс");
        public static readonly ClassNumberEnum ClassSeven = new(7, "7-ой класс");
        public static readonly ClassNumberEnum ClassEight = new(8, "8-ой класс");
        public static readonly ClassNumberEnum ClassNine = new(9, "9-ый класс");
        public static readonly ClassNumberEnum ClassTen = new(10, "10-ый класс");
        public static readonly ClassNumberEnum ClassEleven = new(11, "11-ый класс");
        public static readonly ClassNumberEnum Graduate = new(12, "Выпускник");

        private ClassNumberEnum(int value, string name)
            : base(value, name)
        {
        }
    }
}
