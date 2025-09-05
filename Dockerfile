# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# انسخ ملف الـ solution وملف المشروع (عشان cache بالـ restore)
COPY *.sln ./
COPY SchoolSystems/*.csproj ./SchoolSystems/

# Restore dependencies
RUN dotnet restore ./SchoolSystems/SchoolSystems.csproj

# انسخ باقي الكود
COPY . ./

# Publish project
RUN dotnet publish ./SchoolSystems/SchoolSystems.csproj -c Release -o /app/out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# انسخ الملفات المنشورة من build stage
COPY --from=build /app/out ./

# افتح البورت
EXPOSE 80

# شغّل المشروع
ENTRYPOINT ["dotnet", "SchoolSystems.dll"]
