CREATE PROCEDURE [dbo].[spGetState]
	@Country int
AS
begin
	set nocount on;
	select [Id], [Country], [NameLabel], [Code], [Latitude], [Longitude], [Type] 
	from [dbo].[State]
	where Country = @Country and [Deleted] = 0;
end
