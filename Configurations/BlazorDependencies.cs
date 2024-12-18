namespace mvcblzr1.dependencies;

public static class BlazorDependencies
{
    public static void AddBlazorDependencies(this IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
    }

    public static void AddBlazorApplicationMidleware(this WebApplication app)
    {
        app.MapBlazorHub();
    }
}