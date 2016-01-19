/*
	Name:			[dbo].[ItemArtist]
	Author:			Chris Pickford
	Created:		2016-01-18
	Description:	Table to link artists to items.
*/
CREATE TABLE [dbo].[ItemArtist]
(
	[ItemId]		INT		NOT NULL
,	[ArtistId]		INT		NOT NULL

,	[rowguid]		UNIQUEIDENTIFIER	NOT NULL		ROWGUIDCOL		CONSTRAINT [DF_ItemArtist_rowguid] DEFAULT (NEWID())
,	[ModifiedDate]	DATETIME2			NOT NULL						CONSTRAINT [DF_ItemArtist_ModifiedDate] DEFAULT (SYSDATETIME())

,	CONSTRAINT [PK_ItemArtist_ItemId_ArtistId] PRIMARY KEY CLUSTERED ([ItemId], [ArtistId])
,	CONSTRAINT [FK_ItemArtist_ItemId_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([ItemId])
,	CONSTRAINT [FK_ItemArtist_ArtistId_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist]([ArtistId])
);
GO
