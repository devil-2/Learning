CREATE PROCEDURE [dbo].[spUpdateAddress]
	@Id int ,
	@AddressLine1 decimal,
	@AddressLine2 decimal, 
	@City int, 
	@State int, 
	@Country int, 
	@Pincode nvarchar(20) 
AS
begin
	SET NOCOUNT ON;
	Update [dbo].[Address] set [City] =@City, [State] =@State, [Country] =@Country, [Pincode]= @Pincode
	where Id=@Id;
end
	
