#Para instalar el SDK Dotnet 7

winget install Microsoft.DotNet.SDK.7

dotnet sdk check


#Introduccion al uso de EF Core (Entity Framework Core) con SQLite (Archivo local de base de datos)
Para utilizarlo requerimos, instalar paquetes nuget para el proyecto.

#Paquetes a instalar:

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

#Configuracion del DbContext para la APP:

OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=mydatabase.db");

#Para visualizar la base de datos de forma externa instalar:

https://sqlitestudio.pl/?act=download%E3%80%82SQLiteStudio
