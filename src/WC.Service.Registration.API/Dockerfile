FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.Registration.API/WC.Service.Registration.API.csproj src/WC.Service.Registration.API/
COPY src/WC.Service.Registration.Domain/WC.Service.Registration.Domain.csproj src/WC.Service.Registration.Domain/
COPY src/WC.Service.Registration.Domain.Abstractions/WC.Service.Registration.Domain.Abstractions.csproj src/WC.Service.Registration.Domain.Abstractions/

RUN dotnet restore WC.Service.Registration.API/WC.Service.Registration.API.csproj

COPY src .

WORKDIR /src/WC.Service.Registration.API
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WC.Service.Registration.API.dll"]
