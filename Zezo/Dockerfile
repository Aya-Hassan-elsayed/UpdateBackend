# =========================
# Build Stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy project file
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build & Publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


# =========================
# Runtime Stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

# Copy published application
COPY --from=build /app/publish .

# Render / SnapDeploy port
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "Zezo.dll"]