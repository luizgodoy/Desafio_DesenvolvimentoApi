USE [4NETTDB]
GO

/****** Object:  Table [dbo].[USERS]    Script Date: 07/04/2024 22:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--DELETE FROM [dbo].[USERS]
--GO

DROP TABLE [dbo].[USERS]
GO

CREATE TABLE [dbo].[USERS](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](100) NULL,
	[Username] [varchar](10) NOT NULL,
	[Password] [varchar](10) NULL,
	[Role] [bigint] NULL,
	[Email] [varchar](100) NULL,
	[CreatedAt] [bigint] NULL,
	[UpdatedAt] [bigint] NULL,
	[DeletedAt] [bigint] NULL,
	[CreatedBy] [bigint] NULL
) ON [PRIMARY]
GO
