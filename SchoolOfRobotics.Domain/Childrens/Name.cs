using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Childrens
{
    public class Name : ValueObject
    {
        public static readonly int FirstNameMaxLength = 25;
        public static readonly int LastNameMaxLength = 25;

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<Name> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return Errors.Errors.Children.EmptyFirstName;
            else if (firstName.Length > FirstNameMaxLength) return Errors.Errors.Children.MaxLengthFirstName(FirstNameMaxLength);
            else if (string.IsNullOrWhiteSpace(lastName)) return Errors.Errors.Children.EmptyLastName;
            else if (lastName.Length > LastNameMaxLength) return Errors.Errors.Children.MaxLengthLastName(LastNameMaxLength);
            else return new Name(firstName, lastName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
