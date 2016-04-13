/*
    Name:           [dbo].[Item]
    Author:         Chris Pickford
    Created:        2016-01-18
    Description:    Table to hold public art items.
*/
CREATE TABLE [dbo].[Item]
(
    [ItemId]                    INT                 NOT NULL        IDENTITY(1,1)

,   [Reference]                 VARCHAR(6)          NOT NULL
,   [Title]                     [dbo].[Name]        NOT NULL
,   [Description]               NVARCHAR(2000)      NOT NULL
,   [Date]                      SMALLINT            NULL

,   [UnveilingYear]             SMALLINT            NULL
,   [UnveilingDetails]          NVARCHAR(2000)      NULL
,   [Statement]                 NVARCHAR(2000)      NULL
,   [Material]                  NVARCHAR(500)       NULL
,   [Inscription]               NVARCHAR(500)       NULL
,   [History]                   NVARCHAR(2000)      NULL
,   [Notes]                     NVARCHAR(2000)      NULL
,   [WebsiteUrl]                [dbo].[URL]         NULL

,   [Height]                    SMALLINT            NULL
,   [Width]                     SMALLINT            NULL
,   [Depth]                     SMALLINT            NULL
,   [Diameter]                  SMALLINT            NULL

,   [SurfaceCondition]          NVARCHAR(1000)      NULL
,   [StructuralCondition]       NVARCHAR(1000)      NULL

,   [Address]                   NVARCHAR(1000)      NULL
,   [Location]                  GEOGRAPHY           NULL

,   [Published]                  BIT                 NOT NULL                       CONSTRAINT [DF_Item_Published] DEFAULT (0)

,   [rowguid]                   UNIQUEIDENTIFIER    NOT NULL        ROWGUIDCOL      CONSTRAINT [DF_Item_rowguid] DEFAULT (NEWID())
,   [ModifiedDate]              DATETIME2           NOT NULL                        CONSTRAINT [DF_Item_ModifiedDate] DEFAULT (SYSDATETIME())

,   CONSTRAINT [PK_ArtItem_ItemId] PRIMARY KEY CLUSTERED ([ItemId])
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_Item_Reference] ON [dbo].[Item] ([Reference])
GO

CREATE SPATIAL INDEX [SI_Item_Location] ON [dbo].[Item]([Location]) USING GEOGRAPHY_AUTO_GRID
GO

CREATE NONCLUSTERED INDEX [IX_Item_Published] ON [dbo].[Item]([Published]) WHERE [Published] = 1;
GO
