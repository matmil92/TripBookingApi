using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using TripBookingApi.Application.Interfaces;
using TripBookingApi.Domain.Exceptions;
using TripBookingApi.Infrastructure;
using TripBookingApi.Infrastructure.DbContexts;
using Websky.Nacho.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();
    dbContext.SeedData();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionMessage{
                StatusCode = context.Response.StatusCode,
                Content = contextFeature.Error.Message
            }).ToString());
        }
    });
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
