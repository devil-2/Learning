CREATE PROCEDURE [dbo].[spAddAddress]
	@Id int output,
	@AddressLine1 decimal,
	@AddressLine2 decimal, 
	@City int, 
	@State int, 
	@Country int, 
	@Pincode nvarchar(20) 
AS
begin
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Address]([AddressLine1], [AddressLine2], [City], [State], [Country], [Pincode])
	values (@AddressLine1, @AddressLine2, @City, @State, @Country, @Pincode )

	Select @Id = SCOPE_IDENTITY();
	Select @Id as Id;
end
	
