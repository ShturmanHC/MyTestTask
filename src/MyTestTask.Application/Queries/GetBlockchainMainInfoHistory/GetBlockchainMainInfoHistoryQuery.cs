using MyTestTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Queries.GetBlockchainMainInfoHistory
{
	public record GetBlockchainMainInfoHistoryQuery : IQuery<BlockchainMainInfoHistoryAppDto>
	{
		public required string CurrencyName { get; init; }
		public required int PageSize { get; init; }
		public required int PageNumber { get; init; }
	}
}
