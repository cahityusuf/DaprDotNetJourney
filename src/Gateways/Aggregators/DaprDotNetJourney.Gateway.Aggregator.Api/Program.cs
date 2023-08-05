using Web.HttpAggregator.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddHttpAggregatorApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpAggregatorApi();

app.Run();