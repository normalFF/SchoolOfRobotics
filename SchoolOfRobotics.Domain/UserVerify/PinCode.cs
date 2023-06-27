using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.UserVerify
{
    public class PinCode : ValueObject
    {
        public static readonly int PinCodeLength = 6;

        public string Value { get; }

        private PinCode(string value)
        {
            Value = value;
        }

        public static Result<PinCode> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Errors.Errors.UserVerify.PinCodeEmpty;
            else if (value.Length != PinCodeLength) return Errors.Errors.UserVerify.PinCodeIncorrectLength(PinCodeLength);
            else if (string.IsNullOrWhiteSpace(value.Replace('0', ' '))) return Errors.Errors.UserVerify.IncorrectPinCode;
            else
            {
                return new PinCode(value);
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
