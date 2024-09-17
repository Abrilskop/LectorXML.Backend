using LectorXML.Backend.Application.Comprobantes;
using LectorXML.Backend.Domain.Comprobantes.Interfaces;
using LectorXML.Backend.Domain.Config;
using LectorXML.Backend.Infraestructure.Comprobantes;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
DatabaseConfig databaseConfig = configuration.GetSection("Database").Get<DatabaseConfig>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ComprobanteApp>();
builder.Services.AddTransient<IComprobanteRepository, ComprobanteRepository>();

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
