using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Users.ValueObjects
{
    public class Password : ValueObject
    {
        public static readonly int PasswordMinLength = 6;
        public static readonly int HashLength = 256;

        public byte[] Value { get; }

        private Password(byte[] value)
        {
            Value = value;
        }

        public static Result<Password> Create(byte[] password)
        {
            if (password is null || password.Length != HashLength) return Primitives.Results.Error.Failure(string.Empty, string.Empty);
            else return new Password(password);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
