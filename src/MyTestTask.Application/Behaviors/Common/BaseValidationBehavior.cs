﻿using FluentValidation;
using MediatR;

namespace MyTestTask.Application.Behaviors.Common
{
	public abstract class BaseValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : notnull
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		protected BaseValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if(!_validators.Any())
			{
				return await next();
			}

			var context = new ValidationContext<TRequest>(request);

			var validationResults = await Task.WhenAll(
				_validators
					.Select(validator => validator.ValidateAsync(context)));

			var errors = validationResults
				.Where(validationResult => !validationResult.IsValid)
				.SelectMany(validationResult => validationResult.Errors)
				.ToArray();

			if (errors.Any())
			{
				throw new ValidationException(errors);
			}

			return await next();
		}
	}
}
