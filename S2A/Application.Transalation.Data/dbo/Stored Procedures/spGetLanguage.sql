CREATE PROCEDURE [dbo].[spGetLanguage]
AS
begin
	set nocount on;
	select [Id], [DescriptionLabel], [Code]  from
	[dbo].[Language] 
	where [Status] =0; 
end
