using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.GroupLessons;

public class GroupLesson : AggregateRoot<GroupId>
{
    private List<LessonDate> _lessons;

    public IReadOnlyCollection<LessonDate> Lessons => _lessons.AsReadOnly();


#pragma warning disable CS8618
    private GroupLesson(GroupId id)
        : base(id)
    {
    }
#pragma warning restore CS8618


    private GroupLesson(GroupId id, List<LessonDate> lessons)
        : base(id)
    {
        _lessons = lessons;
    }


    public Result AddLesson(DateTime beginDate, DateTime endDate)
    {
        if (beginDate < DateTime.Now) return Errors.Errors.Lessons.LessonTimeInvalid;
        else if (_lessons.Any(i => i.Time.BeginDate <= beginDate && i.Time.EndDate >= beginDate)
            || _lessons.Any(i => i.Time.BeginDate <= endDate && i.Time.EndDate >= endDate))
        {
            return Errors.Errors.Lessons.LessonTimeInvalid;
        }
        else
        {
            var newLesson = LessonDate.Create(Id, beginDate, endDate);
            if (newLesson.IsFailure) return newLesson.Error;
            else
            {
                _lessons.Add(newLesson.Value);
                return Result.Success();
            }
        }
    }

    public Result ReplaceLessonDate(LessonId lessonId, DateTime beginDate, DateTime endDate)
    {
        if (!_lessons.Select(i => i.Id).Contains(lessonId))
        {
            return Errors.Errors.Lessons.LessonNotFound;
        }
        return _lessons.First(i => i.Id == lessonId).SetTime(beginDate, endDate);
    }
}
