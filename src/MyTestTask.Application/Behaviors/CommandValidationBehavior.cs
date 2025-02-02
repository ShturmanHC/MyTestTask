using FluentValidation;
using MediatR;
using MyTestTask.Application.Behaviors.Common;
using MyTestTask.Application.Common;


namespace MyTestTask.Application.Behaviors
{
	public class CommandValidationBehavior<TRequest, TResponse> : BaseValidationBehavior<TRequest, TResponse>, IPipelineBehavior<TRequest, TResponse>
		where TRequest : ICommand<TResponse>
	{
		public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators) : base(validators)
		{
		}
	}
}
