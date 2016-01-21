/*
    Name:           [dbo].[ItemImage]
    Author:         Chris Pickford
    Created:        2016-01-20
    Description:    Table to link images to items.
*/
CREATE TABLE [dbo].[ItemImage]
(
    [ItemId]            INT                 NOT NULL
,   [stream_id]         UNIQUEIDENTIFIER    NOT NULL

,   [Order]             TINYINT             NOT NULL
,   [Caption]           NVARCHAR(1000)      NULL

,   [rowguid]           UNIQUEIDENTIFIER    NOT NULL        ROWGUIDCOL      CONSTRAINT [DF_ItemImage_rowguid] DEFAULT (NEWID())
,   [ModifiedDate]      DATETIME2           NOT NULL                        CONSTRAINT [DF_ItemImage_ModifiedDate] DEFAULT (SYSDATETIME())

,   CONSTRAINT [PK_ItemImage_ItemId_stream_id] PRIMARY KEY CLUSTERED ([ItemId], [stream_id])
,   CONSTRAINT [FK_ItemImage_ItemId_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([ItemId])
,   CONSTRAINT [FK_ItemImage_stream_id_Image] FOREIGN KEY ([stream_id]) REFERENCES [dbo].[Image]([stream_id])
);
GO
