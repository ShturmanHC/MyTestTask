using System.Text.Json;

namespace MyTestTask.API.Contracts.v1
{
	public record BlockchainMainInfo
	{
		public required DateTime CreatedAt { get; init; }
		public required JsonDocument RawData { get; init; }
	}
}
