using MyTestTask.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Queries.GetBlockchainMainInfoHistory
{
	public record BlockchainMainInfoHistoryAppDto
	{
		public required int PageSize { get; init; }
		public required int PageNumber { get; init; }

		public required IEnumerable<BlockchainMainInfoAppDto> History { get; init; }
	}
}
