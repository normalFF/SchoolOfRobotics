using SchoolOfRobotics.Domain.Childrens.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.CoursesGroups.Entities
{
	public class GroupListener : Entity<GroupId>
	{
		private readonly List<Listener> _listeners;

		public CourseId CourseId { get; private set; }
		public int MinAge { get; private set; }
		public int MaxAge { get; private set; }
		public ClassNumberEnum MinClassNumber { get; private set; }
		public ClassNumberEnum MaxClassNumber { get; private set; }
		public DateTime RecruitmentStartDate { get; private set; }
		public DateTime EnrollmentEndDate { get; private set; }
		public GroupStatusEnum Status { get; private set; }
		public int ListenersCount { get; private set; }
		public IReadOnlyCollection<Listener> Listeners => _listeners.AsReadOnly();


		#pragma warning disable CS8618
		private GroupListener(GroupId id)
			: base(id)
		{	
		}
		#pragma warning restore CS8618


		internal Result AddListener(Children children)
		{
			if (!_listeners.Select(i => i.ChildrenId).All(i => i != children.Id))
			{
				return Errors.Errors.Groups.ChildrenAlreadyExist;
			}
			else if (ListenersCount >= _listeners.Count)
			{
				return Errors.Errors.Groups.MaxListenersCount;
			}
			else
			{
				var childrenYears = DateTime.Today.Year - children.DateOfBirth.Value.Year;

				if (childrenYears > MaxAge || childrenYears < MinAge)
				{
					return Errors.Errors.Groups.ListenerDoesNotMatchGroupConstraint;
				}
				else if (children.ClassNumber < MinClassNumber || children.ClassNumber > MaxClassNumber)
				{
					return Errors.Errors.Groups.ListenerDoesNotMatchGroupConstraint;
				}

				var newListener = Listener.Create(children.Id, Id, ListenerStatusEnum.Added);
				if (newListener.IsFailure) return newListener.Error;
				else
				{
					_listeners.Add(newListener.Value);
					return Result.Success();
				}
			}
		}

		internal Result RemoveListener(ListenerId id)
		{
			if (!_listeners.Select(i => i.Id).Contains(id))
			{
				return Errors.Errors.Groups.ListenerNotFound;
			}
			else
			{
				_listeners.Where(i => i.Id == id).First().SetStatus(ListenerStatusEnum.Removed);
				return Result.Success();
			}
		}
	}
}
