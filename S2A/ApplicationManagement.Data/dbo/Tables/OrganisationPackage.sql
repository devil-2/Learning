CREATE TABLE [dbo].[OrganisationPackage]
(
	[Organisation] INT NOT NULL, 
    [Package] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_OrganisationPackage] PRIMARY KEY ([Organisation],[Package]), 
    CONSTRAINT [FK_OrganisationPackage_ToOrganisation] FOREIGN KEY ([Organisation]) REFERENCES [Organisation]([Id]), 
    CONSTRAINT [FK_OrganisationPackage_ToPackage] FOREIGN KEY ([Package]) REFERENCES [Package]([Id])
)
