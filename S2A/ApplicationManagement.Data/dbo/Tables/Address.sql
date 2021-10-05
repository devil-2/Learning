CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressLine1] NVARCHAR(200) NOT NULL, 
    [AddressLine2] NVARCHAR(200) NOT NULL, 
    [City] INT NOT NULL, 
    [State] INT NOT NULL, 
    [Country] INT NOT NULL, 
    [Pincode] NVARCHAR(10) NOT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0,

)
