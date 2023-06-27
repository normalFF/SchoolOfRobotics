using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Stocks;

public class StockDate : ValueObject
{
	public DateTime BeginDate { get; private set; }
	public DateTime EndDate { get; private set; }

	private StockDate(DateTime beginDate, DateTime endDate)
	{
		BeginDate = beginDate;
		EndDate = endDate;
	}

	public static Result<StockDate> Create(DateTime beginDate, DateTime endDate)
	{
		if (beginDate > endDate) return Errors.Errors.Stocks.DateTimeRangeValueIncorrect;
		else
		{
			return new StockDate(beginDate, endDate);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return BeginDate;
		yield return EndDate;
	}
}