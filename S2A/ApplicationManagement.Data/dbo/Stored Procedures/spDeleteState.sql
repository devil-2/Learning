CREATE PROCEDURE [dbo].[spDeleteState]
	@Id int,
	@Country INT
AS
BEGIN
	SET NOCOUNT ON;
	Update [dbo].[State] set Deleted = 1
    where Id = @Id and [Country] = @Country;
END
