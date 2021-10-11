CREATE PROCEDURE [dbo].[spGetCountry]
AS
begin
	set nocount on;
	select 
	[Id], [NameLabel], [ISO3], [Code], [ISO2], [PhoneCode], [CapitalLabel], [Currency], 
	[Symbol], [TLD], [NativeLabel], [RegionLabel], [SubRegionLabel],  [Latitude], 
	[Longitude], [Emoji], [EmojiU], [Created], [LastModified], [Flag], [WikiDataId]
	from [dbo].[Country] where [Deleted] = 0;
end
