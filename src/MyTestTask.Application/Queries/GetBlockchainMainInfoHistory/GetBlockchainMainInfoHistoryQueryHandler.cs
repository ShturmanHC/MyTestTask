using MyTestTask.Application.Common;
using MyTestTask.Application.Converters;
using MyTestTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Queries.GetBlockchainMainInfoHistory
{
	public class GetBlockchainMainInfoHistoryQueryHandler : IQueryHandler<GetBlockchainMainInfoHistoryQuery, BlockchainMainInfoHistoryAppDto>
	{
		private readonly IBlockchainMainInfoRepository _repository;

		public GetBlockchainMainInfoHistoryQueryHandler(IBlockchainMainInfoRepository repository)
		{
			_repository = repository;
		}

		public async Task<BlockchainMainInfoHistoryAppDto> Handle(GetBlockchainMainInfoHistoryQuery request, CancellationToken cancellationToken)
		{
			var infos = await _repository.GetAllAsync(
				request.CurrencyName, 
				request.PageSize, 
				request.PageNumber);

			return new()
			{
				PageSize = request.PageSize,
				PageNumber = request.PageNumber,
				History = infos.Select(i => i.ToAppDto()).ToArray(),
			};
		}
	}
}
