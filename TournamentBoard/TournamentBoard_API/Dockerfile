FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TournamentBoard_API/TournamentBoard_API.csproj", "TournamentBoard_API/"]
RUN dotnet restore "TournamentBoard_API/TournamentBoard_API.csproj"
COPY . .
WORKDIR "/src/TournamentBoard_API"
RUN dotnet build "TournamentBoard_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TournamentBoard_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TournamentBoard_API.dll"]