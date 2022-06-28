var builder = WebApplication.CreateBuilder(args);
//Service for MVC
builder.Services.AddControllersWithViews();
var app = builder.Build();

//Pipline
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Middlewares
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
