CREATE PROCEDURE [dbo].[spDeleteOrganisation]
	@Id int	
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [DBO].[Organisation] SET [Deleted] =1
	where Id =@Id;
END

