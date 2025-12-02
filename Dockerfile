# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del proyecto
COPY . ./

# Publicar en Release
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar el build publicado
COPY --from=build /app/out .

# Render asigna un puerto dinámico en la variable $PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

# Tu DLL se llama VERMUTCLUB.dll
ENTRYPOINT ["dotnet", "VermutClub.dll"]
