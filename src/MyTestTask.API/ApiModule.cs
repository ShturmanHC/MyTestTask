using Asp.Versioning;
using MyTestTask.API.Configs;
using MyTestTask.API.HostedServices;

namespace MyTestTask.API
{
	public static class ApiModule
	{
		public static IServiceCollection AddApiModule(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
			})
			.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV"; 
				options.SubstituteApiVersionInUrl = true; 
			});

			services.Configure<CurrencyEndpointsConfig>(config =>
				config.CurrencyEndpoints = configuration
					.GetSection(CurrencyEndpointsConfig.Name)
					?.Get<IEnumerable<CurrencyEndpointsConfig.CurrencyEndpoint>>()
					?? throw new ArgumentNullException($"Section in the config with name {CurrencyEndpointsConfig.Name} is missed.")
				);

			services.AddHostedService<MongoDbInitHostedService>();

			services.AddCors(options =>
				options.AddPolicy(
					"PublicAPI", 
					builder => builder
						.AllowAnyOrigin()
						.WithMethods("GET", "POST")
						.AllowAnyHeader())
			);

			return services;
		}
	}
}
