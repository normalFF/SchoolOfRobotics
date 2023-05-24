using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolOfRobotics.Application.Commands.CreateCourse;
using SchoolOfRobotics.Application.Commands.CreateGroup;
using SchoolOfRobotics.Application.Commands.SetCourseStatus;
using SchoolOfRobotics.Contracts.Models.Requests;
using SchoolOfRobotics.Contracts.Models.Responces;
using SchoolOfRobotics.Domain.Enums;

namespace SchoolOfRobotics.Api.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = nameof(UserRoleEnum.Administrator))]
public class AdminController : ApiController
{
	public AdminController(ISender sender, IMapper mapper)
		: base(sender, mapper)
	{
	}

	public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreateCourseCommand>(request);
		var responce = await _sender.Send(command, cancellationToken);
		return responce.IsSuccess ? Ok(_mapper.Map<CreateCourseResponce>(responce.Value)) : Problem(responce.Error);
	}

	public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<CreateGroupCommand>(request);
		var responce = await _sender.Send(command, cancellationToken);
		return responce.IsSuccess ? Ok(_mapper.Map<CreateGroupResponce>(responce.Value)) : Problem(responce.Error);
	}

	public async Task<IActionResult> SetCourseStatus([FromBody] SetCourseStatusRequest request, CancellationToken cancellationToken)
	{
		var command = _mapper.Map<SetCourseStatusCommand>(request);
		var responce = await _sender.Send(command, cancellationToken);
		return responce.IsSuccess ? Ok(_mapper.Map<SetCourseStatusResponce>(responce.Value)) : Problem(responce.Error);
	}
}
