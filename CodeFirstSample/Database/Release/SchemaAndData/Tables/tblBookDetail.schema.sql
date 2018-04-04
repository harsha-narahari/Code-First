PRINT '[dbo].[tblBookDetail] SCHEMA'

IF OBJECT_ID('[dbo].[tblBookDetail]') IS NULL
BEGIN
	CREATE TABLE [dbo].[tblBookDetail](
	[BookDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Publisher] [varchar](50) NULL,
	[BookID] [int] NOT NULL,
	 CONSTRAINT [PK_tblBookDetail] PRIMARY KEY CLUSTERED 
	(
		[BookDetailID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[tblBookDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblBookDetail_tblBook] FOREIGN KEY([BookID])
	REFERENCES [dbo].[tblBook] ([BookID])

	ALTER TABLE [dbo].[tblBookDetail] CHECK CONSTRAINT [FK_tblBookDetail_tblBook]
END

GO