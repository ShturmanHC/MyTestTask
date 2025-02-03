using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Domain.Entities
{
	public class BlockchainCurrency
	{
		public string Name { get; set; } = null!;

		public BlockchainCurrency(string name)
		{
			this.Name = name;
		}
	}
}
