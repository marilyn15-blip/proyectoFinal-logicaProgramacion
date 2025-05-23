    USE [ProyectoBusesDB]
    go
    CREATE TABLE Ruta(
    RutaID INT PRIMARY KEY IDENTITY(1,1),
    LugarSalida NVARCHAR(100),
    LugarLlegada NVARCHAR(100)
    
    )

