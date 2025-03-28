-- Crear Base de Datos
CREATE DATABASE DB_PRUEBA_BP2;
GO
USE DB_PRUEBA_BP2;
GO

-- Eliminar tablas si existen (en orden inverso a dependencias)
DROP TABLE IF EXISTS tblPoliza;
DROP TABLE IF EXISTS tblAsegurado;
DROP TABLE IF EXISTS tblUsuario;
DROP TABLE IF EXISTS tblTipoPoliza;
DROP TABLE IF EXISTS tblCobertura;
DROP TABLE IF EXISTS tblEstadoPoliza;
DROP TABLE IF EXISTS tblTipoPersona;

-- Crear tablas
CREATE TABLE tblTipoPoliza (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE tblCobertura (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE tblEstadoPoliza (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE tblTipoPersona (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE tblAsegurado (
    CedulaAsegurado VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    PrimerApellido VARCHAR(50) NOT NULL,
    SegundoApellido VARCHAR(50),
    TipoPersonaId INT NOT NULL,
    FechaNacimiento SMALLDATETIME NOT NULL,
    CONSTRAINT FK_Asegurado_TipoPersona FOREIGN KEY (TipoPersonaId)
        REFERENCES tblTipoPersona(Id)
);

CREATE TABLE tblPoliza (
    NumeroPoliza VARCHAR(20) PRIMARY KEY,
    TipoPolizaId INT NOT NULL,
    CedulaAsegurado VARCHAR(20) NOT NULL,
    MontoAsegurado DECIMAL(18, 2) NOT NULL,
    FechaVencimiento SMALLDATETIME NOT NULL,
    FechaEmision SMALLDATETIME NOT NULL,
    CoberturaId INT NOT NULL,
    EstadoPolizaId INT NOT NULL,
    Prima MONEY NOT NULL,
    Periodo SMALLDATETIME NOT NULL,
    FechaInclusion SMALLDATETIME NOT NULL,
    Aseguradora VARCHAR(100) NOT NULL,
    CONSTRAINT FK_Poliza_TipoPoliza FOREIGN KEY (TipoPolizaId)
        REFERENCES tblTipoPoliza(Id),
    CONSTRAINT FK_Poliza_Asegurado FOREIGN KEY (CedulaAsegurado)
        REFERENCES tblAsegurado(CedulaAsegurado),
    CONSTRAINT FK_Poliza_Cobertura FOREIGN KEY (CoberturaId)
        REFERENCES tblCobertura(Id),
    CONSTRAINT FK_Poliza_EstadoPoliza FOREIGN KEY (EstadoPolizaId)
        REFERENCES tblEstadoPoliza(Id)
);

CREATE TABLE tblUsuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL,
    EstaActivo BIT NOT NULL DEFAULT 1
);

-- Insertar Tipos de Persona
INSERT INTO tblTipoPersona (Nombre) VALUES 
('Física'),
('Jurídica');

-- Insertar Estados de Póliza
INSERT INTO tblEstadoPoliza (Nombre) VALUES 
('Activa'),
('Vencida'),
('Cancelada');

-- Insertar Tipos de Cobertura
INSERT INTO tblCobertura (Nombre) VALUES 
('Cobertura Básica'),
('Cobertura Completa'),
('Cobertura Extendida');

-- Insertar Tipos de Póliza
INSERT INTO tblTipoPoliza (Nombre) VALUES 
('Auto'),
('Vida'),
('Hogar');

-- Insertar Asegurados
INSERT INTO tblAsegurado (CedulaAsegurado, Nombre, PrimerApellido, SegundoApellido, TipoPersonaId, FechaNacimiento) VALUES
('100015601', 'Alejandra', 'Castillo', 'Carrillo', 2, '1991-01-01'),
('100025602', 'Antonio', 'Castro', 'Thomlinson', 1, '1992-01-02'),
('100035603', 'Mario', 'Torres', 'Prestes', 2, '1993-01-03'),
('100045604', 'Patricia', 'Banderas', 'Pavon', 1, '1994-01-04'),
('100055605', 'Sofia', 'Camacho', 'Munguia', 2, '1995-01-05'),
('100065606', 'Andrea', 'Rostran', 'Potosme', 1, '1996-01-06'),
('100075607', 'Martin', 'Reina', 'Pena', 2, '1997-01-07'),
('100085608', 'Jose', 'Campo', 'Trujillo', 1, '1998-01-08'),
('100095609', 'Beatriz', 'Jimenez', 'Garcia', 2, '1999-01-09'),
('100105610', 'Lorena', 'Elizondo', 'Oli', 1, '2000-01-10');

-- Insertar Tipos de Póliza
INSERT INTO tblTipoPoliza (Nombre) VALUES 
('Auto'),
('Vida'),
('Hogar');



-- Insertar Pólizas
INSERT INTO tblPoliza (
    NumeroPoliza, TipoPolizaId, CedulaAsegurado, MontoAsegurado,
    FechaVencimiento, FechaEmision, CoberturaId, EstadoPolizaId,
    Prima, Periodo, FechaInclusion, Aseguradora
) VALUES
('PZ-1001', 2, '100025602', 3085602.57, '2023-01-16', '2022-01-16', 2, 2, 308560.26, '2022-02-15', '2022-01-16', 'INS'),
('PZ-1002', 3, '100035603', 2784156.26, '2023-01-31', '2022-01-31', 3, 3, 278415.63, '2022-03-02', '2022-01-31', 'INS'),
('PZ-1003', 1, '100045604', 1148159.49, '2023-02-15', '2022-02-15', 1, 1, 114815.95, '2022-03-17', '2022-02-15', 'INS'),
('PZ-1004', 2, '100055605', 3370579.57, '2023-03-02', '2022-03-02', 2, 2, 337057.96, '2022-04-01', '2022-03-02', 'INS'),
('PZ-1005', 3, '100065606', 3121808.76, '2023-03-17', '2022-03-17', 3, 3, 312180.88, '2022-04-16', '2022-03-17', 'ASSA'),
('PZ-1006', 1, '100075607', 4140940.67, '2023-04-01', '2022-04-01', 1, 1, 414094.07, '2022-05-01', '2022-04-01', 'INS'),
('PZ-1007', 2, '100085608', 3153686.81, '2023-04-16', '2022-04-16', 2, 2, 315368.68, '2022-05-16', '2022-04-16', 'INS'),
('PZ-1008', 3, '100095609', 3461191.78, '2023-05-01', '2022-05-01', 3, 3, 346119.18, '2022-05-31', '2022-05-01', 'MAPFRE'),
('PZ-1009', 1, '100105610', 3662763.87, '2023-05-16', '2022-05-16', 1, 1, 366276.39, '2022-06-15', '2022-05-16', 'INS'),
('PZ-1010', 2, '100015601', 1411955.72, '2023-05-31', '2022-05-31', 2, 2, 141195.57, '2022-06-30', '2022-05-31', 'MAPFRE'),
('PZ-1011', 3, '100025602', 3041426.13, '2023-06-15', '2022-06-15', 3, 3, 304142.61, '2022-07-15', '2022-06-15', 'INS'),
('PZ-1012', 1, '100035603', 4751692.95, '2023-06-30', '2022-06-30', 1, 1, 475169.30, '2022-07-30', '2022-06-30', 'MAPFRE'),
('PZ-1013', 2, '100045604', 4877492.84, '2023-07-15', '2022-07-15', 2, 2, 487749.28, '2022-08-14', '2022-07-15', 'INS'),
('PZ-1014', 3, '100055605', 2329293.89, '2023-07-30', '2022-07-30', 3, 3, 232929.39, '2022-08-29', '2022-07-30', 'ASSA'),
('PZ-1015', 1, '100065606', 2527180.91, '2023-08-14', '2022-08-14', 1, 1, 252718.09, '2022-09-13', '2022-08-14', 'MAPFRE'),
('PZ-1016', 2, '100075607', 1149630.45, '2023-08-29', '2022-08-29', 2, 2, 114963.04, '2022-09-28', '2022-08-29', 'ASSA'),
('PZ-1017', 3, '100085608', 4925195.59, '2023-09-13', '2022-09-13', 3, 3, 492519.56, '2022-10-13', '2022-09-13', 'ASSA'),
('PZ-1018', 1, '100095609', 1571895.52, '2023-09-28', '2022-09-28', 1, 1, 157189.55, '2022-10-28', '2022-09-28', 'INS'),
('PZ-1019', 2, '100105610', 4480013.47, '2023-10-13', '2022-10-13', 2, 2, 448001.35, '2022-11-12', '2022-10-13', 'INS'),
('PZ-1020', 3, '100015601', 3688750.85, '2023-10-28', '2022-10-28', 3, 3, 368875.09, '2022-11-27', '2022-10-28', 'ASSA');


-- Insertar usuario admin
INSERT INTO tblUsuario (NombreUsuario, Contrasena, Rol, EstaActivo) VALUES 
('admin', '1234', 'Administrador', 1);
