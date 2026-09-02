# Standard multi-stage ASP.NET Core build — this app installs PulsarComponents via a normal
# PackageReference (restored from nuget.org), not a project reference into the library's own
# source, so this Dockerfile needs nothing PulsarComponents-specific at all.
#
# Deliberately a single `dotnet publish` with an implicit restore, NOT the usual
# copy-csproj-then-restore-then-copy-rest-then-publish-with-no-restore layer-caching split:
# that split silently dropped the framework's own _framework/blazor.web.js static web asset
# from the publish output (confirmed via a bisected repro against the stock `dotnet new blazor`
# template on this exact SDK/runtime image pair) — the page still rendered and returned 200, but
# the SignalR circuit's own bootstrap script 404'd, so the app looked fine while being completely
# non-interactive. Losing Docker layer caching on restore is the accepted tradeoff.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY PulsarComponents.Sample/ PulsarComponents.Sample/
RUN dotnet publish PulsarComponents.Sample/PulsarComponents.Sample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "PulsarComponents.Sample.dll"]
