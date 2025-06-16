FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["Apis/SilverCart.WebAPI/SilverCart.WebAPI.csproj", "Apis/SilverCart.WebAPI/"]
COPY ["Apis/SilverCart.Application/SilverCart.Application.csproj", "Apis/SilverCart.Application/"]
COPY ["Apis/SilverCart.Domain/SilverCart.Domain.csproj", "Apis/SilverCart.Domain/"]
COPY ["Apis/SilverCart.Infrastructure/SilverCart.Infrastructure.csproj", "Apis/SilverCart.Infrastructure/"]

# Restore packages
RUN dotnet restore "Apis/SilverCart.WebAPI/SilverCart.WebAPI.csproj"

# Copy everything else
COPY . .

# Build the application
WORKDIR "/src/Apis/SilverCart.WebAPI"
RUN dotnet build "SilverCart.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SilverCart.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SilverCart.WebAPI.dll"] 