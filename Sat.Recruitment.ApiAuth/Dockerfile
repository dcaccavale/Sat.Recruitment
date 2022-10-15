#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sat.Recruitment.ApiAuth/Sat.Recruitment.ApiAuth.csproj", "Sat.Recruitment.ApiAuth/"]
COPY ["Sat.Recruitment.ApiAuth.ServiceModel/Sat.Recruitment.ApiAuth.ServiceModel.csproj", "Sat.Recruitment.ApiAuth.ServiceModel/"]
RUN dotnet restore "Sat.Recruitment.ApiAuth/Sat.Recruitment.ApiAuth.csproj"
COPY . .
WORKDIR "/src/Sat.Recruitment.ApiAuth"
RUN dotnet build "Sat.Recruitment.ApiAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sat.Recruitment.ApiAuth.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sat.Recruitment.ApiAuth.dll"]