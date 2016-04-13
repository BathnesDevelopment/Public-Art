CREATE TRIGGER [TR_Category_Update] ON [dbo].[Category]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [Category]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[Category]
    INNER JOIN [INSERTED]
        ON [INSERTED].[CategoryId] = [Category].[CategoryId];
END;
