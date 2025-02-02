using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyTestTask.Application.Behaviors;
using MyTestTask.Application.Common;

namespace MyTestTask.Infrastructure
{
	public static class ApplicationModule
	{
		public static IServiceCollection AddApplicationModule(this IServiceCollection services)
		{
			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(IQuery<>).Assembly);

				cfg.AddBehavior(typeof(ISimpleCommandValidationPipelineBehavior<>), typeof(SimpleCommandValidationBehavior<>));
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(QueryValidationBehavior<,>));
			});

			services.AddValidatorsFromAssembly(typeof(IQuery<>).Assembly);

			return services;
		}

	}
}
