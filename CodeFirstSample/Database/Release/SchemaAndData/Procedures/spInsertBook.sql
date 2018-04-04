PRINT 'Creating Procedure - [dbo].[spInsertBook]'

IF OBJECT_ID('[dbo].[spInsertBook]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[spGetBooks]
END

CREATE PROCEDURE [dbo].[spInsertBook] 
	@Name VARCHAR(50),
	@Author VARCHAR(50),
	@Publisher VARCHAR(50)
AS
	DECLARE @BookID INT
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO [dbo].[tblBook]
	(Name)
	VALUES
	(@Name)

	SELECT @BookID = BookID 
	FROM [dbo].[tblBook] 
	WHERE Name = @Name;

	INSERT INTO [dbo].[tblBookDetail]
	([Author], [Publisher], [BookID])
	VALUES
	(@Author, @Publisher, @BookID)	

END

GO