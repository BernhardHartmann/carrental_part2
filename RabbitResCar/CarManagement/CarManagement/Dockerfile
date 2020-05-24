#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.0-nanoserver-1903 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1903 AS build
WORKDIR /src
COPY ["CarManagement/CarManagement.csproj", "CarManagement/"]
RUN dotnet restore "CarManagement/CarManagement.csproj"
COPY . .
WORKDIR "/src/CarManagement"
RUN dotnet build "CarManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarManagement.dll"]