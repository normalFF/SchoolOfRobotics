using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Queries.Login;

public sealed record LoginQuery(string Email, string Password) : IQuery<LoginQueryResponce>;
