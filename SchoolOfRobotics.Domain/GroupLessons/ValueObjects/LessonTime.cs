using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.GroupLessons.ValueObjects
{
    public class LessonTime : ValueObject
    {
        public static readonly int LessonTimeMax = 120;

        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private LessonTime(DateTime beginDate, DateTime endDate)
        {
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public static Result<LessonTime> Create(DateTime beginDate, DateTime endDate)
        {
            if (beginDate > endDate) return Errors.Errors.Lessons.LessonTimeInvalid;
            var dateDiapason = endDate - beginDate;
            if (dateDiapason.Minutes > LessonTimeMax) return Errors.Errors.Lessons.LessonTimeMaxValue(LessonTimeMax);
            else
            {
                return new LessonTime(beginDate, endDate);
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return BeginDate;
            yield return EndDate;
        }
    }
}
