FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY ["src/Ozon.MerchApi/Ozon.MerchApi.csproj",  "src/"]
RUN dotnet restore "src/Ozon.MerchApi.csproj"

COPY . .
WORKDIR /src/src/Ozon.MerchApi
RUN dotnet build "Ozon.MerchApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ozon.MerchApi.csproj" -c Release -o /app/publish
COPY "entrypoint.sh" "/app/publish/."

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
EXPOSE 80

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh


