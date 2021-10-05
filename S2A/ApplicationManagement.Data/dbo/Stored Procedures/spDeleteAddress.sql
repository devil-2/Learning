CREATE PROCEDURE [dbo].[spDeleteAddress]
	@Id int
AS
begin
	SET NOCOUNT ON;
	Update [dbo].[Address] set [Deleted]=1
	where Id=@Id;
end