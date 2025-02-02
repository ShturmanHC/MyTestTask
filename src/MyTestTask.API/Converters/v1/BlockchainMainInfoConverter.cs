using MyTestTask.Application.Common.Dtos;
using System.Text.Json;

namespace MyTestTask.API.Converters.v1
{
	internal static class BlockchainMainInfoConverter
	{
		public static Contracts.v1.BlockchainMainInfo ToApiDto(this BlockchainMainInfoAppDto appDto) => 
			new()
			{
				CreatedAt = appDto.CreatedAt,
				RawData = JsonSerializer.Deserialize<JsonDocument>(appDto.RawData) ?? throw new ArgumentNullException("The RawData cannot be deserialized as a JsonDocument.")
			};
	}
}
