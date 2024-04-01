DROP DATABASE [TitanWeb]
GO

CREATE DATABASE [TitanWeb]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TitanWeb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TitanWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TitanWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TitanWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TitanWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TitanWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TitanWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TitanWeb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TitanWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TitanWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TitanWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TitanWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TitanWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TitanWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TitanWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TitanWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TitanWeb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TitanWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TitanWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TitanWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TitanWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TitanWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TitanWeb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TitanWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TitanWeb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TitanWeb] SET  MULTI_USER 
GO
ALTER DATABASE [TitanWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TitanWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TitanWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TitanWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TitanWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TitanWeb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TitanWeb] SET QUERY_STORE = OFF
GO
USE [TitanWeb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buttons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Buttons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UrlSlug] [nvarchar](max) NOT NULL,
	[Locale] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryItem](
	[CategoriesId] [int] NOT NULL,
	[ItemsId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryItem] PRIMARY KEY CLUSTERED 
(
	[CategoriesId] ASC,
	[ItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[Hyperlink] [nvarchar](max) NULL,
	[IsLogo] [bit] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoldTitle] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NOT NULL,
	[UrlSlug] [nvarchar](max) NOT NULL,
	[SubTitle] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[TelNumber] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[ImageId] [int] NULL,
	[SectionId] [int] NULL,
	[ButtonId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSection](
	[ItemsId] [int] NOT NULL,
	[SectionsId] [int] NOT NULL,
 CONSTRAINT [PK_ItemSection] PRIMARY KEY CLUSTERED 
(
	[ItemsId] ASC,
	[SectionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSubItem](
	[ItemsId] [int] NOT NULL,
	[SubItemsId] [int] NOT NULL,
 CONSTRAINT [PK_ItemSubItem] PRIMARY KEY CLUSTERED 
(
	[ItemsId] ASC,
	[SubItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_RequestForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[UrlSlug] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageId] [int] NULL,
	[Locale] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextItem] [nvarchar](max) NOT NULL,
	[ImageId] [int] NULL,
 CONSTRAINT [PK_SubItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buttons] ON 

INSERT [dbo].[Buttons] ([Id], [Label], [Status]) VALUES (1, N'JOIN US', 1)
INSERT [dbo].[Buttons] ([Id], [Label], [Status]) VALUES (2, N'参加しませんか', 1)
INSERT [dbo].[Buttons] ([Id], [Label], [Status]) VALUES (3, N'REQUEST NOW', 1)
INSERT [dbo].[Buttons] ([Id], [Label], [Status]) VALUES (4, N'今すぐリクエスト', 1)
SET IDENTITY_INSERT [dbo].[Buttons] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (1, N'Logo', N'logo', N'en')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (2, N'Banner', N'banner', N'en')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (3, N'Banner', N'banner-ja', N'ja')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (4, N'Request', N'request', N'en')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (5, N'Request', N'request-ja', N'ja')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (6, N'Footer', N'footer', N'en')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug], [Locale]) VALUES (7, N'Footer', N'footer-ja', N'ja')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (1, 1)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (2, 2)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (2, 4)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (2, 6)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (2, 8)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (3, 3)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (3, 5)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (3, 7)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (3, 9)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (4, 95)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (5, 96)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 97)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 99)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 100)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 101)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 102)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 104)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 106)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (6, 108)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 98)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 99)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 100)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 101)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 103)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 105)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 107)
INSERT [dbo].[CategoryItem] ([CategoriesId], [ItemsId]) VALUES (7, 109)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (1, N'https://titancorpvn.com/assets/images/logo-white.png', N'https://titancorpvn.com/', 1)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (2, N'https://titancorpvn.com/uploads/banners/home-banner-1.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (3, N'https://titancorpvn.com/uploads/banners/home-banner-2.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (4, N'https://titancorpvn.com/uploads/banners/home-banner-3.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (5, N'https://titancorpvn.com/uploads/banners/home-banner-4.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (6, N'https://i.ibb.co/nwDRcXZ/software-development.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (7, N'https://i.ibb.co/d2ZVFP3/maintenance-and-support.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (8, N'https://i.ibb.co/b2dD2SW/software-testing.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (9, N'https://titancorpvn.com/assets/images/icons/domains/ai.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (10, N'https://titancorpvn.com/assets/images/icons/domains/blockchain.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (11, N'https://titancorpvn.com/assets/images/icons/domains/cloud.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (12, N'https://titancorpvn.com/assets/images/icons/domains/crm.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (13, N'https://titancorpvn.com/assets/images/icons/domains/desktop.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (14, N'https://titancorpvn.com/assets/images/icons/domains/mobile.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (15, N'https://titancorpvn.com/assets/images/icons/domains/network.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (16, N'https://titancorpvn.com/assets/images/icons/domains/testing.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (17, N'https://titancorpvn.com/assets/images/icons/domains/web.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (18, N'https://titancorpvn.com/assets/images/innovation.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (19, N'https://titancorpvn.com/assets/images/icons/models/teams.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (20, N'https://titancorpvn.com/assets/images/icons/models/cost.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (21, N'https://titancorpvn.com/assets/images/icons/models/time.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (22, N'https://titancorpvn.com/assets/images/paralax-domains.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (23, N'https://titancorpvn.com/assets/images/our-clients.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (24, N'https://titancorpvn.com/uploads/documents/clients/http___auvenir_com_.jpeg', N'https://auvenir.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (25, N'https://titancorpvn.com/uploads/documents/clients/http___empiregroup_vn_.jpeg', N'https://empiregroup.vn/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (26, N'https://titancorpvn.com/uploads/documents/clients/http___mindgeek_com_.jpeg', N'https://www.aylo.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (27, N'https://titancorpvn.com/uploads/documents/clients/http___superhippo_com_.jpeg', N'https://www.superhippo.com', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (28, N'https://titancorpvn.com/uploads/documents/clients/http___www_collectiveclarity_net_.jpeg', N'https://www.azaries.ai/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (29, N'https://titancorpvn.com/uploads/documents/clients/http___www_digitalperformance_de_.jpeg', N'https://www.digitalperformance.de/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (30, N'https://titancorpvn.com/uploads/documents/clients/http___www_ecopharma_com_vn_.jpeg', N'https://ecopharma.com.vn/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (31, N'https://titancorpvn.com/uploads/documents/clients/http___www_greenpacket_com_.jpeg', N'https://www.greenpacket.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (32, N'https://titancorpvn.com/uploads/documents/clients/http___www_ktcc_co_jp_.jpeg', N'https://www.ktcc.co.jp/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (33, N'https://titancorpvn.com/uploads/documents/clients/http___www_saigonx_com_.jpeg', N'https://saigonx.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (34, N'https://titancorpvn.com/uploads/documents/clients/http___www_sssmine_com_.jpeg', N'https://www.sssmine.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (35, N'https://titancorpvn.com/uploads/documents/clients/http___www_techwisenetworks_com_.jpeg', N'https://www.techwisenetworks.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (36, N'https://titancorpvn.com/uploads/documents/clients/http___www_televz_com_.jpeg', N'http://www.televz.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (37, N'https://titancorpvn.com/uploads/documents/clients/http___www_tpf_com_au_.jpeg', N'https://www.tpf.com.au/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (38, N'https://titancorpvn.com/uploads/documents/clients/https___frogasia_com_.jpeg', N'https://www.frogasia.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (39, N'https://titancorpvn.com/uploads/documents/clients/https___tvt_biz_.jpeg', N'https://tvt.biz/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (40, N'https://titancorpvn.com/uploads/documents/clients/https___www_bgx_ai_.jpeg', N'https://www.bgx.ai/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (41, N'https://titancorpvn.com/uploads/documents/clients/https___www_etnasoft_com_.jpeg', N'https://www.etnasoft.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (42, N'https://titancorpvn.com/uploads/documents/clients/https___www_ewerk_com_.jpeg', N'https://www.ewerk.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (43, N'https://titancorpvn.com/uploads/documents/clients/https___www_greencopper_com_.jpeg', N'https://leapevent.tech/solutions/attendee-engagement/mobile-apps/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (44, N'https://titancorpvn.com/uploads/documents/clients/https___www_mobileiron_com_.jpeg', N'https://www.ivanti.com/company/history/mobileiron?miredirect', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (45, N'https://titancorpvn.com/uploads/documents/clients/https___www_ssense_com_.jpeg', N'https://www.ssense.com/fr-vn', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (46, N'https://titancorpvn.com/uploads/documents/clients/https___www_trafficpartner_com_.jpeg', N'https://www.trafficpartner.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (47, N'https://titancorpvn.com/uploads/documents/clients/https___www_wedgenetworks_com_.jpeg', N'https://www.wedgenetworks.com/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (48, N'https://titancorpvn.com/uploads/documents/testimonials/CEO.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (49, N'https://titancorpvn.com/uploads/documents/testimonials/CEO_&_CTO_(co-founder).png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (50, N'https://titancorpvn.com/uploads/documents/testimonials/Chief_Technical_Officer.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (51, N'https://titancorpvn.com/uploads/documents/testimonials/Director_of_Application_Development.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (52, N'https://titancorpvn.com/uploads/documents/testimonials/Project_Manager.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (53, N'https://titancorpvn.com/uploads/documents/testimonials/VP_of_Technology.png', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (54, N'https://titancorpvn.com/uploads/documents/recognized/Award_01.png', N'https://www.goodfirms.co/company/titan-technology-corporation', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (55, N'https://titancorpvn.com/uploads/documents/recognized/Award_02.png', N'https://vjc.org.vn/japanictday/vi/homepagevn/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (56, N'https://titancorpvn.com/uploads/documents/recognized/Award_03.png', N'https://vinasa.org.vn/Default.aspx?sname=vinasa&sid=4&pageid=3074&catid=4199&catname=gioi-thieu', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (57, N'https://titancorpvn.com/uploads/documents/recognized/Award_04.png', N'http://vnito2015.vnito.org/award/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (58, N'https://titancorpvn.com/uploads/documents/recognized/Award_05.png', N'http://www.phunhuan.hochiminhcity.gov.vn/Pages/default.aspx', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (59, N'https://titancorpvn.com/uploads/documents/recognized/Award_06.png', N'https://hca.org.vn/post/13266', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (60, N'https://titancorpvn.com/uploads/documents/recognized/Award_07.png', N'https://www.jetro.go.jp/en/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (61, N'https://titancorpvn.com/uploads/documents/recognized/Award_08.png', N'https://www.certipedia.com/quality_marks/9000008850?locale=en', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (62, N'https://titancorpvn.com/uploads/documents/recognized/Award_09.png', N'https://softwareoutsourcing.com/vietnam/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (63, N'https://titancorpvn.com/assets/images/hiring.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (64, N'https://i.pinimg.com/736x/ff/97/0e/ff970e6a860db82a4c5506364f87c583.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (65, N'https://i.pinimg.com/736x/fd/e7/22/fde722e17f3094da28df7b2b851d1882.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (66, N'https://i.pinimg.com/736x/1f/6d/06/1f6d06d3e3d34e1e60d4885140ce5b1b.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (67, N'https://i.pinimg.com/736x/29/b7/51/29b751f95339ec3a1893aaa209ec42fe.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (68, N'https://i.pinimg.com/736x/fb/9b/14/fb9b148d33b762847f0278c09684824d.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (69, N'https://i.pinimg.com/736x/9c/cc/eb/9ccceb84208636d016aafce125cb4428.jpg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (70, N'https://www.titancorpvn.com/assets/icons/Mail-solid.svg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (71, N'https://www.titancorpvn.com/assets/icons/Skype.svg', NULL, 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (72, N'https://www.titancorpvn.com/assets/icons/FB.svg', N'https://www.facebook.com/Titan-Technology-Corporation-367359790030585/', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (73, N'https://www.titancorpvn.com/assets/icons/Twitter.svg', N'https://twitter.com/titancorpvn', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (74, N'https://www.titancorpvn.com/assets/icons/Linkdin.svg', N'https://www.linkedin.com/company/titan-technology-corporation', 0)
INSERT [dbo].[Images] ([Id], [ImageUrl], [Hyperlink], [IsLogo]) VALUES (75, N'https://www.titancorpvn.com/assets/icons/Youtube.svg', N'https://www.youtube.com/channel/UCU8y74v5CvedVo4bNGhkQnA', 0)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (1, N'Logo', N'logo', NULL, NULL, 1)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (2, N'INSPIRE', N' YOUR WORK', N'banner-1', NULL, N'Founded on trust and experience, by a professional team, with a big vision and mission to provide the best services to our clients.', 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (3, NULL, N'貴方にとって刺激的な仕事', N'banner-1-ja', NULL, N'弊社のビジョンに基づきお客様へ最高のサービスを、信頼と経験に基づいた当社のプロフェッショナルチームが提供致します。', 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (4, N'COMPREHENSIVE', N' INNOVATIONS', N'banner-2', NULL, N'A dedicated and professional team that offers a wide range of advanced solution for offshore software testing and comprehensive development services.', 3)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (5, NULL, N'総合的な改革', N'banner-2-ja', NULL, N'幅広い高度なソリューションを提供する、オフショア・ソフトウェア・テストと包括的な開発サービス専門チーム。', 3)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (6, N'ADVANCED SOLUTION', N' FOR INNOVATIONS', N'banner-3', NULL, N'Always hunger for new idea creation, we incubate good ideas by providing facilities for product development and environment where creativity leverages our skills and services.', 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (7, NULL, N'イノベーションのための高度なソリューション', N'banner-3-ja', NULL, N'弊社は常に新しいアイデアの創造に貪欲です。スキルとサービスを活用して製品開発と環境のための設備を提供することによって、より良いアイデアを育てます。', 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (8, N'"INSPIRE"', N' WORKING ENVIRONMENT', N'banner-4', NULL, N'Our friendly, challenging, and collaborative environment creates enjoy valuable benefits and sharing ownership.', 5)
INSERT [dbo].[Items] ([Id], [BoldTitle], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (9, NULL, N'“刺激的”な働く環境', N'banner-4-ja', NULL, N'フレンドリーでチャレンジを融合するやりがいのある環境は、価値あるメリットや所有権の共有を作り出します', 5)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (10, N'SOFTWARE DEVELOPMENT', N'software-development', NULL, N'Develop software applications from business ideas to deployment, develop based on product definition, the initial designs, or develop modules with multiple teams for concurrent development thus reducing time to market.', 6)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (11, N'ソフトウェア開発', N'software-development-ja', NULL, N'ビジネスのアイデアから展開にいたるソフトウェアアプリを開発し、製品の定義やモジュール開発は、初期設計に基づいて開発し、同時開発のために複数のチームで行い、製品化までの時間を短縮します', 6)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (12, N'MAINTENANCE AND SUPPORT', N'maintenance-and-support', NULL, N'Maintain, enhance, and develop new features of existing software applications. We also provide services to migrate from the legacy systems to new technologies to help improve performance and add benefits to the client''s businesses.', 7)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (13, N'メンテナンス＆サポート', N'maintenance-and-support-ja', NULL, N'既存のソフトウェアアプリケーションの新機能を維持、強化、開発します。 パフォーマンスを向上させ、クライアントのビジネスに利益をもたらすサービスを提供する為に、レガシーシステムから新しいテクノロジーに移行します。', 7)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (14, N'SOFTWARE TESTING', N'software-testing', NULL, N'Provide all kind of testing services including automation tool development, enhancement and execution to assure the quality of our client’s products.', 8)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (15, N'ソフトウェアテス', N'software-testing-ja', NULL, N'自動化ツールの開発、強化、実行など、あらゆる種類のテストサービスを提供して、お客様の製品の品質を保証します。', 8)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (16, N'MOBILE DEVELOPMENT', N'mobile-development', NULL, N'We have expertise in building mobile applications and mobile games on multiple platforms', 14)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (17, N'MOBILE アプリ開発', N'mobile-development-ja', NULL, N'弊社は複数のプラットフォーム上で、モバイルアプリケーションとモバイルゲームを構築する専門知識を持っています', 14)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (18, N'WEB APP DEVELOPMENT', N'web-app-development', NULL, N'Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line', 17)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (19, N'Web アプリ開発', N'web-app-development-ja', NULL, N'弊社のチームは、インサイトUX / UIを使用してWebアプリケーションを構築する方法を熟知しています。', 17)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (20, N'DESKTOP DEVELOPMENT', N'desktop-development', NULL, N'We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models', 13)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (21, N'DESKTOP アプリ開発', N'desktop-development-ja', NULL, N'弊社はクロスプラットフォーアプリケーションの安定性を拡大し、アーキテクトやビジネスモデルに簡単に変換できるプログラムを開発します。', 13)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (22, N'CLOUD BASED DEVELOPMENT', N'cloud-based-development', NULL, N'We have extensive experience in implementation of specific PaaS and SaaS solutions', 11)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (23, N'CLOUD BASED アプリ開発', N'cloud-based-development-ja', NULL, N'当社は、PaaSとSaaSソリューションにおける豊富な導入経験を持っています', 11)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (24, N'TELECOM & NETWORKING', N'telecom-and-networking', NULL, N'Our team has strong experience in telecom and network systems that enable us to provide both testing and development services', 15)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (25, N'通信＆ネットワーク', N'telecom-and-networking-ja', NULL, N'弊社のチームは、テレコムおよびネットワークシステムで、テストおよび開発の両方を提供可能にする豊富な経験を持っています。', 15)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (26, N'TESTING & QUALITY ASSURANCE', N'testing-and-quality-assurance', NULL, N'We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models', 16)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (27, N'テストティング＆品質保証', N'testing-and-quality-assurance-ja', NULL, N'弊社は、さまざまなドメインおよび品質保証サービスを提供するために、プロジェクトをテストするための明確なプロセスを持って。', 16)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (28, N'BLOCKCHAIN DEVELOPMENT', N'blockchain-development', NULL, N'We have experiences in setting up, configuring, and developing applications based on Block chain technologies: Ethereum, De-centralized, Smart Contract, Cryptocurrency', 10)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (29, N'ブロックチェーン開発', N'blockchain-development-ja', NULL, N'弊社は、ブロックチェーン技術に基づいたアプリケーションのセットアップ、構成、および開発経験を持っています。', 10)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (30, N'ARTIFICIAL INTELLIGENCE', N'artificial-intelligence', NULL, N'We have extensive experiences in implementation of specific solutions with AI inside: Core Machine Learning Algorithms, Unsupervised Learning, Data Preparation...', 9)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (31, N'人工知能（AI）', N'artificial-intelligence-ja', NULL, N'弊社は人工知能を使用した特定のソリューション、コア機械のアルゴリズム学習、教師なし学習、データ準備での実装に幅広い経験を持', 9)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (32, N'ERP/CRM IMPLEMENTATION', N'erpcrm-implementation', NULL, N'Experienced team to consult and implement ERP and CRM solutions based on Microsoft and Open Source technologies (Dynamics AX/365/NAV, OpenERP(Odoo), SugarCRM, vTiger, and so on) with following services', 12)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (33, N'ERP/CRM の導入', N'erpcrm-implementation-ja', NULL, N'経験豊富なチームが、Microsoftおよびオープンソーステクノロジに基づいたERPおよびCRMソリューションをコン', 12)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (34, N'Innovations', N'innovations', NULL, N'We always hunger for new idea creation by providing facilities for product development and an environment where creativity leverages our skills and services.', 18)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (35, N'イノベーション', N'innovations-ja', NULL, N'弊社は常に新しいアイデアの創造を求めて、貪欲に製品開発のための設備、創造性、スキルとサービスを活用する環境をご提供します。', 18)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (36, N'DEDICATED TEAM', N'dedicated-team', NULL, N'<li>Dedicated professional team work for your projects.</li><li>Virtual extension of your engineering team.</li><li>Flexible task assignments based on your needs.</li><li>Stable and scalable resources.</li><li>Budget is measured in man-months.</li><li>The separate team of professionals will work over your project.</li>', 19)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (37, N'専任チーム', N'dedicated-team-ja', NULL, N'<li>専任プロチームがお客様のプロジェクトに取り組みます。</li><li>お客様のエンジニアリングチームの仮想拡張。</li><li>お客様のニーズに合わせて柔軟な作業割り当て。</li><li>安定したリソースの拡張。</li><li>予算は人月単位で計算します</li><li>個別のプロチームがお客様のプロジェクトに取組ます。</li>', 19)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (38, N'FIXED COST', N'fixed-cost', NULL, N'<li>Task assignments are defined clearly at the requirements.</li><li>Project schedule is planned clearly.</li><li>Budget is fixed based on requirements.</li><li>Fixed project budget (measured in man hours) and time limits.</li>', 20)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (39, N'固定コスト', N'fixed-cost-ja', NULL, N'<li>タスクの割り当ては、お客様の要件に合わせて明確に定義されています。</li><li>プロジェクトのスケジュールが明確に計画されています。</li><li>予算は、お客様の要件に応じて計算されます。</li><li>固定されたプロジェクト予算（人数で計算）及び納品締切日</li>', 20)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (40, N'TIME & MATERIAL', N'time-and-material', NULL, N'<li>Flexible task assignments based on your needs within time limits.</li><li>Adjustable and designated resources.</li><li>Budget is flexible and can be adjusted based on your requirements.</li><li>Stable and scalable resources.</li><li>Budget is measured in man-months.</li><li>Project budget is flexible and can be adjusted according to your requirements.</li>', 21)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (41, N'時間と資源', N'time-and-material-ja', NULL, N'<li>納品日内でのお客様のニーズに応じた柔軟なタスク割り当て。</li><li>調整可能で指定されたリソース。</li><li>予算は柔軟性で、お客様の要件に合わせて調整することができます。</li><li>安定した拡張リソース。</li><li>予算は人月単位で計算します</li><li>プロジェクト予算は柔軟で、お客様の要件に応じて調整可能。</li>', 21)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (42, N'Deloitte', N'deloitte', NULL, NULL, 24)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (43, N'MobileIron', N'mobile-iron', NULL, NULL, 44)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (44, N'MindGeek', N'mind-geek', NULL, NULL, 26)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (45, N'TechWise Networks', N'techwise-networks', NULL, NULL, 35)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (46, N'Televz', N'televz', NULL, NULL, 36)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (47, N'SAIGONX', N'saigonx', NULL, NULL, 33)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (48, N'Greenpacket', N'greenpacket', NULL, NULL, 31)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (49, N'SSENSE', N'ssense', NULL, NULL, 45)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (50, N'GreenCopper', N'green-copper', NULL, NULL, 43)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (51, N'BGX', N'bgx', NULL, NULL, 40)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (52, N'Wedge Networks', N'wedge-networks', NULL, NULL, 47)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (53, N'Digital Performance', N'digital-performance', NULL, NULL, 29)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (54, N'Collective Clarity', N'collective-clarity', NULL, NULL, 28)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (55, N'Superhippo', N'superhippo', NULL, NULL, 27)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (56, N'ETNA Software', N'etna-software', NULL, NULL, 41)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (57, N'Traffic Partner', N'traffic-partner', NULL, NULL, 46)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (58, N'Ewerk', N'ewerk', NULL, NULL, 42)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (59, N'KTC', N'ktc', NULL, NULL, 32)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (60, N'Frogasia', N'frogasia', NULL, NULL, 38)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (61, N'TPF', N'tpf', NULL, NULL, 37)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (62, N'TVT', N'tvt', NULL, NULL, 39)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (63, N'sssmine', N'sssmine', NULL, NULL, 34)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (64, N'Ecopharma', N'ecopharma', NULL, NULL, 30)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (65, N'Empiregroup', N'empiregroup', NULL, NULL, 25)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (66, N'DR. TIM PARKER', N'dr-tim-parker', N'Chief Technical Officer', N'“We have worked with Titan Technology for the last three years on a complex and evolving software product. We are delighted with the quality of the deliverables, the enthusiasm of the team, and the dedication to our project. We look forward to continuing this excellent relationship in the years to come, and I strongly recommend Titan Technology as a software outsourcing provider.”', 50)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (67, N'DR. TIM PARKER', N'dr-tim-parker-ja', N'最高技術責任者', N'“「私たちは過去3年間、複雑で進化し続けるソフトウェア製品についてTitan Technologyと協力してきました。 成果物の品質、チームの熱意、そしてプロジェクトへの献身に満足しています。 今後もこの素晴らしい関係を継続できることを楽しみにしており、ソフトウェアアウトソーシングプロバイダーとしてTitan Technologyを強くお勧めします。」”', 50)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (68, N'THOMAS SANTONJA', N'thomas-santonja', N'Director of Application Development', N'“A professional and dedicated team with a spirit of delivery. Successfully worked along us for delivery of years of features.”', 51)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (69, N'THOMAS SANTONJA', N'thomas-santonja-ja', N'アプリケーション開発役員', N'“デリバリー精神のあるプロフェッショナルで献身的なチーム。長年の機能を提供するために私たちと一緒に成功しました”', 51)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (70, N'VALERY KHVATOV', N'valery-khvatov', N'VP of Technology', N'“The work of Titan Technology is distinguished by high professionalism and initiative. It is a wonderful combination for a tech company. Our project consisted of building a mobile app for a blockchain platform. The team asked many right questions throughout the development process and in the end the app was even better and more thought out than in our initial view. And to add, we were on budget and schedule.', 53)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (71, N'VALERY KHVATOV', N'valery-khvatov-ja', N'VPテクノロジー', N'“Titan Technologyの仕事は、高いプロ意識とイニシアチブが特徴です。 これは、テクノロジー企業にとって大切な組み合わせです。 私たちのプロジェクトは、ブロックチェーンプラットフォーム用のモバイルアプリを構築することでした。 チームは開発プロセス全体を通じて多くの質問をし、最終的にアプリは私たちの最初の見解よりもさらに良いものとなりました。 予算とスケジュールも順調でした。更に 開発の質も非常に高いです。 もう1つの非常に良い要因はコミュニケーションです。 これは、リモートチームにとって最も重要です。 非常に責任ある企業であるTitan Technologyとの連携をお勧めします。”', 53)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (72, N'HONGWEN ZHANG, PH.D', N'hongwen-zhang-phd', N'CEO & CTO (co-founder)', N'“Wedge Networks Inc, based in Canada, is a leader in Real-time Threat Prevention for the cloud networks. Our products and services are distributed world-wide. Product quality, reliability, and supportability are critical to our success.', 49)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (73, N'HONGWEN ZHANG, PH.D', N'hongwen-zhang-phd-ja', N'CEO & CTO (共同創設者)', N'“Wedge Networks Incはカナダを拠点とする、クラウドネットワークのリアルタイム脅威防止のリーダー企業です。 当社の製品とサービスは世界中に配布されています。 製品の品質、信頼性、サポートは私たちの成功にとって重要です。 それが、タングエンと彼のTitanチームと提携した理由です。Titanチームは、ウェッジネットワークの拡張チームとして、世界クラスのQAと製品サポートサービスを提供してくれました。 チームは高度なスキルと信頼性があり、柔軟性もあります。 最近の製品発売の成功は、その重要な貢献の証です”', 49)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (74, N'CHRIS HENNIGFELD', N'chris-hennigfeld', N'Project Manager', N'“We greatly appreciate the reliable and cost-effective team Titan has provided to us to develop and maintain one of our systems with over a thousand internal users for several years.”', 52)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (75, N'CHRIS HENNIGFELD', N'chris-hennigfeld-ja', N'プロジェクトマネージャー', N'“当社の数千人以上の内部ユーザーを抱えるシステムの1つを、Titanは数年間開発および保守を提供してくれ、信頼性と費用効果の高いチームに、私は非常に感謝しています”', 52)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (76, N'STEPHEN COLE', N'stephen-cole', N'CEO', N'“In these challenging times, I wanted to say thank you for the outstanding effort and service we have experienced with Titan.They are professionals who really take customer care to the highest levels.We will definitely be using Titan services for our new upcoming projects. Your Company is exemplary in the world of software development and project management. Our projects have always been on time and within budget at Ai6 and Collective Clarity.”', 48)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (77, N'STEPHEN COLE', N'stephen-cole-ja', N'CEO', N'“「正直に言って、タイタンは素晴らしく信頼できる、非常に勤勉なグループだと言えるでしょう。 私は5年以上にわたって彼らとお付き合いしてきました。他の人に彼らを勧めることに何の躊躇もありません。 あなたは彼らの責任ある 便利でインタラクティブな対応に驚くでしょう。 私はタイタンを徹底的にお勧めします。」”', 48)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (78, N'TUV', N'tuv', NULL, NULL, 61)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (79, N'Good Firms', N'good-firms', NULL, NULL, 54)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (80, N'Vinasa', N'vinasa', NULL, NULL, 56)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (81, N'Vietnam IT', N'vietnam-it', NULL, NULL, 57)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (82, N'Phu Nhuan', N'phu-nhuan', NULL, NULL, 58)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (83, N'VJC', N'vjc', NULL, NULL, 55)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (84, N'HCA', N'hca', NULL, NULL, 59)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (85, N'Jetro', N'jetrto', NULL, NULL, 60)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (86, N'Software Outscourcing Journal', N'software-outscourcing-journal', NULL, NULL, 62)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId], [ButtonId]) VALUES (87, N'Latest Jobs', N'latest-jobs', NULL, N'Titan Technology Corporation is the place where we care about individuals. We offer a friendly, challenging, and collaborative home, where every staff is well-treated, enjoy valuable benefits and willing to share ownership with us.', 63, 1)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId], [ButtonId]) VALUES (88, N'最近の仕事', N'latest-jobs-ja', NULL, N'Titan Technology Corporationは、個人を大切にする会社です。フレンドリー、やりがいをコラボレーションして提供、すべてのスタッフが平等に扱われ、貴重なメリットを享受し、会社の所有権を共有していきます。', 63, 2)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (89, N'TITAN’S 10-YEAR CELEBRATION', N'titans-10-year-celebration', NULL, N'The celebration began with a series of exciting competitive activities such as football, badminton, push-ups, Tic & Toe, cooking, musical performance and more, leading up to the main event on 15th April – the Gala Day. This allowed employees to showcase their talents, work together as a team, and engage in friendly competition. The highlight of this celebration was a trip to the stunning Tui Blue Resort in Nam Hoi An. The trip was an astounding success, as it provided a perfect opportunity for employees to connect with one another and build stronger relationships. It was also packed with a sharing night, where the management team and employees were able to reflect on their experiences, share stories and memories, and connect on a deeper level. Furthermore, the team building activities provided a perfect opportunity for employees to work together, learn new skills, and strengthen teamwork and collaboration among colleagues. The most anticipated part was absolutely the Gala Dinner, a fitting celebration of the company''s 10-year anniversary. It was truly a warm dinner, filled with laughter, music, and dancing, providing a perfect opportunity for employees to let loose and enjoy themselves after busy and productive days. The memories and fun were captured in a video, which can be watched on our Youtube channel Titan - 10-year Anniversary. The trip undoubtedly served as a significant investment in the company''s future, and we look forward to many more years of continued success.', '2004-05-23 14:25:10', 64)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (90, N'YEAR-END PARTY!!! 2022', N'year-end-party-2022', NULL, N'Despite the challenges posed by the ongoing pandemic, economic instability, and other difficulties, we at Titan are grateful to have had your support. Together, we have managed to navigate through a difficult year. We also took this occasion to acknowledge and celebrate the outstanding contributions of our excellent employees during the past year. Titan big family had moments of full play and experienced a very special and funny year-end party together in solidarity. All promise a new year with lots of luck for everyone. As we look forward to 2023, we at Titan remain committed to making further efforts to improve and grow as a company. We would like to extend our sincere gratitude for your continued support of Titan.', '2004-05-23 14:25:10', 65)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (91, N'WARM WINTER CHARITY 2022', N'warm-winter-charity-2022', NULL, N'Residing in a tropical country, we sometimes take for granted the life-saving necessities of staying warm. The truth is that there are areas within Vietnam where residents, especially underprivileged children, are affected by cold and extreme weather events. Acknowledging the harsh conditions faced by children living in remote and mountainous areas, Titan organized a charity event named “Warm Winter” that gave away 288 packages of gift including uniforms, cold weather clothing, and school stationary sets to the students at Da Nhinh Elementary School in Dam Rong, Lam Dong in October 2022. Our donation before the wintertime was more than just making the little kids comfortable. Titan members and the Company itself wanted to give the gift of hope that delighted the kids and inspired them to continue their education.', '2004-05-23 14:25:10', 66)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (92, N'5 TECH TRENDS IN HEALTHCARE AND MEDICAL APP DEVELOPMENT', N'5-tech-trends-in-healthcare-and-medical-app-development', N'By Admin', N'There are many medical apps on the market; every day there are more and more healthcare startups. If you decide to create a medical app, you need to think outside the box and you need to create something new and extremely innovative that will combine all the best technologies in one app. Nevertheless, what makes the healthcare application unique? Is it the UI that is easy to use? Auto-fill structure? “Time to take your pills” notifications? Home delivery from pharmacy options? Or maybe all mentioned above and more? In this article, let’s take a look at technological trends of healthcare and medical app development in the coming year.', '2021-06-10 14:25:10', 67)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (93, N'A DEVELOPER’S TALE OF DEADLINES AND FANTASY TIME ESTIMATES', N'a-developers-tale-of-deadlines-and-fantasy-time-estimates', N'By Admin', N'You were asked to write a program, and during the discovery phase of the discussions, you were asked how long it was going to take. The spotlight was on you and everyone turned to face you. On their faces you could see the real question they were asking… How long are you going to set us behind our actual target? Cause let’s face it, that is what they really want to know. How long do they have to wait before they can use and advertise that new feature to the market?', '2021-06-10 14:25:10', 68)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [CreatedDate], [ImageId]) VALUES (94, N'A PRACTICAL GUIDE TO BETTER CODE REVIEWS', N'a-practical-guide-to-better-code-reviews', N'By Admin', N'A CODE REVIEW is a part of the development process in which a developer and their colleagues work together and look for bugs within some code that may be ready for release. At such a moment, you can be either the code developer or one of the reviewers.', '2021-06-10 14:25:10', 69)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Description], [ButtonId]) VALUES (95, N'REQUEST FOR INFORMATION', N'request-for-information', N'Thank for your interest in Titan. Please fill out the form to tell us about your area of needs. Our representative will contact you shortly.', 3)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Description], [ButtonId]) VALUES (96, N'情報を要求する', N'request-for-information-ja', N'弊社に関心をお 寄せいただきありがとうご ざ いました。フォームに必要事項を記入して、お問い合わせ分野をお知らせください。担当者より折り返しご連絡いたします。', 4)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (97, N'CONTACT US', N'contact-us', NULL, N'FIND OUT US ON GOOGLE MAP', NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (98, N'CONTACT US', N'contact-us', NULL, N'FIND OUT US ON GOOGLE MAP', NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Address], [TelNumber], [ImageId]) VALUES (99, N'Headquarters', N'headquarters', N'40 Lam Son Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam', N'Tel: +84-28-3997-7233', NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Address], [TelNumber], [ImageId]) VALUES (100, N'Branch office', N'branch-office-1', N'34 Bach Dang Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam', N'Tel: +84-28-3997-723', NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Address], [TelNumber], [ImageId]) VALUES (101, N'Branch office', N'branch-office-2', N'9/1/2 Tran Dai Nghia Street, Ward 8, Da Lat City, Vietnam', N'Tel: +84-26-3382-8379', NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug]) VALUES (102, N'General Inquiries', N'general-inquiries')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug]) VALUES (103, N'総合窓口', N'general-inquiries-ja')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug]) VALUES (104, N'Sales & Support', N'sales-and-support')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug]) VALUES (105, N'セールス、サポート', N'sales-and-support-ja')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Description]) VALUES (106, N'Copyright', N'copyright', N'© 2024 Titan Technology Corporation. All rights reserved. Privacy & Terms of Use')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [Description]) VALUES (107, N'Copyright', N'copyright-ja', N'© 2024 Titan Technology Corporation. 全著作権所有。 プライバシーポリシー・利用規約')
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (108, N'Connect with us', N'social-media', NULL, NULL, NULL)
INSERT [dbo].[Items] ([Id], [Title], [UrlSlug], [SubTitle], [Description], [ImageId]) VALUES (109, N'米国との接続', N'social-media-ja', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO

INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (10, 1)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (12, 1)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (14, 1)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (11, 2)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (13, 2)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (15, 2)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (16, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (18, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (20, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (22, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (24, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (26, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (28, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (30, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (32, 3)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (17, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (19, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (21, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (23, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (25, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (27, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (29, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (31, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (33, 4)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (34, 5)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (35, 6)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (36, 7)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (38, 7)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (40, 7)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (37, 8)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (39, 8)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (41, 8)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (42, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (43, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (44, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (45, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (46, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (47, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (48, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (49, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (50, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (51, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (52, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (53, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (54, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (55, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (56, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (57, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (58, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (59, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (60, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (61, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (62, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (63, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (64, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (65, 9)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (42, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (43, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (44, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (45, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (46, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (47, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (48, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (49, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (50, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (51, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (52, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (53, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (54, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (55, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (56, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (57, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (58, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (59, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (60, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (61, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (62, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (63, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (64, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (65, 10)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (66, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (68, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (70, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (72, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (74, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (76, 11)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (67, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (69, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (71, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (73, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (75, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (77, 12)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (78, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (79, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (80, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (81, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (82, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (83, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (84, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (85, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (86, 13)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (78, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (79, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (80, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (81, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (82, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (83, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (84, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (85, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (86, 14)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (87, 15)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (88, 16)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (89, 17)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (90, 17)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (91, 17)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (89, 18)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (90, 18)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (91, 18)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (92, 19)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (93, 19)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (94, 19)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (92, 20)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (93, 20)
INSERT [dbo].[ItemSection] ([ItemsId], [SectionsId]) VALUES (94, 20)
GO

INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (102, 1)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (103, 1)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (102, 2)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (103, 2)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (104, 3)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (105, 3)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (104, 4)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (105, 4)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (108, 5)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (108, 6)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (108, 7)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (108, 8)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (109, 5)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (109, 6)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (109, 7)
INSERT [dbo].[ItemSubItem] ([ItemsId], [SubItemsId]) VALUES (109, 8)
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (1, N'Services', N'WE PROVIDE', N'services', N'Professional and trusted services with cost-effective and exceptional expertise to deal with any complexities in scalable projects', N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (2, N'Services', N'提供するサービス', N'services-ja', N'最高な専門知識を持つプロフェッショナルによる信頼できるサービスで、複雑で広範囲なプロジェクトに対処するための費用対効果が高い。', N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (3, N'Domains', N'DOMAINS & TECHNOLOGIES', N'domains', NULL, N'en', 22)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (4, N'Domains', N'ドメイン＆テクノロジー', N'domains-ja', NULL, N'ja', 22)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (5, N'Innovations',N'INNOVATIONS', N'innovations', NULL, N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (6, N'Innovations',N'イノベーション', N'innovations-ja', NULL, N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (7, N'Models', N'ENGAGEMENT MODELS', N'models', N'We provide flexible business engagement models for offshore software testing and development services. They can be altered or combined at any stages of the business engagement.', N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (8, N'Models', N'導入モデル', N'models-ja', N'弊社はオフショアソフトウェアのテスト及び開発サービスのための柔軟なビジネス導入モデルを提供します。ビジネス導入の任意の段階で変更または組み合わせることができます。', N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (9, N'Clients', N'OUR CLIENTS', N'clients', NULL, N'en', 23)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (10, N'Clients', N'弊社のクライアント', N'clients-ja', NULL, N'ja', 23)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (11, N'Customers', N'CUSTOMER TESTIMONIALS', N'customers', N'We deeply appreciate all feedbacks from our customers and keep those as realistic results of high-quality service in Titan', N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (12, N'Customers', N'お客様の声', N'customers-ja', N'お客様からのすべてのフィードバックに深く感謝し、弊社の高品質なサービスの現実にそれらを役立たせます。', N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (13, N'As Recognized By', N'As Recognized By', N'as-recognized', NULL, N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (14, N'As Recognized By', N'受賞・認証', N'as-recognized-ja', NULL, N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (15, N'Careers', N'LATEST JOBS', N'careers', NULL, N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (16, N'Careers', N'最近の仕事', N'careers-ja', NULL, N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (17, N'News',N'NEWS & EVENTS', N'news', NULL, N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (18, N'News',N'ニュース ＆ イベント', N'news-ja', NULL, N'ja', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (19, N'Blogs', N'BLOGS', N'blogs', NULL, N'en', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [UrlSlug], [Description], [Locale], [ImageId]) VALUES (20, N'Blogs', N'ブログ', N'blogs-ja', NULL, N'ja', NULL)
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[SubItems] ON 

INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (1, N'info@titancorpvn.com', 70)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (2, N'titancorpvn', 71)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (3, N'sales@titancorpvn.com', 70)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (4, N'support@titancorpvn.com', 70)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (5, N'Facebook', 72)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (6, N'Twitter', 73)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (7, N'Linkdin', 74)
INSERT [dbo].[SubItems] ([Id], [TextItem], [ImageId]) VALUES (8, N'Youtube', 75)
SET IDENTITY_INSERT [dbo].[SubItems] OFF
GO

CREATE NONCLUSTERED INDEX [IX_CategoryItem_ItemsId] ON [dbo].[CategoryItem]
(
	[ItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Items_ButtonId] ON [dbo].[Items]
(
	[ButtonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Items_ImageId] ON [dbo].[Items]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_ItemSection_SectionsId] ON [dbo].[ItemSection]
(
	[SectionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_ItemSubItem_SubItemsId] ON [dbo].[ItemSubItem]
(
	[SubItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_RequestForms_CategoryId] ON [dbo].[RequestForms]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Sections_ImageId] ON [dbo].[Sections]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_SubItems_ImageId] ON [dbo].[SubItems]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategoryItem]  WITH CHECK ADD  CONSTRAINT [FK_CategoryItem_Categories_CategoriesId] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryItem] CHECK CONSTRAINT [FK_CategoryItem_Categories_CategoriesId]
GO
ALTER TABLE [dbo].[CategoryItem]  WITH CHECK ADD  CONSTRAINT [FK_CategoryItem_Items_ItemsId] FOREIGN KEY([ItemsId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryItem] CHECK CONSTRAINT [FK_CategoryItem_Items_ItemsId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Buttons_ButtonId] FOREIGN KEY([ButtonId])
REFERENCES [dbo].[Buttons] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Buttons_ButtonId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Images_ImageId]
GO
ALTER TABLE [dbo].[ItemSection]  WITH CHECK ADD  CONSTRAINT [FK_ItemSection_Items_ItemsId] FOREIGN KEY([ItemsId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemSection] CHECK CONSTRAINT [FK_ItemSection_Items_ItemsId]
GO
ALTER TABLE [dbo].[ItemSection]  WITH CHECK ADD  CONSTRAINT [FK_ItemSection_Sections_SectionsId] FOREIGN KEY([SectionsId])
REFERENCES [dbo].[Sections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemSection] CHECK CONSTRAINT [FK_ItemSection_Sections_SectionsId]
GO
ALTER TABLE [dbo].[ItemSubItem]  WITH CHECK ADD  CONSTRAINT [FK_ItemSubItem_Items_ItemsId] FOREIGN KEY([ItemsId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemSubItem] CHECK CONSTRAINT [FK_ItemSubItem_Items_ItemsId]
GO
ALTER TABLE [dbo].[ItemSubItem]  WITH CHECK ADD  CONSTRAINT [FK_ItemSubItem_SubItems_SubItemsId] FOREIGN KEY([SubItemsId])
REFERENCES [dbo].[SubItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemSubItem] CHECK CONSTRAINT [FK_ItemSubItem_SubItems_SubItemsId]
GO
ALTER TABLE [dbo].[RequestForms]  WITH CHECK ADD  CONSTRAINT [FK_RequestForms_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[RequestForms] CHECK CONSTRAINT [FK_RequestForms_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Sections]  WITH CHECK ADD  CONSTRAINT [FK_Sections_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Sections] CHECK CONSTRAINT [FK_Sections_Images_ImageId]
GO
ALTER TABLE [dbo].[SubItems]  WITH CHECK ADD  CONSTRAINT [FK_SubItems_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[SubItems] CHECK CONSTRAINT [FK_SubItems_Images_ImageId]
GO
USE [master]
GO
ALTER DATABASE [TitanWeb] SET  READ_WRITE 
GO