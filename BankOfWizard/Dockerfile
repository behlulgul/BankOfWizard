#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BankOfWizard/BankOfWizard.csproj", "BankOfWizard/"]
COPY ["BankOfWizard.Identity/BankOfWizard.Identity.csproj", "BankOfWizard.Identity/"]
COPY ["BankOfWizard.App/BankOfWizard.App.csproj", "BankOfWizard.App/"]
COPY ["BankOfWizard.Domain/BankOfWizard.Domain.csproj", "BankOfWizard.Domain/"]
COPY ["BankOfWizard.Repository/BankOfWizard.Repository.csproj", "BankOfWizard.Repository/"]
RUN dotnet restore "BankOfWizard/BankOfWizard.csproj"
COPY . .
WORKDIR "/src/BankOfWizard"
RUN dotnet build "BankOfWizard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankOfWizard.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankOfWizard.dll"]