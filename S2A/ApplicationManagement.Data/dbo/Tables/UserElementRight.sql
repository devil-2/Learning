CREATE TABLE [dbo].[UserElementRight]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[User] nvarchar(128) NOT NULL, 
    [ActionElement] INT NOT NULL, 
    [AddEnabled] BIT NOT NULL DEFAULT 0, 
    [ViewEnabled] BIT NOT NULL DEFAULT 0, 
    [UpdateEnabled] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_UserElementRight_User_ActionElement] UNIQUE ([User],[ActionElement]), 
    CONSTRAINT [FK_UserElementRight_ToUser] FOREIGN KEY ([User]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserElementRight_ToActionElement] FOREIGN KEY ([ActionElement]) REFERENCES [ActionElement]([Id])
)
