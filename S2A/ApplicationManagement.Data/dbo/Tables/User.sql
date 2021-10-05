CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(200) NOT NULL, 
    [LastName] NVARCHAR(200) NOT NULL, 
    [EmailAddress] NVARCHAR(200) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [Status] BIT NOT NULL DEFAULT 0, 
    [ValidTill] DATETIME2 NOT NULL, 
    [EmailValidated] BIT NOT NULL DEFAULT 0, 
    [PhoneNumberValidated] NCHAR(10) NOT NULL DEFAULT 0, 
    [PermanentAddress] INT NOT NULL, 
    [CurrentAddress] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_User_ToAddressC] FOREIGN KEY ([PermanentAddress]) REFERENCES [Address]([Id]),
    CONSTRAINT [FK_User_ToAddressP] FOREIGN KEY ([CurrentAddress]) REFERENCES [Address]([Id])
)
