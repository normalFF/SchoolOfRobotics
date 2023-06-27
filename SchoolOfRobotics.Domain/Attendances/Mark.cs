using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Attendances;

public class Mark : Entity<MarkId>
{
    public LessonId LessonId { get; set; }
    public GroupId GroupId { get; private set; }
    public ListenerId ListenerId { get; private set; }
    public MarkStatusEnum Status { get; private set; }


#pragma warning disable CS8618
    private Mark(MarkId id)
        : base(id)
    {
    }
#pragma warning restore CS8618


    private Mark(MarkId id, LessonId lessonId, GroupId groupId, ListenerId listenerId, MarkStatusEnum status)
        : base(id)
    {
        GroupId = groupId;
        LessonId = lessonId;
        ListenerId = listenerId;
        Status = status;
    }

    internal static Result<Mark> Create(GroupId groupId, LessonId lessonId, ListenerId listenerId, MarkStatusEnum status)
    {
        return new Mark(new(Guid.NewGuid()), lessonId, groupId, listenerId, status);
    }

    internal void SetStatus(MarkStatusEnum status)
    {
        Status = status;
    }
}
