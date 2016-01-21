/*
    Name:           [dbo].[ImageFT]
    Author:         Chris Pickford
    Created:        2016-01-20
    Description:    Filetable to hold images of the items.
*/
CREATE TABLE [dbo].[ImageFT]
    AS FILETABLE WITH (FileTable_Directory = 'Images')
