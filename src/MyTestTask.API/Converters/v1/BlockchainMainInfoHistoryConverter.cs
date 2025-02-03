using MyTestTask.Application.Queries.GetBlockchainMainInfoHistory;

namespace MyTestTask.API.Converters.v1
{
	internal static class BlockchainMainInfoHistoryConverter
	{
		public static Contracts.v1.BlockchainMainInfoHistory ToApiDto(this BlockchainMainInfoHistoryAppDto appDto)
		{
			return new()
			{
				PageSize = appDto.PageSize,
				PageNumber = appDto.PageNumber,
				Hisitory = appDto.History.Select(i => i.ToApiDto()).ToArray(),
			};
		}
	}
}
