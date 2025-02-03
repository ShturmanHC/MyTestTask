using MediatR;
using MyTestTask.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Behaviors
{
	public interface ISimpleCommandValidationPipelineBehavior<TRequest> : IPipelineBehavior<TRequest, Unit>
		where TRequest : ICommand
	{
	}
}
