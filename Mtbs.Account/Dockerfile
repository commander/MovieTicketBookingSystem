#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mtbs.Account/Mtbs.Account.csproj", "Mtbs.Account/"]
RUN dotnet restore "Mtbs.Account/Mtbs.Account.csproj"
COPY . .
WORKDIR "/src/Mtbs.Account"
RUN dotnet build "Mtbs.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mtbs.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mtbs.Account.dll"]