#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["host/Syrna.AuditLogging.Web.Unified/Syrna.AuditLogging.Web.Unified.csproj", "host/Syrna.AuditLogging.Web.Unified/"]
COPY ["src/Syrna.AuditLogging.Web/Syrna.AuditLogging.Web.csproj", "src/Syrna.AuditLogging.Web/"]
COPY ["src/Syrna.AuditLogging.HttpApi/Syrna.AuditLogging.HttpApi.csproj", "src/Syrna.AuditLogging.HttpApi/"]
COPY ["src/Syrna.AuditLogging.Application.Contracts/Syrna.AuditLogging.Application.Contracts.csproj", "src/Syrna.AuditLogging.Application.Contracts/"]
COPY ["src/Syrna.AuditLogging.Domain.Shared/Syrna.AuditLogging.Domain.Shared.csproj", "src/Syrna.AuditLogging.Domain.Shared/"]
COPY ["src/Syrna.AuditLogging.Application/Syrna.AuditLogging.Application.csproj", "src/Syrna.AuditLogging.Application/"]
COPY ["src/Syrna.AuditLogging.Domain/Syrna.AuditLogging.Domain.csproj", "src/Syrna.AuditLogging.Domain/"]
COPY ["src/Syrna.AuditLogging.EntityFrameworkCore/Syrna.AuditLogging.EntityFrameworkCore.csproj", "src/Syrna.AuditLogging.EntityFrameworkCore/"]
COPY ["host/Syrna.AuditLogging.Host.Shared/Syrna.AuditLogging.Host.Shared.csproj", "host/Syrna.AuditLogging.Host.Shared/"]
COPY Directory.Build.props .
RUN dotnet restore "host/Syrna.AuditLogging.Web.Unified/Syrna.AuditLogging.Web.Unified.csproj"
COPY . .
WORKDIR "/src/host/Syrna.AuditLogging.Web.Unified"
RUN dotnet build "Syrna.AuditLogging.Web.Unified.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Syrna.AuditLogging.Web.Unified.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Syrna.AuditLogging.Web.Unified.dll"]