FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

WORKDIR /src

COPY ["src/Ozon.MerchandiseService.csproj",  "src/"]

RUN dotnet restore "src/Ozon.MerchandiseService.csproj"

COPY . .

WORKDIR /src/src

RUN dotnet build "Ozon.MerchandiseService.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "Ozon.MerchandiseService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app

EXPOSE 80

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "Ozon.MerchandiseService.dll" ]


