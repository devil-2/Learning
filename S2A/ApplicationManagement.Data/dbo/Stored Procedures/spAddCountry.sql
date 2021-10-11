CREATE PROCEDURE [dbo].[spAddCountry]
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
    @Latitude DECIMAL(15, 8), 
    @Longitude DECIMAL(15, 8), 
    @Emoji VARCHAR(200), 
    @EmojiU VARCHAR(200), 
    @Flag BIT, 
    @WikiDataId VARCHAR(255)
AS
begin
    set nocount on;
	INSERT INTO [DBO].[Country] ([NameLabel], [ISO3], [Code], [ISO2], [PhoneCode], [CapitalLabel], [Currency], 
	[Symbol], [TLD], [NativeLabel], [RegionLabel], [SubRegionLabel],  [Latitude], 
	[Longitude], [Emoji], [EmojiU], [Flag], [WikiDataId])
	values(@NameLabel, @ISO3, @Code, @ISO2, @PhoneCode, @CapitalLabel, @Currency, 
	@Symbol, @TLD, @NativeLabel, @RegionLabel, @SubRegionLabel, @Latitude, 
	@Longitude, @Emoji, @EmojiU, @Flag, @WikiDataId);

    Select SCOPE_IDENTITY() as Id;
end
