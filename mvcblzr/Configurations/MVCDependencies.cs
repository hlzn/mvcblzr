namespace mvcblzr1.dependencies;
public static class MVCDependencies
{
    public static void AddMVCDependencies(this IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public static void AddMVCApplicationMidleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
            }
}