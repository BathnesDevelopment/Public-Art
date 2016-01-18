﻿CREATE TABLE [dbo].[ItemCategory]
(
	[ItemId]		INT		NOT NULL
,	[CategoryId]	INT		NOT NULL

,	[rowguid]		UNIQUEIDENTIFIER	NOT NULL		ROWGUIDCOL		CONSTRAINT [DF_ItemCategory_rowguid] DEFAULT (NEWID())
,	[ModifiedDate]	DATETIME2			NOT NULL						CONSTRAINT [DF_ItemCategory_ModifiedDate] DEFAULT (SYSDATETIME())

,	CONSTRAINT [PK_ItemCategory_ItemId_CategoryId] PRIMARY KEY CLUSTERED ([ItemId], [CategoryId])
,	CONSTRAINT [FK_ItemCategory_ItemId_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([ItemId])
,	CONSTRAINT [FK_ItemCategory_CategoryId_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([CategoryId])
);
GO

