using MongoDB.Bson;
using MyTestTask.Domain.Entities;
using MyTestTask.Infrastructure.Repositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Converters
{
	internal static class BlockchainMainInfoConverter
	{
		public static BlockchainMainInfoMongoDto ToMongoDto(this BlockchainMainInfo entity) => 
			new()
			{
				CreatedAt = entity.CreatedAt,
				Currency = new BlockchainMainInfoMongoDto.BlockchainCurrencyMongoDto
				{
					Name = entity.Currency.Name,
				},
				RawData = BsonDocument.Parse(entity.RawData)
			};

		public static BlockchainMainInfo ToEntity(this BlockchainMainInfoMongoDto mongoDto) => 
			new(
				new BlockchainCurrency(mongoDto.Currency.Name),
				mongoDto.CreatedAt,
				mongoDto.RawData.ToJson());
	}
}
