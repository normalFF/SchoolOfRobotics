using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Users.ValueObjects
{
    public class Email : ValueObject
    {
        public static readonly int MaxLength = 129;
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Errors.Errors.User.EmptyEmail;
            else if (value.Length > MaxLength) return Errors.Errors.User.MaxLengthEmail(MaxLength);

            return new Email(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
