namespace mvcblzr1.dependencies;

public static class DevelopmentDependencies
{
    public static void AddDevelopmentDependencies(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        // if (!app.Environment.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Home/Error");
        //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //     app.UseHsts();
        // }
    }
}