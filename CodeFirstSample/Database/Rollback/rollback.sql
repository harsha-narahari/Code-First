:on error exit

:setvar DatabaseDirectory "C:\Harsha\Samples\Database\CodeFirstSample\CodeFirstSample\Scripts\Rollback\"

SET XACT_ABORT ON
SET NOCOUNT ON

USE [Sample]

PRINT 'Rolling back schema and data for Sample database...'

BEGIN TRANSACTION

PRINT 'Schema and data...'

:r $(DatabaseDirectory)\SchemaAndData\Tables\"tblBook.schema.sql"
:r $(DatabaseDirectory)\SchemaAndData\Tables\"tblBookDetail.schema.sql"


PRINT 'Stored Procedure...'

:r $(DatabaseDirectory)\SchemaAndData\Procedures\"spGetBooks.sql"
:r $(DatabaseDirectory)\SchemaAndData\Procedures\"spInsertBook.sql"


COMMIT TRANSACTION

PRINT 'ALL SQL changes are rolledback successfully!'
GO