using Amber.Sun.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Sqlite;
using Amber.Sun.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["AzureAd:Instance"] ??
throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["AzureAd:Audience"] ??
throw new ArgumentNullException("Auth0:Audience");

// Add services to the container.

builder.Services.AddControllers();
{
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;
});

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


Builder.services.AddCors(Options =>
{
    Options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        // .AllowAnyHeader()
        .AllowAnyMethod();
        });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("delete:catalog", policy =>
    {
        policy.RequirementAuthenticatedUser()
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
app.UseAuthentication();
app.MapControllers();

app.Run();
