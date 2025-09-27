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

-- ========================
-- INSERTAR CATEGORIAS
-- ========================
INSERT INTO Categorias (Nombre, Foto) VALUES
('Historia', NULL),
('Ciencia', NULL),
('Geografía', NULL),
('Literatura', NULL),
('Cultura General', NULL),
('Tecnología', NULL),
('Arte', NULL),
('Deportes', NULL),
('Cine', NULL),
('Música', NULL);

-- ========================
-- INSERTAR PREGUNTAS
-- ========================
-- Historia (1)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(1,'¿Quién fue el primer presidente de Argentina?',NULL),
(1,'¿En qué año comenzó la Revolución Francesa?',NULL),
(1,'¿Qué evento marcó el fin de la Segunda Guerra Mundial?',NULL),
(1,'¿Quién lideró la independencia de México?',NULL),
(1,'¿Cuál fue la causa principal de la Primera Guerra Mundial?',NULL);

-- Ciencia (2)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(2,'¿Cuál es la fórmula química del agua?',NULL),
(2,'¿Qué planeta es conocido como el planeta rojo?',NULL),
(2,'¿Quién propuso la teoría de la relatividad?',NULL),
(2,'¿Qué órgano produce insulina?',NULL),
(2,'¿Qué gas respiramos principalmente?',NULL);

-- Geografía (3)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(3,'¿Cuál es la capital de Japón?',NULL),
(3,'¿Qué río es el más largo del mundo?',NULL),
(3,'¿Cuál es el país más grande del mundo?',NULL),
(3,'¿Qué desierto es el más árido?',NULL),
(3,'¿Qué océano es el más grande?',NULL);

-- Literatura (4)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(4,'¿Quién escribió "Cien años de soledad"?',NULL),
(4,'¿Quién escribió "Don Quijote de la Mancha"?',NULL),
(4,'¿Qué poeta escribió "La Divina Comedia"?',NULL),
(4,'¿Qué autora escribió "Orgullo y Prejuicio"?',NULL),
(4,'¿Quién es el autor de "Hamlet"?',NULL);

-- Cultura General (5)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(5,'¿Cuál es el idioma más hablado del mundo?',NULL),
(5,'¿Qué país tiene más población?',NULL),
(5,'¿Cuál es la moneda de Estados Unidos?',NULL),
(5,'¿Qué continente tiene más países?',NULL),
(5,'¿Cuál es el animal terrestre más rápido?',NULL);

-- Tecnología (6)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(6,'¿Quién es considerado el padre de la computación?',NULL),
(6,'¿Qué significa "HTML"?',NULL),
(6,'¿Qué empresa creó el sistema operativo Windows?',NULL),
(6,'¿Qué lenguaje se usa para crear páginas web?',NULL),
(6,'¿Qué es un CPU?',NULL);

-- Arte (7)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(7,'¿Quién pintó la Mona Lisa?',NULL),
(7,'¿Qué corriente artística representa a Salvador Dalí?',NULL),
(7,'¿Dónde se encuentra el museo del Louvre?',NULL),
(7,'¿Qué técnica usa pincel sobre húmedo en pintura?',NULL),
(7,'¿Quién es el autor de la Capilla Sixtina?',NULL);

-- Deportes (8)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(8,'¿Cuántos jugadores tiene un equipo de fútbol?',NULL),
(8,'¿En qué país se originó el tenis?',NULL),
(8,'¿Qué deportista tiene más medallas olímpicas?',NULL),
(8,'¿Cuál es el récord mundial de 100m planos?',NULL),
(8,'¿Qué deporte usa un disco llamado puck?',NULL);

-- Cine (9)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(9,'¿Quién dirigió "Titanic"?',NULL),
(9,'¿En qué año se estrenó "Star Wars"?',NULL),
(9,'¿Quién interpretó a Jack Sparrow?',NULL),
(9,'¿Qué película ganó el Oscar a Mejor Película en 2020?',NULL),
(9,'¿Qué actor interpreta a Iron Man?',NULL);

-- Música (10)
INSERT INTO Preguntas (IdCategoria, Enunciado, Foto) VALUES
(10,'¿Quién compuso la Novena Sinfonía?',NULL),
(10,'¿Qué banda cantó "Bohemian Rhapsody"?',NULL),
(10,'¿Qué instrumento tiene 88 teclas?',NULL),
(10,'¿Quién es conocido como el Rey del Pop?',NULL),
(10,'¿Qué género musical es el Reggaetón?',NULL);

-- ========================
-- INSERTAR RESPUESTAS
-- ========================
-- Historia
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(1,1,'Manuel Belgrano',0,NULL),(1,2,'Juan Domingo Perón',0,NULL),(1,3,'Bernardino Rivadavia',1,NULL),(1,4,'Hipólito Yrigoyen',0,NULL),
(2,1,'1789',1,NULL),(2,2,'1776',0,NULL),(2,3,'1804',0,NULL),(2,4,'1799',0,NULL),
(3,1,'La caída del Muro de Berlín',0,NULL),(3,2,'La rendición de Japón',1,NULL),(3,3,'El bombardeo de Pearl Harbor',0,NULL),(3,4,'El tratado de Versalles',0,NULL),
(4,1,'Miguel Hidalgo',1,NULL),(4,2,'Simón Bolívar',0,NULL),(4,3,'José de San Martín',0,NULL),(4,4,'Pancho Villa',0,NULL),
(5,1,'El asesinato del archiduque Francisco Fernando',1,NULL),(5,2,'La Revolución Industrial',0,NULL),(5,3,'La Guerra de Crimea',0,NULL),(5,4,'El Tratado de Versalles',0,NULL);

-- Ciencia
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(6,1,'H2O',1,NULL),(6,2,'CO2',0,NULL),(6,3,'NaCl',0,NULL),(6,4,'O2',0,NULL),
(7,1,'Marte',1,NULL),(7,2,'Júpiter',0,NULL),(7,3,'Venus',0,NULL),(7,4,'Saturno',0,NULL),
(8,1,'Albert Einstein',1,NULL),(8,2,'Isaac Newton',0,NULL),(8,3,'Galileo Galilei',0,NULL),(8,4,'Nikola Tesla',0,NULL),
(9,1,'Hígado',0,NULL),(9,2,'Páncreas',1,NULL),(9,3,'Riñón',0,NULL),(9,4,'Pulmón',0,NULL),
(10,1,'Oxígeno',1,NULL),(10,2,'Nitrógeno',0,NULL),(10,3,'Dióxido de carbono',0,NULL),(10,4,'Hidrógeno',0,NULL);

-- Geografía
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(11,1,'Tokio',1,NULL),(11,2,'Kioto',0,NULL),(11,3,'Osaka',0,NULL),(11,4,'Hiroshima',0,NULL),
(12,1,'Amazonas',0,NULL),(12,2,'Nilo',1,NULL),(12,3,'Yangtsé',0,NULL),(12,4,'Misisipi',0,NULL),
(13,1,'Rusia',1,NULL),(13,2,'China',0,NULL),(13,3,'Estados Unidos',0,NULL),(13,4,'Canadá',0,NULL),
(14,1,'Sahara',1,NULL),(14,2,'Gobi',0,NULL),(14,3,'Atacama',0,NULL),(14,4,'Kalahari',0,NULL),
(15,1,'Pacífico',1,NULL),(15,2,'Atlántico',0,NULL),(15,3,'Índico',0,NULL),(15,4,'Ártico',0,NULL);

-- Literatura
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(16,1,'Gabriel García Márquez',1,NULL),(16,2,'Pablo Neruda',0,NULL),(16,3,'Jorge Luis Borges',0,NULL),(16,4,'Mario Vargas Llosa',0,NULL),
(17,1,'Miguel de Cervantes',1,NULL),(17,2,'Lope de Vega',0,NULL),(17,3,'Gustavo Adolfo Bécquer',0,NULL),(17,4,'Federico García Lorca',0,NULL),
(18,1,'Dante Alighieri',1,NULL),(18,2,'Boccaccio',0,NULL),(18,3,'Petrarca',0,NULL),(18,4,'Goethe',0,NULL),
(19,1,'Jane Austen',1,NULL),(19,2,'Charlotte Brontë',0,NULL),(19,3,'Mary Shelley',0,NULL),(19,4,'Emily Dickinson',0,NULL),
(20,1,'William Shakespeare',1,NULL),(20,2,'John Milton',0,NULL),(20,3,'Geoffrey Chaucer',0,NULL),(20,4,'Edgar Allan Poe',0,NULL);

-- Cultura General
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(21,1,'Inglés',1,NULL),(21,2,'Chino',0,NULL),(21,3,'Español',0,NULL),(21,4,'Francés',0,NULL),
(22,1,'China',1,NULL),(22,2,'India',0,NULL),(22,3,'Estados Unidos',0,NULL),(22,4,'Rusia',0,NULL),
(23,1,'Dólar',1,NULL),(23,2,'Euro',0,NULL),(23,3,'Yen',0,NULL),(23,4,'Libra',0,NULL),
(24,1,'África',1,NULL),(24,2,'Asia',0,NULL),(24,3,'Europa',0,NULL),(24,4,'América',0,NULL),
(25,1,'Guepardo',1,NULL),(25,2,'León',0,NULL),(25,3,'Caballo',0,NULL),(25,4,'Tigre',0,NULL);

-- Tecnología
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(26,1,'Charles Babbage',1,NULL),(26,2,'Alan Turing',0,NULL),(26,3,'Bill Gates',0,NULL),(26,4,'Steve Jobs',0,NULL),
(27,1,'HyperText Markup Language',1,NULL),(27,2,'HighText Machine Language',0,NULL),(27,3,'Hyperlink Machine Language',0,NULL),(27,4,'Home Tool Markup Language',0,NULL),
(28,1,'Microsoft',1,NULL),(28,2,'Apple',0,NULL),(28,3,'IBM',0,NULL),(28,4,'Google',0,NULL),
(29,1,'HTML',0,NULL),(29,2,'JavaScript',1,NULL),(29,3,'Python',0,NULL),(29,4,'C++',0,NULL),
(30,1,'Unidad Central de Proceso',1,NULL),(30,2,'Central Processing Unit',1,NULL),(30,3,'Control Processor Unit',0,NULL),(30,4,'Computer Processing Unit',0,NULL);

-- Arte
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(31,1,'Leonardo da Vinci',1,NULL),(31,2,'Pablo Picasso',0,NULL),(31,3,'Miguel Ángel',0,NULL),(31,4,'Salvador Dalí',0,NULL),
(32,1,'Surrealismo',1,NULL),(32,2,'Impresionismo',0,NULL),(32,3,'Cubismo',0,NULL),(32,4,'Barroco',0,NULL),
(33,1,'París',1,NULL),(33,2,'Roma',0,NULL),(33,3,'Londres',0,NULL),(33,4,'Nueva York',0,NULL),
(34,1,'Acuarela',0,NULL),(34,2,'Óleo sobre húmedo',1,NULL),(34,3,'Témpera',0,NULL),(34,4,'Fresco',0,NULL),
(35,1,'Miguel Ángel',1,NULL),(35,2,'Leonardo da Vinci',0,NULL),(35,3,'Rafael',0,NULL),(35,4,'Donatello',0,NULL);

-- Deportes
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(36,1,'11',1,NULL),(36,2,'10',0,NULL),(36,3,'9',0,NULL),(36,4,'12',0,NULL),
(37,1,'Inglaterra',1,NULL),(37,2,'Francia',0,NULL),(37,3,'Estados Unidos',0,NULL),(37,4,'Australia',0,NULL),
(38,1,'Michael Phelps',1,NULL),(38,2,'Usain Bolt',0,NULL),(38,3,'Mark Spitz',0,NULL),(38,4,'Carl Lewis',0,NULL),
(39,1,'9.58s',1,NULL),(39,2,'10.00s',0,NULL),(39,3,'9.68s',0,NULL),(39,4,'10.12s',0,NULL),
(40,1,'Hockey sobre hielo',1,NULL),(40,2,'Fútbol',0,NULL),(40,3,'Lacrosse',0,NULL),(40,4,'Bandy',0,NULL);

-- Cine
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(41,1,'James Cameron',1,NULL),(41,2,'Steven Spielberg',0,NULL),(41,3,'Christopher Nolan',0,NULL),(41,4,'Martin Scorsese',0,NULL),
(42,1,'1977',1,NULL),(42,2,'1980',0,NULL),(42,3,'1975',0,NULL),(42,4,'1983',0,NULL),
(43,1,'Johnny Depp',1,NULL),(43,2,'Orlando Bloom',0,NULL),(43,3,'Leonardo DiCaprio',0,NULL),(43,4,'Brad Pitt',0,NULL),
(44,1,'Parasite',1,NULL),(44,2,'1917',0,NULL),(44,3,'Joker',0,NULL),(44,4,'Once Upon a Time in Hollywood',0,NULL),
(45,1,'Robert Downey Jr.',1,NULL),(45,2,'Chris Evans',0,NULL),(45,3,'Chris Hemsworth',0,NULL),(45,4,'Mark Ruffalo',0,NULL);

-- Música
INSERT INTO Respuestas (IdPregunta,Opcion,Contenido,Correcta,Foto) VALUES
(46,1,'Ludwig van Beethoven',1,NULL),(46,2,'Johann Sebastian Bach',0,NULL),(46,3,'Wolfgang Amadeus Mozart',0,NULL),(46,4,'Frédéric Chopin',0,NULL),
(47,1,'Queen',1,NULL),(47,2,'The Beatles',0,NULL),(47,3,'Pink Floyd',0,NULL),(47,4,'Led Zeppelin',0,NULL),
(48,1,'Piano',1,NULL),(48,2,'Guitarra',0,NULL),(48,3,'Violín',0,NULL),(48,4,'Flauta',0,NULL),
(49,1,'Michael Jackson',1,NULL),(49,2,'Elvis Presley',0,NULL),(49,3,'Prince',0,NULL),(49,4,'Freddie Mercury',0,NULL),
(50,1,'Reggaetón',1,NULL),(50,2,'Rock',0,NULL),(50,3,'Pop',0,NULL),(50,4,'Salsa',0,NULL);

