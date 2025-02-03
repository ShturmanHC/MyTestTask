using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MyTestTask.Domain.Entities;
using MyTestTask.Domain.Repositories;
using MyTestTask.Infrastructure.Converters;
using MyTestTask.Infrastructure.Repositories.Dto;
using MyTestTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Repositories
{
	public class BlockchainMainInfoRepository : IBlockchainMainInfoRepository
	{
		private readonly IMongoCollection<BlockchainMainInfoMongoDto> _collection;
		private readonly ILogger<BlockchainMainInfoRepository> _logger;

		public BlockchainMainInfoRepository(
			IMongoClient mongoClient,
			ILogger<BlockchainMainInfoRepository> logger)
		{
			_collection = mongoClient.GetDatabase(MongoDbInitializer.DbName)
				.GetCollection<BlockchainMainInfoMongoDto>(MongoDbInitializer.BlockchainMainInfoCollectionName);
			_logger = logger;
		}

		public async Task<IEnumerable<BlockchainMainInfo>> GetAllAsync(string currencyName, int pageSize, int pageNumber)
		{
			var filter = Builders<BlockchainMainInfoMongoDto>.Filter.Eq(x => x.Currency.Name, currencyName);
			var sort = Builders<BlockchainMainInfoMongoDto>.Sort.Descending(x => x.CreatedAt);

			try
			{
				var dbInfos = await _collection.Find(filter)
					.Sort(sort)
					.Skip(pageNumber * pageSize)
					.Limit(pageSize)
					.ToListAsync();
				
				return dbInfos.Select(dbi => dbi.ToEntity()).ToArray();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while working with MongoDB in method {MethodName}.", nameof(GetAllAsync));
				throw;
			}
		}

		public async Task SaveAsync(BlockchainMainInfo info)
		{
			try
			{
				await _collection.InsertOneAsync(info.ToMongoDto());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while working with MongoDB in method {MethodName}.", nameof(SaveAsync));
				throw;
			}
		}
	}
}
