CREATE TABLE [dbo].[ProileRight]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Profile] INT NOT NULL, 
    [Menu] INT NOT NULL, 
    [CanView] BIT NOT NULL DEFAULT 0, 
    [CanAdd] BIT NOT NULL DEFAULT 0, 
    [CanUpdate] BIT NOT NULL DEFAULT 0, 
    [CanDelete] BIT NOT NULL DEFAULT 0,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_ProileRight_ToProfile] FOREIGN KEY ([Profile]) REFERENCES [Profile]([Id]), 
    CONSTRAINT [FK_ProileRight_ToMenu] FOREIGN KEY ([Menu]) REFERENCES [Menu]([Id])
)
