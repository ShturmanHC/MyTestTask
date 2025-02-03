using MyTestTask.Application.Services;
using MyTestTask.Infrastructure.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Services
{
	public class BlockchainMainInfoProvider : IBlockchainMainInfoProvider
	{
		private readonly IBlockCypherApi _api;

		public BlockchainMainInfoProvider(IBlockCypherApi api) => _api = api;

		public Task<string> FetchAsync(string currencyName) => _api.FetchRawDataAsync(currencyName);
	}
}
