USE [master]
GO
/****** Object:  Database [CitizensDB]    Script Date: 8/24/2014 10:35:54 AM ******/
CREATE DATABASE [CitizensDB]
GO

USE [CitizensDB]
GO
/****** Object:  Table [dbo].[ADDRESS]    Script Date: 8/24/2014 10:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRESS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](100) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTINENT]    Script Date: 8/24/2014 10:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTINENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CONTINENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 8/24/2014 10:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 8/24/2014 10:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWN]    Script Date: 8/24/2014 10:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_TOWN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADDRESS] ON 

INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (1, N'bul. Madrid', 1)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (2, N'kv Levski', 2)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (3, N'Mountin Drive', 5)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (5, N'Main Bulevard', 6)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (6, N'One Strasse', 3)
SET IDENTITY_INSERT [dbo].[ADDRESS] OFF
SET IDENTITY_INSERT [dbo].[CONTINENT] ON 

INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (2, N'Asia')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (3, N'North America')
SET IDENTITY_INSERT [dbo].[CONTINENT] OFF
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 

INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (2, N'Germany', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (3, N'China', 2)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (4, N'United States', 3)
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
SET IDENTITY_INSERT [dbo].[PERSON] ON 

INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Svetlin', N'Nakov', 1)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Niki', N'Kostov', 2)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Johnny', N'Depp', 3)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (5, N'Jackie', N'Chan', 5)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (6, N'Miroslav', N'Klose', 6)
SET IDENTITY_INSERT [dbo].[PERSON] OFF
SET IDENTITY_INSERT [dbo].[TOWN] ON 

INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (2, N'Varna', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (3, N'Berlin', 2)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (4, N'Tokyo', 3)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (5, N'San Francisco', 4)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (6, N'Hong Kong', 3)
SET IDENTITY_INSERT [dbo].[TOWN] OFF
ALTER TABLE [dbo].[ADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESS_TOWN] FOREIGN KEY([town_id])
REFERENCES [dbo].[TOWN] ([id])
GO
ALTER TABLE [dbo].[ADDRESS] CHECK CONSTRAINT [FK_ADDRESS_TOWN]
GO
ALTER TABLE [dbo].[COUNTRY]  WITH CHECK ADD  CONSTRAINT [FK_COUNTRY_CONTINENT] FOREIGN KEY([continent_id])
REFERENCES [dbo].[CONTINENT] ([id])
GO
ALTER TABLE [dbo].[COUNTRY] CHECK CONSTRAINT [FK_COUNTRY_CONTINENT]
GO
ALTER TABLE [dbo].[PERSON]  WITH CHECK ADD  CONSTRAINT [FK_PERSON_ADDRESS] FOREIGN KEY([address_id])
REFERENCES [dbo].[ADDRESS] ([id])
GO
ALTER TABLE [dbo].[PERSON] CHECK CONSTRAINT [FK_PERSON_ADDRESS]
GO
ALTER TABLE [dbo].[TOWN]  WITH CHECK ADD  CONSTRAINT [FK_TOWN_COUNTRY] FOREIGN KEY([country_id])
REFERENCES [dbo].[COUNTRY] ([id])
GO
ALTER TABLE [dbo].[TOWN] CHECK CONSTRAINT [FK_TOWN_COUNTRY]
GO
USE [master]
GO
ALTER DATABASE [CitizensDB] SET  READ_WRITE 
GO
