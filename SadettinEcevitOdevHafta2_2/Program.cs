using Microsoft.EntityFrameworkCore;
using SadettinEcevitOdevHafta2_2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configration = builder.Configuration;
builder.Services.AddDbContext<EducationDbContext>(options =>
        options.UseSqlServer(configration.GetConnectionString("Default"))
);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
