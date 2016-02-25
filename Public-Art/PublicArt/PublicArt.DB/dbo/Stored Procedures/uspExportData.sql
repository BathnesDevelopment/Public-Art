/*
    Name:           [dbo].[uspExportData]
    Author:         Chris Pickford
    Created:        2016-02-16
    Description:    Flattens all data for export to CSV.
                    
*/
CREATE PROCEDURE [dbo].[uspExportData] (
    @columnHeaders BIT = 0
)
AS
SET NOCOUNT ON;

;
WITH    [CTE_ItemCategory]([ItemId], [Description])
          AS (SELECT
                [ItemId]
              , [Description]
              FROM
                [dbo].[ItemCategory]
              INNER JOIN [dbo].[Category]
                ON [Category].[CategoryId] = [ItemCategory].[CategoryId]
             ),
        [CTE_ItemCategoryFlat]([ItemId], [Categories])
          AS (SELECT
                [ItemId] = [c1].[ItemId]
              , [Categories] = STUFF((SELECT
                                        '|' + [c2].[Description]
                                      FROM
                                        [CTE_ItemCategory] [c2]
                                      WHERE
                                        [c2].[ItemId] = [c1].[ItemId]
                                      ORDER BY
                                        [c2].[Description] ASC
                                     FOR
                                      XML PATH('')
                                     ), 1, 1, '')
              FROM
                [CTE_ItemCategory] [c1]
              GROUP BY
                [c1].[ItemId]
             ),
        [CTE_ItemArtistIds]([ItemId], [ArtistId1], [ArtistId2], [ArtistId3], [ArtistId4], [ArtistId5], [ArtistId6])
          AS (SELECT
                [ItemId] = [pvt].[ItemId]
              , [ArtistId1] = [pvt].[1]
              , [ArtistId2] = [pvt].[2]
              , [ArtistId3] = [pvt].[3]
              , [ArtistId4] = [pvt].[4]
              , [ArtistId5] = [pvt].[5]
              , [ArtistId6] = [pvt].[6]
              FROM
                (SELECT
                    [ItemId]
                 ,  [ItemArtist].[ArtistId]
                 ,  [Order] = ROW_NUMBER() OVER (PARTITION BY [ItemId] ORDER BY [Name])
                 FROM
                    [dbo].[ItemArtist]
                 INNER JOIN [dbo].[Artist]
                    ON [Artist].[ArtistId] = [ItemArtist].[ArtistId]
                ) AS [s] PIVOT ( MAX([ArtistId]) FOR [Order] IN ([1], [2], [3],
                                                              [4], [5], [6]) ) AS [pvt]
             ),
        [CTE_ItemArtistNotes]([ItemId], [ArtistNotes1], [ArtistNotes2], [ArtistNotes3], [ArtistNotes4], [ArtistNotes5], [ArtistNotes6])
          AS (SELECT
                [ItemId] = [pvt].[ItemId]
              , [ArtistNotes1] = [pvt].[1]
              , [ArtistNotes2] = [pvt].[2]
              , [ArtistNotes3] = [pvt].[3]
              , [ArtistNotes4] = [pvt].[4]
              , [ArtistNotes5] = [pvt].[5]
              , [ArtistNotes6] = [pvt].[6]
              FROM
                (SELECT
                    [ItemId]
                 ,  [Notes]
                 ,  [Order] = ROW_NUMBER() OVER (PARTITION BY [ItemId] ORDER BY [Name])
                 FROM
                    [dbo].[ItemArtist]
                 INNER JOIN [dbo].[Artist]
                    ON [Artist].[ArtistId] = [ItemArtist].[ArtistId]
                ) AS [s] PIVOT ( MAX([Notes]) FOR [Order] IN ([1], [2], [3],
                                                              [4], [5], [6]) ) AS [pvt]
             ),
        [CTE_ItemArtistFlat]([ItemId], [Artist1_Name], [Artist1_Biography], [Artist1_WebsiteUrl], [Artist1_StartYear], [Artist1_EndYear], [Artist1_Notes], [Artist2_Name], [Artist2_Biography], [Artist2_WebsiteUrl], [Artist2_StartYear], [Artist2_EndYear], [Artist2_Notes], [Artist3_Name], [Artist3_Biography], [Artist3_WebsiteUrl], [Artist3_StartYear], [Artist3_EndYear], [Artist3_Notes], [Artist4_Name], [Artist4_Biography], [Artist4_WebsiteUrl], [Artist4_StartYear], [Artist4_EndYear], [Artist4_Notes], [Artist5_Name], [Artist5_Biography], [Artist5_WebsiteUrl], [Artist5_StartYear], [Artist5_EndYear], [Artist5_Notes], [Artist6_Name], [Artist6_Biography], [Artist6_WebsiteUrl], [Artist6_StartYear], [Artist6_EndYear], [Artist6_Notes])
          AS (SELECT
                [ItemId] = [CTE_ItemArtistIds].[ItemId]
              , [Artist1_Name] = [Artist1].[Name]
              , [Artist1_Biography] = [Artist1].[Biography]
              , [Artist1_WebsiteUrl] = [Artist1].[WebsiteUrl]
              , [Artist1_StartYear] = [Artist1].[StartYear]
              , [Artist1_EndYear] = [Artist1].[EndYear]
              , [Artist1_Notes] = [CTE_ItemArtistNotes].[ArtistNotes1]
              , [Artist2_Name] = [Artist2].[Name]
              , [Artist2_Biography] = [Artist2].[Biography]
              , [Artist2_WebsiteUrl] = [Artist2].[WebsiteUrl]
              , [Artist2_StartYear] = [Artist2].[StartYear]
              , [Artist2_EndYear] = [Artist2].[EndYear]
              , [Artist2_Notes] = [CTE_ItemArtistNotes].[ArtistNotes2]
              , [Artist3_Name] = [Artist3].[Name]
              , [Artist3_Biography] = [Artist3].[Biography]
              , [Artist3_WebsiteUrl] = [Artist3].[WebsiteUrl]
              , [Artist3_StartYear] = [Artist3].[StartYear]
              , [Artist3_EndYear] = [Artist3].[EndYear]
              , [Artist3_Notes] = [CTE_ItemArtistNotes].[ArtistNotes3]
              , [Artist4_Name] = [Artist4].[Name]
              , [Artist4_Biography] = [Artist4].[Biography]
              , [Artist4_WebsiteUrl] = [Artist4].[WebsiteUrl]
              , [Artist4_StartYear] = [Artist4].[StartYear]
              , [Artist4_EndYear] = [Artist4].[EndYear]
              , [Artist4_Notes] = [CTE_ItemArtistNotes].[ArtistNotes4]
              , [Artist5_Name] = [Artist5].[Name]
              , [Artist5_Biography] = [Artist5].[Biography]
              , [Artist5_WebsiteUrl] = [Artist5].[WebsiteUrl]
              , [Artist5_StartYear] = [Artist5].[StartYear]
              , [Artist5_EndYear] = [Artist5].[EndYear]
              , [Artist5_Notes] = [CTE_ItemArtistNotes].[ArtistNotes5]
              , [Artist6_Name] = [Artist6].[Name]
              , [Artist6_Biography] = [Artist6].[Biography]
              , [Artist6_WebsiteUrl] = [Artist6].[WebsiteUrl]
              , [Artist6_StartYear] = [Artist6].[StartYear]
              , [Artist6_EndYear] = [Artist6].[EndYear]
              , [Artist6_Notes] = [CTE_ItemArtistNotes].[ArtistNotes6]
              FROM
                [CTE_ItemArtistIds]
              INNER JOIN [CTE_ItemArtistNotes]
                ON [CTE_ItemArtistIds].[ItemId] = [CTE_ItemArtistNotes].[ItemId]
              LEFT JOIN [dbo].[Artist] AS [Artist1]
                ON [Artist1].[ArtistId] = [CTE_ItemArtistIds].[ArtistId1]
              LEFT JOIN [dbo].[Artist] AS [Artist2]
                ON [Artist2].[ArtistId] = [CTE_ItemArtistIds].[ArtistId2]
              LEFT JOIN [dbo].[Artist] AS [Artist3]
                ON [Artist3].[ArtistId] = [CTE_ItemArtistIds].[ArtistId3]
              LEFT JOIN [dbo].[Artist] AS [Artist4]
                ON [Artist4].[ArtistId] = [CTE_ItemArtistIds].[ArtistId4]
              LEFT JOIN [dbo].[Artist] AS [Artist5]
                ON [Artist5].[ArtistId] = [CTE_ItemArtistIds].[ArtistId5]
              LEFT JOIN [dbo].[Artist] AS [Artist6]
                ON [Artist6].[ArtistId] = [CTE_ItemArtistIds].[ArtistId6]
             ),
        [CTE_ItemImageFlat]([ItemId], [ImageFileNames], [ImageCaptions])
          AS (SELECT
                [ItemId] = [i1].[ItemId]
              , [ImageFileNames] = STUFF((SELECT
                                            '|' +
                                            CONVERT(VARCHAR(40), [i2].[stream_id]) +
                                            '.jpg'
                                          FROM
                                            [dbo].[ItemImage] [i2]
                                          WHERE
                                            [i2].[ItemId] = [i1].[ItemId]
                                          ORDER BY
                                            [i2].[Primary] DESC, [i2].[stream_id]
                                         FOR
                                          XML PATH('')
                                         ), 1, 1, '')
              , [ImageCaptions] = STUFF((SELECT
                                            '|' +
                                            CONVERT(VARCHAR(40), [i2].[Caption])
                                          FROM
                                            [dbo].[ItemImage] [i2]
                                          WHERE
                                            [i2].[ItemId] = [i1].[ItemId]
                                          ORDER BY
                                            [i2].[Primary] DESC, [i2].[stream_id]
                                         FOR
                                          XML PATH('')
                                         ), 1, 1, '')
              FROM
                [dbo].[ItemImage] [i1]
              GROUP BY
                [i1].[ItemId]
             )
    SELECT
         [Reference] = 'Reference'
        ,[Title] = 'Title'
        ,[Description] = 'Description'
        ,[Date] = 'Date'
        ,[UnveilingYear] = 'UnveilingYear'
        ,[UnveilingDetails] = 'UnveilingDetails'
        ,[Statement] = 'Statement'
        ,[Material] = 'Material'
        ,[Inscription] = 'Inscription'
        ,[History] = 'History'
        ,[Notes] = 'Notes'
        ,[WebsiteUrl] = 'WebsiteUrl'
        ,[Height] = 'Height'
        ,[Width] = 'Width'
        ,[Depth] = 'Depth'
        ,[Diameter] = 'Diameter'
        ,[SurfaceCondition] = 'SurfaceCondition'
        ,[StructuralCondition] = 'StructuralCondition'
        ,[Address] = 'Address'
        ,[Location] = 'Location'
        ,[Lat] = 'Lat'
        ,[Lng] = 'Lng'
        ,[Categories] = 'Categories'
        ,[Artist1_Name] = 'Artist1_Name'
        ,[Artist1_Biography] = 'Artist1_Biography'
        ,[Artist1_WebsiteUrl] = 'Artist1_WebsiteUrl'
        ,[Artist1_StartYear] = 'Artist1_StartYear'
        ,[Artist1_EndYear] = 'Artist1_EndYear'
        ,[Artist1_Notes] = 'Artist1_Notes'
        ,[Artist2_Name] = 'Artist2_Name'
        ,[Artist2_Biography] = 'Artist2_Biography'
        ,[Artist2_WebsiteUrl] = 'Artist2_WebsiteUrl'
        ,[Artist2_StartYear] = 'Artist2_StartYear'
        ,[Artist2_EndYear] = 'Artist2_EndYear'
        ,[Artist2_Notes] = 'Artist2_Notes'
        ,[Artist3_Name] = 'Artist3_Name'
        ,[Artist3_Biography] = 'Artist3_Biography'
        ,[Artist3_WebsiteUrl] = 'Artist3_WebsiteUrl'
        ,[Artist3_StartYear] = 'Artist3_StartYear'
        ,[Artist3_EndYear] = 'Artist3_EndYear'
        ,[Artist3_Notes] = 'Artist3_Notes'
        ,[Artist4_Name] = 'Artist4_Name'
        ,[Artist4_Biography] = 'Artist4_Biography'
        ,[Artist4_WebsiteUrl] = 'Artist4_WebsiteUrl'
        ,[Artist4_StartYear] = 'Artist4_StartYear'
        ,[Artist4_EndYear] = 'Artist4_EndYear'
        ,[Artist4_Notes] = 'Artist4_Notes'
        ,[Artist5_Name] = 'Artist5_Name'
        ,[Artist5_Biography] = 'Artist5_Biography'
        ,[Artist5_WebsiteUrl] = 'Artist5_WebsiteUrl'
        ,[Artist5_StartYear] = 'Artist5_StartYear'
        ,[Artist5_EndYear] = 'Artist5_EndYear'
        ,[Artist5_Notes] = 'Artist5_Notes'
        ,[Artist6_Name] = 'Artist6_Name'
        ,[Artist6_Biography] = 'Artist6_Biography'
        ,[Artist6_WebsiteUrl] = 'Artist6_WebsiteUrl'
        ,[Artist6_StartYear] = 'Artist6_StartYear'
        ,[Artist6_EndYear] = 'Artist6_EndYear'
        ,[Artist6_Notes] = 'Artist6_Notes'
        ,[ImageFileNames] = 'ImageFileNames'
        ,[ImageCaptions] = 'ImageCaptions'
    WHERE @columnHeaders = 1
    UNION ALL
    SELECT
        [Reference] = [Reference]
    ,   [Title] = [dbo].[fncEscapeText]([Title])
    ,   [Description] = [dbo].[fncEscapeText]([Description])
    ,   [Date] = CONVERT(CHAR(4), [Date])
    ,   [UnveilingYear] = CONVERT(CHAR(4), [UnveilingYear])
    ,   [UnveilingDetails] = [dbo].[fncEscapeText]([UnveilingDetails])
    ,   [Statement] = [dbo].[fncEscapeText]([Statement])
    ,   [Material] = [dbo].[fncEscapeText]([Material])
    ,   [Inscription] = [dbo].[fncEscapeText]([Inscription])
    ,   [History] = [dbo].[fncEscapeText]([History])
    ,   [Notes] = [dbo].[fncEscapeText]([Notes])
    ,   [WebsiteUrl] = [WebsiteUrl]
    ,   [Height] = CONVERT(VARCHAR(10), [Height])
    ,   [Width] = CONVERT(VARCHAR(10), [Width])
    ,   [Depth] = CONVERT(VARCHAR(10), [Depth])
    ,   [Diameter] = CONVERT(VARCHAR(10), [Diameter])
    ,   [SurfaceCondition] = [dbo].[fncEscapeText]([SurfaceCondition])
    ,   [StructuralCondition] = [dbo].[fncEscapeText]([StructuralCondition])
    ,   [Address] = [dbo].[fncEscapeText]([Address])
    ,   [Location] = '(' + CONVERT(VARCHAR(16), [Location].[Lat]) + ',' + CONVERT(VARCHAR(16), [Location].[Long]) + ')'
    ,   [Lat] = CONVERT(VARCHAR(16), [Location].[Lat])
    ,   [Lng] = CONVERT(VARCHAR(16), [Location].[Long])
    ,   [Categories] = [CTE_ItemCategoryFlat].[Categories]
    ,   [Artist1_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist1_Name])
    ,   [Artist1_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist1_Biography])
    ,   [Artist1_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist1_WebsiteUrl]
    ,   [Artist1_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist1_StartYear])
    ,   [Artist1_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist1_EndYear])
    ,   [Artist1_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist1_Notes])
    ,   [Artist2_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist2_Name])
    ,   [Artist2_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist2_Biography])
    ,   [Artist2_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist2_WebsiteUrl]
    ,   [Artist2_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist2_StartYear])
    ,   [Artist2_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist2_EndYear])
    ,   [Artist2_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist2_Notes])
    ,   [Artist3_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist3_Name])
    ,   [Artist3_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist3_Biography])
    ,   [Artist3_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist3_WebsiteUrl]
    ,   [Artist3_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist3_StartYear])
    ,   [Artist3_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist3_EndYear])
    ,   [Artist3_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist3_Notes])
    ,   [Artist4_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist4_Name])
    ,   [Artist4_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist4_Biography])
    ,   [Artist4_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist4_WebsiteUrl]
    ,   [Artist4_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist4_StartYear])
    ,   [Artist4_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist4_EndYear])
    ,   [Artist4_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist4_Notes])
    ,   [Artist5_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist5_Name])
    ,   [Artist5_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist5_Biography])
    ,   [Artist5_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist5_WebsiteUrl]
    ,   [Artist5_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist5_StartYear])
    ,   [Artist5_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist5_EndYear])
    ,   [Artist5_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist5_Notes])
    ,   [Artist6_Name] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist6_Name])
    ,   [Artist6_Biography] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist6_Biography])
    ,   [Artist6_WebsiteUrl] = [CTE_ItemArtistFlat].[Artist6_WebsiteUrl]
    ,   [Artist6_StartYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist6_StartYear])
    ,   [Artist6_EndYear] = CONVERT(CHAR(4), [CTE_ItemArtistFlat].[Artist6_EndYear])
    ,   [Artist6_Notes] = [dbo].[fncEscapeText]([CTE_ItemArtistFlat].[Artist6_Notes])
    ,   [ImageFileNames] = [CTE_ItemImageFlat].[ImageFileNames]
    ,   [ImageCaptions] = [CTE_ItemImageFlat].[ImageCaptions]
    FROM
        [dbo].[Item]
    LEFT JOIN [CTE_ItemCategoryFlat]
        ON [CTE_ItemCategoryFlat].[ItemId] = [Item].[ItemId]
    LEFT JOIN [CTE_ItemArtistFlat]
        ON [CTE_ItemArtistFlat].[ItemId] = [Item].[ItemId]
    LEFT JOIN [CTE_ItemImageFlat]
        ON [CTE_ItemImageFlat].[ItemId] = [Item].[ItemId]
    WHERE
        [Published] = 1;

RETURN 0;
