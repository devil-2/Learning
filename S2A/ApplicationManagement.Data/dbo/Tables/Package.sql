CREATE TABLE [dbo].[Package]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [NameLabel] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0
)
