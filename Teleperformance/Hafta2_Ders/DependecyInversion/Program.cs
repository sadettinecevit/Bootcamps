var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services: dependency injection burada yapılıyor.

// builder.Services.AddSingleton(); => bir instance oluşturur. Uygulama çalıştığı sürece hayatta kalır.
// builder.Services.AddScoped(typeof(string)); => Her requestte bir tane oluşur. (Refresh dahil) request life time kadar kalır.
// builder.Services.AddTransient(); => Her scop için bir tane alır. 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
