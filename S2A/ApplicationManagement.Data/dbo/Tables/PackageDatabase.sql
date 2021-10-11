CREATE TABLE [dbo].[PackageDatabase]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Package] INT NOT NULL, 
    [Database] INT NOT NULL, 
    CONSTRAINT [AK_PackageDatabase_Package_Database] UNIQUE ([Package],[Database]), 
    CONSTRAINT [FK_PackageDatabase_ToPackage] FOREIGN KEY ([Package]) REFERENCES [Package]([Id]),
    CONSTRAINT [FK_PackageDatabase_ToDatabase] FOREIGN KEY ([Database]) REFERENCES [Database]([Id])
)
