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

MERGE INTO [dbo].[ItemImage] AS [TARGET]
USING
    (SELECT
        [ItemId]
     ,  [path_locator]
     ,  [Order] = ROW_NUMBER() OVER (PARTITION BY [Item].[ItemId] ORDER BY [Image].[name])
     FROM
        [dbo].[Image]
     INNER JOIN [dbo].[Item]
        ON [Reference] = LEFT([name], LEN([name]) - 6)
    ) AS [SOURCE] ([ItemId], [path_locator], [Order])
ON [TARGET].[ItemId] = [SOURCE].[ItemId] AND
    [TARGET].[path_locator] = [SOURCE].[path_locator]
WHEN NOT MATCHED BY TARGET THEN
    INSERT
           ([ItemId]
           ,[path_locator]
           ,[Order]
           ,[Caption]
           )
    VALUES ([SOURCE].[ItemId]
           ,[SOURCE].[path_locator]
           ,[SOURCE].[Order]
           ,NULL
           );

RETURN 0;
