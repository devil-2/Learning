CREATE TABLE [dbo].[MenuAction]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Menu] INT NOT NULL, 
    [Area] NVARCHAR(50) NULL, 
    [Controller] NVARCHAR(50) NULL, 
    [Action] NVARCHAR(50) NULL, 
    [Type] SMALLINT NULL, 
    [Url] NVARCHAR(200) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_MenuAction_ToMenu] FOREIGN KEY ([Menu]) REFERENCES [Menu]([Id])
)
