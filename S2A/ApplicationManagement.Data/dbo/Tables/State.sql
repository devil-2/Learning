CREATE TABLE [dbo].[State]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [CountryId] INT NOT NULL, 
    [NameLabel] INT NOT NULL,
    [Code] varchar(255) NOT NULL,
    [Latitude] DECIMAL(10, 8) NULL, 
    [Longitude] DECIMAL(10, 8) NULL, 
    [Type] varchar(255) NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_State_ToCountry] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id])
)
