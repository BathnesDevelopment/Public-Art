CREATE TRIGGER [TR_ItemCategory_Update] ON [dbo].[ItemCategory]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [ItemCategory]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[ItemCategory]
    INNER JOIN [INSERTED]
        ON [INSERTED].[CategoryId] = [ItemCategory].[CategoryId] AND
           [INSERTED].[ItemId] = [ItemCategory].[ItemId];
END;
