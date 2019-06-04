USE [FinanceWebsite]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockPrices] (
    [Symbol] [nvarchar](15) NOT NULL,
    [Date] [datetime] NOT NULL,
    [Open] [numeric](38, 9) NOT NULL,
    [High] [numeric](38, 9) NOT NULL,
    [Low] [numeric](38, 9) NOT NULL,
    [Close] [numeric](38, 9) NOT NULL,
    [AdjClose] [numeric](38, 9) NOT NULL,
    [Volume] [bigint] NOT NULL
    CONSTRAINT [PK_dbo.StockPrices] PRIMARY KEY ([Symbol], [Date])
)
GO