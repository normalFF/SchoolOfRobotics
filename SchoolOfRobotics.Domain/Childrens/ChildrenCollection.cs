using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Domain.Childrens
{
    public sealed class ChildrenCollection : AggregateRoot<UserId>
    {
        private readonly List<Children> _childrens;

        public UserRoleEnum Role { get; private set; }
        public IReadOnlyCollection<Children> Childrens => _childrens.AsReadOnly();


#pragma warning disable CS8618
        private ChildrenCollection(UserId id)
            : base(id)
        {
        }
#pragma warning restore CS8618

        private ChildrenCollection(UserId id, UserRoleEnum role)
            : base(id)
        {
            Role = role;
            _childrens = new List<Children>();
        }

        public Result ReplaceChildrenName(ChildrenId childrenId, Name newName)
        {
            if (Childrens.All(i => i.Id != childrenId)) return Errors.Errors.Children.ChildrenNotFound;
            else if (Childrens.Where(i => i.Name == newName && i.Id != childrenId).Count() > 0) return Errors.Errors.Children.ChildrenNameAlreadyExist;
            else
            {
                Childrens.Where(i => i.Id == childrenId).First().ReplaceName(newName);
                return Result.Success();
            }
        }

        public Result AddNewChildren(Name name, DateOfBirth dateOfBirth, ClassNumberEnum classNumber)
        {
            if (Role != UserRoleEnum.Parent) return Errors.Errors.Children.IncorrectUserRole;
            if (Childrens.Where(i => i.Name == name).Count() > 0) return Errors.Errors.Children.ChildrenNameAlreadyExist;
            else
            {
                _childrens.Add(new Children(new ChildrenId(Guid.NewGuid()), Id, name, dateOfBirth, classNumber));
                return Result.Success();
            }
        }
    }
}
