using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Childrens
{
    public class DateOfBirth : ValueObject
    {
        public static readonly int MinAge = 4;
        public static readonly int MaxAge = 16;

        public DateTime Value { get; private set; }

        private DateOfBirth(DateTime value)
        {
            Value = value;
        }

        public static Result<DateOfBirth> Create(DateTime value)
        {
            if (DateTime.Today.Year - value.Year < MinAge && DateTime.Today.Year - value.Year > MaxAge)
            {
                return Errors.Errors.Children.IncorrectChildrenAge(MinAge, MaxAge);
            }
            return new DateOfBirth(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
