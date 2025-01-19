FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.Registration.Domain/WC.Service.Registration.Domain.csproj src/WC.Service.Registration.Domain/
COPY src/WC.Service.Registration.Domain.Abstractions/WC.Service.Registration.Domain.Abstractions.csproj src/WC.Service.Registration.Domain.Abstractions/
COPY src/WC.Service.Registration.CreateAdmin/WC.Service.Registration.CreateAdmin.csproj src/WC.Service.Registration.CreateAdmin/

RUN dotnet restore src/WC.Service.Registration.CreateAdmin/WC.Service.Registration.CreateAdmin.csproj

COPY src .
WORKDIR /src/WC.Service.Registration.CreateAdmin
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY src/WC.Service.Registration.CreateAdmin/appsettings.json /app/../..

ENTRYPOINT ["dotnet", "WC.Service.Registration.CreateAdmin.dll"]
