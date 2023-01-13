/**

If you like you can use this table for doing version controll of your system.

*/


IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Migrations')
BEGIN
	CREATE TABLE [dbo].[Migrations](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ClientVersion] [nvarchar](200) NULL, 
		[DatabaseVersion] [nvarchar](200) NULL, 
		[CreatedOn] DateTime NULL
	 CONSTRAINT [PK_Migrations] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
	) ON [PRIMARY]

END

Insert into Migrations (ClientVersion, DatabaseVersion, CreatedOn) values  ('1.0.0','1.0.0', GETDATE())

GO


