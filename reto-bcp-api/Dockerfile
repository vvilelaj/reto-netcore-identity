FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["reto-bcp-api/reto-bcp-api.csproj", "reto-bcp-api/"]
RUN dotnet restore "reto-bcp-api/reto-bcp-api.csproj"
COPY . .
WORKDIR "/src/reto-bcp-api"
RUN dotnet build "reto-bcp-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "reto-bcp-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "reto-bcp-api.dll"]