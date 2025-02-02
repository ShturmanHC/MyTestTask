using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure.Services
{
	public interface IMongoDbInitializer
	{
		Task InitializeAsync();
	}
}
