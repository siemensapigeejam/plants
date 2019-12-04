# Define base image
FROM microsoft/dotnet:2.2-sdk AS build-env

# Copy project files
WORKDIR /source
COPY ["DESPortal.Plants/DESPortal.Plants.csproj", "./DESPortal.Plants/DESPortal.Plants.csproj"]

# Restore
RUN dotnet restore "./DESPortal.Plants/DESPortal.Plants.csproj"

# Copy all source code
COPY . .

# Publish
WORKDIR /source
RUN dotnet publish -c Release -o /publish

# Runtime
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "DESPortal.Plants.dll"]
