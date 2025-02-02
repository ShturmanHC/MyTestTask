using Asp.Versioning;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MyTestTask.API;
using MyTestTask.API.Configs;
using MyTestTask.API.Converters.v1;
using MyTestTask.Application.Commands.FetchAndStoreBlockchainMainInfo;
using MyTestTask.Application.Queries.GetBlockchainMainInfoHistory;
using MyTestTask.Infrastructure;
using System.Linq;

const int DefaultHistoryPageSize = 10;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainModule();
builder.Services.AddApplicationModule();
builder.Services.AddInfrastructureModule(builder.Configuration);
builder.Services.AddApiModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("PublicAPI");

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/hc");

var v1 = app.NewVersionedApi("v{version:apiVersion}")
	.MapGroup("/api/v{version:apiVersion}")
	.HasApiVersion(1, 0);

var endpointsConfig = app.Services.GetRequiredService<IOptions<CurrencyEndpointsConfig>>().Value;

foreach (var ce in endpointsConfig.CurrencyEndpoints)
{
    if (String.IsNullOrEmpty(ce.TestNetName))
    {
        v1.MapPost(
            $"/blockchain/{ce.Code}",
            async (IMediator mediator) =>
            {
                var storedMainInfo = await mediator.Send(
                    new FetchAndStoreBlockchainMainInfoCommand
                    {
                        CurrencyName = ce.MainNetName,
                    });

                return Results.Ok(storedMainInfo.ToApiDto());
            }).WithTags(ce.Code);

        v1.MapGet(
            $"/blockchain/{ce.Code}/history",
            async (IMediator mediator, int pageSize = DefaultHistoryPageSize, int pageNumber = 0) =>
            {
                var history = await mediator.Send(
                    new GetBlockchainMainInfoHistoryQuery
                    {
                        CurrencyName = ce.MainNetName,
                        PageSize = pageSize,
                        PageNumber = pageNumber,
                    });

                return Results.Ok(history.ToApiDto());
            }).WithTags(ce.Code); ;
    }
    else
    {
		v1.MapPost(
				$"/blockchain/{ce.Code}",
				async (IMediator mediator, bool useTestNet = false) =>
				{
					var storedMainInfo = await mediator.Send(
						new FetchAndStoreBlockchainMainInfoCommand
						{
							CurrencyName = useTestNet ? ce.TestNetName : ce.MainNetName,
						});

					return Results.Ok(storedMainInfo.ToApiDto());
				}).WithTags(ce.Code); ;

		v1.MapGet(
			$"/blockchain/{ce.Code}/history",
			async (IMediator mediator, bool useTestNet = false, int pageSize = DefaultHistoryPageSize, int pageNumber = 0) =>
			{
				var history = await mediator.Send(
					new GetBlockchainMainInfoHistoryQuery
					{
						CurrencyName = useTestNet ? ce.TestNetName : ce.MainNetName,
						PageSize = pageSize,
						PageNumber = pageNumber,
					});

                return Results.Ok(history.ToApiDto());
			}).WithTags(ce.Code); ;
	}
}

app.Run();