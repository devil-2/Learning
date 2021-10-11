CREATE PROCEDURE [dbo].[spAddState]
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
	insert into [dbo].[State]([Country], [NameLabel], [Code], [Latitude], [Longitude], [Type])
	values(@Country,@NameLabel,@Code,@Latitude,@Longitude,@Type);
    Select SCOPE_IDENTITY() as Id;
END
