USE VuelingCrud  
-- Creamos la Tabla
CREATE TABLE dbo.Students
(
   Id			INT IDENTITY(1,1)   NOT NULL   PRIMARY KEY,
   GUID		uniqueidentifier NOT NULL,
   Nombre			[NVARCHAR](50)  NOT NULL,
   Apellidos		[NVARCHAR](50)  NOT NULL,
   DNI				[CHAR](9)		NOT NULL,
   FechaNacimiento	DateTime		NOT NULL,
   FechaRegistro	DateTime		NOT NULL,
   Edad				INT				NOT NULL
);
GO