/*
    Name:           [dbo].[Artist]
    Author:         Chris Pickford
    Created:        2016-01-18
    Description:    Table to hold artists.
*/
CREATE TABLE [dbo].[Artist]
(
    [ArtistId]      INT                 NOT NULL        IDENTITY(1,1)
,   [Name]          [dbo].[Name]        NOT NULL
,   [Biography]     NVARCHAR(4000)      NULL
,   [WebsiteURL]    [dbo].[URL]         NULL
,   [StartYear]     SMALLINT            NULL
,   [EndYear]       SMALLINT            NULL

,   [rowguid]       UNIQUEIDENTIFIER    NOT NULL        ROWGUIDCOL      CONSTRAINT [DF_Artist_rowguid] DEFAULT (NEWID())
,   [ModifiedDate]  DATETIME2           NOT NULL                        CONSTRAINT [DF_Artist_ModifiedDate] DEFAULT (SYSDATETIME())

,   CONSTRAINT [PK_Artist_ArtistId] PRIMARY KEY CLUSTERED ([ArtistId])

);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UI_Artist_Name] ON [dbo].[Artist]([Name]);
GO
