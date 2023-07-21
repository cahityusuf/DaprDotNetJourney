#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Api/DaprDotNetJourney.Microservices.Basket.Api.csproj", "src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Api/"]
COPY ["src/Framework/DaprDotNetJourney.Framework.Api/DaprDotNetJourney.Framework.Api.csproj", "src/Framework/DaprDotNetJourney.Framework.Api/"]
COPY ["src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Abstraction/DaprDotNetJourney.Microservices.Basket.Abstraction.csproj", "src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Abstraction/"]
COPY ["src/Framework/DaprDotNetJourney.Framework.Abstractions/DaprDotNetJourney.Framework.Abstractions.csproj", "src/Framework/DaprDotNetJourney.Framework.Abstractions/"]
COPY ["src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Application/DaprDotNetJourney.Microservices.Basket.Application.csproj", "src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Application/"]
RUN dotnet restore "src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Api/DaprDotNetJourney.Microservices.Basket.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/BasketAPI/DaprDotNetJourney.Microservices.Basket.Api"
RUN dotnet build "DaprDotNetJourney.Microservices.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprDotNetJourney.Microservices.Basket.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprDotNetJourney.Microservices.Basket.Api.dll"]