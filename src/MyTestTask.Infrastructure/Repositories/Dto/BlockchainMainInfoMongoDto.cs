using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Repositories.Dto
{
	internal class BlockchainMainInfoMongoDto
	{
		[BsonId]
		public ObjectId Id { get; set; }

		public BlockchainCurrencyMongoDto Currency { get; set; } = null!;
		public DateTime CreatedAt { get; set; }

		public BsonDocument RawData { get; set; } = null!;

		public class BlockchainCurrencyMongoDto
		{ 
			public string Name { get; set; } = null!;
		}
	}
}
