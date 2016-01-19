/*
	Name:			[dbo].[URL]
	Author:			Chris Pickford
	Created:		2016-01-18
	Description:	Data type to store internet URL.
*/
CREATE TYPE
	[dbo].[URL]
FROM
	NVARCHAR(2083) NOT NULL;
