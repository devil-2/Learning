CREATE TABLE [dbo].[Language]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DescriptionLabel] DECIMAL NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    [Status] BIT NOT NULL DEFAULT 0,
)
