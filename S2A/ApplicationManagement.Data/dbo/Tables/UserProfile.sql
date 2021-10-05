CREATE TABLE [dbo].[UserProfile]
(
	[User] NVARCHAR(128) NOT NULL, 
    [Profile] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY ([User],[Profile]), 
    CONSTRAINT [FK_UserProfile_ToUser] FOREIGN KEY ([User]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserProfile_ToMenu] FOREIGN KEY ([Profile]) REFERENCES [Menu]([Id])
)
