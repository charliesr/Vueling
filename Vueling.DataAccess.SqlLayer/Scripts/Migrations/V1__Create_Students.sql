USE VuelingCrud  
-- Creamos la Tabla
CREATE TABLE dbo.Students
(
   GUID					uniqueidentifier	NOT NULL	UNIQUE,
   Id					INT IDENTITY(1,1)   NOT NULL   PRIMARY KEY,
   Nombre				NVARCHAR(50)		NOT NULL,
   Apellidos			NVARCHAR(50)		NOT NULL,
   DNI					CHAR(9)				NOT NULL,
   FechaDeNacimiento	DateTime			NOT NULL,
   FechaHoraRegistro	DateTime			NOT NULL,
   Edad					INT					NOT NULL
);
GO