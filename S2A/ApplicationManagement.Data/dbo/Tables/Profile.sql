CREATE TABLE [dbo].[Profile]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NameLabel] INT NOT NULL, 
    [Package] INT NOT NULL,
    [Type] INT NOT NULL,--web/windows
    [Deleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Profile_ToPackage] FOREIGN KEY ([Package]) REFERENCES [Package]([Id])
)
