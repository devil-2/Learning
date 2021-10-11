CREATE PROCEDURE [dbo].[spAddTimeZone]
	@Id INT, 
    @Country INT, 
    @ZoneNameLabel int, 
    @GmtOffset INT, 
    @GmtOffsetName VARCHAR(255), 
    @Abbreviation VARCHAR(50), 
    @TimeZoneNameLabel INT
AS
begin
    set nocount on;
    INSERT INTO [dbo].[TimeZone]([Country], [ZoneNameLabel], [GmtOffset], [GmtOffsetName], [Abbreviation], [TimeZoneNameLabel])
    VALUES(@Country, @ZoneNameLabel, @GmtOffset, @GmtOffsetName, @Abbreviation, @TimeZoneNameLabel);
    SELECT SCOPE_IDENTITY() AS Id;
end
