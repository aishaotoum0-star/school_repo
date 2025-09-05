# 🔹 Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV DOTNET_USE_POLLING_FILE_WATCHER=1

WORKDIR /app

# 🔹 Copy project files and restore dependencies
COPY ./SchoolSystems/SchoolSystems.csproj ./SchoolSystems/
RUN dotnet restore ./SchoolSystems/SchoolSystems.csproj

# 🔹 Copy the rest of the files
COPY ./SchoolSystems ./SchoolSystems

# 🔹 Build the project
RUN dotnet build ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/build

# 🔹 Publish the project
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/publish

# 🔹 Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app

# 🔹 Copy published files from build stage
COPY --from=build /app/publish .

# 🔹 Expose port
EXPOSE 80

# 🔹 Run the application
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
