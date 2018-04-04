PRINT 'Creating Procedure - [dbo].[spGetBooks]'

IF OBJECT_ID('[dbo].[spGetBooks]') IS NOT NULL
BEGIN
	DROP PROCEDURE [dbo].[spGetBooks]
END

CREATE PROCEDURE [dbo].[spGetBooks]
	@Name varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT b.BookID, 
		b.Name as BookName, 
		bd.Author, 
		bd.Publisher 
	FROM tblBook b 
		INNER JOIN tblBookDetail bd ON b.BookID = bd.BookID 
	WHERE b.Name =	CASE 
						WHEN @Name IS NULL OR LTRIM(RTRIM(@Name)) = ''
							THEN b.Name 
						ELSE @Name
					END    
END

GO