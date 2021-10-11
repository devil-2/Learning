CREATE PROCEDURE [dbo].[spGetTimeZone]
	@Id int = 0
AS
begin
	set nocount on;
	Select [Id], [Country], [ZoneNameLabel], [GmtOffset], [GmtOffsetName], [Abbreviation], [TimeZoneNameLabel]
	from [dbo].[TimeZone] where [Country] = @Id;
end