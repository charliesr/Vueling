USE VuelingCrud
GO

CREATE TYPE StudentType AS TABLE
(
   GUID		        uniqueidentifier,
   Nombre			NVARCHAR(50),
   Apellidos		NVARCHAR(50),
   DNI				CHAR(9),
   FechaNacimiento	DateTime,
   FechaRegistro	DateTime,
   Edad				INT
)
GO

CREATE PROCEDURE AddStudent 
	@studentTvp [StudentType] READONLY 
	AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM Students WHERE Students.GUID = (SELECT TOP(1) GUID FROM @studentTvp))
			INSERT INTO dbo.Students
				([GUID],[Nombre],[Apellidos],[DNI],[FechaNacimiento],[FechaRegistro],[Edad])
			SELECT TOP(1) [GUID],[Nombre],[Apellidos],[DNI],[FechaNacimiento],[FechaRegistro],[Edad] FROM @studentTvp
	END;
GO

CREATE PROCEDURE SelectAllStudents AS
    SELECT * FROM dbo.Students
    RETURN
GO

CREATE PROCEDURE SelectByGuid 
    @guid uniqueidentifier AS
    SELECT * FROM Students WHERE Students.GUID = @guid
GO

CREATE PROCEDURE DeleteStudent
    @guid uniqueidentifier AS
    DELETE FROM Students WHERE Students.GUID = @guid
GO

CREATE PROCEDURE UpdateStudent
    @guid uniqueidentifier,
    @studentTvp [StudentType] READONLY AS
    IF EXISTS (SELECT * FROM Students WHERE Students.GUID = @guid)
    BEGIN
        EXEC DeleteStudent @guid;
        EXEC AddStudent @studentTvp;
    END;
GO

