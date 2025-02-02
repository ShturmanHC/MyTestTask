namespace MyTestTask.API.Contracts.v1
{
	public record BlockchainMainInfoHistory
	{
		public required int PageSize { get; init; }
		public required int PageNumber { get; init; }
		public required IEnumerable<BlockchainMainInfo> Hisitory {  get; init; }
	}
}
