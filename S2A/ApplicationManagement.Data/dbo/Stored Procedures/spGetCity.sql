CREATE PROCEDURE [dbo].[spGetCity]
	@Id int
AS
begin
	set nocount on;
	select [Id], [State], [NameLabel], [Latitude], [Longitude] from
	[dbo].[City] where [State] = @Id and [Deleted] = 0;
end
