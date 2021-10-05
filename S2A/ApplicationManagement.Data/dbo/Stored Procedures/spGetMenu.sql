CREATE PROCEDURE [dbo].[spGetMenu]
	@Id int
AS
begin
	set nocount on;
	SELECT [Id], [Package], [NameLabel], [Parent], [CanAdd], [CanView], [CanDelete], [CanUpdate], [Action], [Type] 
	FROM [dbo].[Menu] 
	where [Package] = @Id;
end
