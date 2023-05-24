using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly ISender _sender;
	protected readonly IMapper _mapper;

	public ApiController(ISender sender, IMapper mapper)
	{
		_sender = sender;
		_mapper = mapper;
	}

	protected IActionResult Problem(Result result) =>
		result switch
		{
			{ IsSuccess: true } => throw new InvalidOperationException(),
			IValidationResult validationResult => 
			BadRequest(
				CreateProblemDetails(
					"Ошибка при проверки модели", StatusCodes.Status400BadRequest, result.Error, validationResult.Errors)),
			_ =>
			BadRequest(
				CreateProblemDetails(
					"Bad request", StatusCodes.Status400BadRequest, result.Error))
		};

	private static ProblemDetails CreateProblemDetails(
		string title,
		int status,
		Error error,
		Error[]? errors = null) => new()
		{
			Title = title,
			Type = error.Code,
			Detail = error.Description,
			Status = status,
			Extensions = { { nameof(errors), errors } }
		};
}