using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Domain.UserVerify
{
    public class VerifyUser : AggregateRoot<UserId>
    {
        public PinCode PinCode { get; private set; }
        public DateTime UserCreateDate { get; private set; }
        public DateTime UserRemoveDate { get; private set; }

#pragma warning disable CS8618
        private VerifyUser(UserId id)
            : base(id)
        {
        }
#pragma warning restore CS8618

        private VerifyUser(UserId id, PinCode pinCode, DateTime userCreateDate)
            : base(id)
        {
            PinCode = pinCode;
            UserCreateDate = userCreateDate;
            UserRemoveDate = userCreateDate.AddHours(1);
        }

        public static Result<VerifyUser> Create(User user, string pinCode)
        {
            if (user.Role != UserRoleEnum.Unconfirmed) return Errors.Errors.UserVerify.IncorrectUserRole;
            var newPinCode = PinCode.Create(pinCode);

            if (newPinCode.IsFailure) return newPinCode.Error;
            else
            {
                return new VerifyUser(user.Id, newPinCode.Value, user.RegistrationDate);
            }
        }
    }
}
