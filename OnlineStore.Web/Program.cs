using OnlineStore.Web.Dependencies;
using OnlineStore.Web.ApiServices.Services;
using OnlineStore.Web.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();

#region "Apis Dependency"

builder.Services.AddApiAlmancenDependency();
builder.Services.AddAuthDependencyApi();

#endregion


builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
       name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
