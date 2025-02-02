using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Queries.GetBlockchainMainInfoHistory
{
	public class GetBlockchainMainInfoHistoryQueryValidator : AbstractValidator<GetBlockchainMainInfoHistoryQuery>
	{
		public GetBlockchainMainInfoHistoryQueryValidator()
		{
			RuleFor(r => r.CurrencyName).NotEmpty();
			RuleFor(r => r.PageSize).GreaterThanOrEqualTo(1);
			RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(0);
		}
	}
}
