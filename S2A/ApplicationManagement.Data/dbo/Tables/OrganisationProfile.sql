CREATE TABLE [dbo].[OrganisationProfile]
(
    [Organisation] INT NOT NULL, 
    [Profile] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [PK_OrganisationProfile] PRIMARY KEY ([Organisation],[Profile]), 
    CONSTRAINT [FK_OrganisationProfile_ToOrganisation] FOREIGN KEY ([Organisation]) REFERENCES [Organisation]([Id]), 
    CONSTRAINT [FK_OrganisationProfile_ToProfile] FOREIGN KEY ([Profile]) REFERENCES [Profile]([Id])
)
