USE [FinanceWebsite]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [UserId] [bigint] NOT NULL,
    [Email] [nvarchar] (max) NOT NULL,
    [Salt] [nvarchar] (max) NOT NULL,
    [HashedPassword] [nvarchar] (max) NOT NULL
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY ([UserId])
)
GO