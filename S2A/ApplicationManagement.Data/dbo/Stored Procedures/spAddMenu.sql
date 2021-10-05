CREATE PROCEDURE [dbo].[spAddMenu]
	@Id int output,
	@Package int,
	@NameLabel decimal,
	@Parent int,
	@CanAdd bit,
	@CanView bit,
	@CanDelete bit,
	@CanUpdate bit,
	@Action int,
	@Type smallint
AS
begin
	set nocount on;
	INSERT INTO [dbo].[Menu]([Package], [NameLabel], [Parent], [CanAdd], [CanView], [CanDelete], [CanUpdate], [Action], [Type] )
	values(@Package,@NameLabel,@Parent,@CanAdd,@CanView,@CanDelete,@CanUpdate,@Action,@Type);
	SELECT @Id = SCOPE_IDENTITY();
	Select @Id as Id;
end
