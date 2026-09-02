namespace PulsarComponents.Sample.Services;

// Owns the shared "view source" drawer's content AND open state, so any descendant of ExampleLayout
// (the routed page itself, or a nested layout like ApplicationLayout) can trigger it uniformly. Two
// independent content slots — Page (set fresh by every page's own OnInitialized) and Frame (set once
// by ApplicationLayout, since the frame/shell code is the same file regardless of which page is
// active) — so viewing one never overwrites the other; ShowingFrame just picks which slot the drawer
// currently displays. Scoped (one per circuit), same manager+Changed shape PulsarComponents itself
// uses (IPulsarWindowManager, IPulsarThemeManager).
public sealed class ExampleSourceService
{
    public string? PageTitle { get; private set; }
    public string? PageSource { get; private set; }
    public string? FrameTitle { get; private set; }
    public string? FrameSource { get; private set; }
    public bool IsOpen { get; private set; }
    public bool ShowingFrame { get; private set; }

    public event Action? Changed;

    /// <summary>Called by each page's own OnInitialized — does NOT open the drawer, just keeps the
    /// "current page" slot current so the view-source button always has the right content ready.</summary>
    public void SetPageSource(string title, string source)
    {
        PageTitle = title;
        PageSource = source;
        Changed?.Invoke();
    }

    /// <summary>Called once by ApplicationLayout's own OnInitialized — the frame's source never
    /// changes per navigation, so this is set once and left alone.</summary>
    public void SetFrameSource(string title, string source)
    {
        FrameTitle = title;
        FrameSource = source;
    }

    public void OpenPage()
    {
        ShowingFrame = false;
        IsOpen = true;
        Changed?.Invoke();
    }

    public void OpenFrame()
    {
        ShowingFrame = true;
        IsOpen = true;
        Changed?.Invoke();
    }

    public void Close()
    {
        IsOpen = false;
        Changed?.Invoke();
    }
}
