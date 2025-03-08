


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrdersAPI/OrdersAPI.csproj", "OrdersAPI/"]
COPY ["Orders.Application/Orders.Application.csproj", "Orders.Application/"]
COPY ["Orders.DataAccess/Orders.Infrastructure.csproj", "Orders.DataAccess/"]
COPY ["Orders.Models/Orders.Domain.csproj", "Orders.Models/"]
RUN dotnet restore "./OrdersAPI/OrdersAPI.csproj"
COPY . .
WORKDIR "/src/OrdersAPI"
RUN dotnet build "./OrdersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrdersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersAPI.dll"]