namespace mvcblzr1.dependencies;

public static class BlazorDependencies
{
    public static void AddBlazorDependencies(this IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        // services.AddRazorComponents()
        //     .AddInteractiveServerComponents();
    }

    public static void AddBlazorApplicationMidleware(this WebApplication app)
    {
        app.UseAntiforgery();
        app.MapBlazorHub();
        //app.MapRazorComponents<justblzr.Components.App>().AddInteractiveServerRenderMode();
        //app.MapFallbackToPage("/App");
    }
}