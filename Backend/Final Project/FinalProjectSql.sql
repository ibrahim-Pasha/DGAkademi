USE [FinalProject]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 27.08.2022 22:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Duration] [float] NULL,
	[Type] [varchar](50) NULL,
	[Producer] [varchar](100) NULL,
	[Description] [varchar](500) NULL,
	[Popular] [bit] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 27.08.2022 22:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Duration] [float] NULL,
	[Type] [varchar](50) NULL,
	[Producer] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Pisodes] [int] NULL,
	[Popular] [bit] NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.08.2022 22:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[SurName] [varchar](200) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Name], [Duration], [Type], [Producer], [Description], [Popular]) VALUES (1002, N'Hulk', 2, N'action', N'bella', N'strsdgvfsfasddssfdaing', 1)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Series] ON 
GO
INSERT [dbo].[Series] ([Id], [Name], [Duration], [Type], [Producer], [Description], [Pisodes], [Popular]) VALUES (1, N'aa', 2, N'action', N'victor', N'asdsdfsdvfv', 2, 1)
GO
INSERT [dbo].[Series] ([Id], [Name], [Duration], [Type], [Producer], [Description], [Pisodes], [Popular]) VALUES (1003, N'frends', 1, N'comede', N'tony', N'comede series', 60, 0)
GO
SET IDENTITY_INSERT [dbo].[Series] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [SurName], [UserName], [Password], [Role]) VALUES (1, N'Ibrahim', N'Pasha', N'ibrahim11', N'sifrem111', N'Manager')
GO
INSERT [dbo].[Users] ([Id], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2, N'Ahmet', N'Yildiz', N'ah11', N'ikinci22', N'Gust')
GO
INSERT [dbo].[Users] ([Id], [Name], [SurName], [UserName], [Password], [Role]) VALUES (4, N'sude', N'mutlu', N'sude1', N'yaya1122', NULL)
GO
INSERT [dbo].[Users] ([Id], [Name], [SurName], [UserName], [Password], [Role]) VALUES (5, N'sude', N'mutlu', N'sasu11', N'sasu1234', N'Gust')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Role]  DEFAULT ('Gust') FOR [Role]
GO
