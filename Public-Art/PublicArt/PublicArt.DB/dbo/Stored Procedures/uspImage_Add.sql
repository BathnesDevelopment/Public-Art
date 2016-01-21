CREATE PROCEDURE [dbo].[uspImage_Add] (
     @filename NVARCHAR(255)
    ,@filedata VARBINARY(MAX)
    )
AS
DECLARE @docid UNIQUEIDENTIFIER;
BEGIN
    SET @docid = NEWID();
    INSERT  INTO [dbo].[Image]
            ([stream_id]
            ,[file_stream]
            ,[name]
            )
    VALUES
            (@docid
            ,@filedata
            ,@filename
            );
    SELECT
        [stream_id]
    ,   [file_stream].[PathName]() AS [unc_path]
    FROM
        [dbo].[Image]
    WHERE
        [stream_id] = @docid;
END;