CREATE PROCEDURE [dbo].[spGetCountry]
AS
begin
	set nocount on;
	select [Id], [NameLabel] 
	from [dbo].[Country] where [Deleted] = 0;
end
