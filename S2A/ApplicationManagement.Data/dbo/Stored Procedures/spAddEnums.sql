CREATE PROCEDURE [dbo].[spAddEnums]
	@Id int,
	@Parent int,
	@Value int,
	@Label int
AS
begin
	set nocount on;
	insert into [dbo].[Enums]([Parent], [Value], [Label])
	values(@Parent, @Value, @Label);
	select SCOPE_IDENTITY() as ID;
end