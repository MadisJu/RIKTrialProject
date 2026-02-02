FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
ARG APP_UID=1000
ENV APP_UID=$APP_UID
WORKDIR /app
RUN mkdir -p /app/data && chown -R $APP_UID /app/data
USER $APP_UID
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RIKTrialServer/RIKTrialServer.csproj", "RIKTrialServer/"]
RUN dotnet restore "./RIKTrialServer/RIKTrialServer.csproj"
COPY . .
WORKDIR "/src/RIKTrialServer"
RUN dotnet build "./RIKTrialServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RIKTrialServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RIKTrialServer.dll"]