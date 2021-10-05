CREATE PROCEDURE [dbo].[spAddLanguage]
	@Id int ,
	@DescriptionLabel int,
	@Code varchar(50)
AS
begin
	set nocount on;
	INSERT INTO [dbo].[Language] (Id, Code,DescriptionLabel)
	VALUES (@Id,  @Code, @DescriptionLabel);
end
