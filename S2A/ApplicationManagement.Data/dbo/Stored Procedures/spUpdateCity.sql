CREATE PROCEDURE [dbo].[spUpdateCity]
    @Id INT, 
    @State INT, 
    @NameLabel INT, 
    @Latitude DECIMAL(15, 8), 
    @Longitude DECIMAL(15, 8)
AS
begin
	set nocount on;
	Update [dbo].[City]  set  [Latitude] =@Latitude, [Longitude]=@Longitude where Id=@Id and [State]=@State;
end