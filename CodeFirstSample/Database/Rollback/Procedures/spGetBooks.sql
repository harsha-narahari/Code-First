PRINT 'Creating Procedure - [dbo].[spGetBooks]'

IF OBJECT_ID('[dbo].[spGetBooks]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[spGetBooks]
END

GO