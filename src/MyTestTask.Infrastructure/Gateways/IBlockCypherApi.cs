using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Gateways
{
	public interface IBlockCypherApi
	{
		Task<string> FetchRawDataAsync(string currencyName);
	}
}
