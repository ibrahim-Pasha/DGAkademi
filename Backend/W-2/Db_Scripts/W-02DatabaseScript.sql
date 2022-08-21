USE [W-02]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](500) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](500) NULL,
	[Address] [varchar](500) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[SurName] [varchar](500) NULL,
	[salary] [money] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [date] NULL,
	[ShipName] [varchar](500) NULL,
	[ShipAddress] [varchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](500) NULL,
	[CategoryId] [int] NULL,
	[UnitPrice] [money] NULL,
 CONSTRAINT [PK_Productts] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.08.2022 18:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[SurName] [varchar](500) NULL,
	[UserName] [varchar](500) NULL,
	[Password] [varchar](500) NULL,
	[Role] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Drinks')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'samiri')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'drinckes')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Address], [PhoneNumber], [UserId]) VALUES (1, N'Ahmet baki', N'Adana', N'554897822', 2026)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [Name], [SurName], [salary], [UserId]) VALUES (3, N'mehmet', N'han', 5000.0000, 2027)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Name], [SurName], [salary], [UserId]) VALUES (8, N'sema', N'yilmaz', 20000.0000, 2023)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [OrderDate], [ShipName], [ShipAddress]) VALUES (1, 1, CAST(N'2022-07-21' AS Date), N'CupCake', N'sadsad')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [UnitPrice]) VALUES (1, N'Apllejuse', 2, 80.0000)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [UnitPrice]) VALUES (2, N'orangeJuse', 2, 30.0000)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (2, N'Customer')
GO
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (1, N'Employee')
GO
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (4, N'Ik')
GO
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (3, N'Manager')
GO
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (5, N'Purchasing_Department')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2022, N'Ibrahim', N'Issa Basha', N'ib12', N'123', N'Manager')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2023, N'Ahmet', N'tas', N'ah1', N'321', N'Employee')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2024, N'dugu', N'günes', N'dg1', N'ps1', N'Ik')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2025, N'Beyza', N'Aksoy', N'ba1', N'a12', N'Purchasing_Department')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2026, N'samet', N'azikçi', N'sa1', N'sa123', N'Customer')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2027, N'mehmet', N'han', N'memo1', N'hanu112', N'Employee')
GO
INSERT [dbo].[Users] ([UserId], [Name], [SurName], [UserName], [Password], [Role]) VALUES (2028, N'serhat', N'can', N'sero', N'258', N'Customer')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Role]  DEFAULT ('Customer') FOR [Role]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Productts_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Productts_Categories]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Role])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
