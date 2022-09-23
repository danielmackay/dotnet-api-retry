using dotnet_api_retry.Controllers;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Microsoft.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStarWarsClient, StarWarsClient>();
builder.Services.AddHttpClient(StarWarsClient.ClientName, client =>
    {
        client.BaseAddress = new Uri("https://swapi.dev/api/");
    })
    // Simplified Transient Policy
    .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(
        Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)
    ));
    // Raw Policy
    // .AddPolicyHandler(Policy<HttpResponseMessage>
    //     .Handle<HttpRequestException>()
    //     .OrResult(x => x.StatusCode is >= System.Net.HttpStatusCode.InternalServerError or System.Net.HttpStatusCode.RequestTimeout)
    //     .WaitAndRetryAsync(
    //         Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)
    //     )
    //);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
