using MyTestTask.Application.Common;
using MyTestTask.Application.Common.Dtos;

namespace MyTestTask.Application.Commands.FetchAndStoreBlockchainMainInfo
{
	public record FetchAndStoreBlockchainMainInfoCommand : ICommand<BlockchainMainInfoAppDto>
	{
		public required string CurrencyName { get; init; }
	}
}
