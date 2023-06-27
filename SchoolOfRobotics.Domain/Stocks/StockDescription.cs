using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Stocks;

public class StockDescription : ValueObject
{
	public string Value { get; private set; }

	private StockDescription(string value)
	{
		Value = value;
	}

	public static Result<StockDescription> Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name)) return Errors.Errors.Stocks.StockDescriptionEmpty;
		else
		{
			return new StockDescription(name);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}
}