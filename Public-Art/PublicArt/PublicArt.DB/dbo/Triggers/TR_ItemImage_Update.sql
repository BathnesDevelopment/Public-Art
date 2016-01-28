CREATE TRIGGER [TR_ItemImage_Update] ON [dbo].[ItemImage]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [ItemImage]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[ItemImage]
    INNER JOIN [INSERTED]
        ON [INSERTED].[ItemId] = [ItemImage].[ItemId] AND
           [INSERTED].[stream_id] = [ItemImage].[stream_id];
END;
