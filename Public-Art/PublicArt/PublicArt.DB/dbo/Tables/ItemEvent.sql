/*
	Name:			[dbo].[ItemEvent]
	Author:			Chris Pickford
	Created:		2016-01-18
	Description:	Table to hold a dated history of an item.
*/
CREATE TABLE [dbo].[ItemEvent]
(
	[ItemId]		INT					NOT NULL
,	[EventId]		TINYINT				NOT NULL
,	[EventDate]		DATE				NOT NULL
,	[Description]	NVARCHAR(1000)		NOT NULL

,	[rowguid]		UNIQUEIDENTIFIER	NOT NULL		ROWGUIDCOL		CONSTRAINT [DF_ItemEvent_rowguid] DEFAULT (NEWID())
,	[ModifiedDate]	DATETIME2			NOT NULL						CONSTRAINT [DF_ItemEvent_ModifiedDate] DEFAULT (SYSDATETIME())

,	CONSTRAINT [PK_ItemEvent_ItemId_EventId] PRIMARY KEY CLUSTERED ([ItemId], [EventId])
,	CONSTRAINT [FK_ItemEvent_ItemId_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([ItemId])

);
GO
