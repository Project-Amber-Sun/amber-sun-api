using Amber.Sun.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Sqlite;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite("Data Source =../Registrar.sqlite",
b => b.MigrationsAssembly("Amber-Sun.Api"))
);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:300")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
