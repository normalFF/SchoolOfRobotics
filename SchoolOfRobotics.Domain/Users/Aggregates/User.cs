using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Users.Events;
using SchoolOfRobotics.Domain.Users.ValueObjects;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Domain.Users.Aggregates;

public class User : AggregateRoot<UserId>
{
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public UserRoleEnum Role { get; private set; }
    public DateTime RegistrationDate { get; private set; }

    private User(UserId id, FullName name, Email email, Password password, DateTime registrationDate, UserRoleEnum role)
        : base(id)
    {
        Name = name;
        Email = email;
        RegistrationDate = registrationDate;
        Password = password;
        Role = role;
    }

    #pragma warning disable CS8618
	private User(UserId id)
	    : base(id)
	{
	}
    #pragma warning restore CS8618


    public static Result<User> CreateParent(string firstName, string lastName, string patronymic, string email, byte[] password)
    {
        var newUser = CreateUser(firstName, lastName, patronymic, email, password, UserRoleEnum.Unconfirmed);
        if (newUser.IsSuccess) newUser.Value.RaiseDomainEvent(new ParentRegisteredDomainEvent(newUser.Value.Id));
        return newUser;
    }

    public static Result<User> CreateTeacher(string firstName, string lastName, string patronymic, string email, byte[] password)
    {
        return CreateUser(firstName, lastName, patronymic, email, password, UserRoleEnum.Teacher);
    }

    private static Result<User> CreateUser(string firstName, string lastName, string patronymic, string email, byte[] password, UserRoleEnum role)
    {
		var userName = FullName.Create(firstName, lastName, patronymic);
		var userEmail = Email.Create(email);
		var userPassword = Password.Create(password);

		if (userName.IsFailure) return userName.Error;
		else if (userEmail.IsFailure) return userEmail.Error;
		else if (userPassword.IsFailure) return userPassword.Error;
		else
		{
            return new User(new UserId(Guid.NewGuid()), userName.Value, userEmail.Value, userPassword.Value, DateTime.UtcNow, role);
		}
	}


    public void ReplacePassword(Password newPassword)
    {
        Password = newPassword;
    }

    public void ReplaceName(FullName newName)
    {
        Name = newName;
    }

    public void ReplaceEmail(Email newEmail)
    {
        Email = newEmail;
    }

    public Result ReplaceRole(UserRoleEnum newRole)
    {
        if (newRole == UserRoleEnum.Unconfirmed) return Errors.Errors.User.UnconfirmedRole;
        else
        {
            Role = newRole;
            return Result.Success();
        }
    }
}