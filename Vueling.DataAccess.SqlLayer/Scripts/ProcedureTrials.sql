USE VuelingCrud
GO
DECLARE @pruebaStudent AS [dbo].[StudentType]

INSERT INTO @pruebaStudent
VALUES 
(
	NEWID(),
	'Carlos',
	'Sanchez Romero',
	'64646464Y',
	SYSDATETIME(),
	SYSDATETIME(),
	30
)

EXEC dbo.AddStudent @pruebaStudent;