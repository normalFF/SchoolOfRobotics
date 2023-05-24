using SchoolOfRobotics.Domain.Childrens.ValueObjects;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Childrens.Entities;

public class Children : Entity<ChildrenId>
{
    public UserId UserId { get; private set; }
    public Name Name { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public ClassNumberEnum ClassNumber { get; private set; }

    internal Children(ChildrenId id, UserId userId, Name name, DateOfBirth dateOfBirth, ClassNumberEnum classNumber)
        : base(id)
    {
        UserId = userId;
        Name = name;
        DateOfBirth = dateOfBirth;
        ClassNumber = classNumber;
    }

    #pragma warning disable CS8618
	private Children(ChildrenId id)
		: base(id)
    {
    }
    #pragma warning restore CS8618

	internal void ReplaceName(Name newName)
    {
        Name = newName;
    }

    internal void ReplaceAge(DateOfBirth newDateOfBirth)
    {
        DateOfBirth = newDateOfBirth;
    }

    internal void ReplaceClassNumber(ClassNumberEnum newClassNumber)
    {
        ClassNumber = newClassNumber;
    }
}