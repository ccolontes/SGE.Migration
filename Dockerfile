FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SGE.Api/SGE.Api.csproj", "SGE.Api/"]
COPY ["src/SGE.Application/SGE.Application.csproj", "SGE.Application/"]
COPY ["src/SGE.Domain/SGE.Domain.csproj", "SGE.Domain/"]
COPY ["src/SGE.Contracts/SGE.Contracts.csproj", "SGE.Contracts/"]
COPY ["src/SGE.Infrastructure/SGE.Infrastructure.csproj", "SGE.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "SGE.Api/SGE.Api.csproj"
COPY . ../
WORKDIR /src/SGE.Api
RUN dotnet build "SGE.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGE.Api.dll"]