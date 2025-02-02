using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Domain.Entities
{
	public class BlockchainMainInfo
	{
		public BlockchainCurrency Currency { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public string RawData { get; set; } = null!;

		public BlockchainMainInfo(
			BlockchainCurrency currency,
			DateTime createdAt,
			string rawData)
		{
			if (createdAt.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("The Kind of CreatedAt DateTime should be Utc.", nameof(createdAt));
			}

			this.Currency = currency;
			this.CreatedAt = createdAt;
			this.RawData = rawData;
		}
	}
}
