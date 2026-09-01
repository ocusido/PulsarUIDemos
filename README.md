# PulsarComponents Sample

A working example app built with [PulsarComponents](https://pulsarui.com) — a Blazor component
library built from scratch, with no dependency on Bootstrap, Tailwind, or MudBlazor.

This is a full Blazor Server (Interactive) app: a dashboard with stat cards, tag filters, a toast
and a window opened from action buttons, a calendar page, and a components showcase page — a
sidebar/toolbar app shell built entirely out of `PulsarComponents`, installed the same way any
consumer of the package would install it (`dotnet add package`, not a project reference into the
library's own source).

## Run it

```bash
git clone https://github.com/ocusido/PulsarComponents.Sample.git
cd PulsarComponents.Sample
dotnet run --project PulsarComponents.Sample
```

Then open the URL printed in the console (typically `http://localhost:5000` or similar).

## Learn more

- **[pulsarui.com](https://pulsarui.com)** — full API reference and live examples for every component.
- **[NuGet package](https://www.nuget.org/packages/PulsarComponents)**.
- **[Main repository](https://github.com/ocusido/PulsarComponents)**.

## License

This sample app's own code is free to copy/adapt for your own projects. The `PulsarComponents`
package itself is free to use in your own applications while under active development, but the
library itself may not be redistributed, resold, or repackaged — see
[pulsarui.com/license](https://pulsarui.com/license) for the full terms.
