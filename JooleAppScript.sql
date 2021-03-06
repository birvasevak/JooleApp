USE [JooleApp]
GO
/****** Object:  Table [dbo].[tblAttribute]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAttribute](
	[attributeID] [int] IDENTITY(0,1) NOT NULL,
	[attributeName] [varchar](50) NULL,
	[isTechSpec] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[attributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[categoryID] [int] IDENTITY(0,1) NOT NULL,
	[categoryName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[productID] [int] IDENTITY(0,1) NOT NULL,
	[subCategoryID] [int] NULL,
	[productName] [varchar](50) NULL,
	[imagePath] [varchar](50) NULL,
	[modelName] [varchar](50) NULL,
	[modelYear] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductAttribute]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductAttribute](
	[productID] [int] NULL,
	[attributeID] [int] NULL,
	[attributeValue] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubCategory]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubCategory](
	[subCategoryID] [int] IDENTITY(0,1) NOT NULL,
	[categoryID] [int] NULL,
	[categoryName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[subCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubCategoryAttribute]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubCategoryAttribute](
	[subCategoryID] [int] NULL,
	[attributeID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTechSpecFilter]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTechSpecFilter](
	[subCategoryID] [int] NULL,
	[attributeID] [int] NULL,
	[maxVal] [varchar](50) NULL,
	[minVal] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 10/14/2020 8:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[userID] [int] IDENTITY(0,1) NOT NULL,
	[userName] [varchar](50) NULL,
	[emailAddress] [varchar](50) NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[userAddress] [varchar](50) NULL,
	[phone] [varchar](10) NULL,
	[userImage] [varchar](100) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAttribute] ON 

INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (0, N'Display Size', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (1, N'Resoultion', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (2, N'Weight', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (3, N'Voltage', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (4, N'Wing Size', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (5, N'RPM', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (6, N'Number of fan speeds', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (7, N'Processor Count', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (8, N'RAM', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (9, N'Disk Space', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (10, N'Battery', 1)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (11, N'Application', 0)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (12, N'Mount', 0)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (13, N'Accessories', 0)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (14, N'Processor Name', 0)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (15, N'GPU Name', 0)
INSERT [dbo].[tblAttribute] ([attributeID], [attributeName], [isTechSpec]) VALUES (16, N'UseType', 0)
SET IDENTITY_INSERT [dbo].[tblAttribute] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([categoryID], [categoryName]) VALUES (0, N'Laptops')
INSERT [dbo].[tblCategory] ([categoryID], [categoryName]) VALUES (1, N'Mechanical')
INSERT [dbo].[tblCategory] ([categoryID], [categoryName]) VALUES (2, N'Monitors')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON 

INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (0, 1, N'Acer Nitro 5', NULL, N'AB3', N'2017')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (1, 1, N'Asus Zephyrus G14', NULL, N'AB4', N'2019')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (2, 2, N'Monte Carlo armstrong', NULL, N'AB5', N'2016')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (3, 2, N'Heisenberg Maverick', NULL, N'AB6', N'2018')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (4, 3, N'Samsumg Smart LCD', NULL, N'AB7', N'2017')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (5, 4, N'Samsung Smart LED', NULL, N'AB8', N'2020')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (6, 5, N'MacBook Air', NULL, N'AB1', N'2016')
INSERT [dbo].[tblProduct] ([productID], [subCategoryID], [productName], [imagePath], [modelName], [modelYear]) VALUES (7, 5, N'MacBook Pro', NULL, N'AB2', N'2018')
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
GO
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 0, N'13')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 1, N'1440')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 2, N'1')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 3, N'220')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 7, N'6')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 8, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 9, N'512')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 10, N'4050')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 11, N'Hand held')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (1, 12, N'Table')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 0, N'13')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 1, N'1440')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 2, N'0.6')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 3, N'220')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 7, N'4')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 8, N'4')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 9, N'256')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 10, N'3050')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 11, N'Hand held')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (0, 12, N'Table')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 0, N'15')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 1, N'1440')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 2, N'1.2')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 3, N'220')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 7, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 8, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 9, N'1000')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 10, N'5000')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 11, N'Moderate Gaming')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 12, N'Table')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (2, 15, N'GTX 1650')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 0, N'17')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 1, N'4096')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 2, N'1.1')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 3, N'220')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 7, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 8, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 9, N'1000')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 10, N'4000')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 11, N'Extreme Gaming')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 12, N'Table')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (3, 15, N'GTX 2080')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 2, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 3, N'21.4')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 4, N'32')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 5, N'3200')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 6, N'7')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 11, N'Indoor')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 12, N'Ceiling')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 13, N'Light')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (4, 16, N'Commercial')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 2, N'8')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 3, N'26.4')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 4, N'30')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 5, N'3600')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 6, N'5')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 11, N'Indoor')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 12, N'Ceiling')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 13, N'No Light')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (5, 16, N'Commercial')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 0, N'62')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 1, N'4096')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 2, N'4.5')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 13, N'Controller')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 16, N'Commercial')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 12, N'Indoor')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (6, 14, N'Smart')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 0, N'50')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 1, N'4096')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 2, N'4')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 13, N'Controller')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 16, N'Commercial')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 12, N'Indoor')
INSERT [dbo].[tblProductAttribute] ([productID], [attributeID], [attributeValue]) VALUES (7, 14, N'Smart')
GO
SET IDENTITY_INSERT [dbo].[tblSubCategory] ON 

INSERT [dbo].[tblSubCategory] ([subCategoryID], [categoryID], [categoryName]) VALUES (1, 0, N'Gaming')
INSERT [dbo].[tblSubCategory] ([subCategoryID], [categoryID], [categoryName]) VALUES (2, 1, N'Fans')
INSERT [dbo].[tblSubCategory] ([subCategoryID], [categoryID], [categoryName]) VALUES (3, 2, N'LCD')
INSERT [dbo].[tblSubCategory] ([subCategoryID], [categoryID], [categoryName]) VALUES (4, 2, N'LED')
INSERT [dbo].[tblSubCategory] ([subCategoryID], [categoryID], [categoryName]) VALUES (5, 0, N'MacBooks')
SET IDENTITY_INSERT [dbo].[tblSubCategory] OFF
GO
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 0)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 1)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 2)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 3)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 7)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 8)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 9)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 10)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 11)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 12)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (1, 15)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 0)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 1)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 2)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 3)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 7)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 8)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 9)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 10)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 11)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (5, 12)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 2)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 3)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 4)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 5)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 6)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 11)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 12)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 13)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (2, 16)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 0)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 1)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 2)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 13)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 16)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 12)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (3, 14)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 0)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 1)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 2)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 13)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 16)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 12)
INSERT [dbo].[tblSubCategoryAttribute] ([subCategoryID], [attributeID]) VALUES (4, 14)
GO
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 0, N'17', N'15')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 1, N'4096', N'1440')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 2, N'1.2', N'1.1')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 3, N'220', N'220')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 7, N'8', N'8')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 8, N'8', N'8')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 9, N'1000', N'1000')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (1, 10, N'5000', N'4000')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 0, N'13', N'13')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 1, N'1440', N'1440')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 2, N'1', N'0.6')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 3, N'220', N'220')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 7, N'6', N'4')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 8, N'8', N'4')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 9, N'512', N'256')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (5, 10, N'4050', N'3050')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (2, 2, N'8', N'8')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (2, 3, N'26.4', N'21.4')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (2, 4, N'32', N'30')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (2, 5, N'3600', N'3200')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (2, 6, N'7', N'5')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (3, 0, N'62', N'62')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (3, 1, N'4096', N'4096')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (3, 2, N'4.5', N'4.5')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (4, 0, N'50', N'50')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (4, 1, N'4096', N'4096')
INSERT [dbo].[tblTechSpecFilter] ([subCategoryID], [attributeID], [maxVal], [minVal]) VALUES (4, 2, N'4', N'4')
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([userID], [userName], [emailAddress], [firstName], [lastName], [userAddress], [phone], [userImage], [password]) VALUES (0, N'admin', N'123@gmail.com', N'John', N'Doe', NULL, N'6466466646', NULL, N'1001')
INSERT [dbo].[tblUser] ([userID], [userName], [emailAddress], [firstName], [lastName], [userAddress], [phone], [userImage], [password]) VALUES (1, N'rose', N'rose@gmail.com', NULL, NULL, NULL, NULL, N'IMG_6026.JPG', N'rose')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD FOREIGN KEY([subCategoryID])
REFERENCES [dbo].[tblSubCategory] ([subCategoryID])
GO
ALTER TABLE [dbo].[tblProductAttribute]  WITH CHECK ADD FOREIGN KEY([attributeID])
REFERENCES [dbo].[tblAttribute] ([attributeID])
GO
ALTER TABLE [dbo].[tblProductAttribute]  WITH CHECK ADD FOREIGN KEY([productID])
REFERENCES [dbo].[tblProduct] ([productID])
GO
ALTER TABLE [dbo].[tblSubCategory]  WITH CHECK ADD FOREIGN KEY([categoryID])
REFERENCES [dbo].[tblCategory] ([categoryID])
GO
ALTER TABLE [dbo].[tblSubCategoryAttribute]  WITH CHECK ADD FOREIGN KEY([attributeID])
REFERENCES [dbo].[tblAttribute] ([attributeID])
GO
ALTER TABLE [dbo].[tblSubCategoryAttribute]  WITH CHECK ADD FOREIGN KEY([subCategoryID])
REFERENCES [dbo].[tblSubCategory] ([subCategoryID])
GO
ALTER TABLE [dbo].[tblTechSpecFilter]  WITH CHECK ADD FOREIGN KEY([attributeID])
REFERENCES [dbo].[tblAttribute] ([attributeID])
GO
ALTER TABLE [dbo].[tblTechSpecFilter]  WITH CHECK ADD FOREIGN KEY([subCategoryID])
REFERENCES [dbo].[tblSubCategory] ([subCategoryID])
GO
