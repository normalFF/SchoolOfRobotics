using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.GroupLessons
{
    public class LessonDate : Entity<LessonId>
    {
        public GroupId GroupId { get; private set; }
        public LessonStatusEnum Status { get; private set; }
        public LessonTime Time { get; private set; }
        public TeacherId? TeacherId { get; private set; }


#pragma warning disable CS8618
        private LessonDate(LessonId id)
            : base(id)
        {
        }
#pragma warning restore CS8618


        private LessonDate(LessonId id, GroupId groupId, LessonStatusEnum status, LessonTime time)
            : base(id)
        {
            GroupId = groupId;
            Status = status;
            Time = time;
        }

        internal static Result<LessonDate> Create(GroupId groupId, DateTime beginDate, DateTime endDate)
        {
            var time = LessonTime.Create(beginDate, endDate);
            if (time.IsFailure) return time.Error;
            else
            {
                return new LessonDate(new(Guid.NewGuid()), groupId, LessonStatusEnum.Expected, time.Value);
            }
        }

        internal Result SetTime(DateTime begin, DateTime end)
        {
            if (Status == LessonStatusEnum.Done) return Errors.Errors.Lessons.LessonTimeInvalid;
            var newTime = LessonTime.Create(begin, end);
            if (newTime.IsFailure) return newTime.Error;
            else
            {
                Time = newTime.Value;
                return Result.Success();
            }
        }

        internal Result Done(TeacherId teacherId)
        {
            if (Status != LessonStatusEnum.Expected || TeacherId is not null)
            {
                return Errors.Errors.Lessons.SetLessonStatus;
            }
            else
            {
                TeacherId = teacherId;
                Status = LessonStatusEnum.Done;
                return Result.Success();
            }
        }

        internal Result SetStatus(LessonStatusEnum status)
        {
            if (status == LessonStatusEnum.Done
                && DateTime.Now > Time.BeginDate
                && Status == LessonStatusEnum.Expected)
            {
                Status = status;
                return Result.Success();
            }
            else if (status == LessonStatusEnum.Сanceled
                && Status == LessonStatusEnum.Expected)
            {
                Status = status;
                return Result.Success();
            }

            return Errors.Errors.Lessons.SetLessonStatus;
        }
    }
}
