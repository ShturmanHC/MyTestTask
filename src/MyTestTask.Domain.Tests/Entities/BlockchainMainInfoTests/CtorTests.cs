using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyTestTask.Domain.Entities;

namespace MyTestTask.Domain.Tests.Entities.BlockchainMainInfoTests
{
	public class CtorTests
	{
		[Fact]
		public void CorrectCreation()
		{ 
			// Arrange
			var currency = new BlockchainCurrency("BTC.main");
			var createdAt = DateTime.UtcNow;
			var rawData = @"{
    ""name"": ""BTC.main"",
    ""height"": 882020,
    ""hash"": ""00000000000000000000ea3174946c38f526abd145b8b74212317c83a8ce88e8"",
    ""time"": ""2025-02-02T18:47:32.707484994Z"",
    ""latest_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000000ea3174946c38f526abd145b8b74212317c83a8ce88e8"",
    ""previous_hash"": ""00000000000000000001af0e4460aca2fc50d4916843010c1c1f8d74b83f2bbe"",
    ""previous_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000001af0e4460aca2fc50d4916843010c1c1f8d74b83f2bbe"",
    ""peer_count"": 302,
    ""unconfirmed_count"": 591,
    ""high_fee_per_kb"": 3727,
    ""medium_fee_per_kb"": 2857,
    ""low_fee_per_kb"": 2046,
    ""last_fork_height"": 878195,
    ""last_fork_hash"": ""0000000000000000000118ba6ca352890cb4c6a87f7370ee2fafa73985fdcbea""
    }";

            // Act
            var entity = new BlockchainMainInfo(currency, createdAt, rawData);

            // Assert
            Assert.NotNull(entity.Currency);
            Assert.Equal(currency.Name, entity.Currency.Name);
            Assert.Equal(createdAt, entity.CreatedAt);
			Assert.Equal(DateTimeKind.Utc, createdAt.Kind);
            Assert.Equal(rawData, entity.RawData);
		}

        [Theory]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Unspecified)]
        public void WrongKindOfCreatedAt(DateTimeKind createdAtKind)
        {
			// Arrange
			var currency = new BlockchainCurrency("BTC.main");
			var createdAt = new DateTime(2025, 1, 1, 0, 0, 0, createdAtKind);
			var rawData = @"{
    ""name"": ""BTC.main"",
    ""height"": 882020,
    ""hash"": ""00000000000000000000ea3174946c38f526abd145b8b74212317c83a8ce88e8"",
    ""time"": ""2025-02-02T18:47:32.707484994Z"",
    ""latest_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000000ea3174946c38f526abd145b8b74212317c83a8ce88e8"",
    ""previous_hash"": ""00000000000000000001af0e4460aca2fc50d4916843010c1c1f8d74b83f2bbe"",
    ""previous_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000001af0e4460aca2fc50d4916843010c1c1f8d74b83f2bbe"",
    ""peer_count"": 302,
    ""unconfirmed_count"": 591,
    ""high_fee_per_kb"": 3727,
    ""medium_fee_per_kb"": 2857,
    ""low_fee_per_kb"": 2046,
    ""last_fork_height"": 878195,
    ""last_fork_hash"": ""0000000000000000000118ba6ca352890cb4c6a87f7370ee2fafa73985fdcbea""
    }";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>("createdAt", () => new BlockchainMainInfo(currency, createdAt, rawData));
            Assert.Equal("The Kind of CreatedAt DateTime should be Utc. (Parameter 'createdAt')", ex.Message);
		}
	}
}
