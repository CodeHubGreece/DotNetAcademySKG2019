USE [master]
GO

CREATE DATABASE [Vidly]
GO

USE [Vidly]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 7/4/2019 5:02:18 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsSubscribedToNewsletter] [bit] NOT NULL,
	[MembershipTypeId] [int] NOT NULL,
	[Birthdate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 7/4/2019 5:02:19 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipTypes]    Script Date: 7/4/2019 5:02:19 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SignUpFee] [smallint] NOT NULL,
	[DurationInMonths] [tinyint] NOT NULL,
	[DiscountRate] [tinyint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.MembershipTypes] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 7/4/2019 5:02:19 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[GenreId] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[NumberInStock] [tinyint] NOT NULL,
	[NumberAvailable] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 7/4/2019 5:02:19 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateRented] [datetime] NOT NULL,
	[DateReturned] [datetime] NULL,
	[Customer_Id] [int] NOT NULL,
	[Movie_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Rentals] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [IsSubscribedToNewsletter]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [MembershipTypeId]
GO
ALTER TABLE [dbo].[MembershipTypes] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Movies] ADD  DEFAULT ((0)) FOR [NumberAvailable]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Customers_dbo.MembershipTypes_MembershipTypeId] FOREIGN KEY([MembershipTypeId])
REFERENCES [dbo].[MembershipTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_dbo.Customers_dbo.MembershipTypes_MembershipTypeId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rentals_dbo.Customers_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_dbo.Rentals_dbo.Customers_Customer_Id]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rentals_dbo.Movies_Movie_Id] FOREIGN KEY([Movie_Id])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_dbo.Rentals_dbo.Movies_Movie_Id]
GO
