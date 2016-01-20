/*
    Name:           [dbo].[Image]
    Author:         Chris Pickford
    Created:        2016-01-20
    Description:    Filetable to hold images of the items.
*/
CREATE TABLE [dbo].[Image]
    AS FILETABLE WITH (FileTable_Directory = 'Images')
