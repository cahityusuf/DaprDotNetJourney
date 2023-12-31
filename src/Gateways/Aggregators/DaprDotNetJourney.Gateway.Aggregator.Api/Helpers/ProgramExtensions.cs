﻿using Dapr.Client;
using DaprDotNetJourney.Framework.Api.Extensions;
using DaprDotNetJourney.Gateway.Aggregator.Abstraction.Services;
using DaprDotNetJourney.Gateway.Aggregator.Application.Services;

namespace Web.HttpAggregator.Api.Helpers
{
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder AddHttpAggregatorApi(
            this WebApplicationBuilder builder)
        {
            builder.AddCustomSwagger();
            builder.AddCustomMvc();
            builder.AddCustomAuthentication();
            builder.AddCustomApplicationServices();

            return builder;
        }

        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IBasketService, BasketService>(
                _ => new BasketService(DaprClient.CreateInvokeHttpClient("basket-api")));
        }

        public static WebApplication UseHttpAggregatorApi(this WebApplication app)
        {
            app.UseCustomSwagger();
            app.UseCloudEvents();
            app.UseCustomAuthentication();
            app.UseCors("CorsPolicy");
            app.UseCustomRoute();
            app.MapSubscribeHandler();

            return app;
        }
    }
}
