CREATE TRIGGER [TR_ImageThumbnail_Update] ON [dbo].[ImageThumbnail]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [ImageThumbnail]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[ImageThumbnail]
    INNER JOIN [INSERTED]
        ON [INSERTED].[stream_id] = [ImageThumbnail].[stream_id] AND
           [INSERTED].[magnitude] = [ImageThumbnail].[magnitude];
END;
