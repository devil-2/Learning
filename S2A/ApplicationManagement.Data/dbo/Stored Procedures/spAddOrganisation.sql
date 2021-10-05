CREATE PROCEDURE [dbo].[spAddOrganisation]
	@Id int output,
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
	INSERT INTO [DBO].[Organisation] 
	([NameLabel], [DescriptionLabel], [Domain], [Email], [Status], [ValidTill], [AuthenticationType], [Address], [UserApprovalRequired] )
	values
	(@NameLabel, @DescriptionLabel, @Domain, @Email, @Status, @ValidTill, @AuthenticationType, @Address, @UserApprovalRequired)	

	Select @Id = SCOPE_IDENTITY();
	Select @Id as Id;
END
