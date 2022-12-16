using Microsoft.EntityFrameworkCore;
using encuesta.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//aun no encuentro solucion a este error
//builder.Services.AddDbContext<encuestaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaConexionSQLServer")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<encuestaContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// ocupamos los siguientes app. para poder usar el crud con el api

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
