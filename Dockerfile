FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["I4DAB_resturant.csproj", ""]
RUN dotnet restore "./I4DAB_resturant.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "I4DAB_resturant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "I4DAB_resturant.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "I4DAB_resturant.dll"]