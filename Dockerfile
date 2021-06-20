FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

WORKDIR /src

COPY ./paket.dependencies .
COPY ./paket.lock .
COPY ./.paket/ ./.paket/
COPY ./.config/ ./.config/

RUN dotnet tool restore

RUN dotnet paket restore

COPY ./demo/ ./app/

RUN dotnet publish ./app/Hateoas.Sample.sln -c Release -o /deploy

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as final

WORKDIR /app

COPY --from=build /deploy .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "WebApi.dll"]