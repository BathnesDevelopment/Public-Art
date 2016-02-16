CREATE PROCEDURE [dbo].[uspExportImages] (@path VARCHAR(220))
AS
SET NOCOUNT ON;

DECLARE @output TABLE (
     [stream_id] UNIQUEIDENTIFIER NOT NULL
                                  PRIMARY KEY
    ,[image_path] VARCHAR(260) NOT NULL
    );

INSERT  INTO @output
SELECT
    [stream_id]
,   [image_path] = [dbo].[ExportImageFile](@path,
                                           CONVERT(VARCHAR(40), [stream_id]) +
                                           '.jpg', [file_stream])
FROM
    [dbo].[ItemImage];

SELECT
    [stream_id]
,   [image_path]
FROM
    @output;

RETURN 0;
