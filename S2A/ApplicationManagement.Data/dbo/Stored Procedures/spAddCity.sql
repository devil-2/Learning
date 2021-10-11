CREATE PROCEDURE [dbo].[spAddCity]
	@Id INT, 
    @State INT, 
    @NameLabel INT, 
    @Latitude DECIMAL(15, 8), 
    @Longitude DECIMAL(15, 8)
AS
begin
	set nocount on;
	insert into [dbo].[City] ([State], [NameLabel], [Latitude], [Longitude])
    values(@State,@NameLabel,@Latitude,@Longitude);
    Select SCOPE_IDENTITY() as Id; 
end
