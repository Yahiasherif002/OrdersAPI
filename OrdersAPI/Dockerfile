# Build stage - Build the application from source code
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

# Set working directory to /src
WORKDIR /src

# Copy only the .csproj files first to cache dependencies
COPY ["OrdersAPI/OrdersAPI.csproj", "OrdersAPI/"]
COPY ["Orders.Application/Orders.Application.csproj", "Orders.Application/"]
COPY ["Orders.DataAccess/Orders.Infrastructure.csproj", "Orders.DataAccess/"]
COPY ["Orders.Models/Orders.Domain.csproj", "Orders.Models/"]

# Run dotnet restore with verbose output
RUN dotnet restore "./OrdersAPI/OrdersAPI.csproj" --verbosity detailed

# Now copy all the source files
COPY . .

# Set the working directory to the OrdersAPI project
WORKDIR "/src/OrdersAPI"

# Build the application
RUN dotnet build "./OrdersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage - Create a publish version of the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publish the application
RUN dotnet publish "./OrdersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage - Production/Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Set the working directory to /app in the final image
WORKDIR /app

# Copy the published app from the publish stage
COPY --from=publish /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "OrdersAPI.dll"]
