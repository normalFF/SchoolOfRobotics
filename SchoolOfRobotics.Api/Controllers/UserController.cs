using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolOfRobotics.Application.Queries.GetChildrensByUserId;
using SchoolOfRobotics.Contracts.Models.Responces;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ApiController
{
	public UserController(ISender sender, IMapper mapper)
		: base(sender, mapper)
	{
	}

	[Authorize(Roles = nameof(UserRoleEnum.Teacher))]
	[Authorize(Roles = nameof(UserRoleEnum.Administrator))]
	[Authorize(Roles = nameof(UserRoleEnum.Parent))]
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetChildrens(Guid id, CancellationToken cancellationToken)
	{
		var query = new GetChildrenByUserIdQuety(id);
		Result<GetChildrenByUserIdResponce> handlerResponce = await _sender.Send(query, cancellationToken);

		if (handlerResponce.IsFailure)
		{
			return Problem(handlerResponce);
		}
		else 
		{
			ChildrenCollectionResponce responce = _mapper.Map<ChildrenCollectionResponce>(handlerResponce);
			return Ok(responce);
		}
	}
}
