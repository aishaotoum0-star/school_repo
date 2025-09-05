# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies first (caching)
COPY ./SchoolSystems/SchoolSystems.csproj ./SchoolSystems/
RUN dotnet restore ./SchoolSystems/SchoolSystems.csproj

# Copy all source files
COPY ./SchoolSystems ./SchoolSystems

# Build and publish
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copy published files
COPY --from=build /app/publish ./

# Expose port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
