# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy project file and restore as distinct layers
COPY ./SchoolSystems/SchoolSystems.csproj ./SchoolSystems/
RUN dotnet restore ./SchoolSystems/SchoolSystems.csproj

# Copy everything else and build
COPY ./SchoolSystems ./SchoolSystems
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/publish

# Stage 2: Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
