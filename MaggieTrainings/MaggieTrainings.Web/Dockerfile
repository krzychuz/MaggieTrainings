#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MaggieTrainings.Web/MaggieTrainings.Web.csproj", "MaggieTrainings.Web/"]
COPY ["MaggieTrainings.Domain/MaggieTrainings.Domain.csproj", "MaggieTrainings.Domain/"]
RUN dotnet restore "MaggieTrainings.Web/MaggieTrainings.Web.csproj"
COPY . .
WORKDIR "/src/MaggieTrainings.Web"
RUN dotnet build "MaggieTrainings.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MaggieTrainings.Web.csproj" -c Release -o /app/publish
COPY "MaggieTrainings.db" /app/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MaggieTrainings.Web.dll"]