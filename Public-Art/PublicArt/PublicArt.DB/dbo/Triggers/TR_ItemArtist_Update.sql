CREATE TRIGGER [TR_ItemArtist_Update] ON [dbo].[ItemArtist]
    FOR UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE
        [ItemArtist]
    SET
        [ModifiedDate] = CURRENT_TIMESTAMP
    FROM
        [dbo].[ItemArtist]
    INNER JOIN [INSERTED]
        ON [INSERTED].[ArtistId] = [ItemArtist].[ArtistId] AND
           [INSERTED].[ItemId] = [ItemArtist].[ItemId];
END;
