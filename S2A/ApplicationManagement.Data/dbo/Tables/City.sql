CREATE TABLE [dbo].[City]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [State] INT NOT NULL, 
    [NameLabel] INT NULL, 
    [Latitude] DECIMAL(15, 8) NULL, 
    [Longitude] DECIMAL(15, 8) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_City_ToState] FOREIGN KEY ([State]) REFERENCES [State]([Id]),
)
