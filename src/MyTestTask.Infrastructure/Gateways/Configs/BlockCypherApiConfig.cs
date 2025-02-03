using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Gateways.Configs
{
	public class BlockCypherApiConfig
	{
		public static string Name = nameof(BlockCypherApiConfig).Replace("Config", String.Empty);

		public string BaseUrl { get; set; } = string.Empty;
		public Dictionary<string, string> Endpoints { get; set; } = new();
	}
}
