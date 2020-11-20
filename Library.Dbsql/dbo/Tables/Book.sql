CREATE TABLE [dbo].[Book] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [AuthorId]    INT             NOT NULL,
    [Title]       NVARCHAR (200)  NULL,
    [Isbn]        NVARCHAR (200)  NULL,
    [Synopsis]    NVARCHAR (200)  NULL,
    [Description] NVARCHAR (2000) NULL,
    [ImageUrl]    NVARCHAR (200)  NULL,
    [Enable]      BIT             CONSTRAINT [DF_Book_Enable] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Author] ([Id]) ON DELETE CASCADE
);

