CREATE TABLE [dbo].[Menu]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Package] INT NOT NULL, 
    [NameLabel] INT NOT NULL, 
    [Parent] INT NOT NULL, 
    [CanAdd] BIT NOT NULL DEFAULT 0, 
    [CanView] BIT NOT NULL DEFAULT 0, 
    [CanDelete] BIT NOT NULL DEFAULT 0, 
    [CanUpdate] BIT NOT NULL DEFAULT 0, 
    [Action] INT NOT NULL, 
    [Type] SMALLINT NOT NULL DEFAULT 0,
    [Deleted] BIT NOT NULL DEFAULT 0
)
