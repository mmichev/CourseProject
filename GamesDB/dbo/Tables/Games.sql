CREATE TABLE [dbo].[Games] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (200) NOT NULL,
    [DateOfPublishing] DATE           NOT NULL,
    [Category]         INT            NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Games_Categories] FOREIGN KEY ([Category]) REFERENCES [dbo].[Categories] ([ID]) ON DELETE CASCADE
);

