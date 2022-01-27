# Get Base SDK image from Windows
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy the .csproj files, .sln file
COPY *.sln ./
COPY WebAPI/*.csproj ./WebAPI/
COPY Entities/*.csproj ./Entities/
COPY DataAccess/*.csproj ./DataAccess/
COPY Core/*.csproj ./Core/
COPY Business/*.csproj ./Business/

# Restore any dependencies (via NUGET)
RUN dotnet restore 

# Copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
