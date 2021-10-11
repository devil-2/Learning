CREATE TABLE [dbo].[State]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Country] INT NOT NULL, 
    [NameLabel] INT NOT NULL,
    [Code] varchar(255) NOT NULL,
    [Latitude] DECIMAL(15, 8) NULL, 
    [Longitude] DECIMAL(15, 8) NULL, 
    [Type] varchar(255)  NULL, --No Idea what is this
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_State_ToCountry] FOREIGN KEY ([Country]) REFERENCES [Country]([Id])
)
