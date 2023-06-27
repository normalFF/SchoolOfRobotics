using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.CoursesGroups;

public class Listener : Entity<ListenerId>
{
    public ChildrenId ChildrenId { get; private set; }
    public GroupId GroupId { get; private set; }
    public ListenerStatusEnum Status { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime StatusUpdateDate { get; private set; }

    private Listener(ListenerId id, ChildrenId childrenId, GroupId groupId, ListenerStatusEnum status, DateTime createDate)
        : base(id)
    {
        ChildrenId = childrenId;
        GroupId = groupId;
        Status = status;
        CreateDate = createDate;
        StatusUpdateDate = createDate;
    }

    internal static Result<Listener> Create(ChildrenId childrenId, GroupId groupId, ListenerStatusEnum status)
    {
        return new Listener(new(Guid.NewGuid()), childrenId, groupId, status, DateTime.UtcNow);
    }

    internal void SetStatus(ListenerStatusEnum newListenerStatus)
    {
        Status = newListenerStatus;
        StatusUpdateDate = DateTime.Now;
    }
}
