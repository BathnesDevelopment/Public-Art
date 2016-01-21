﻿/*
    Name:           [dbo].[uspSeed_ItemArtist]
    Author:         Chris Pickford
    Created:        2016-01-21
    Description:    Populates table with seed data to be executed post-deployment.
                    Use the following SQL to generate values from a populated table:
                        SELECT N'('
	                        +  'N''' + [Item].[Reference] + ''', '
                            +  'N''' + [Category].[Description]+ ''''
	                        + N'),'
                        FROM
                            [dbo].[ItemCategory]
                        INNER JOIN [dbo].[Item]
                            ON [Item].[ItemId] = [ItemCategory].[ItemId]
                        INNER JOIN [dbo].[Category]
                            ON [Category].[CategoryId] = [ItemCategory].[CategoryId];
*/
CREATE PROCEDURE [dbo].[uspSeed_ItemCategory]
AS

SET NOCOUNT ON;

MERGE INTO [dbo].[ItemCategory] AS [TARGET]
USING ( SELECT
            [Item].[ItemId]
        ,   [Category].[CategoryId]
        FROM (
            VALUES

(N'BA24', N'Decorative'),
(N'BA24', N'Paving'),
(N'BA44', N'Figurative'),
(N'BA44', N'Sculpture'),
(N'BA70', N'Abstract'),
(N'BA70', N'Sculpture'),
(N'BA1', N'Church Art'),
(N'BA1', N'Decorative'),
(N'BA1', N'Figurative'),
(N'BA2', N'Church Art'),
(N'BA3', N'Abstract'),
(N'BA3', N'Church Art'),
(N'BA3', N'Figurative'),
(N'BA4', N'Church Art'),
(N'BA4', N'Figurative'),
(N'BA5', N'Figurative'),
(N'BA5', N'Sculpture'),
(N'BA6', N'Church Art'),
(N'BA6', N'Decorative'),
(N'BA7', N'Church Art'),
(N'BA7', N'Decorative'),
(N'BA8', N'Church Art'),
(N'BA8', N'Figurative'),
(N'BA9', N'Church Art'),
(N'BA9', N'Figurative'),
(N'BA10', N'Abstract'),
(N'BA10', N'Church Art'),
(N'BA11', N'Abstract'),
(N'BA11', N'Church Art'),
(N'BA12', N'Figurative'),
(N'BA12', N'Painting'),
(N'BA13', N'Figurative'),
(N'BA13', N'Sculpture'),
(N'BA14', N'Abstract'),
(N'BA14', N'Church Art'),
(N'BA15', N'Decorative'),
(N'BA15', N'Paving'),
(N'BA16', N'Abstract'),
(N'BA16', N'Sculpture'),
(N'BA17', N'Figurative'),
(N'BA17', N'Sculpture'),
(N'BA18', N'Abstract'),
(N'BA18', N'Church Art'),
(N'BA19', N'Abstract'),
(N'BA19', N'Other'),
(N'BA20', N'Figurative'),
(N'BA20', N'Sculpture'),
(N'BA21', N'Figurative'),
(N'BA21', N'Sculpture'),
(N'BA23', N'Figurative'),
(N'BA23', N'Sculpture'),
(N'BA25', N'Abstract'),
(N'BA25', N'Sculpture'),
(N'BA26', N'Decorative'),
(N'BA26', N'Figurative'),
(N'BA26', N'Mural'),
(N'BA27', N'Paving'),
(N'BA28', N'Decorative'),
(N'BA28', N'Sculpture'),
(N'BA29', N'Figurative'),
(N'BA29', N'Painting'),
(N'BA30', N'Figurative'),
(N'BA30', N'Photography'),
(N'BA31', N'Drawing'),
(N'BA31', N'Figurative'),
(N'BA32', N'Drawing'),
(N'BA32', N'Figurative'),
(N'BA33', N'Abstract'),
(N'BA33', N'Painting'),
(N'BA34', N'Abstract'),
(N'BA34', N'Painting'),
(N'BA35', N'Figurative'),
(N'BA35', N'Sculpture'),
(N'BA36', N'Drawing'),
(N'BA36', N'Figurative'),
(N'BA36', N'Photography'),
(N'BA36', N'Sculpture'),
(N'BA37', N'Figurative'),
(N'BA37', N'Other'),
(N'BA38', N'Figurative'),
(N'BA38', N'Other'),
(N'BA39', N'Figurative'),
(N'BA39', N'Sculpture'),
(N'BA40', N'Photography'),
(N'BA41', N'Figurative'),
(N'BA41', N'Painting'),
(N'BA42', N'Abstract'),
(N'BA42', N'Sculpture'),
(N'BA43', N'Drawing'),
(N'BA45', N'Figurative'),
(N'BA45', N'Sculpture'),
(N'BA46', N'Figurative'),
(N'BA46', N'Painting'),
(N'BA47', N'Figurative'),
(N'BA47', N'Painting'),
(N'BA48', N'Figurative'),
(N'BA48', N'Sculpture'),
(N'BA49', N'Figurative'),
(N'BA49', N'Painting'),
(N'BA50', N'Abstract'),
(N'BA50', N'Figurative'),
(N'BA50', N'Photography'),
(N'BA51', N'Decorative'),
(N'BA51', N'Paving'),
(N'BA51', N'Sculpture'),
(N'BA52', N'Decorative'),
(N'BA52', N'Sculpture'),
(N'BA53', N'Abstract'),
(N'BA53', N'Church Art'),
(N'BA54', N'Abstract'),
(N'BA54', N'Sculpture'),
(N'BA55', N'Abstract'),
(N'BA55', N'Sculpture'),
(N'BA56', N'Figurative'),
(N'BA56', N'Sculpture'),
(N'BA57', N'Figurative'),
(N'BA57', N'Sculpture'),
(N'BA58', N'Figurative'),
(N'BA58', N'Mosaic'),
(N'BA59', N'Abstract'),
(N'BA59', N'Decorative'),
(N'BA59', N'Figurative'),
(N'BA59', N'Sculpture'),
(N'BA60', N'Figurative'),
(N'BA60', N'Sculpture'),
(N'BA61', N'Drawing'),
(N'BA61', N'Figurative'),
(N'BA62', N'Figurative'),
(N'BA62', N'Sculpture'),
(N'BA63', N'Figurative'),
(N'BA63', N'Sculpture'),
(N'BA64', N'Sculpture'),
(N'BA65', N'Figurative'),
(N'BA65', N'Sculpture'),
(N'BA66', N'Figurative'),
(N'BA66', N'Mural'),
(N'BA67', N'Abstract'),
(N'BA67', N'Figurative'),
(N'BA67', N'Painting'),
(N'BA68', N'Decorative'),
(N'BA68', N'Sculpture'),
(N'BA69', N'Decorative'),
(N'BA69', N'Sculpture'),
(N'BA105', N'Figurative'),
(N'BA105', N'Sculpture'),
(N'CM106', N'Decorative'),
(N'CM106', N'Sculpture'),
(N'BA107', N'Figurative'),
(N'BA107', N'Sculpture'),
(N'BA108', N'Figurative'),
(N'BA108', N'Sculpture'),
(N'BA109', N'Figurative'),
(N'BA109', N'Sculpture'),
(N'CP110', N'Figurative'),
(N'CP110', N'Sculpture'),
(N'BA111', N'Street furniture'),
(N'CW167', N'Decorative'),
(N'CW168', N'Abstract'),
(N'CW168', N'Sculpture'),
(N'R170', N'Figurative'),
(N'R170', N'Sculpture'),
(N'BA171', N'Abstract'),
(N'BA171', N'Figurative'),
(N'BA171', N'Painting'),
(N'BA172', N'Abstract'),
(N'BA172', N'Figurative'),
(N'BA172', N'Paving'),
(N'BA173', N'Abstract'),
(N'BA173', N'Figurative'),
(N'BA173', N'Sculpture'),
(N'BA174', N'Abstract'),
(N'BA174', N'Sculpture'),
(N'BA175', N'Figurative'),
(N'BA175', N'Painting'),
(N'BA71', N'Photography'),
(N'BA72', N'Photography'),
(N'BA73', N'Drawing'),
(N'BA74', N'Photography'),
(N'BA75', N'Photography'),
(N'BA76', N'Photography'),
(N'BA77', N'Photography'),
(N'BA78', N'Abstract'),
(N'BA78', N'Drawing'),
(N'BA79', N'Abstract'),
(N'BA79', N'Photography'),
(N'BA80', N'Abstract'),
(N'BA80', N'Photography'),
(N'BA81', N'Photography'),
(N'BA82', N'Photography'),
(N'BA88', N'Abstract'),
(N'BA88', N'Other'),
(N'BA91', N'Abstract'),
(N'BA91', N'Painting'),
(N'BA92', N'Figurative'),
(N'BA92', N'Painting'),
(N'BA93', N'Figurative'),
(N'BA93', N'Mosaic'),
(N'BA94', N'Church Art'),
(N'BA94', N'Figurative'),
(N'BA95', N'Abstract'),
(N'BA95', N'Church Art'),
(N'BA96', N'Figurative'),
(N'BA96', N'Painting'),
(N'BA97', N'Figurative'),
(N'BA97', N'Painting'),
(N'BA98', N'Drawing'),
(N'BA98', N'Figurative'),
(N'BA100', N'Figurative'),
(N'BA100', N'Other'),
(N'BA101', N'Figurative'),
(N'BA101', N'Painting'),
(N'BA102', N'Painting'),
(N'BA103', N'Sculpture'),
(N'BA104', N'Abstract'),
(N'BA104', N'Figurative'),
(N'BA104', N'Sculpture'),
(N'BA104', N'Surrealist'),
(N'BO127', N'Figurative'),
(N'BO127', N'Mural'),
(N'BS166', N'Figurative'),
(N'BS166', N'Mosaic'),
(N'BA156', N'Figurative'),
(N'BA156', N'Mosaic'),
(N'MN164', N'Decorative'),
(N'MN164', N'Mosaic'),
(N'CP169', N'Figurative'),
(N'CP169', N'Sculpture'),
(N'BA185', N'Abstract'),
(N'BA185', N'Sculpture'),
(N'BA183', N'Figurative'),
(N'BA183', N'Sculpture'),
(N'BA184', N'Abstract'),
(N'BA184', N'Sculpture'),
(N'BA177', N'Figurative'),
(N'BA177', N'Sculpture'),
(N'BA182', N'Figurative'),
(N'BA182', N'Sculpture'),
(N'BA180', N'Decorative'),
(N'BA180', N'Sculpture'),
(N'BA181', N'Other'),
(N'BA176', N'Figurative'),
(N'BA176', N'Sculpture'),
(N'BA186', N'Figurative'),
(N'BA186', N'Sculpture'),
(N'BA178', N'Abstract'),
(N'BA178', N'Figurative'),
(N'BA178', N'Other'),
(N'BA179', N'Figurative'),
(N'BA179', N'Photography')

        ) AS [VALUES] ([Reference], [Description])
        INNER JOIN [dbo].[Item]
            ON [Item].[Reference] = [VALUES].[Reference]
        INNER JOIN [dbo].[Category]
            ON [Category].[Description] = [VALUES].[Description]

) AS [SOURCE] (
    [ItemId]
,   [CategoryId]
)
ON [TARGET].[ItemId] = [SOURCE].[ItemId]
AND [TARGET].[CategoryId] = [SOURCE].[CategoryId]

WHEN NOT MATCHED BY TARGET THEN
    INSERT (    
        [ItemId]
    ,   [CategoryId]
    )
    VALUES (
        [SOURCE].[ItemId]
    ,   [SOURCE].[CategoryId]
    );

RETURN 0;