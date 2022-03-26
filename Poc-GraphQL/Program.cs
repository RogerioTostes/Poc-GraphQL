using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Poc_GraphQL.Application.Models.Request;
using Poc_GraphQL.Application.Models.Response;
using Poc_GraphQL.Application.UseCase;
using Poc_GraphQL.Domain.Gateways;
using Poc_GraphQL.Infrastructure.GraphQL;
using Poc_GraphQL.Infrastructure.GraphQL.Type;
using Poc_GraphQL.Infrastructure.Persistence.Dapper;
using Poc_GraphQL.Infrastructure.Persistence.Repositories;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperConnection>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IUseCaseAsyncR<IEnumerable<CustomerResponse>>, GetAllCustomerUseCaseAsync>();
builder.Services.AddTransient<IUseCaseAsync<CustomerRequest>, InsertCustomerUseCaseAsync>();
builder.Services.AddTransient<IUseCaseAsync<SaleRequest>, InsertSaleUseCaseAsync>();
builder.Services.AddInMemorySubscriptions();
builder.Services.AddScoped<ICustomerGateway, CustomerRepository>();
builder.Services.AddScoped<ISaleGateway, SaleRepository>();
builder.Services
           .AddGraphQLServer()
           .AddType<CustomerType>()
           .AddType<SaleType>()
           .AddQueryType<Query>()
           .AddSubscriptionType<Subscription>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/graphql",
        Path = "/playground"
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();
app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.Run();
