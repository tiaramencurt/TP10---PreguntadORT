CREATE DATABASE PreguntadOrt;
GO
USE PreguntadOrt;
GO

CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Foto VARCHAR(200) NULL
);

CREATE TABLE Preguntas (
    IdPregunta INT IDENTITY(1,1) PRIMARY KEY,
    IdCategoria INT NOT NULL FOREIGN KEY REFERENCES Categorias(IdCategoria),
    Enunciado VARCHAR(MAX) NOT NULL,
    Foto VARCHAR(200) NULL
);

CREATE TABLE Respuestas (
    IdRespuesta INT IDENTITY(1,1) PRIMARY KEY,
    IdPregunta INT NOT NULL FOREIGN KEY REFERENCES Preguntas(IdPregunta),
    Opcion INT NOT NULL, -- 1..4
    Contenido VARCHAR(500) NOT NULL,
    Correcta BIT NOT NULL,
    Foto VARCHAR(200) NULL
);

-- Opcional: tabla Puntajes (para el opcional)
CREATE TABLE Puntajes (
    IdPuntaje INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Puntaje INT NOT NULL,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE()
);
GO
