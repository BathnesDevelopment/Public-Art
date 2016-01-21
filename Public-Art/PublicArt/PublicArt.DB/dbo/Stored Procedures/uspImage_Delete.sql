CREATE PROCEDURE [dbo].[uspImage_Delete] (
     @docId UNIQUEIDENTIFIER
    )
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM
        [dbo].[Image]
    WHERE
        [stream_id] = @docId;    
END;