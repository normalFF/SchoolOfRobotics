using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Stocks;

public class StockName : ValueObject
{
	public static readonly int ValueMaxLength = 50;

	public string Value { get; private set; }

	private StockName(string value) 
	{
		Value = value;
	}

	public static Result<StockName> Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name)) return Errors.Errors.Stocks.StockNameEmpty;
		else
		{
			return new StockName(name);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}
}