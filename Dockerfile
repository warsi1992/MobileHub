# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY MobileHub.API/MobileHub.API.csproj MobileHub.API/
COPY MobileHub.Application/MobileHub.Application.csproj MobileHub.Application/
COPY MobileHub.Domain/MobileHub.Domain.csproj MobileHub.Domain/
COPY MobileHub.Infrastructure/MobileHub.Infrastructure.csproj MobileHub.Infrastructure/
RUN dotnet restore MobileHub.API/MobileHub.API.csproj

# Copy the rest of the source and publish
COPY . .
RUN dotnet publish MobileHub.API/MobileHub.API.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Bind Kestrel to 0.0.0.0 and the Railway-provided PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}
EXPOSE 8080
ENTRYPOINT ["dotnet", "MobileHub.API.dll"]
