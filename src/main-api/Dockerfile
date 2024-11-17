#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Fuel.Api/Fuel.Api.csproj", "Fuel.Api/"]
RUN dotnet restore "Fuel.Api/Fuel.Api.csproj"
COPY . .
WORKDIR "/src/Fuel.Api"
RUN dotnet build "Fuel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fuel.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fuel.Api.dll"]