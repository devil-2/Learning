CREATE TABLE [dbo].[MenuAction]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Menu] INT NOT NULL, 
    [Area] NVARCHAR(150) NULL, 
    [Controller] NVARCHAR(150) NULL, 
    [Action] NVARCHAR(150) NULL, 
    [View] NVARCHAR(150) NULL, 
    [Type] INT NULL, ---architecture type
    [Url] NVARCHAR(200) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_MenuAction_ToMenu] FOREIGN KEY ([Menu]) REFERENCES [Menu]([Id])
)
