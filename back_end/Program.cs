using System.Text.Json.Serialization;
using back_end.Context;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// .JsonSerializerOptions resolve o problema da Serialização cíclica
builder.Services.AddControllers().AddJsonOptions(options =>
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexão com SqlServer
string SqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(SqlServerConnection));

builder.Services.AddCors();


/***************************************************************************************************/


var app = builder.Build();// Configure

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//app.UseCors(options => options.WithOrigins("http://localhost:8080").WithMethods("GET","POST","PUT"));// Habilitando CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
