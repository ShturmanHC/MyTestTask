using Microsoft.Extensions.Options;
using MyTestTask.Infrastructure.Gateways.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Gateways
{
	public class BlockCypherApi : IBlockCypherApi
	{
		private readonly BlockCypherApiConfig _config;
		private readonly IHttpClientFactory _httpClientFactory;

		public BlockCypherApi(
			IOptions<BlockCypherApiConfig> options,
			IHttpClientFactory httpClientFactory)
		{
			_config = options.Value;
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> FetchRawDataAsync(string currencyName)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Get, _config.Endpoints[currencyName]);
			var responseMessage = await _httpClientFactory
				.CreateClient(nameof(BlockCypherApi))
				.SendAsync(requestMessage);

			return await responseMessage.Content.ReadAsStringAsync();
		}
	}
}
