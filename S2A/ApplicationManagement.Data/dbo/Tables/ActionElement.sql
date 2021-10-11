CREATE TABLE [dbo].[ActionElement]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [MenuAction] INT NOT NULL, 
    [ElementName] VARCHAR(200) NOT NULL, 
    [Type] INT NOT NULL, 
    [Label] INT NULL,
    [AddEnabled] BIT NOT NULL DEFAULT 0, 
    [ViewEnabled] BIT NOT NULL DEFAULT 0, 
    [UpdateEnabled] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_ActionElement_Action_ElementName] UNIQUE ([MenuAction],[ElementName],[Type]), 
    CONSTRAINT [FK_ActionElement_ToMenuAction] FOREIGN KEY ([MenuAction]) REFERENCES [MenuAction]([Id])
)
