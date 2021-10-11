CREATE PROCEDURE [dbo].[spUpdateState]
	@Id int,
	@Country INT, 
    @NameLabel INT,
    @Code varchar(255),
    @Latitude DECIMAL(15, 8), 
    @Longitude DECIMAL(15, 8), 
    @Type varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	Update [dbo].[State] set [Code] = @Code, [Latitude]=@Latitude, [Longitude]=@Longitude, [Type]=@Type
    where Id =@Id and  [Country] = @Country;
END
