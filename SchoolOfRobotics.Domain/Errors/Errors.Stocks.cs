using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Errors;

public static partial class Errors
{
	public static class Stocks
	{
		public static Error StockNameEmpty => Error.Validation(
			code: "StockName.Empty",
			description: "Название акции не может быть пустым значением");

		public static Error StockDescriptionEmpty => Error.Validation(
			code: "StockName.Empty",
			description: "Описание акции не может быть пустым значением");

		public static Error DateTimeRangeValueIncorrect => Error.Validation(
			code: "StockDate.RangeValueIncorrect",
			description: "Некорректный диапазон даты");
	}
}