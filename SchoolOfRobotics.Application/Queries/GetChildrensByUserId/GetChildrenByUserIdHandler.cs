using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Domain.Childrens;

namespace SchoolOfRobotics.Application.Queries.GetChildrensByUserId;

public sealed class GetChildrenByUserIdHandler : IQueryHandler<GetChildrenByUserIdQuety, GetChildrenByUserIdResponce>
{
	private readonly IRequestContext _requestContext;
	private readonly IChildrenCollectionRepository _childrenCollectionRepository;

	public GetChildrenByUserIdHandler(IRequestContext requestContext, IChildrenCollectionRepository childrenCollectionRepository)
	{
		_requestContext = requestContext;
		_childrenCollectionRepository = childrenCollectionRepository;
	}

	public async Task<Result<GetChildrenByUserIdResponce>> Handle(GetChildrenByUserIdQuety request, CancellationToken cancellationToken)
	{
		var userId = new UserId(request.UserId);
		var currentUser = _requestContext.GetCurrentUser();

		if (currentUser is not null)
		{
			if (currentUser.Id == userId || currentUser.Role == UserRoleEnum.Administrator)
			{
				var currentCollection = await _childrenCollectionRepository.GetChildrenCollectionById(userId, cancellationToken);
				if (currentCollection is not null)
				{
					return new GetChildrenByUserIdResponce(currentCollection.Childrens.ToArray());
				}
				return new GetChildrenByUserIdResponce(new Children[] { });
			}
		}
		return Errors.User.UserUndefined;
	}
}
