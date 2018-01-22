CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [login] CHAR(10) NOT NULL, 
    [password] NCHAR(10) NOT NULL, 
    [email] NCHAR(10) NULL, 
    [info] NCHAR(10) NULL
)
