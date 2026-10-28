using TaskFlow.Business.Extensions;
using TaskFlow.DataAccess;
using TaskFlow.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString =
    builder.Configuration.GetConnectionString("TaskFlowConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "TaskFlowConnection connection string was not found.");
}


builder.Services.AddBusinessLayer(connectionString);





var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();