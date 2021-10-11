CREATE PROCEDURE [dbo].[spDeleteTimeZone]
	@Id INT, 
    @Country INT
AS
begin
    set nocount on;
    Update [dbo].[TimeZone] set [Deleted] =1  
    where Id= @Id and [Country] = @Country
end
