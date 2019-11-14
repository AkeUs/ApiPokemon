FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /src
COPY ["PokeApiCustom/PokeApiCustom.csproj", "PokeApiCustom/"]
RUN dotnet restore "PokeApiCustom/PokeApiCustom.csproj"
COPY . .
WORKDIR "/src/PokeApiCustom"
RUN dotnet build "PokeApiCustom.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PokeApiCustom.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PokeApiCustom.dll"]