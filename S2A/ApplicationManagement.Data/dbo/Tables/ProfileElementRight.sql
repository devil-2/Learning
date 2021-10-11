CREATE TABLE [dbo].[ProfileElementRight]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[Profile] INT NOT NULL, 
    [ActionElement] INT NOT NULL, 
    [AddEnabled] BIT NOT NULL DEFAULT 0, 
    [ViewEnabled] BIT NOT NULL DEFAULT 0, 
    [UpdateEnabled] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_ProfileElementRight_Profile_ActionElement] UNIQUE  ([Profile],[ActionElement]), 
    CONSTRAINT [FK_ProfileElementRight_ToProfile] FOREIGN KEY ([Profile]) REFERENCES [Profile]([Id]), 
    CONSTRAINT [FK_ProfileElementRight_ToActionElement] FOREIGN KEY ([ActionElement]) REFERENCES [ActionElement]([Id]), 
)
