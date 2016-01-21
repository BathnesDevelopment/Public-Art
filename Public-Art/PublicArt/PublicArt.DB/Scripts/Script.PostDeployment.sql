/*
Post-Deployment Script Template                         
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.       
 Use SQLCMD syntax to include a file in the post-deployment script.         
 Example:      :r .\myfile.sql                              
 Use SQLCMD syntax to reference a variable in the post-deployment script.       
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                 
--------------------------------------------------------------------------------------
*/

EXEC [dbo].[uspSeed_Category];
EXEC [dbo].[uspSeed_Artist];
EXEC [dbo].[uspSeed_Item];

EXEC [dbo].[uspSeed_ItemCategory];
EXEC [dbo].[uspSeed_ItemArtist];
EXEC [dbo].[uspSeed_ItemImage];