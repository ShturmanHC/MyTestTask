using FluentValidation;
using MediatR;
using MyTestTask.Application.Behaviors.Common;
using MyTestTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Behaviors
{
	public class QueryValidationBehavior<TRequest, TResponse> : BaseValidationBehavior<TRequest, TResponse>, IPipelineBehavior<TRequest, TResponse>
		where TRequest : IQuery<TResponse>
	{
		public QueryValidationBehavior(IEnumerable<IValidator<TRequest>> validators) : base(validators)
		{
		}
	}
}
