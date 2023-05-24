using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Attendances.Entities;


public class ListenerStatus : Entity<ListenerId>
{
	public GroupId GroupId { get; private set; }
	public ListenerStatusEnum Status { get; private set; }


	#pragma warning disable CS8618
	private ListenerStatus(ListenerId id)
		: base(id)
	{
	}
	#pragma warning restore CS8618


	private ListenerStatus(ListenerId id, GroupId groupId, ListenerStatusEnum status)
		: base(id)
	{
		GroupId = groupId;
		Status = status;
	}
}
