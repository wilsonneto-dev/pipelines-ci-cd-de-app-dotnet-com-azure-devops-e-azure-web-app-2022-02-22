FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY . .
RUN dotnet restore "./src/BooksCatalog.Api/BooksCatalog.Api.csproj"
RUN dotnet tool install --global dotnet-ef


CMD set -e; cd ./src/BooksCatalog.Infra.Persistence/; until /root/.dotnet/tools/dotnet-ef database update -s ../BooksCatalog.Api/BooksCatalog.Api.csproj -v; do	>&2 echo "SQL Server is starting up, trying to migrations"; sleep 1; done; >&2 echo "finished"
