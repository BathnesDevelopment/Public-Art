/*
    Name:           [dbo].[Image]
    Author:         Chris Pickford
    Created:        2016-01-21
    Description:    View to allow Entity Framework to interact with the filetable
*/
CREATE VIEW [dbo].[Image]
AS
SELECT
    [stream_id]
,   [file_stream]
,   [name]
,   [is_directory]
,   [unc_path] = [file_stream].PathName()
FROM
    [dbo].[ImageFT];
