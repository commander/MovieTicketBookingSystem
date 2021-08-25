FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mtbs.Api/Mtbs.Api.csproj", "Mtbs.Api/"]
COPY ["Mtbs.Core/Mtbs.Core.csproj", "Mtbs.Core/"]
COPY ["Mtbs.Models/Mtbs.Models.csproj", "Mtbs.Models/"]
COPY ["Mtbs.DataAccess/Mtbs.DataAccess.csproj", "Mtbs.DataAccess/"]
RUN dotnet restore "Mtbs.Api/Mtbs.Api.csproj"
COPY . .
WORKDIR "/src/Mtbs.Api"
RUN dotnet build "Mtbs.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mtbs.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mtbs.Api.dll"]
