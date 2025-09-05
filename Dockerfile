# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy solution and project files first (for better caching)
COPY *.sln ./
COPY SchoolSystems/*.csproj ./SchoolSystems/

# Restore dependencies
RUN dotnet restore ./SchoolSystems/SchoolSystems.csproj

# Copy the rest of the source code
COPY . .

# Publish project to /app/out
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/out ./

# Expose the application port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
