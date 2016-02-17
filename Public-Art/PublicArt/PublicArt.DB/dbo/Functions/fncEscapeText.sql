CREATE FUNCTION [dbo].[fncEscapeText]
(
    @text NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN '"' + REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@text, '"', '""'), '“', '""'), '”', '""'), '''', ''''''), CHAR(10), '<br>') + '"';
END
