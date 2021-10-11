CREATE PROCEDURE [dbo].[spUpdateTimeZone]
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
    Update [dbo].[TimeZone] set [GmtOffset] = @GmtOffset, [GmtOffsetName]=@GmtOffsetName, [Abbreviation]=@Abbreviation    
    where Id= @Id and [Country] = @Country
end
