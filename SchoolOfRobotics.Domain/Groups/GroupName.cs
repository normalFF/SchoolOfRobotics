using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Groups
{
    public class GroupName : ValueObject
    {
        public static readonly int MaxNameLength = 30;

        public string Value { get; set; }

        private GroupName(string value)
        {
            Value = value;
        }

        public static Result<GroupName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Errors.Errors.Groups.EmptyGroupName;
            else if (value.Length > MaxNameLength) return Errors.Errors.Groups.MaxLengthGroupName(MaxNameLength);
            else
            {
                return new GroupName(value);
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
