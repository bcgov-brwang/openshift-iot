# Use an official .NET Core runtime as a parent image
#FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1
#FROM microsoft/dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS build

# Set the working directory to /app
WORKDIR /app

# Copy the published output of the .NET Core app to the container
COPY bin/Debug/netcoreapp3.1/ .
COPY Dockerfile /tmp/build/inputs/Dockerfile

# Expose port 80 to the world outside this container
#EXPOSE 80

# Define environment variable
ENV ASPNETCORE_ENVIRONMENT Production

# Run the .NET Core app on container startup
ENTRYPOINT ["dotnet", "MqttPublisher.dll"]
