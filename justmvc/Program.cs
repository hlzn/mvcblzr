using features.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using features.Actions;

var builder = WebApplication.CreateBuilder(args);
//MVC
builder.Services.AddControllersWithViews();

//DB
builder.Services.AddDbContext<BlzrDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnectionString")));

//Services
builder.Services.AddScoped<UserActions>();
builder.Services.AddScoped<TenantActions>();

//Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//MVC
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//Blazor
app.UseAntiforgery();
app.MapRazorComponents<justblzr.Components.App>()
    .AddInteractiveServerRenderMode();
    //.AddAdditionalAssemblies(typeof(justblzr.Components._Imports).Assembly);

app.Run();
