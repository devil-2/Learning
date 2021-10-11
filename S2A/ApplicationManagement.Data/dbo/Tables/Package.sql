CREATE TABLE [dbo].[Package]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [NameLabel] INT NOT NULL,
    [Type] INT NOT NULL,--web/windows
    [Deleted] BIT NOT NULL DEFAULT 0
)
