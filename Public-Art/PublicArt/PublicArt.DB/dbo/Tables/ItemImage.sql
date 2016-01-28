/*
    Name:           [dbo].[ItemImage]
    Author:         Chris Pickford
    Created:        2016-01-20
    Description:    Table to link images to items.
*/
CREATE TABLE [dbo].[ItemImage]
(
    [ItemId]            INT                         NOT NULL
,   [stream_id]         UNIQUEIDENTIFIER            NOT NULL    ROWGUIDCOL      CONSTRAINT [DF_ItemImage_stream_id] DEFAULT (NEWID())

,   [file_stream]       VARBINARY(MAX)  FILESTREAM  NOT NULL        

,   [Primary]           BIT                         NOT NULL
,   [Caption]           NVARCHAR(1000)              NULL

,   [ModifiedDate]      DATETIME2                   NOT NULL                    CONSTRAINT [DF_ItemImage_ModifiedDate] DEFAULT (SYSDATETIME())

,   CONSTRAINT [PK_ItemImage_ItemId_stream_id] UNIQUE CLUSTERED ([ItemId], [stream_id])
,   CONSTRAINT [UI_ItemImage_stream_id] PRIMARY KEY NONCLUSTERED ([stream_id])
,   CONSTRAINT [FK_ItemImage_ItemId_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([ItemId])
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UXF_ItemImage_ItemId_Primary] ON [dbo].[ItemImage] ([ItemId]) WHERE [Primary] = 1;
GO