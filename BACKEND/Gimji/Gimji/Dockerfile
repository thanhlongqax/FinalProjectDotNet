#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Stage 1: Sử dụng image SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gimji/Gimji.csproj", "Gimji/"]
RUN dotnet restore "Gimji/Gimji.csproj"
COPY . .
WORKDIR "/src/Gimji"
RUN dotnet build "Gimji.csproj" -c Release -o /app/build

# Set the working directory for the application
WORKDIR /src/Gimji
# Stage 3: Publish ứng dụng
FROM build AS publish
RUN dotnet publish "Gimji.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gimji.dll"]