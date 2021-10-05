CREATE PROCEDURE [dbo].[spGetState]
	@CountryId int
AS
begin
	set nocount on;
	select [Id], [NameLabel]
	from [dbo].[State]
	where CountryId = @CountryId and [Deleted] = 0;
end
