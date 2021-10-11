CREATE PROCEDURE [dbo].[spUpdateCountry]
	@Id int,
	@NameLabel int,
	@ISO3 VARCHAR(3), 
    @Code VARCHAR(3), 
    @ISO2 VARCHAR(2), 
    @PhoneCode VARCHAR(255), 
    @CapitalLabel int, 
    @Currency VARCHAR(255), 
    @Symbol VARCHAR(255), 
    @TLD VARCHAR(255), 
    @NativeLabel INT, 
    @RegionLabel INT, 
    @SubRegionLabel INT, 
    @TimeZone INT, 
    @Latitude DECIMAL(15, 8), 
    @Longitude DECIMAL(15, 8), 
    @Emoji VARCHAR(200), 
    @EmojiU VARCHAR(200), 
    @Flag BIT, 
    @WikiDataId VARCHAR(255)
AS
begin
    set nocount on;
    Update [DBO].[Country] set 
     [ISO3]=@ISO3, [Code] = @Code, [ISO2]=@ISO2, [PhoneCode]=@PhoneCode,[Currency] =@Currency, [Symbol]=@Symbol, [TLD]= @TLD, [Latitude]= @Latitude, 
	 [Longitude]= @Longitude, [Emoji] =@Emoji, [EmojiU] =@EmojiU, [LastModified] = GETUTCDATE(), [Flag] =@Flag, [WikiDataId]=@WikiDataId
    where Id=@Id;

end;

