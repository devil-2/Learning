CREATE PROCEDURE [dbo].[spGetAddress]
	@Id int
AS
begin
	set nocount on;
	Select  [AddressLine1], [AddressLine2], [City], [State], [Country], [Pincode] 
	from [dbo].[Address] where Id = @Id and [Deleted] = 0;
end
