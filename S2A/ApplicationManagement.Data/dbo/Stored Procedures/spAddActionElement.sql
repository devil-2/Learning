CREATE PROCEDURE [dbo].[spAddActionElement]
	@Id int,
	@MenuAction int,
	@ElementName varchar(255),
	@Type int,
	@Label int,
	@AddEnabled bit,
	@ViewEnabled bit,
	@UpdateEnabled bit
AS
begin
	set nocount on;
	insert into [dbo].[ActionElement] ([MenuAction], [ElementName], [Type], [Label], [AddEnabled], [ViewEnabled], [UpdateEnabled])
	values(@MenuAction, @ElementName, @Type, @Label, @AddEnabled, @ViewEnabled, @UpdateEnabled)
	select SCOPE_IDENTITY() as ID;
end
