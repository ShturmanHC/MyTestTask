using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MyTestTask.Infrastructure.Repositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Services
{
	public class MongoDbInitializer : IMongoDbInitializer
	{
		public const string DbName = "MyTestTaskDb";
		public const string BlockchainMainInfoCollectionName = "BlockchainMainInfos";

		private readonly IMongoDatabase _database;

		public MongoDbInitializer(IMongoClient client)
		{
			_database = client.GetDatabase(DbName);
		}

		public async Task InitializeAsync()
		{
			var collectionNames = await _database.ListCollectionNames().ToListAsync();
			if (!collectionNames.Contains(BlockchainMainInfoCollectionName))
			{
				await _database.CreateCollectionAsync(BlockchainMainInfoCollectionName);
			}

			var collection = _database.GetCollection<BlockchainMainInfoMongoDto>(BlockchainMainInfoCollectionName);

			var currencyNameIndexKeys = Builders<BlockchainMainInfoMongoDto>.IndexKeys.Ascending(x => x.Currency.Name);
			var currencyNameIndexModel = new CreateIndexModel<BlockchainMainInfoMongoDto>(
				currencyNameIndexKeys, 
				new CreateIndexOptions 
				{ 
					Name = "BlockchainCurrencyNameIndex",
				});

			await collection.Indexes.CreateOneAsync(currencyNameIndexModel);

			var createdAtIndexKeys = Builders<BlockchainMainInfoMongoDto>.IndexKeys.Descending(x => x.CreatedAt);
			var createdAtIndexModel = new CreateIndexModel<BlockchainMainInfoMongoDto>(
				createdAtIndexKeys,
				new CreateIndexOptions
				{ 
					Name = "BlockchainCreatedAtIndex"
				});

			await collection.Indexes.CreateOneAsync(createdAtIndexModel);
		}
	}
}
