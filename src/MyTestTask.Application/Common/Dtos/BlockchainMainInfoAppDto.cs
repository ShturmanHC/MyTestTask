using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Common.Dtos
{
	public record BlockchainMainInfoAppDto
	{
		public required DateTime CreatedAt { get; init; }
		public required string RawData { get; init; } 
	}
}
