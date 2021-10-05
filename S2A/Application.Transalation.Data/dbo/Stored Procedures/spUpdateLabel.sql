CREATE PROCEDURE [dbo].[spUpdateLabel]
	@Id decimal,
	@LanguageId int,
	@Translation nvarchar(max)
AS
begin
	set nocount on;
	UPDATE [dbo].[Label] SET [Translation] = @Translation where LanguageId = @LanguageId and Id=@Id;
end
