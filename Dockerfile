# Estágio de Build (Compilação) usando o SDK 7.0
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY . ./
RUN dotnet restore

# Publica o app em modo Release na pasta 'out'
RUN dotnet publish -c Release -o out

# Estágio de Execução (Rodar o app) usando o Runtime 7.0
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta 80 para o Render
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Comando para iniciar a sua API
ENTRYPOINT ["dotnet", "JworgApi.dll"]