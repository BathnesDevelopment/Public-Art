/*
    Name:           [dbo].[uspSeed_ItemImage]
    Author:         Chris Pickford
    Created:        2016-01-20
    Description:    Populates ItemImage table with seed data to be executed post-deployment.
                    Matches files held in the FILETABLE against the item Reference to maintain assocations.
*/
CREATE PROCEDURE [dbo].[uspSeed_ItemImage]
AS
SET NOCOUNT ON;

BEGIN TRANSACTION

MERGE INTO [dbo].[ItemImage] AS [TARGET]
USING
    (SELECT
        [ItemId]
     ,  [stream_id]
     ,  [file_stream]
     ,  [Primary] = ROW_NUMBER() OVER (PARTITION BY [Item].[ItemId] ORDER BY [ImageFT].[name])
     FROM
        [dbo].[ImageFT]
     INNER JOIN [dbo].[Item]
        ON [Reference] = LEFT([name], LEN([name]) - 6)
    ) AS [SOURCE] ([ItemId], [stream_id], [file_stream], [Primary])
ON [TARGET].[ItemId] = [SOURCE].[ItemId] AND
    [TARGET].[stream_id] = [SOURCE].[stream_id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT
           ([ItemId]
           ,[stream_id]
           ,[file_stream]
           ,[Primary]
           ,[Caption]
           )
    VALUES ([SOURCE].[ItemId]
           ,[SOURCE].[stream_id]
           ,[SOURCE].[file_stream]
           ,IIF([SOURCE].[Primary] = 1, 1, 0)
           ,NULL
           );

TRUNCATE TABLE [dbo].[ImageFT];

COMMIT TRANSACTION

RETURN 0;
