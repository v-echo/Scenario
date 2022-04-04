CREATE TABLE [dbo].[Results] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED ([Id] ASC)
);

