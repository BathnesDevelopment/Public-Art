CREATE TRIGGER [TR_Item_Update] ON [dbo].[Item]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [Item]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[Item]
    INNER JOIN [INSERTED]
        ON [INSERTED].[ItemId] = [Item].[ItemId];
END;
