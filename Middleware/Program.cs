using Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseMiddleware<GlobalErrorHandling>();

//app.Use(async (ctx, next) =>
//{
//    await ctx.Response.WriteAsync("Middleware");
//    await next.Invoke();
//}
//);
////Map path'e yazılır.
//app.Map("/student", builder =>
//{
//    //builder.Run();
//});

//app.MapWhen(ctx => ctx.Request.Method == "POST", builder =>
//{
//    //builder.Run();
//}
//);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
