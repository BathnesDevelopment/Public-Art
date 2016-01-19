/*
	Name:			[dbo].[Category]
	Author:			Chris Pickford
	Created:		2016-01-18
	Description:	Table to hold categories of items.
*/
CREATE TABLE [dbo].[Category]
(
	[CategoryId]		INT					NOT NULL		IDENTITY(1,1)
,	[Description]		NVARCHAR(100)		NOT NULL

,	[rowguid]			UNIQUEIDENTIFIER	NOT NULL		ROWGUIDCOL		CONSTRAINT [DF_Category_rowguid] DEFAULT (NEWID())
,	[ModifiedDate]		DATETIME2			NOT NULL						CONSTRAINT [DF_Category_ModifiedDate] DEFAULT (SYSDATETIME())

,	CONSTRAINT [PK_Category_CategoryId] PRIMARY KEY CLUSTERED ([CategoryId])
);
GO

