using Carter;
using Diwa.Todo.Api.Adapter;
using Diwa.Todo.Api.Adapter.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices();
builder.Services.AddCarter();

builder.AddServiceDefaults();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.MapCarter();

app.Run();