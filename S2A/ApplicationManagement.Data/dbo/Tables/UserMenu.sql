CREATE TABLE [dbo].[UserMenu]
(
    [User] NVARCHAR(128) NOT NULL, 
    [Menu] INT NOT NULL, 
    [CanView] BIT NOT NULL DEFAULT 0, 
    [CanAdd] BIT NOT NULL DEFAULT 0, 
    [CanUpdate] BIT NOT NULL DEFAULT 0, 
    [CanDelete] BIT NOT NULL DEFAULT 0,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_UserMenu] PRIMARY KEY ([User],[Menu]), 
    CONSTRAINT [FK_UserMenu_ToUser] FOREIGN KEY ([User]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserMenu_ToMenu] FOREIGN KEY ([Menu]) REFERENCES [Menu]([Id])
)
