using MyTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Domain.Repositories
{
	public interface IBlockchainMainInfoRepository
	{
		Task<IEnumerable<BlockchainMainInfo>> GetAllAsync(string currencyName, int pageSize, int pageNumber);

		Task SaveAsync(BlockchainMainInfo info);
	}
}
