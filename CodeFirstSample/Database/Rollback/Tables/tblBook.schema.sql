PRINT '[dbo].[tblBook] SCHEMA'

IF OBJECT_ID('[dbo].[tblBook]') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[tblBook]
END

GO