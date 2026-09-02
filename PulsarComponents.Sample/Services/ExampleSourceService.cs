namespace PulsarComponents.Sample.Services;

// Carries "what source should the shared ExampleLayout's view-source drawer show right now" up from
// whichever example page is currently routed. A CascadingValue can't do this — the layout is the
// PARENT of the routed page (RouteView renders Layout, which renders @Body, which is the page), so
// cascading only flows layout -> page, never the other way. Scoped (one per circuit), same
// manager+Changed shape PulsarComponents itself uses (IPulsarWindowManager, IPulsarThemeManager).
public sealed class ExampleSourceService
{
    public string? CurrentTitle { get; private set; }
    public string? CurrentSource { get; private set; }

    public event Action? Changed;

    public void SetSource(string title, string source)
    {
        CurrentTitle = title;
        CurrentSource = source;
        Changed?.Invoke();
    }
}
