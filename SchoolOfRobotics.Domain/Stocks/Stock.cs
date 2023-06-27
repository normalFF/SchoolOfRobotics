using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Stocks;

public class Stock : AggregateRoot<StockId>
{
	public StockName Name { get; private set; }
	public StockDescription Description { get; private set; }
	public StockDate Date { get; private set; }


	#pragma warning disable CS8618
	private Stock(StockId id)
		: base(id)
	{
	}
	#pragma warning restore CS8618


	private Stock(StockId id, StockName name, StockDescription description, StockDate date)
		: base(id)
	{
		Name = name;
		Description = description;
		Date = date;
	}

	internal static Result<Stock> Create(string name, string description, DateTime beginDate, DateTime endDate)
	{
		var newName = StockName.Create(name);
		var newDescription = StockDescription.Create(description);
		var newDate = StockDate.Create(beginDate, endDate);

		if (newDate.IsFailure) return newDate.Error;
		else if (newDescription.IsFailure) return newDescription.Error;
		else if (newName.IsFailure) return newName.Error;
		else
		{
			return new Stock(new StockId(Guid.NewGuid()), newName.Value, newDescription.Value, newDate.Value);
		}
	}

	internal Result SetName(string name)
	{
		var newName = StockName.Create(name);
		if (newName.IsFailure) return newName.Error;
		else
		{
			Name = newName.Value;
			return Result.Success();
		}
	}

	internal Result SetDescription(string description)
	{
		var newDescription = StockDescription.Create(description);
		if (newDescription.IsFailure) return newDescription.Error;
		else
		{
			Description = newDescription.Value;
			return Result.Success();
		}
	}

	internal Result SetDate(DateTime beginDate, DateTime endDate)
	{
		var newDate = StockDate.Create(beginDate, endDate);
		if (newDate.IsFailure) return newDate.Error;
		else
		{
			Date = newDate.Value;
			return Result.Success();
		}
	}
}