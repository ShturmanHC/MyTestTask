using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Infrastructure
{
	public static class DomainModule
	{
		public static IServiceCollection AddDomainModule(this IServiceCollection services)
		{

			return services;
		}
	}
}
