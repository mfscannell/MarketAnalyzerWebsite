USE [FinanceWebsite]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stocks] (
    [Symbol] [nvarchar](15) NOT NULL,
    [CompanyName] [nvarchar](255) NOT NULL,
    CONSTRAINT [PK_dbo.Stocks] PRIMARY KEY ([Symbol])
)
GO