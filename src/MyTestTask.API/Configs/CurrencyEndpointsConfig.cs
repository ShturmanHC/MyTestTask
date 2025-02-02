using System.Security.Cryptography.X509Certificates;

namespace MyTestTask.API.Configs
{
	public class CurrencyEndpointsConfig
	{
		public static string Name = nameof(CurrencyEndpointsConfig).Replace("Config", String.Empty);

		public IEnumerable<CurrencyEndpoint> CurrencyEndpoints { get; set; } = null!;

		public class CurrencyEndpoint
		{
			public string Code { get; set; } = null!;
			public string MainNetName { get; set; } = null!;
			public string? TestNetName { get; set; }
		}
	}
}
