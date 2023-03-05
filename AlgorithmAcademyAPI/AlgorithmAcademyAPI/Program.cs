using AlgorithmAcademyAPI.Core.Models.Users;
using AlgorithmAcademyAPI.Data;
using AlgorithmAcademyAPI.Infrastructure.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Automapper.
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/users", async (AlgorithmAcademyContext context, IMapper mapper) =>
{
    var users = await context.Users
        .Include(user => user.UserContacts)
        .Include(user => user.UserType)
        .Include(user => user.Name)
        .ToListAsync();

    var mappedUsers = mapper.Map<IEnumerable<User>>(users);

    return users;
})
.WithName("GetUsersAsync");

app.MapGet("/contacts", async (AlgorithmAcademyContext context, IMapper mapper) =>
{
    var contacts = await context.UserContacts
        .AsNoTracking()
        .Include(contact => contact.Name)
        .ToListAsync();

    var mappedContacts = mapper.Map<IEnumerable<UserContact>>(contacts);
    return mappedContacts;
})
.WithName("GetContactsAsync");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

