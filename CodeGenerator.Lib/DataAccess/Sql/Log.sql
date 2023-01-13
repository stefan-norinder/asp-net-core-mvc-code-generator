/**

If you like you can use this table for database logging 

*/



IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log')
BEGIN
	CREATE TABLE [dbo].[Log](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Origin] [nvarchar](2000) NULL, 
		[Message] [nvarchar](2000) NULL, 
		[LogLevel] [nvarchar](2000) NULL,
		[CreatedOn] DateTime NULL,
		[Exception] [nvarchar](4000) NULL,
		[Trace] [nvarchar](4000) NULL
	 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
	) ON [PRIMARY]
END
GO
