/*
	Name:			[dbo].[uspSeed_Category]
	Author:			Chris Pickford
	Created:		2016-01-19
	Description:	Populates table with seed data to be executed post-deployment.
*/
CREATE PROCEDURE [dbo].[uspSeed_Category]
AS

SET NOCOUNT ON;

MERGE INTO [dbo].[Category] AS [TARGET]
USING ( VALUES 

(N'Abstract'),
(N'Church Art'),
(N'Decorative'),
(N'Drawing'),
(N'Figurative'),
(N'Functional'),
(N'Mosaic'),
(N'Mural'),
(N'Other'),
(N'Painting'),
(N'Paving'),
(N'Photography'),
(N'Sculpture'),
(N'Street furniture'),
(N'Surrealist'),
(N'Victorian')

) AS [SOURCE] ([Description])
ON [TARGET].[Description] = [SOURCE].[Description]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Description])
	VALUES ([SOURCE].[Description]);

RETURN 0;

