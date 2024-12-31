using justblzr.Components;
using features.Data;
using Microsoft.EntityFrameworkCore;
using features.Actions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UserActions>();
builder.Services.AddScoped<TenantActions>();

//DB
builder.Services.AddDbContext<BlzrDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
