using DependecyInversionMVC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services: dependency injection burada yapılıyor.

// builder.Services.AddSingleton(); => bir instance oluşturur. Uygulama çalıştığı sürece hayatta kalır.
// builder.Services.AddScoped(typeof(string)); => Her requestte bir tane oluşur. (Refresh dahil) request life time kadar kalır.
// builder.Services.AddTransient(); => Her scop için bir tane alır. 

builder.Services.AddScoped<IWeatherForecastManager, WeatherForecastManager>();
builder.Services.AddScoped<IWeatherForecastManager, WeatherForecastManager2>();

builder.Services.AddScoped<ServiceResolver>(sp => wf =>
{
    switch (wf)
    {
        case WFM.Second:
            return sp.GetService<WeatherForecastManager2>();
        default:
            return sp.GetService<WeatherForecastManager>();
    }
});

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
