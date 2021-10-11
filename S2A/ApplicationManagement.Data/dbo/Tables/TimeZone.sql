CREATE TABLE [dbo].[TimeZone]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Country] INT NOT NULL, 
    [ZoneNameLabel] INT NOT NULL, 
    [GmtOffset] INT NOT NULL, 
    [GmtOffsetName] VARCHAR(255) NOT NULL, 
    [Abbreviation] VARCHAR(50) NOT NULL, 
    [TimeZoneNameLabel] INT NOT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0,
)
