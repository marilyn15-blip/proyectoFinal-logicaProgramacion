USE [ProyectoBusesDB]
go
CREATE TABLE RutaHorarioBus (
    RutaHorarioBusID INT PRIMARY KEY IDENTITY(1,1),
    RutaHorarioID INT,
    BusID INT,
    FOREIGN KEY (RutaHorarioID) REFERENCES RutaHorario(RutaHorarioID)
    ON DELETE CASCADE
)   