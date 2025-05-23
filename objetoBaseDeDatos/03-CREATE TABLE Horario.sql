    USE [ProyectoBusesDB]
    go
    CREATE TABLE Horario(
    HorarioID INT PRIMARY KEY IDENTITY(1,1),
    horaSalida TIME,
    horaLLegada TIME
   
    )