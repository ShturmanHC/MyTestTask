using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Services
{
	public interface IBlockchainMainInfoProvider
	{
		Task<string> FetchAsync(string currencyName);
	}
}
