# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy solution and project files first to leverage caching
COPY *.sln ./
COPY SchoolSystems/*.csproj ./SchoolSystems/
RUN dotnet restore

# Copy all source files and publish
COPY SchoolSystems/ ./SchoolSystems/
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/out ./

# Expose port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
