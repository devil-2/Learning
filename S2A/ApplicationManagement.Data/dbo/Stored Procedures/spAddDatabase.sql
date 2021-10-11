CREATE PROCEDURE [dbo].[spAddDatabase]
	@Id INT, 
	@Organisation INT, 
	@Type INT, 
	@Server NVARCHAR(255), 
	@Host VARCHAR(255), 
	@Name VARCHAR(255), 
	@UserId VARCHAR(255), 
	@Password VARCHAR(255), 
	@Status INT, 
	@Readonly INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Database] ([Organisation], [Type], [Server], [Host], [Name], [UserId], [Password], [Status], [Readonly])
	VALUES( @Organisation, @Type, @Server, @Host, @Name, @UserId, @Password, @Status, @Readonly)
	select SCOPE_IDENTITY() as ID;
END
	
