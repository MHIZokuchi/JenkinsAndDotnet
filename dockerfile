#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.sln .
COPY ["Asp.netCoreMVCCRUD/Asp.netCoreMVCCRUD.csproj", "Asp.netCoreMVCCRUD/"]
RUN dotnet restore "Asp.netCoreMVCCRUD/Asp.netCoreMVCCRUD.csproj"
COPY . .
WORKDIR "/src/Asp.netCoreMVCCRUD"
RUN dotnet build "Asp.netCoreMVCCRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp.netCoreMVCCRUD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Asp.netCoreMVCCRUD.dll
