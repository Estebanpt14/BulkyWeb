FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj .
RUN dotnet restore

# Copiar y construir la aplicación
COPY . .
RUN dotnet build -c Release

# Instalar el paquete de Evolve
#RUN dotnet add package Evolve

# Evolve - Ejecutar migraciones antes de iniciar la aplicación
#RUN dotnet tool install --global Evolve.CommandLine
#ENV PATH="${PATH}:/root/.dotnet/tools"
#RUN evolve migrate -c "Host=db;Port=5432;Database=your_database;Username=your_username;Password=your_password;Pooling=true;"

# Publicar la aplicación
RUN dotnet publish -c Release -o out

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out ./

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "BulkyWeb.dll"]
