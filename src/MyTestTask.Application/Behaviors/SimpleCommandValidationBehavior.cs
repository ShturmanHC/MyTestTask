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
	public class SimpleCommandValidationBehavior<TRequest> : BaseValidationBehavior<TRequest, Unit>, ISimpleCommandValidationPipelineBehavior<TRequest>
		where TRequest : ICommand
	{
		public SimpleCommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators) : base(validators)
		{
		}
	}
}
