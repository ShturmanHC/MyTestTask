
using MyTestTask.Infrastructure.Services;

namespace MyTestTask.API.HostedServices
{
	public class MongoDbInitHostedService : IHostedService
	{
		private readonly IMongoDbInitializer _initializer;

		public MongoDbInitHostedService(IMongoDbInitializer initializer) => _initializer = initializer;

		public Task StartAsync(CancellationToken cancellationToken) => _initializer.InitializeAsync();

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

	}

}
