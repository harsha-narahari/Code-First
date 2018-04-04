PRINT 'Creating Procedure - [dbo].[spInsertBook]'

IF OBJECT_ID('[dbo].[spInsertBook]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[spGetBooks]
END

GO