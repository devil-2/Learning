CREATE PROCEDURE [dbo].[spUpdateLanguage]
	@Id int ,
	@Label int,
	@Code varchar(50)
AS
begin
	set nocount on;
	Update [dbo].[Language] set Code =@Code, DescriptionLabel=@Label where Id=@Id;
end
