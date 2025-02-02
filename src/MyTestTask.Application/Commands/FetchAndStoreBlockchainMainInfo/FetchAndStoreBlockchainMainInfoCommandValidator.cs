using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Commands.FetchAndStoreBlockchainMainInfo
{
	public class FetchAndStoreBlockchainMainInfoCommandValidator : AbstractValidator<FetchAndStoreBlockchainMainInfoCommand>
	{
		public FetchAndStoreBlockchainMainInfoCommandValidator()
		{
			RuleFor(r => r.CurrencyName).NotEmpty();
		}
	}
}
