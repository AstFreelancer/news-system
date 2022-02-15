CREATE TABLE [dbo].[autors] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[name] [varchar] (50) COLLATE Cyrillic_General_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[comments] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[news_id] [int] NOT NULL ,
	[autor] [int] NOT NULL ,
	[comment] [varchar] (200) COLLATE Cyrillic_General_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[logins] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[login] [varchar] (50) COLLATE Cyrillic_General_CI_AS NOT NULL ,
	[password] [varchar] (50) COLLATE Cyrillic_General_CI_AS NOT NULL ,
	[a_level] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[news] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[caption] [varchar] (50) COLLATE Cyrillic_General_CI_AS NOT NULL ,
	[small_text] [varchar] (100) COLLATE Cyrillic_General_CI_AS NOT NULL ,
	[large_text] [varchar] (500) COLLATE Cyrillic_General_CI_AS NOT NULL ,
	[autor] [int] NOT NULL ,
	[date] [datetime] NOT NULL ,
	[type] [int] NOT NULL 
) ON [PRIMARY]
GO