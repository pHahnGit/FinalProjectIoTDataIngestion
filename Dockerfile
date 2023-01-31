#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/src/RawDataManager/", "/src/RawDataManager"]
COPY ["/src/SensadeLibrary/", "/src/SensadeLibrary"]
RUN dotnet restore "RawDataManager/RawDataManager.csproj"
#COPY . .
WORKDIR "/src/RawDataManager/"
RUN dotnet build "RawDataManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RawDataManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "RawDataManager.dll"]

