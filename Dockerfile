# Standard multi-stage ASP.NET Core build — this app installs PulsarComponents via a normal
# PackageReference (restored from nuget.org), not a project reference into the library's own
# source, so this Dockerfile needs nothing PulsarComponents-specific at all.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY PulsarComponents.Sample/PulsarComponents.Sample.csproj PulsarComponents.Sample/
RUN dotnet restore PulsarComponents.Sample/PulsarComponents.Sample.csproj
COPY PulsarComponents.Sample/ PulsarComponents.Sample/
RUN dotnet publish PulsarComponents.Sample/PulsarComponents.Sample.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "PulsarComponents.Sample.dll"]
