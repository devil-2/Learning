CREATE TABLE [dbo].[Enums]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Parent] INT NOT NULL,--Status/DBType MenyType
    [Value] INT NOT NULL, 
    [Label] INT NOT NULL, 
    CONSTRAINT [AK_Status_Group_Value] UNIQUE ([Parent],[Value])
)
