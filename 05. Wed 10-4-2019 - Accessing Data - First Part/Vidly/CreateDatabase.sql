USE [master]
GO

CREATE DATABASE [Vidly]
GO

USE [Vidly]
GO

CREATE TABLE [dbo].[Genres] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](255) NOT NULL,
    CONSTRAINT [PK_dbo.Genres] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Movies] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    [GenreId] [int] NOT NULL,
    [DateAdded] [datetime] NOT NULL,
    [ReleaseDate] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Movies] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_GenreId] ON [dbo].[Movies]([GenreId])
ALTER TABLE [dbo].[Movies] ADD CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id]) ON DELETE CASCADE
