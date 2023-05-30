#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/RectangleService.Api/RectangleService.Api.csproj", "Src/RectangleService.Api/"]
COPY ["Src/RectangleService.Core/RectangleService.Core.csproj", "Src/RectangleService.Core/"]
COPY ["Src/RectangleService.Infrastructure/RectangleService.Infrastructure.csproj", "Src/RectangleService.Infrastructure/"]
RUN dotnet restore "Src/RectangleService.Api/RectangleService.Api.csproj"
COPY . .
WORKDIR "/src/Src/RectangleService.Api"
RUN dotnet build "RectangleService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectangleService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectangleService.Api.dll"]