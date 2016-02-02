/*
    Name:           [dbo].[uspItemImage_SetPrimary]
    Author:         Chris Pickford
    Created:        2016-02-02
    Description:    Sets the Primary bit flag for a particular ItemId and stream_id.
                    Only one ItemImage can be set primary for an ItemId so unsets all others.
                    
*/
CREATE PROCEDURE [dbo].[uspItemImage_SetPrimary]
    @itemId INT
,   @stream_id UNIQUEIDENTIFIER
AS
BEGIN

    SET NOCOUNT ON;

    IF NOT EXISTS ( SELECT NULL FROM [dbo].[ItemImage] WHERE [ItemId] = @itemId AND [stream_id] = @stream_id )
    BEGIN
        DECLARE @stream_id_vc NVARCHAR(36) = CONVERT(NVARCHAR(36), NEWID());
        RAISERROR(  N'No ItemImage exists with ItemId = %d and stream_id = ''%s''',
                11,
                1,
                @itemId,
                @stream_id_vc);
    END;

    BEGIN TRANSACTION;

    UPDATE
        [dbo].[ItemImage]
    SET
        [Primary] = 0
    WHERE
        [ItemId] = @itemId;

    UPDATE
        [dbo].[ItemImage]
    SET
        [Primary] = 1
    WHERE
        [ItemId] = @itemId AND
        [stream_id] = @stream_id;

    COMMIT TRANSACTION;

    RETURN 0;

END;