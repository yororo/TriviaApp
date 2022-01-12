using Microsoft.Net.Http.Headers;
using TriviaApp.Data.Service;
using TriviaApp.Data.Service.Extensions;
using TriviaApp.Domain.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IQuestionDataService, QuestionDataService>();
builder.Services.AddDataServiceServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5226", "https://localhost:7226")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

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
