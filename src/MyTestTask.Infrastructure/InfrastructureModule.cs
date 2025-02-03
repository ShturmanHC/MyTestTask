using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyTestTask.Application.Services;
using MyTestTask.Domain.Repositories;
using MyTestTask.Infrastructure.Gateways;
using MyTestTask.Infrastructure.Gateways.Configs;
using MyTestTask.Infrastructure.Repositories;
using MyTestTask.Infrastructure.Services;

namespace MyTestTask.Infrastructure
{
	public static class InfrastructureModule
	{
		public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddLogging(builder => builder.AddConsole());

			services.Configure<BlockCypherApiConfig>(configuration.GetSection(BlockCypherApiConfig.Name));

			services.AddHttpClient<BlockCypherApi>((sp, client) =>
			{
				var config = sp.GetRequiredService<IOptions<BlockCypherApiConfig>>().Value;
				client.BaseAddress = new Uri(config.BaseUrl);
			});

			services.AddScoped<IBlockCypherApi, BlockCypherApi>();
			services.AddScoped<IBlockchainMainInfoProvider, BlockchainMainInfoProvider>();
			services.AddScoped<IBlockchainMainInfoRepository, BlockchainMainInfoRepository>();

			services.AddMongoInfrastructure(configuration);

			services.AddHealthChecks()
				.AddMongoDb(configuration.GetConnectionString("MyTestTaskMongoDb") ?? throw new ArgumentNullException("The connection string MyTestTaskMongoDb is missed."))
				.AddUrlGroup(sp => 
				{
					var config = sp.GetRequiredService<IOptions<BlockCypherApiConfig>>().Value;
					return new Uri($"{config.BaseUrl}{config.Endpoints.First().Value}");
				});

			return services;
		}

		private static IServiceCollection AddMongoInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MyTestTaskMongoDb")));
			services.AddTransient<IMongoDbInitializer, MongoDbInitializer>();

			return services;
		}
	}
}
