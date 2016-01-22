CREATE TABLE [dbo].[ImageThumbnail] (
    [stream_id]         UNIQUEIDENTIFIER                NOT NULL        ROWGUIDCOL
,   [file_stream]       VARBINARY(MAX)  FILESTREAM      NOT NULL
,   [ModifiedDate]      DATETIME2                       NOT NULL        CONSTRAINT [DF_ImageThumbnail_ModifiedDate] DEFAULT (SYSDATETIME())
,   CONSTRAINT [PK_ImageThumbnail_stream_id] PRIMARY KEY CLUSTERED ([stream_id])
,   CONSTRAINT [FK_ImageThumbnail_stream_id_ImageFT] FOREIGN KEY ([stream_id]) REFERENCES [dbo].[ImageFT]([stream_id])
);
GO
