namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record SetGroupStatusRequest(Guid GroupId, int StatusValue);
