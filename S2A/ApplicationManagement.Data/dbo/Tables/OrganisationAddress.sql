CREATE TABLE [dbo].[OrganisationAddress]
(
	[Organisation] INT NOT NULL, 
    [Address] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_OrganisationAddress_ToOrganisation] FOREIGN KEY ([Organisation]) REFERENCES [Organisation]([Id]), 
    CONSTRAINT [FK_OrganisationAddress_ToAddress] FOREIGN KEY ([Address]) REFERENCES [Address]([Id]), 
    CONSTRAINT [PK_OrganisationAddress] Primary key([Organisation],[Address])
)
