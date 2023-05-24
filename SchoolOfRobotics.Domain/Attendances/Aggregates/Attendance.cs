using SchoolOfRobotics.Domain.Attendances.Entities;
using SchoolOfRobotics.Domain.CoursesTeachers.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.GroupLessons.Entities;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Attendances.Aggregates
{
    public class Attendance : AggregateRoot<GroupId>
	{
		private readonly List<Teacher> _teachers;
		private readonly List<LessonDate> _lessons;
		private readonly List<ListenerStatus> _listeners;
		private readonly List<Mark> _marks;

		public CourseId CourseId { get; private set; }
		public GroupStatusEnum Status { get; private set; }
		public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();
		public IReadOnlyCollection<LessonDate> Lessons => _lessons.AsReadOnly();
		public IReadOnlyCollection<Mark> Marks => _marks.AsReadOnly();
		public IReadOnlyCollection<ListenerStatus> Listeners => _listeners.AsReadOnly();

		
		#pragma warning disable CS8618
		private Attendance(GroupId id)
			: base(id)
		{
		}
		#pragma warning restore CS8618


		private Attendance(
			GroupId id,
			CourseId courseId,
			List<Teacher> teachers,
			List<LessonDate> lessons,
			List<Mark> attendances,
			List<ListenerStatus> listeners,
			GroupStatusEnum status)
			: base(id)
		{
			_teachers = teachers;
			_lessons = lessons;
			_marks = attendances;
			_listeners = listeners;
			Status = status;
			CourseId = courseId;
		}

		public Result MarkVisitListeners(UserId user, LessonId lessonId, Dictionary<ListenerId, MarkStatusEnum> listenersStatus)
		{
			if (Status != GroupStatusEnum.Open) return Errors.Errors.Attendance.MarkStatusError;
			else
			{
				if (!Teachers.Select(i => i.UserId).Contains(user))
				{
					return Errors.Errors.Course.TeacherNotFound;
				}
				else if (!Lessons.Select(i => i.Id).Contains(lessonId))
				{
					return Errors.Errors.Lessons.LessonNotFound;
				}
				else
				{
					var currentLesson = _lessons.Where(i => i.Id == lessonId).First();
					if (currentLesson.Status == LessonStatusEnum.Expected)
					{
						var absentsListeners = Listeners.Where(i =>
															i.Status == ListenerStatusEnum.Removed
															|| !listenersStatus.ContainsKey(i.Id))
														.Select(i => i.Id);

						Result<Mark> newAttendance;
						foreach (var item in absentsListeners)
						{
							newAttendance = Mark.Create(Id, lessonId, item, MarkStatusEnum.Absent);
							if (newAttendance.IsFailure)
							{
								return newAttendance.Error;
							}
							_marks.Add(newAttendance.Value);
						}
						foreach (var item in listenersStatus)
						{
							newAttendance = Mark.Create(Id, lessonId, item.Key, item.Value);
							if (newAttendance.IsFailure)
							{
								return newAttendance.Error;
							}
							_marks.Add(newAttendance.Value);
						}

						return currentLesson.Done(Teachers.Where(i => i.UserId == user).First().Id);
					}
					else if (currentLesson.Status == LessonStatusEnum.Done)
					{
						Result<Mark> newAttendance;
						foreach (var item in listenersStatus)
						{
							newAttendance = Mark.Create(Id, lessonId, item.Key, item.Value);
							if (newAttendance.IsFailure)
							{
								return newAttendance.Error;
							}
							_marks.Add(newAttendance.Value);
						}
						return Result.Success();
					}

					return Errors.Errors.Attendance.MarkLessonStatusError;
				}
			}
		}
	}
}
