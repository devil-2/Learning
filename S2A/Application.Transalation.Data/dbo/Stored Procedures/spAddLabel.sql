CREATE PROCEDURE [dbo].[spAddLabel]
	@Code int,
	@LanguageId int,
	@Translation nvarchar(max)
AS
begin
	declare @Id int;
	set nocount on;

	if exists(SELECT Code from [dbo].[Label] where Code = @Code and LanguageId = @LanguageId)
	BEGIN
		select -1;
		return;
	END
	if not exists(SELECT Code from [dbo].[Label] where Code = @Code)
	BEGIN
		select @Code = isnull(Max(Code),0) + 1 from [dbo].[Label];
	END
	
	INSERT INTO [dbo].[Label]([Code],[LanguageId],  [Translation])
	VALUES (@Code, @LanguageId,  @Translation);

	Select @Id = SCOPE_IDENTITY();
	SELECT Code from [dbo].[Label] where Id= @Id;
end