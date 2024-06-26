DROP DATABASE [TitanWeb]
GO

CREATE DATABASE [TitanWeb]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TitanWeb] SET COMPATIBILITY_LEVEL = 160
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
ALTER DATABASE [TitanWeb] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [TitanWeb] SET RECOVERY FULL 
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
EXEC sys.sp_db_vardecimal_storage_format N'TitanWeb', N'ON'
GO
ALTER DATABASE [TitanWeb] SET QUERY_STORE = ON
GO
ALTER DATABASE [TitanWeb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TitanWeb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buttons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](max) NULL,
	[JapaneseLabel] [nvarchar](max) NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[RowVersion] [timestamp] NULL,
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
	[Name] [nvarchar](max) NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[RowVersion] [timestamp] NULL,
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
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Hyperlink] [nvarchar](max) NULL,
	[IsLogo] [bit] NOT NULL,
	[RowVersion] [timestamp] NULL,
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
	[JapaneseBoldTitle] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[JapaneseTitle] [nvarchar](max) NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[SubTitle] [nvarchar](max) NULL,
	[JapaneseSubTitle] [nvarchar](max) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[JapaneseShortDescription] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[JapaneseDescription] [nvarchar](max) NULL,
	[IsDisplayed] [bit] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[TelNumber] [nvarchar](max) NULL,
	[InfoGmail] [nvarchar](max) NULL,
	[InfoGmail2] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[ImageId] [int] NULL,
	[SectionId] [int] NULL,
	[ButtonId] [int] NULL,
	[CategoryId] [int] NULL,
	[RowVersion] [timestamp] NULL,
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
CREATE TABLE [dbo].[RequestForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CategoryId] [int] NULL,
	[RowVersion] [timestamp] NULL,
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
	[Name] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[JapaneseTitle] [nvarchar](max) NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[JapaneseDescription] [nvarchar](max) NULL,
	[SectionOrder] [int] NOT NULL,
	[ImageId] [int] NULL,
	[RowVersion] [timestamp] NULL,
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
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[Linkedin] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[ItemId] [int] NOT NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_SubItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buttons] ON 

INSERT [dbo].[Buttons] ([Id], [Label], [JapaneseLabel], [UrlSlug], [Status]) VALUES (1, N'日本', N'English', N'locale-button', 1)
INSERT [dbo].[Buttons] ([Id], [Label], [JapaneseLabel], [UrlSlug], [Status]) VALUES (2, N'JOIN US', N'参加しませんか', N'job-button', 1)
INSERT [dbo].[Buttons] ([Id], [Label], [JapaneseLabel], [UrlSlug], [Status]) VALUES (3, N'REQUEST NOW', N'今すぐリクエスト', N'request-button', 1)
SET IDENTITY_INSERT [dbo].[Buttons] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug]) VALUES (1, N'Navbar', N'navbar')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug]) VALUES (2, N'Banner', N'banner')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug]) VALUES (3, N'Request', N'request')
INSERT [dbo].[Categories] ([Id], [Name], [UrlSlug]) VALUES (4, N'Footer', N'footer')
SET IDENTITY_INSERT [dbo].[Categories] OFF
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
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (1, NULL, NULL, N'Navbar', N'Navbar', N'navbar', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, 1)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (2, N'INSPIRE', NULL, N' YOUR WORK', N'貴方にとって刺激的な仕事', N'banner-1', NULL, NULL, NULL, NULL, N'Founded on trust and experience, by a professional team, with a big vision and mission to provide the best services to our clients.', N'弊社のビジョンに基づきお客様へ最高のサービスを、信頼と経験に基づいた当社のプロフェッショナルチームが提供致します。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL, 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (3, N'COMPREHENSIVE', NULL, N' INNOVATIONS', N'総合的な改革', N'banner-2', NULL, NULL, NULL, NULL, N'A dedicated and professional team that offers a wide range of advanced solution for offshore software testing and comprehensive development services.', N'幅広い高度なソリューションを提供する、オフショア・ソフトウェア・テストと包括的な開発サービス専門チーム。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (4, N'ADVANCED SOLUTION', NULL, N' FOR INNOVATIONS', N'イノベーションのための高度なソリューション', N'banner-3', NULL, NULL, NULL, NULL, N'Always hunger for new idea creation, we incubate good ideas by providing facilities for product development and environment where creativity leverages our skills and services.', N'弊社は常に新しいアイデアの創造に貪欲です。スキルとサービスを活用して製品開発と環境のための設備を提供することによって、より良いアイデアを育てます。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (5, N'"INSPIRE"', NULL, N' WORKING ENVIRONMENT', N'“刺激的”な働く環境', N'banner-4', NULL, NULL, NULL, NULL, N'Our friendly, challenging, and collaborative environment creates enjoy valuable benefits and sharing ownership.', N'フレンドリーでチャレンジを融合するやりがいのある環境は、価値あるメリットや所有権の共有を作り出します', 1, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, 2)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (6, NULL, NULL, N'SOFTWARE DEVELOPMENT', N'ソフトウェア開発', N'software-development', NULL, NULL, NULL, NULL, N'Develop software applications from business ideas to deployment, develop based on product definition, the initial designs, or develop modules with multiple teams for concurrent development thus reducing time to market.', N'ビジネスのアイデアから展開にいたるソフトウェアアプリを開発し、製品の定義やモジュール開発は、初期設計に基づいて開発し、同時開発のために複数のチームで行い、製品化までの時間を短縮します', 1, NULL, NULL, NULL, NULL, NULL, NULL, 6, 1, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (7, NULL, NULL, N'MAINTENANCE AND SUPPORT', N'メンテナンス＆サポート', N'maintenance-and-support', NULL, NULL, NULL, NULL, N'Maintain, enhance, and develop new features of existing software applications. We also provide services to migrate from the legacy systems to new technologies to help improve performance and add benefits to the client''s businesses.', N'既存のソフトウェアアプリケーションの新機能を維持、強化、開発します。 パフォーマンスを向上させ、クライアントのビジネスに利益をもたらすサービスを提供する為に、レガシーシステムから新しいテクノロジーに移行します。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 7, 1, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (8, NULL, NULL, N'SOFTWARE TESTING', N'ソフトウェアテス', N'software-testing', NULL, NULL, NULL, NULL, N'Provide all kind of testing services including automation tool development, enhancement and execution to assure the quality of our client’s products.', N'自動化ツールの開発、強化、実行など、あらゆる種類のテストサービスを提供して、お客様の製品の品質を保証します。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 8, 1, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (9, NULL, NULL, N'MOBILE DEVELOPMENT', N'MOBILE アプリ開発', N'mobile-development', NULL, NULL, NULL, NULL, N'We have expertise in building mobile applications and mobile games on multiple platforms', N'弊社は複数のプラットフォーム上で、モバイルアプリケーションとモバイルゲームを構築する専門知識を持っています', 1, NULL, NULL, NULL, NULL, NULL, NULL, 14, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (10, NULL, NULL, N'WEB APP DEVELOPMENT', N'Web アプリ開発', N'web-app-development', NULL, NULL, NULL, NULL, N'Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line', N'弊社のチームは、インサイトUX / UIを使用してWebアプリケーションを構築する方法を熟知しています。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 17, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (11, NULL, NULL, N'DESKTOP DEVELOPMENT', N'DESKTOP アプリ開発', N'desktop-development', NULL, NULL, NULL, NULL, N'We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models', N'弊社はクロスプラットフォーアプリケーションの安定性を拡大し、アーキテクトやビジネスモデルに簡単に変換できるプログラムを開発します。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 13, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (12, NULL, NULL, N'CLOUD BASED DEVELOPMENT', N'CLOUD BASED アプリ開発', N'cloud-based-development', NULL, NULL, NULL, NULL, N'We have extensive experience in implementation of specific PaaS and SaaS solutions', N'当社は、PaaSとSaaSソリューションにおける豊富な導入経験を持っています', 1, NULL, NULL, NULL, NULL, NULL, NULL, 11, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (13, NULL, NULL, N'TELECOM & NETWORKING', N'通信＆ネットワーク', N'telecom-and-networking', NULL, NULL, NULL, NULL, N'Our team has strong experience in telecom and network systems that enable us to provide both testing and development services', N'弊社のチームは、テレコムおよびネットワークシステムで、テストおよび開発の両方を提供可能にする豊富な経験を持っています。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 15, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (14, NULL, NULL, N'TESTING & QUALITY ASSURANCE', N'テストティング＆品質保証', N'testing-and-quality-assurance', NULL, NULL, NULL, NULL, N'We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models', N'弊社は、さまざまなドメインおよび品質保証サービスを提供するために、プロジェクトをテストするための明確なプロセスを持って。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 16, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (15, NULL, NULL, N'BLOCKCHAIN DEVELOPMENT', N'ブロックチェーン開発', N'blockchain-development', NULL, NULL, NULL, NULL, N'We have experiences in setting up, configuring, and developing applications based on Block chain technologies: Ethereum, De-centralized, Smart Contract, Cryptocurrency', N'弊社は、ブロックチェーン技術に基づいたアプリケーションのセットアップ、構成、および開発経験を持っています。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (16, NULL, NULL, N'ARTIFICIAL INTELLIGENCE', N'人工知能（AI）', N'artificial-intelligence', NULL, NULL, NULL, NULL, N'We have extensive experiences in implementation of specific solutions with AI inside: Core Machine Learning Algorithms, Unsupervised Learning, Data Preparation...', N'弊社は人工知能を使用した特定のソリューション、コア機械のアルゴリズム学習、教師なし学習、データ準備での実装に幅広い経験を持', 1, NULL, NULL, NULL, NULL, NULL, NULL, 9, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (17, NULL, NULL, N'ERP/CRM IMPLEMENTATION', N'ERP/CRM の導入', N'erpcrm-implementation', NULL, NULL, NULL, NULL, N'Experienced team to consult and implement ERP and CRM solutions based on Microsoft and Open Source technologies (Dynamics AX/365/NAV, OpenERP(Odoo), SugarCRM, vTiger, and so on) with following services', N'経験豊富なチームが、Microsoftおよびオープンソーステクノロジに基づいたERPおよびCRMソリューションをコン', 1, NULL, NULL, NULL, NULL, NULL, NULL, 12, 2, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (18, NULL, NULL, N'Innovations', N'イノベーション', N'innovations', NULL, NULL, NULL, NULL, N'We always hunger for new idea creation by providing facilities for product development and an environment where creativity leverages our skills and services.', N'弊社は常に新しいアイデアの創造を求めて、貪欲に製品開発のための設備、創造性、スキルとサービスを活用する環境をご提供します。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 18, 3, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (19, NULL, NULL, N'DEDICATED TEAM', N'専任チーム', N'dedicated-team', NULL, NULL, NULL, NULL, N'<li>Dedicated professional team work for your projects.</li><li>Virtual extension of your engineering team.</li><li>Flexible task assignments based on your needs.</li><li>Stable and scalable resources.</li><li>Budget is measured in man-months.</li><li>The separate team of professionals will work over your project.</li>', N'<li>専任プロチームがお客様のプロジェクトに取り組みます。</li><li>お客様のエンジニアリングチームの仮想拡張。</li><li>お客様のニーズに合わせて柔軟な作業割り当て。</li><li>安定したリソースの拡張。</li><li>予算は人月単位で計算します</li><li>個別のプロチームがお客様のプロジェクトに取組ます。</li>', 1, NULL, NULL, NULL, NULL, NULL, NULL, 19, 4, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (20, NULL, NULL, N'FIXED COST', N'固定コスト', N'fixed-cost', NULL, NULL, NULL, NULL, N'<li>Task assignments are defined clearly at the requirements.</li><li>Project schedule is planned clearly.</li><li>Budget is fixed based on requirements.</li><li>Fixed project budget (measured in man hours) and time limits.</li>', N'<li>タスクの割り当ては、お客様の要件に合わせて明確に定義されています。</li><li>プロジェクトのスケジュールが明確に計画されています。</li><li>予算は、お客様の要件に応じて計算されます。</li><li>固定されたプロジェクト予算（人数で計算）及び納品締切日</li>', 1, NULL, NULL, NULL, NULL, NULL, NULL, 20, 4, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (21, NULL, NULL, N'TIME & MATERIAL', N'時間と資源', N'time-and-material', NULL, NULL, NULL, NULL, N'<li>Flexible task assignments based on your needs within time limits.</li><li>Adjustable and designated resources.</li><li>Budget is flexible and can be adjusted based on your requirements.</li><li>Stable and scalable resources.</li><li>Budget is measured in man-months.</li><li>Project budget is flexible and can be adjusted according to your requirements.</li>', N'<li>納品日内でのお客様のニーズに応じた柔軟なタスク割り当て。</li><li>調整可能で指定されたリソース。</li><li>予算は柔軟性で、お客様の要件に合わせて調整することができます。</li><li>安定した拡張リソース。</li><li>予算は人月単位で計算します</li><li>プロジェクト予算は柔軟で、お客様の要件に応じて調整可能。</li>', 1, NULL, NULL, NULL, NULL, NULL, NULL, 21, 4, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (22, NULL, NULL, N'Deloitte', N'Deloitte', N'deloitte', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 24, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (23, NULL, NULL, N'MobileIron', N'MobileIron', N'mobile-iron', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 44, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (24, NULL, NULL, N'MindGeek', N'MindGeek', N'mind-geek', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 26, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (25, NULL, NULL, N'TechWise Networks', N'TechWise Networks', N'techwise-networks', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 35, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (26, NULL, NULL, N'Televz', N'Televz', N'televz', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 36, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (27, NULL, NULL, N'SAIGONX', N'SAIGONX', N'saigonx', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 33, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (28, NULL, NULL, N'Greenpacket', N'Greenpacket', N'greenpacket', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 31, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (29, NULL, NULL, N'SSENSE', N'SSENSE', N'ssense', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 45, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (30, NULL, NULL, N'GreenCopper', N'GreenCopper', N'green-copper', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 43, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (31, NULL, NULL, N'BGX', N'BGX', N'bgx', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 40, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (32, NULL, NULL, N'Wedge Networks', N'Wedge Networks', N'wedge-networks', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 47, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (33, NULL, NULL, N'Digital Performance', N'Digital Performance', N'digital-performance', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 29, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (34, NULL, NULL, N'Collective Clarity', N'Collective Clarity', N'collective-clarity', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 28, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (35, NULL, NULL, N'Superhippo', N'Superhippo', N'superhippo', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 27, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (36, NULL, NULL, N'ETNA Software', N'ETNA Software', N'etna-software', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 41, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (37, NULL, NULL, N'Traffic Partner', N'Traffic Partner', N'traffic-partner', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 46, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (38, NULL, NULL, N'Ewerk', N'Ewerk', N'ewerk', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 42, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (39, NULL, NULL, N'KTC', N'KTC', N'ktc', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 32, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (40, NULL, NULL, N'Frogasia', N'Frogasia', N'frogasia', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 38, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (41, NULL, NULL, N'TPF', N'TPF', N'tpf', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 37, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (42, NULL, NULL, N'TVT', N'TVT', N'tvt', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 39, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (43, NULL, NULL, N'sssmine', N'sssmine', N'sssmine', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 34, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (44, NULL, NULL, N'Ecopharma', N'Ecopharma', N'ecopharma', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 30, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (45, NULL, NULL, N'Empiregroup', N'Empiregroup', N'empiregroup', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 25, 5, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (46, NULL, NULL, N'DR. TIM PARKER', N'DR. TIM PARKER', N'dr-tim-parker', N'Chief Technical Officer', N'最高技術責任者', NULL, NULL, N'“We have worked with Titan Technology for the last three years on a complex and evolving software product. We are delighted with the quality of the deliverables, the enthusiasm of the team, and the dedication to our project. We look forward to continuing this excellent relationship in the years to come, and I strongly recommend Titan Technology as a software outsourcing provider.”', N'“「私たちは過去3年間、複雑で進化し続けるソフトウェア製品についてTitan Technologyと協力してきました。 成果物の品質、チームの熱意、そしてプロジェクトへの献身に満足しています。 今後もこの素晴らしい関係を継続できることを楽しみにしており、ソフトウェアアウトソーシングプロバイダーとしてTitan Technologyを強くお勧めします。」”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 50, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (47, NULL, NULL, N'THOMAS SANTONJA', N'THOMAS SANTONJA', N'thomas-santonja', N'Director of Application Development', N'アプリケーション開発役員', NULL, NULL, N'“A professional and dedicated team with a spirit of delivery. Successfully worked along us for delivery of years of features.”', N'“デリバリー精神のあるプロフェッショナルで献身的なチーム。長年の機能を提供するために私たちと一緒に成功しました”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 51, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (48, NULL, NULL, N'VALERY KHVATOV', N'VALERY KHVATOV', N'valery-khvatov', N'VP of Technology', N'VPテクノロジー', NULL, NULL, N'“The work of Titan Technology is distinguished by high professionalism and initiative. It is a wonderful combination for a tech company. Our project consisted of building a mobile app for a blockchain platform. The team asked many right questions throughout the development process and in the end the app was even better and more thought out than in our initial view. And to add, we were on budget and schedule.', N'“Titan Technologyの仕事は、高いプロ意識とイニシアチブが特徴です。 これは、テクノロジー企業にとって大切な組み合わせです。 私たちのプロジェクトは、ブロックチェーンプラットフォーム用のモバイルアプリを構築することでした。 チームは開発プロセス全体を通じて多くの質問をし、最終的にアプリは私たちの最初の見解よりもさらに良いものとなりました。 予算とスケジュールも順調でした。更に 開発の質も非常に高いです。 もう1つの非常に良い要因はコミュニケーションです。 これは、リモートチームにとって最も重要です。 非常に責任ある企業であるTitan Technologyとの連携をお勧めします。”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 53, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (49, NULL, NULL, N'HONGWEN ZHANG, PH.D', N'HONGWEN ZHANG, PH.D', N'hongwen-zhang-phd', N'CEO & CTO (co-founder)', N'CEO & CTO (共同創設者)', NULL, NULL, N'“Wedge Networks Inc, based in Canada, is a leader in Real-time Threat Prevention for the cloud networks. Our products and services are distributed world-wide. Product quality, reliability, and supportability are critical to our success.', N'“Wedge Networks Incはカナダを拠点とする、クラウドネットワークのリアルタイム脅威防止のリーダー企業です。 当社の製品とサービスは世界中に配布されています。 製品の品質、信頼性、サポートは私たちの成功にとって重要です。 それが、タングエンと彼のTitanチームと提携した理由です。Titanチームは、ウェッジネットワークの拡張チームとして、世界クラスのQAと製品サポートサービスを提供してくれました。 チームは高度なスキルと信頼性があり、柔軟性もあります。 最近の製品発売の成功は、その重要な貢献の証です”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 49, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (50, NULL, NULL, N'CHRIS HENNIGFELD', N'CHRIS HENNIGFELD', N'chris-hennigfeld', N'Project Manager', N'プロジェクトマネージャー', NULL, NULL, N'“We greatly appreciate the reliable and cost-effective team Titan has provided to us to develop and maintain one of our systems with over a thousand internal users for several years.”', N'“当社の数千人以上の内部ユーザーを抱えるシステムの1つを、Titanは数年間開発および保守を提供してくれ、信頼性と費用効果の高いチームに、私は非常に感謝しています”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 52, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (51, NULL, NULL, N'STEPHEN COLE', N'STEPHEN COLE', N'stephen-cole', N'CEO', N'CEO', NULL, NULL, N'“In these challenging times, I wanted to say thank you for the outstanding effort and service we have experienced with Titan.They are professionals who really take customer care to the highest levels.We will definitely be using Titan services for our new upcoming projects. Your Company is exemplary in the world of software development and project management. Our projects have always been on time and within budget at Ai6 and Collective Clarity.”', N'“「正直に言って、タイタンは素晴らしく信頼できる、非常に勤勉なグループだと言えるでしょう。 私は5年以上にわたって彼らとお付き合いしてきました。他の人に彼らを勧めることに何の躊躇もありません。 あなたは彼らの責任ある 便利でインタラクティブな対応に驚くでしょう。 私はタイタンを徹底的にお勧めします。」”', 1, NULL, NULL, NULL, NULL, NULL, NULL, 48, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (52, NULL, NULL, N'TUV', N'TUV', N'tuv', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 61, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (53, NULL, NULL, N'Good Firms', N'Good Firms', N'good-firms', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 54, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (54, NULL, NULL, N'Vinasa', N'Vinasa', N'vinasa', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 56, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (55, NULL, NULL, N'Vietnam IT', N'Vietnam IT', N'vietnam-it', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 57, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (56, NULL, NULL, N'Phu Nhuan', N'Phu Nhuan', N'phu-nhuan', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 58, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (57, NULL, NULL, N'VJC', N'VJC', N'vjc', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 55, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (58, NULL, NULL, N'HCA', N'HCA', N'hca', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 59, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (59, NULL, NULL, N'Jetro', N'Jetro', N'jetrto', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 60, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (60, NULL, NULL, N'Software Outscourcing Journal', NULL, N'software-outscourcing-journal', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 62, 7, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (61, NULL, NULL, N'Latest Jobs', N'最近の仕事', N'latest-jobs', NULL, NULL, NULL, NULL, N'Titan Technology Corporation is the place where we care about individuals. We offer a friendly, challenging, and collaborative home, where every staff is well-treated, enjoy valuable benefits and willing to share ownership with us.', N'Titan Technology Corporationは、個人を大切にする会社です。フレンドリー、やりがいをコラボレーションして提供、すべてのスタッフが平等に扱われ、貴重なメリットを享受し、会社の所有権を共有していきます。', 1, NULL, NULL, NULL, NULL, NULL, NULL, 63, 8, 2, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (62, NULL, NULL, N'TITAN’S 10-YEAR CELEBRATION', N'TITAN’S 10-YEAR CELEBRATION', N'titans-10-year-celebration', NULL, NULL, N'It has been 10 years since the date of Titan’s establishment, from 2013 to 2023. Our big family recently commemorated this meaningful milest ...', N'It has been 10 years since the date of Titan’s establishment, from 2013 to 2023. Our big family recently commemorated this meaningful milest ...', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2004-05-23T14:25:10.0000000' AS DateTime2), NULL, 64, 9, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (63, NULL, NULL, N'YEAR-END PARTY!!! 2022', N'YEAR-END PARTY!!! 2022', N'year-end-party-2022', NULL, NULL, N'We at Titan recently celebrated the end of an eventful year with our YEAR END PARTY 2022! After a year of dedicated work, Titan have experie.Despite the challenges posed by the ongoing pandemic, economic instability, and other difficulties, we at Titan are grateful to have had your support. Together, we have managed to navigate through a difficult year. We also took this occasion to acknowledge and celebrate the outstanding contributions of our excellent employees during the past year. ...', N'We at Titan recently celebrated the end of an eventful year with our YEAR END PARTY 2022! After a year of dedicated work, Titan have experie.Despite the challenges posed by the ongoing pandemic, economic instability, and other difficulties, we at Titan are grateful to have had your support. Together, we have managed to navigate through a difficult year. We also took this occasion to acknowledge and celebrate the outstanding contributions of our excellent employees during the past year. ...', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2004-05-23T14:25:10.0000000' AS DateTime2), NULL, 65, 9, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (64, NULL, NULL, N'WARM WINTER CHARITY 2022', N'WARM WINTER CHARITY 2022', N'warm-winter-charity-2022', NULL, NULL, N'Titan organized a charity event named “Warm Winter” that gave away 288 packages of gift including uniforms, cold weather clothing, and schoo… ...', N'Titan organized a charity event named “Warm Winter” that gave away 288 packages of gift including uniforms, cold weather clothing, and schoo… ...', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2004-05-23T14:25:10.0000000' AS DateTime2), NULL, 66, 9, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (65, NULL, NULL, N'5 TECH TRENDS IN HEALTHCARE AND MEDICAL APP DEVELOPMENT', N'5 TECH TRENDS IN HEALTHCARE AND MEDICAL APP DEVELOPMENT', N'5-tech-trends-in-healthcare-and-medical-app-development', N'Admin', NULL, N'There are many medical apps on the market; every day there are more and more healthcare startups. If you decide to create a medical app, you need to think outside the box and you need to....', N'There are many medical apps on the market; every day there are more and more healthcare startups. If you decide to create a medical app, you need to think outside the box and you need to....', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2021-06-10T14:25:10.0000000' AS DateTime2), NULL, 67, 10, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (66, NULL, NULL, N'A DEVELOPER’S TALE OF DEADLINES AND FANTASY TIME ESTIMATES', N'A DEVELOPER’S TALE OF DEADLINES AND FANTASY TIME ESTIMATES', N'a-developers-tale-of-deadlines-and-fantasy-time-estimates', N'Admin', NULL, N'You were asked to write a program, and during the discovery phase of the discussions, you were asked how long it was going to take.....', N'You were asked to write a program, and during the discovery phase of the discussions, you were asked how long it was going to take.....', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2021-06-10T14:25:10.0000000' AS DateTime2), NULL, 68, 10, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (67, NULL, NULL, N'A PRACTICAL GUIDE TO BETTER CODE REVIEWS', N'A PRACTICAL GUIDE TO BETTER CODE REVIEWS', N'a-practical-guide-to-better-code-reviews', N'Admin', NULL, N'A CODE REVIEW is a part of the development process in which a developer and their colleagues work together and look for bugs within some code...', N'A CODE REVIEW is a part of the development process in which a developer and their colleagues work together and look for bugs within some code...', NULL, NULL, 1, NULL, NULL, NULL, NULL, CAST(N'2021-06-10T14:25:10.0000000' AS DateTime2), NULL, 69, 10, NULL, NULL)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (68, NULL, NULL, N'REQUEST FOR INFORMATION', N'情報を要求する', N'request-for-information', NULL, NULL, NULL, NULL, N'Thank for your interest in Titan. Please fill out the form to tell us about your area of needs. Our representative will contact you shortly.', N'弊社に関心をお 寄せいただきありがとうご ざ いました。フォームに必要事項を記入して、お問い合わせ分野をお知らせください。担当者より折り返しご連絡いたします。', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, 3)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (69, NULL, NULL, N'Headquarters:', N'Headquarters:', N'headquarters', NULL, NULL, NULL, NULL, NULL, NULL, 1, N'40 Lam Son Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam', N'+84-28-3997-7233', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (70, NULL, NULL, N'Branch office', N'Branch office', N'branch-office-1', NULL, NULL, NULL, NULL, NULL, NULL, 1, N'34 Bach Dang Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam', N'+84-28-3997-723', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (71, NULL, NULL, N'Branch office', N'Branch office', N'branch-office-2', NULL, NULL, NULL, NULL, NULL, NULL, 1, N'9/1/2 Tran Dai Nghia Street, Ward 8, Da Lat City, Vietnam', N'+84-26-3382-8379', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (72, NULL, NULL, N'General Inquiries', N'総合窓口', N'general-inquiries', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'info@titancorpvn.com', N'titancorpvn', NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (73, NULL, NULL, N'Sales & Support', N'セールス、サポート', N'sales-and-support', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'sales@titancorpvn.com', N'support@titancorpvn.com', NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (74, NULL, NULL, N'Copyright', N'Copyright', N'copyright', NULL, NULL, NULL, NULL, N'© 2024 Titan Technology Corporation. All rights reserved.', N'© 2024 Titan Technology Corporation. 全著作権所有。', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Items] ([Id], [BoldTitle], [JapaneseBoldTitle], [Title], [JapaneseTitle], [UrlSlug], [SubTitle], [JapaneseSubTitle], [ShortDescription], [JapaneseShortDescription], [Description], [JapaneseDescription], [IsDisplayed], [Address], [TelNumber], [InfoGmail], [InfoGmail2], [CreatedDate], [UpdatedDate], [ImageId], [SectionId], [ButtonId], [CategoryId]) VALUES (75, NULL, NULL, N'Connect with us', N'米国との接続', N'social-media', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (1, N'Services', N'WE PROVIDE', N'提供するサービス', N'services', N'Professional and trusted services with cost-effective and exceptional expertise to deal with any complexities in scalable projects', N'最高な専門知識を持つプロフェッショナルによる信頼できるサービスで、複雑で広範囲なプロジェクトに対処するための費用対効果が高い。', 1, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (2, N'Domains', N'DOMAINS & TECHNOLOGIES', N'ドメイン＆テクノロジー', N'domains', NULL, NULL, 2, 22)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (3, N'Innovations', N'INNOVATIONS', N'イノベーション', N'innovations', NULL, NULL, 3, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (4, N'Models', N'ENGAGEMENT MODELS', N'導入モデル', N'models', N'We provide flexible business engagement models for offshore software testing and development services. They can be altered or combined at any stages of the business engagement.', N'弊社はオフショアソフトウェアのテスト及び開発サービスのための柔軟なビジネス導入モデルを提供します。ビジネス導入の任意の段階で変更または組み合わせることができます。', 4, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (5, N'Clients', N'OUR CLIENTS', N'弊社のクライアント', N'clients', NULL, NULL, 5, 23)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (6, N'Customers', N'CUSTOMER TESTIMONIALS', N'お客様の声', N'customers', N'We deeply appreciate all feedbacks from our customers and keep those as realistic results of high-quality service in Titan', N'お客様からのすべてのフィードバックに深く感謝し、弊社の高品質なサービスの現実にそれらを役立たせます。', 6, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (7, N'As Recognized By', N'As Recognized By', N'受賞・認証', N'as-recognized', NULL, NULL, 7, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (8, N'Careers', N'LATEST JOBS', N'最近の仕事', N'careers', NULL, NULL, 8, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (9, N'News', N'NEWS & EVENTS', N'ニュース ＆ イベント', N'news', NULL, NULL, 9, NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Title], [JapaneseTitle], [UrlSlug], [Description], [JapaneseDescription], [SectionOrder], [ImageId]) VALUES (10, N'Blogs', N'BLOGS', N'ブログ', N'blogs', NULL, NULL, 10, NULL)
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[SubItems] ON 

INSERT [dbo].[SubItems] ([Id], [Facebook], [Twitter], [Linkedin], [Youtube], [ItemId]) VALUES (1, N'https://www.facebook.com/Titan-Technology-Corporation-367359790030585/', N'https://twitter.com/titancorpvn', N'https://www.linkedin.com/company/titan-technology-corporation', N'https://www.youtube.com/channel/UCU8y74v5CvedVo4bNGhkQnA', 75)
SET IDENTITY_INSERT [dbo].[SubItems] OFF
GO

CREATE NONCLUSTERED INDEX [IX_Items_ButtonId] ON [dbo].[Items]
(
	[ButtonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Items_CategoryId] ON [dbo].[Items]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Items_ImageId] ON [dbo].[Items]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Items_SectionId] ON [dbo].[Items]
(
	[SectionId] ASC
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

CREATE NONCLUSTERED INDEX [IX_SubItems_ItemId] ON [dbo].[SubItems]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items] ADD  DEFAULT ((1)) FOR [IsDisplayed]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Buttons_ButtonId] FOREIGN KEY([ButtonId])
REFERENCES [dbo].[Buttons] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Buttons_ButtonId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Images_ImageId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Sections_SectionId] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Sections_SectionId]
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
ALTER TABLE [dbo].[SubItems]  WITH CHECK ADD  CONSTRAINT [FK_SubItems_Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubItems] CHECK CONSTRAINT [FK_SubItems_Items_ItemId]
GO
USE [master]
GO
ALTER DATABASE [TitanWeb] SET  READ_WRITE 
GO
