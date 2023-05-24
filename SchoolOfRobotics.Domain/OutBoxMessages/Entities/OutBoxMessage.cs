namespace SchoolOfRobotics.Domain.OutBoxMessages.Entities
{
	public sealed class OutBoxMessage
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public DateTime OccurredDate { get; set; }
		public DateTime? ExecuteDate { get; set; }
		public DateTime? ProcessedDate { get; set; }
		public string? Error { get; set; }
	}
}
