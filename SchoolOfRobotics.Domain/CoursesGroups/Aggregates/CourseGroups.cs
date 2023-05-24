using SchoolOfRobotics.Domain.Childrens.Entities;
using SchoolOfRobotics.Domain.CoursesGroups.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.CoursesGroups.Aggregates
{
	public class CourseGroups : AggregateRoot<CourseId>
	{
		private readonly List<GroupListener> _groups;

		public CourseStatusEnum Status { get; private set; }
		public IReadOnlyCollection<GroupListener> Groups => _groups.AsReadOnly();


		#pragma warning disable CS8618
		private CourseGroups(CourseId id)
			: base(id)
		{
		}
		#pragma warning restore CS8618


		private CourseGroups(CourseId id, List<GroupListener> groups, CourseStatusEnum status)
			: base(id)
		{
			_groups = groups;
			Status = status;
		}


		public Result AddListener(GroupId id, Children children)
		{
			if (Status == CourseStatusEnum.Close)
			{
				return Errors.Errors.Course.CourseClosed;
			}
			if (!_groups.Select(i => i.Id).Contains(id))
			{
				return Errors.Errors.Groups.GroupNotFound;
			}
			else
			{
				foreach (var g in _groups)
				{
					foreach (var l in g.Listeners)
					{
						if (l.ChildrenId == children.Id && l.Status != ListenerStatusEnum.Removed)
						{
							return Errors.Errors.Groups.ChildrenAlreadyExistOtherGroup;
						}
					}
				}
				_groups.Where(i => i.Id == id).First().AddListener(children);
				return Result.Success();
			}
		}

		public Result RemoveListener(GroupId groupId, ListenerId listenerId)
		{
			if (!_groups.Select(i => i.Id).Contains(groupId))
			{
				return Errors.Errors.Groups.GroupNotFound;
			}
			else
			{
				_groups.Where(i => i.Id == groupId).First().RemoveListener(listenerId);
				return Result.Success();
			}
		}
	}
}
