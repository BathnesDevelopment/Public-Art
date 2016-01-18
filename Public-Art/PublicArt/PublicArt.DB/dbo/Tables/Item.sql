CREATE TABLE [dbo].[Item]
(
	[ItemId]		INT				NOT NULL		IDENTITY(1,1)
,	[Title]			[dbo].[Name]	NOT NULL
,	[Reference]		VARCHAR(6)		NOT NULL
,	[ItemDate]		DATE			NULL		-- TODO: Change this column to a FK referencing some kind of log table


,	[rowguid]		UNIQUEIDENTIFIER	NOT NULL		ROWGUIDCOL		CONSTRAINT [DF_Item_rowguid] DEFAULT (NEWID())
,	[ModifiedDate]	DATETIME2			NOT NULL						CONSTRAINT [DF_Item_ModifiedDate] DEFAULT (SYSDATETIME())

,	CONSTRAINT [PK_ArtItem_ItemId] PRIMARY KEY CLUSTERED ([ItemId])
);
GO

CREATE UNIQUE INDEX [IX_Item_Reference] ON [dbo].[Item] ([Reference])
GO