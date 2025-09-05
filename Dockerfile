# Build stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy solution and restore dependencies
COPY *.sln .
COPY SchoolSystems/*.csproj ./SchoolSystems/
RUN dotnet restore

# Copy all files and publish
COPY . .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
