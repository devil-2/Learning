CREATE PROCEDURE [dbo].[spDeleteCountry]
    @Id int
	AS
begin
    set nocount on;
    Update [DBO].[Country] set 
    [Deleted] =1
    where Id=@Id;
  
end;
