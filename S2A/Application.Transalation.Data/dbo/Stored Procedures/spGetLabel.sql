CREATE PROCEDURE [dbo].[spGetLabel]
	@Id int,
	@LanguageId int
AS
begin
	set nocount on;
	select [Translation] from 
	[dbo].[Label] 
	where LanguageId = @LanguageId and Id=@Id;
end
