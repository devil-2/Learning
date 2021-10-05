CREATE TABLE [dbo].[Organisation]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [NameLabel] INT NOT NULL, 
    [DescriptionLabel] INT NOT NULL, 
    [Domain] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(100) NULL, 
    [Status] BIT NOT NULL DEFAULT 0, 
    [ValidTill] DATETIME2 NULL, 
    [AuthenticationType] INT NOT NULL DEFAULT 0, 
    [Address] INT NOT NULL, 
    [UserApprovalRequired] BIT NOT NULL DEFAULT 0, 
    [Deleted] BIT NOT NULL DEFAULT 0
)
