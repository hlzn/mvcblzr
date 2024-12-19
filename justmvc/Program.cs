var builder = WebApplication.CreateBuilder(args);
//MVC
builder.Services.AddControllersWithViews();

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
