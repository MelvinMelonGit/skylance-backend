FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["skylance-backend.csproj", "./"]
RUN dotnet restore "./skylance-backend.csproj"
COPY . .
RUN dotnet publish "./skylance-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Force ASP.NET to listen on all interfaces (inside container)
ENV ASPNETCORE_URLS=http://0.0.0.0:80
ENTRYPOINT ["dotnet", "skylance-backend.dll"]
