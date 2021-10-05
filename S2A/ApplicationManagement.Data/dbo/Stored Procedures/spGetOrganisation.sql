CREATE PROCEDURE [dbo].[spGetOrganisation]
	@Id int
AS
begin
	SET NOCOUNT ON;
	
	select  [NameLabel], [DescriptionLabel], [Domain], [Email], [Status], [ValidTill], [AuthenticationType], [Address], [UserApprovalRequired]
	from 	[dbo].[Organisation] 
	where 	Id = @Id and [Deleted] = 0;
end