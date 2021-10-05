CREATE TABLE [dbo].[OrganisationLanguage]
(
	[Organisation] INT NOT NULL, 
    [Language] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_OrganisationLanguage_ToOrganisation] FOREIGN KEY ([Organisation]) REFERENCES [Organisation]([Id]), 
    CONSTRAINT [PK_OrganisationLanguage] Primary key([Organisation],[Language])
)
