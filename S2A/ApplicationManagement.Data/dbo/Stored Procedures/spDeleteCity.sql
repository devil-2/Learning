CREATE PROCEDURE [dbo].[spDeleteCity]
	@Id INT, 
    @State INT
AS
begin
	set nocount on;
	Update [dbo].[City]  set  [Deleted] = 1 where Id=@Id and [State]=@State;
end
