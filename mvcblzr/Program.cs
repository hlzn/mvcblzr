using mvcblzr1.dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMVCDependencies();
// Added
builder.Services.AddBlazorDependencies();

var app = builder.Build();

app.AddDevelopmentDependencies();
app.AddMVCApplicationMidleware();
// Added
app.AddBlazorApplicationMidleware();

app.Run();
