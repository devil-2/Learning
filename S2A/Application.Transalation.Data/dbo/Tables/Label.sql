CREATE TABLE [dbo].[Label]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Code] int not null,
    [LanguageId] INT NOT NULL, 
    [Translation] NVARCHAR(MAX) NOT NULL, 
    [Status] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [UK_Label] UNIQUE ([Code],[LanguageId])

)
