using MyTestTask.Application.Common.Dtos;
using MyTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Converters
{
	public static class BlockchainMainInfoConverter
	{
		public static BlockchainMainInfoAppDto ToAppDto(this BlockchainMainInfo entity) => 
			new()
			{
				CreatedAt = entity.CreatedAt,
				RawData = entity.RawData,
			};
	}
}
