using MyTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Domain.Tests.Entities.BlockchainCurrencyTest
{
	public class CtosTests
	{
		[Fact]
		public void CorrectCreation()
		{
			// Arrange
			var currencyName = "BTC.main";

			// Act
			var entity = new BlockchainCurrency(currencyName);

			// Assert
			Assert.Equal(currencyName, entity.Name);
		}
	}
}
