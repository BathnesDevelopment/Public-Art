CREATE TRIGGER [TR_Artist_Update] ON [dbo].[Artist]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [Artist]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[Artist]
    INNER JOIN [INSERTED]
        ON [INSERTED].[ArtistId] = [Artist].[ArtistId];
END;
