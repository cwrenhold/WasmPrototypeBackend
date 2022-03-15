#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WasmPrototypeBackend.MVC/WasmPrototypeBackend.MVC.fsproj", "WasmPrototypeBackend.MVC/"]
RUN dotnet restore "WasmPrototypeBackend.MVC/WasmPrototypeBackend.MVC.fsproj"
COPY . .
WORKDIR "/src/WasmPrototypeBackend.MVC"
RUN dotnet build "WasmPrototypeBackend.MVC.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WasmPrototypeBackend.MVC.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WasmPrototypeBackend.MVC.dll"]
