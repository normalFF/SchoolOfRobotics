using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Users.ValueObjects
{
    public sealed class FullName : ValueObject
    {
        public static readonly int FirstNameMaxLength = 25;
        public static readonly int LastNameMaxLength = 25;
        public static readonly int PatronymicMaxLength = 25;

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Patronymic { get; private set; }

		private FullName(string firstName, string lastName, string patronymic)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public static Result<FullName> Create(string firstName, string lastName, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return Errors.Errors.User.EmptyFirstName;
            else if (firstName.Length > FirstNameMaxLength) return Errors.Errors.User.MaxLengthFirstName(FirstNameMaxLength);
            else if (string.IsNullOrWhiteSpace(lastName)) return Errors.Errors.User.EmptyLastName;
            else if (lastName.Length > LastNameMaxLength) return Errors.Errors.User.MaxLengthLastName(LastNameMaxLength);
            else if (string.IsNullOrWhiteSpace(patronymic)) return Errors.Errors.User.EmptyPatronymic;
            else if (patronymic.Length > PatronymicMaxLength) return Errors.Errors.User.MaxLengthPatronymic(PatronymicMaxLength);
            else
            {
                return new FullName(firstName, lastName, patronymic);
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
            yield return Patronymic;
        }
    }
}
