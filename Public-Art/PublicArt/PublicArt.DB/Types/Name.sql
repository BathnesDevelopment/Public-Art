/*
	Name:			[dbo].[Name]
	Author:			Chris Pickford
	Created:		2016-01-18
	Description:	Data type to store entity name.
*/
CREATE TYPE
	[dbo].[Name]
FROM
	NVARCHAR(300) NOT NULL;
