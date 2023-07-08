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


/**

Here's for keeping track of deployed database updates 

*/

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Migration')
BEGIN
	CREATE TABLE [dbo].[Migration](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ClientVersion] [nvarchar](200) NULL, 
		[DatabaseVersion] [nvarchar](200) NULL, 
		[CreatedOn] DateTime NULL
	 CONSTRAINT [PK_Migration] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
	) ON [PRIMARY]

	
	Insert into Migration (ClientVersion, DatabaseVersion, CreatedOn) values  ('1.0.0','1.0.0', GETDATE())

END
GO