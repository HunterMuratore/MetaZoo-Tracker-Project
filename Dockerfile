FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Install NodeJS
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -y nodejs

# Copy csproj and restore as distinct layers
COPY ["Inventory Tracker Project.sln", "./"]
COPY ["Inventory Tracker Project/Inventory Tracker Project.csproj", "./Inventory Tracker Project/"]
COPY ["Inventory Tracker Project Tests/Inventory Tracker Project Tests.csproj", "./Inventory Tracker Project Tests/"]
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Inventory Tracker Project.dll"]