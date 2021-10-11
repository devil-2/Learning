CREATE TABLE [dbo].[Database]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Organisation] INT NOT NULL,
    [Type] INT NOT NULL, --DbType /oracle/sqlserver
    [Server] NVARCHAR(150) NOT NULL, 
    [Host] NVARCHAR(150) NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL,
    [UserId] NVARCHAR(150) NOT NULL, 
    [Password] NVARCHAR(255) NOT NULL, 
    [Status] INT NOT NULL, --active/inactive
    [Readonly] INT NOT NULL, -- ReadOnly/WriteOnly/ReadWrite
    CONSTRAINT [FK_Database_ToOrganisation] FOREIGN KEY ([Organisation]) REFERENCES [Organisation]([Id])
)
