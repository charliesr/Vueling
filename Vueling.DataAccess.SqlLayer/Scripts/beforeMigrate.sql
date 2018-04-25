IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'VuelingCrud'
)
CREATE DATABASE VuelingCrud
ON PRIMARY(
    name='VuelingCrud_Primary',
	filename='C:\DataBase\VuelingCrud.mdf',
	size=4MB,
	maxsize=10MB,
	filegrowth=1MB),
FILEGROUP VuelingCrud_FG1
  ( NAME = 'VuelingCrud_FG1_Dat1',
    FILENAME =
       'C:\DataBase\VuelingCrud_FG1_1.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB),
  ( NAME = 'VuelingCrud_FG1_Dat2',
    FILENAME =
       'C:\DataBase\VuelingCrud_FG1_2.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB),
FILEGROUP VuelingCrudFileStreamGroup1 CONTAINS FILESTREAM
  ( NAME = 'VuelingCrud_FS',
    FILENAME = 'c:\DataBase\VuelingCrudFileStream')
LOG ON(
	name=VuelingCrudlog,
	filename='C:\DataBase\VuelingCrudlog.ldf',
	size=2MB, 
	maxsize=2MB,
	filegrowth=0MB
	)
	COLLATE modern_spanish_ci_as
GO