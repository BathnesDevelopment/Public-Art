CREATE TABLE [dbo].[ImageThumbnail] (
    [stream_id]         UNIQUEIDENTIFIER                NOT NULL        
,   [magnitude]         INT                             NOT NULL

,   [file_stream]       VARBINARY(MAX)  FILESTREAM      NOT NULL

,   [rowguid]           UNIQUEIDENTIFIER    ROWGUIDCOL  NOT NULL        CONSTRAINT [DF_ImageThumbnail_rowguid] DEFAULT (NEWID())
,   [ModifiedDate]      DATETIME2                       NOT NULL        CONSTRAINT [DF_ImageThumbnail_ModifiedDate] DEFAULT (SYSDATETIME())

,   CONSTRAINT [PK_ImageThumbnail_stream_id_magnitude] PRIMARY KEY CLUSTERED ([stream_id], [magnitude])
,   CONSTRAINT [UI_ImageThumbnail_stream_id] UNIQUE NONCLUSTERED ([rowguid])
,   CONSTRAINT [FK_ImageThumbnail_stream_id_ItemImage] FOREIGN KEY ([stream_id]) REFERENCES [dbo].[ItemImage]([stream_id]) ON DELETE CASCADE
);
GO
