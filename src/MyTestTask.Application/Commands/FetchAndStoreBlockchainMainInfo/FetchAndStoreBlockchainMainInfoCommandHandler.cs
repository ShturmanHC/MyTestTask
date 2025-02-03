using MyTestTask.Application.Common;
using MyTestTask.Application.Common.Dtos;
using MyTestTask.Application.Converters;
using MyTestTask.Application.Services;
using MyTestTask.Domain.Entities;
using MyTestTask.Domain.Repositories;

namespace MyTestTask.Application.Commands.FetchAndStoreBlockchainMainInfo
{
	public class FetchAndStoreBlockchainMainInfoCommandHandler : ICommandHandler<FetchAndStoreBlockchainMainInfoCommand, BlockchainMainInfoAppDto>
	{
		private readonly IBlockchainMainInfoProvider _provider;
		private readonly IBlockchainMainInfoRepository _repository;

		public FetchAndStoreBlockchainMainInfoCommandHandler(
			IBlockchainMainInfoProvider provider,
			IBlockchainMainInfoRepository repository)
		{
			_provider = provider;
			_repository = repository;
		}

		public async Task<BlockchainMainInfoAppDto> Handle(FetchAndStoreBlockchainMainInfoCommand request, CancellationToken cancellationToken)
		{
			var requestDate = DateTime.UtcNow;
			var rawData = await _provider.FetchAsync(request.CurrencyName);

			var info = new BlockchainMainInfo(
				new BlockchainCurrency(request.CurrencyName),
				requestDate,
				rawData);

			await _repository.SaveAsync(info);

			return info.ToAppDto();
		}
	}
}
