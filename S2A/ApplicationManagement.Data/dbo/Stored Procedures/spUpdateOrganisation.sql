CREATE PROCEDURE [dbo].[spUpdateOrganisation]
	@Id int,
	@NameLabel decimal,
	@DescriptionLabel decimal,
	@Domain nvarchar(100),
	@Email nvarchar(100),
	@Status bit,
	@ValidTill datetime2,
	@AuthenticationType smallint,
	@Address int,
	@UserApprovalRequired bit
	
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS ( SELECT Id FROM [dbo].[Organisation] where Id =@Id)
	begin
		UPDATE [DBO].[Organisation] SET [Domain]= @Domain, [Email] =@Email,[Status]=@Status,[ValidTill]=@ValidTill,
		[AuthenticationType] =@AuthenticationType,[Address]=@Address,[UserApprovalRequired]= @UserApprovalRequired
		where Id =@Id;
	end
END
