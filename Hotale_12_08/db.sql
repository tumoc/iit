USE [webkhachhang_thienanhotel]
GO
/****** Object:  Table [dbo].[Advertising]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertising](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Url] [nvarchar](250) NULL,
	[Image] [nvarchar](300) NOT NULL,
	[Target] [nvarchar](10) NULL,
	[Index] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Advertising] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[Index] [int] NULL,
	[Home] [bit] NOT NULL,
	[languageID] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](250) NOT NULL,
	[Image] [nvarchar](300) NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Index] [int] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Hot] [bit] NOT NULL,
	[Home] [bit] NOT NULL,
	[Datetime] [datetime] NULL,
	[Customer] [bit] NOT NULL,
	[Authur] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRoom]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRoom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](300) NULL,
	[City] [nvarchar](200) NULL,
	[Country] [nvarchar](200) NOT NULL,
	[Smoking] [bit] NOT NULL,
	[ArrivalFlight] [nvarchar](50) NULL,
	[ArrivalTime] [nvarchar](50) NULL,
	[Request] [nvarchar](2000) NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[Adult] [int] NOT NULL,
	[Child] [int] NOT NULL,
	[DateBook] [datetime] NOT NULL,
	[InfoBooking] [nvarchar](500) NOT NULL,
	[TotalMoney] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_BookRoomOnline] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](300) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ArticleID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[languageID] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigWebsite]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigWebsite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Port] [int] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ConfigHotel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Country] [nvarchar](250) NOT NULL,
	[Request] [nvarchar](2000) NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Enquiry] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Star] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[RoomId] [int] NULL,
	[Avatar] [nvarchar](255) NOT NULL,
	[langaugeID] [varchar](10) NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Index] [int] NULL,
	[SmallImage] [nvarchar](300) NOT NULL,
	[LargeImage] [nvarchar](300) NOT NULL,
	[MenuId] [int] NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Logo] [nvarchar](300) NOT NULL,
	[Image] [nvarchar](300) NOT NULL,
	[Tel] [nvarchar](100) NOT NULL,
	[Hotline] [nvarchar](250) NULL,
	[Fax] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[CodeBooking] [nvarchar](20) NOT NULL,
	[Website] [nvarchar](100) NOT NULL,
	[Condition] [nvarchar](max) NOT NULL,
	[Tripadvisor] [nvarchar](2000) NULL,
	[Facebook] [nvarchar](250) NULL,
	[Instagram] [nvarchar](250) NULL,
	[Twitter] [nvarchar](250) NULL,
	[Youtube] [nvarchar](250) NULL,
	[CopyRight] [nvarchar](300) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Favicon] [nvarchar](250) NULL,
 CONSTRAINT [PK_Hotel1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelRule]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Rule] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[Index] [int] NULL,
	[languageID] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](300) NOT NULL,
	[Default] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](300) NOT NULL,
	[ParentID] [int] NULL,
	[Type] [int] NOT NULL,
	[Index] [int] NULL,
	[Location] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[Link] [nvarchar](250) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plugin]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plugin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CSS] [text] NULL,
	[JS] [text] NULL,
	[SideBar] [nvarchar](max) NULL,
 CONSTRAINT [PK_CSS_JS_SideBar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL,
	[Image] [nvarchar](300) NOT NULL,
	[MaxPeople] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[PriceNet] [decimal](18, 0) NULL,
	[Index] [int] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Home] [bit] NOT NULL,
	[Roomspace] [decimal](18, 0) NOT NULL,
	[Roomview] [nvarchar](150) NOT NULL,
	[Typebed] [nvarchar](50) NOT NULL,
	[Numofbed] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAmenity]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAmenity](
	[RoomAmenityID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[AmenityID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomAmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomGallery]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomGallery](
	[RoomGalleryId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[ImageSmall] [nvarchar](300) NOT NULL,
	[ImageLarge] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_dbo.RoomGallery] PRIMARY KEY CLUSTERED 
(
	[RoomGalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SendEmail]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendEmail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Type] [int] NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ContentDefault] [nvarchar](max) NOT NULL,
	[Success] [nvarchar](max) NOT NULL,
	[Error] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SendEmail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](250) NOT NULL,
	[Image] [nvarchar](300) NOT NULL,
	[Index] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Home] [bit] NOT NULL,
	[Price] [decimal](18, 1) NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceGallery]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceGallery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceID] [int] NOT NULL,
	[ImageSmall] [nvarchar](300) NOT NULL,
	[ImageLarge] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_RestaurantGallery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[MenuIDs] [nvarchar](250) NULL,
	[Image] [nvarchar](300) NOT NULL,
	[Link] [nvarchar](500) NULL,
	[Index] [int] NULL,
	[ViewAll] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Content] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscribe]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usefullink]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usefullink](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [varchar](10) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Link] [nvarchar](500) NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[Stauts] [bit] NOT NULL,
 CONSTRAINT [PK_Usefullink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/07/2022 9:51:35 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordOld] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (1, N'/files/images/icon/icon_wifi.png', N'Wifi', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (2, N'/files/images/icon/icon_nosmoking.png', N'No smoking', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (3, N'/files/images/icon/icon_phone.png', N'Phone', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (4, N'/files/images/icon/icon_aircondition.png', N'Air-codition', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (5, N'/files/images/icon/icon_birthdaycake.png', N'Birthday', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (6, N'/files/images/icon/icon_tivi.png', N'Tivi', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (7, N'/files/images/icon/icon_car.png', N'Parking', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (8, N'/files/images/icon/icon_swimmingPool.png', N'Pool', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (9, N'/files/images/icon/icon_spa.png', N'Spa', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (10, N'/files/images/icon/icon_vault.png', N'Safe', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (11, N'/files/images/icon/icon_shower.png', N'Shower', 1, 0, 0, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (12, N'/files/images/icon/icon_dumbble.png', N'Gym', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (13, N'/files/images/icon/ico_booking.png', N'Booking', 1, 0, 1, N'en')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (14, N'/files/images/icon/icon_wifi.png', N'Wifi', 1, 5, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (15, N'/files/images/icon/icon_car.png', N'Bãi đỗ xe', 1, 1, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (16, N'/files/images/icon/icon_spa.png', N'Spa', 1, 3, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (17, N'/files/images/icon/icon_swimmingPool.png', N'Bể bơi', 1, 2, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (18, N'/files/images/icon/icon_birthdaycake.png', N'Tiệc sinh nhật', 1, 6, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (19, N'/files/images/icon/icon_dumbble.png', N'Thể thao', 1, 4, 1, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (20, N'/files/images/icon/icon_tivi.png', N'Ti vi', 1, 0, 0, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (21, N'/files/images/icon/icon_phone.png', N'Điện thoại', 1, 0, 0, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (22, N'/files/images/icon/icon_shower.png', N'Vòi tắm hoa sen', 1, 0, 0, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (23, N'/files/images/icon/icon_vault.png', N'Két an toàn', 1, 0, 0, N'vi')
INSERT [dbo].[Amenities] ([ID], [Image], [Title], [Status], [Index], [Home], [languageID]) VALUES (24, N'/files/images/icon/ico_booking.png', N'Đặt trước', 1, 7, 1, N'vi')
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2141, 3241, N'Cities To Visit For Your First Time In Europe', N'cities-to-visit-for-your-first-time-in-europe', N'/files/images/pexels-photo-871053-700x990.jpeg', N'<span style="color:rgb(101, 101, 101)">Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</span>', N'<p>
                                    <strong>Far far away, behind the word mountains</strong>, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large
                                    language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <blockquote class="quote">
                                    <p>
                                        <em>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows.</em>
                                    </p>
                                </blockquote>
                                <div class="block-image">
                                    <figure>
                                        <img src="/Asset/images/bl-img.jpg" alt="">
                                    </figure>
                                </div>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, t<span style="text-decoration: underline">here live the blind texts. Separated they live in Bookm</span>arksgrove right at the
                                    coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted. It with the necessary regelialia.
                                    It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the&nbsp; initial into the belt. The Big Oxmox advised her not to do so, because
                                    there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made
                                </p>
                                <h4><strong>Some Useful Travel Tips</strong></h4>
                                <ul class="list-no-left">
                                    <li>Travel Planning</li>
                                    <li>Staying Like a Local</li>
                                    <li>How to do the budget</li>
                                    <li>How to do the budget</li>
                                </ul>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by
                                    their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <figure class="block-gallery">
                                    <ul class="block-gallery-grid">
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll1.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll2.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll3.jpg" alt="">
                                        </li>
                                    </ul>
                                </figure>
                                <p>The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into
                                    the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline
                                    of her own road, the Line.</p>', 0, N'Cities To Visit For Your First Time In Europe', N'Cities To Visit For Your First Time In Europe', 1, 0, 1, CAST(N'2022-07-08T17:08:11.153' AS DateTime), 0, N'James Doe')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2142, 3241, N'Cities To Visit For Your First Time In Europe2', N'cities-to-visit-for-your-first-time-in-europe2', N'/files/images/shop-slo-vhztm9QC0L0-unsplash-700x990.jpg', N'<span style="color:rgb(101, 101, 101)">Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</span>', N'<p>
                                    <strong>Far far away, behind the word mountains</strong>, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large
                                    language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <blockquote class="quote">
                                    <p>
                                        <em>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows.</em>
                                    </p>
                                </blockquote>
                                <div class="block-image">
                                    <figure>
                                        <img src="/Asset/images/bl-img.jpg" alt="">
                                    </figure>
                                </div>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, t<span style="text-decoration: underline">here live the blind texts. Separated they live in Bookm</span>arksgrove right at the
                                    coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted. It with the necessary regelialia.
                                    It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the&nbsp; initial into the belt. The Big Oxmox advised her not to do so, because
                                    there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made
                                </p>
                                <h4><strong>Some Useful Travel Tips</strong></h4>
                                <ul class="list-no-left">
                                    <li>Travel Planning</li>
                                    <li>Staying Like a Local</li>
                                    <li>How to do the budget</li>
                                    <li>How to do the budget</li>
                                </ul>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by
                                    their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <figure class="block-gallery">
                                    <ul class="block-gallery-grid">
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll1.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll2.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="/Asset/images/gll3.jpg" alt="">
                                        </li>
                                    </ul>
                                </figure>
                                <p>The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into
                                    the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline
                                    of her own road, the Line.</p>', 0, N'Cities To Visit For Your First Time In Europe2', N'Cities To Visit For Your First Time In Europe2', 1, 0, 1, CAST(N'2022-07-08T17:14:43.280' AS DateTime), 0, N'James Doe')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2143, 3235, N'cus1', N'cus1', N'/files/images/insta1.jpg', N'<div>Solo Traveler</div>
', N'<div class="img-quote">&ldquo;</div>

<div class="desc">
<p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence.</p>
</div>
', 0, N'cus1', N'cus1', 1, 0, 1, CAST(N'2022-07-09T10:53:23.770' AS DateTime), 1, N'Joan Smith')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2144, 3235, N'cus2', N'cus2', N'/files/images/insta1.jpg', N'<div>Solo Traveler</div>
', N'<div class="img-quote">&ldquo;</div>

<div class="desc">
<p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence.</p>
</div>
', 0, N'cus2', N'cus2', 1, 0, 1, CAST(N'2022-07-09T10:54:15.300' AS DateTime), 1, N'Joan Smith')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2145, 3238, N'3 Michelin Stars Restaurant, Vézère', N'3-michelin-stars-restaurant-vezere', N'/files/images/chef-cook.jpg', N'<span style="color:rgb(137, 137, 137)">A brasserie inspired by French cuisine, a fresh and modern place to visit and enjoy dishes always handmade of the best ingredients of the season.</span>', N'<span style="color:rgb(137, 137, 137); font-family:jost; font-size:18px">A brasserie inspired by French cuisine, a fresh and modern place to visit and enjoy dishes always handmade of the best ingredients of the season.</span>', 0, N'3 Michelin Stars Restaurant, Vézère', N'3 Michelin Stars Restaurant, Vézère', 1, 0, 1, CAST(N'2022-07-16T02:28:37.990' AS DateTime), 0, N'jame')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2146, 3238, N'The Penthouse Bar, An iconic american bar', N'the-penthouse-bar-an-iconic-american-bar', N'/files/images/bar.jpg', N'<span style="color:rgb(137, 137, 137)">The cozy bar area accompanying the Penthouse is a classic cocktail bar at it&rsquo;s finest. Our experienced bartenders are here to offer you both the classic bewerages and the newest global trends.</span>', N'<span style="color:rgb(137, 137, 137); font-family:jost; font-size:18px">The cozy bar area accompanying the Penthouse is a classic cocktail bar at it&rsquo;s finest. Our experienced bartenders are here to offer you both the classic bewerages and the newest global trends.</span>', 0, N'The Penthouse Bar, An iconic american bar', N'The Penthouse Bar, An iconic american bar', 1, 0, 1, CAST(N'2022-07-16T02:29:16.380' AS DateTime), 0, N'jame')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2147, 3238, N'The Spa. Refresh Yourself', N'the-spa-refresh-yourself', N'/files/images/spa.jpg', N'<span style="color:rgb(137, 137, 137)">Whether you are in search of a well-appointed gym or a pampering moment on the massage table and inside the warm saunas, you can always find a place for yourself at our spa.</span>', N'<span style="color:rgb(137, 137, 137); font-family:jost; font-size:18px">Whether you are in search of a well-appointed gym or a pampering moment on the massage table and inside the warm saunas, you can always find a place for yourself at our spa.</span>', 0, N'The Spa. Refresh Yourself', N'The Spa. Refresh Yourself', 1, 0, 1, CAST(N'2022-07-16T02:30:09.377' AS DateTime), 0, N'jame')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2148, 3252, N'Các thành phố nên đến thăm lần đầu tiên ở châu Âu', N'cac-thanh-pho-nen-den-tham-lan-dau-tien-o-chau-au', N'/files/images/pexels-photo-871053-700x990.jpeg', N'<span style="color:rgb(101, 101, 101)">Xa xa, đằng sau những ngọn n&uacute;i chữ, xa những quốc gia Vokalia v&agrave; Consonantia, c&oacute; những văn tự m&ugrave; mịt.</span>', N'<p>
                                    <strong>Far far away, behind the word mountains</strong>, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large
                                    language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <blockquote class="quote">
                                    <p>
                                        <em>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows.</em>
                                    </p>
                                </blockquote>
                                <div class="block-image">
                                    <figure>
                                        <img src="~Asset/images/bl-img.jpg" alt="">
                                    </figure>
                                </div>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, t<span style="text-decoration: underline">here live the blind texts. Separated they live in Bookm</span>arksgrove right at the
                                    coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted. It with the necessary regelialia.
                                    It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the&nbsp; initial into the belt. The Big Oxmox advised her not to do so, because
                                    there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made
                                </p>
                                <h4><strong>Some Useful Travel Tips</strong></h4>
                                <ul class="list-no-left">
                                    <li>Travel Planning</li>
                                    <li>Staying Like a Local</li>
                                    <li>How to do the budget</li>
                                    <li>How to do the budget</li>
                                </ul>
                                <p>
                                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by
                                    their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted.
                                </p>
                                <figure class="block-gallery">
                                    <ul class="block-gallery-grid">
                                        <li class="block-gallery__item">
                                            <img src="~Asset/images/gll1.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="~Asset/images/gll2.jpg" alt="">
                                        </li>
                                        <li class="block-gallery__item">
                                            <img src="~Asset/images/gll3.jpg" alt="">
                                        </li>
                                    </ul>
                                </figure>
                                <p>The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into
                                    the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline
                                    of her own road, the Line.</p>', 0, N'Các thành phố nên đến thăm lần đầu tiên ở châu Âu', N'Các thành phố nên đến thăm lần đầu tiên ở châu Âu', 1, 0, 1, CAST(N'2022-07-16T08:59:00.297' AS DateTime), 0, N'Hà Tú')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2149, 3252, N'Các Thành Phố Nên Đến Thăm Lần Đầu Tiên Ở Châu Âu 2', N'cac-thanh-pho-nen-den-tham-lan-dau-tien-o-chau-au-2', N'/files/images/shop-slo-vhztm9QC0L0-unsplash-700x990.jpg', N'dsds', N'sdsd', 0, N'Các Thành Phố Nên Đến Thăm Lần Đầu Tiên Ở Châu Âu 2', N'Các Thành Phố Nên Đến Thăm Lần Đầu Tiên Ở Châu Âu 2', 1, 0, 1, CAST(N'2022-07-16T09:04:50.383' AS DateTime), 0, N'Hà Tú')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2150, 3255, N'Mẹo chọn chỗ ở cho kỳ nghỉ', N'meo-chon-cho-o-cho-ky-nghi', N'/files/images/shutterstock_307470824-700x990.jpg', N'đsdsds', N'dsdsds', 0, N'Mẹo chọn chỗ ở cho kỳ nghỉ', N'Mẹo chọn chỗ ở cho kỳ nghỉ', 1, 0, 1, CAST(N'2022-07-16T09:07:58.043' AS DateTime), 0, N'Hà Tú')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2151, 3246, N'cus1', N'cus1', N'/files/images/insta1.jpg', N'Kh&aacute;ch du lịch một m&igrave;nh', N'Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh. T&ocirc;i ở một m&igrave;nh, v&agrave; cảm thấy sự quyến rũ của sự tồn tại.', 0, N'cus1', N'cus1', 1, 0, 1, CAST(N'2022-07-16T09:43:40.030' AS DateTime), 1, N'Joan Smith')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2152, 3246, N'cus2', N'cus2', N'/files/images/insta1.jpg', N'Kh&aacute;ch du lịch một m&igrave;nh', N'Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh. T&ocirc;i ở một m&igrave;nh, v&agrave; cảm thấy sự quyến rũ của sự tồn tại.', 0, N'cus2', N'cus2', 1, 0, 1, CAST(N'2022-07-16T10:04:19.217' AS DateTime), 1, N'Joan Smith')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2153, 3248, N'Nhà hàng 3 sao Michelin, Vézère', N'nha-hang-3-sao-michelin-vezere', N'/files/images/chef-cook.jpg', N'Qu&aacute;n bia lấy cảm hứng từ ẩm thực Ph&aacute;p, một địa điểm mới mẻ v&agrave; hiện đại để tham quan v&agrave; thưởng thức c&aacute;c m&oacute;n ăn lu&ocirc;n được l&agrave;m thủ c&ocirc;ng từ những nguy&ecirc;n liệu tốt nhất trong m&ugrave;a.', N'Qu&aacute;n bia lấy cảm hứng từ ẩm thực Ph&aacute;p, một địa điểm mới mẻ v&agrave; hiện đại để tham quan v&agrave; thưởng thức c&aacute;c m&oacute;n ăn lu&ocirc;n được l&agrave;m thủ c&ocirc;ng từ những nguy&ecirc;n liệu tốt nhất trong m&ugrave;a.<span style="color:rgb(137, 137, 137); font-family:jost; font-size:18px">.</span>', 0, N'Nhà hàng 3 sao Michelin, Vézère', N'Nhà hàng 3 sao Michelin, Vézère', 1, 0, 1, CAST(N'2022-07-16T15:12:41.690' AS DateTime), 0, N'Hà Tú')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2154, 3248, N'The Penthouse Bar, một quán bar mang tính biểu tượng của Mỹ', N'the-penthouse-bar-mot-quan-bar-mang-tinh-bieu-tuong-cua-my', N'/files/images/bar.jpg', N'Khu vực quầy bar ấm c&uacute;ng đi k&egrave;m với Căn hộ &aacute;p m&aacute;i l&agrave; một quầy bar phục vụ cocktail cổ điển tốt nhất tại đ&acirc;y. C&aacute;c nh&acirc;n vi&ecirc;n pha chế gi&agrave;u kinh nghiệm của ch&uacute;ng t&ocirc;i lu&ocirc;n sẵn s&agrave;ng cung cấp cho bạn cả những m&oacute;n ăn cổ điển v&agrave; xu hướng to&agrave;n cầu mới nhất.', N'Khu vực quầy bar ấm c&uacute;ng đi k&egrave;m với Căn hộ &aacute;p m&aacute;i l&agrave; một quầy bar phục vụ cocktail cổ điển tốt nhất tại đ&acirc;y. C&aacute;c nh&acirc;n vi&ecirc;n pha chế gi&agrave;u kinh nghiệm của ch&uacute;ng t&ocirc;i lu&ocirc;n sẵn s&agrave;ng cung cấp cho bạn cả những m&oacute;n ăn cổ điển v&agrave; xu hướng to&agrave;n cầu mới nhất.', 0, N'The Penthouse Bar, một quán bar mang tính biểu tượng của Mỹ', N'The Penthouse Bar, một quán bar mang tính biểu tượng của Mỹ', 1, 0, 1, CAST(N'2022-07-16T15:14:36.030' AS DateTime), 0, N'Hà Tú')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2155, 3248, N'Thẩm mĩ viện. Làm mới bản thân', N'tham-mi-vien-lam-moi-ban-than', N'/files/images/spa.jpg', N'Cho d&ugrave; bạn đang t&igrave;m kiếm một ph&ograve;ng tập thể dục đầy đủ tiện nghi hay một gi&acirc;y ph&uacute;t thư gi&atilde;n tr&ecirc;n b&agrave;n m&aacute;t-xa v&agrave; b&ecirc;n trong c&aacute;c ph&ograve;ng x&ocirc;ng hơi kh&ocirc; ấm &aacute;p, bạn lu&ocirc;n c&oacute; thể t&igrave;m thấy một nơi cho m&igrave;nh tại spa của ch&uacute;ng t&ocirc;i.', N'Cho d&ugrave; bạn đang t&igrave;m kiếm một ph&ograve;ng tập thể dục đầy đủ tiện nghi hay một gi&acirc;y ph&uacute;t thư gi&atilde;n tr&ecirc;n b&agrave;n m&aacute;t-xa v&agrave; b&ecirc;n trong c&aacute;c ph&ograve;ng x&ocirc;ng hơi kh&ocirc; ấm &aacute;p, bạn lu&ocirc;n c&oacute; thể t&igrave;m thấy một nơi cho m&igrave;nh tại spa của ch&uacute;ng t&ocirc;i.', 0, N'Thẩm mĩ viện. Làm mới bản thân', N'Thẩm mĩ viện. Làm mới bản thân', 1, 0, 1, CAST(N'2022-07-16T15:15:49.390' AS DateTime), 0, N'Jame Doe')
INSERT [dbo].[Article] ([ID], [MenuID], [Title], [Alias], [Image], [Description], [Content], [Index], [MetaTitle], [MetaDescription], [Status], [Hot], [Home], [Datetime], [Customer], [Authur]) VALUES (2156, 3245, N'test', N'test', N'/files/images/bl-img.jpg', N'hello', N'hello', 0, N'test', N'test', 1, 0, 0, CAST(N'2022-07-18T09:04:15.963' AS DateTime), 0, N'Hà Tú')
SET IDENTITY_INSERT [dbo].[Article] OFF
GO
SET IDENTITY_INSERT [dbo].[BookRoom] ON 

INSERT [dbo].[BookRoom] ([ID], [Code], [Gender], [FullName], [Email], [Phone], [Address], [City], [Country], [Smoking], [ArrivalFlight], [ArrivalTime], [Request], [CheckIn], [CheckOut], [Adult], [Child], [DateBook], [InfoBooking], [TotalMoney]) VALUES (1048, N'TAH1', N'Mr', N'ha tu', N'hatu@gmail', N'098765432', NULL, NULL, N'Viet nam', 0, NULL, NULL, NULL, CAST(N'2022-07-16T00:00:00.000' AS DateTime), CAST(N'2022-07-17T00:00:00.000' AS DateTime), 1, 0, CAST(N'2022-07-16T01:41:16.073' AS DateTime), N'Luxury Suite = 1, ', CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[BookRoom] ([ID], [Code], [Gender], [FullName], [Email], [Phone], [Address], [City], [Country], [Smoking], [ArrivalFlight], [ArrivalTime], [Request], [CheckIn], [CheckOut], [Adult], [Child], [DateBook], [InfoBooking], [TotalMoney]) VALUES (1049, N'TAH1049', N'Mr', N'ha tu', N'hatu@gmail', N'0987654', NULL, NULL, N'Viet nam', 0, NULL, NULL, N'l,kmjhgfd', CAST(N'2022-07-16T00:00:00.000' AS DateTime), CAST(N'2022-07-17T00:00:00.000' AS DateTime), 1, 0, CAST(N'2022-07-16T01:47:47.787' AS DateTime), N'', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[BookRoom] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (47, N'nice', N'hatu@gmail', N'https://webhotel.com.vn/', CAST(N'2022-07-16T15:24:56.943' AS DateTime), 2142, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (48, N'perfect', N'hatu@gmail', N'https://webhotel.com.vn', CAST(N'2022-07-16T15:27:13.193' AS DateTime), 2142, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (49, N'oke bro', N'info@webhotel.com.vn', N'https://webhotel.com.vn/', CAST(N'2022-07-16T15:55:57.807' AS DateTime), 2142, N'Web Hotel', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (50, N'good', N'hatu@gmail', N'https://webhotel.com.vn', CAST(N'2022-07-16T15:56:35.203' AS DateTime), 2142, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (51, N'oke', N'hatu@gmail', N'https://webhotel.com.vn', CAST(N'2022-07-16T15:56:49.937' AS DateTime), 2142, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (52, N'hay', N'hatu@gmail', N'https://webhotel.com.vn', CAST(N'2022-07-16T15:57:39.307' AS DateTime), 2149, N'ha tu', N'vi')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (53, N'hay', N'info@webhotel.com.vn', N'https://webhotel.com.vn', CAST(N'2022-07-16T15:57:50.253' AS DateTime), 2149, N'Web Hotel', N'vi')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (54, N'dsdsd', N'hatu@gmail', N'https://webhotel.com.vn/', CAST(N'2022-07-16T16:00:26.343' AS DateTime), 2148, N'tu', N'vi')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (55, N'sdsd', N'hatu@gmail', N'https://webhotel.com.vn', CAST(N'2022-07-16T16:00:36.700' AS DateTime), 2148, N'sasa', N'vi')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (56, N'oh no', N'hatu@gmail', N'sasas', CAST(N'2022-07-16T16:06:16.760' AS DateTime), 2141, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (57, N'dsdsds', N'hatu@gmail', N'sasas', CAST(N'2022-07-16T16:07:44.550' AS DateTime), 2141, N'ha tu', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (58, N'dsdsd', N'haoctua1k5@gmail.com', N'https://webhotel.vn/', CAST(N'2022-07-16T16:21:52.087' AS DateTime), 2148, N'Web Hotel', N'vi')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (59, N'dsdsd', N'haoctua1k5@gmail.com', N'dsds', CAST(N'2022-07-16T16:22:32.437' AS DateTime), 2141, N'sdsd', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (60, N'dd', N'haoctua1k5@gmail.com', N'https://webhotel.vn/', CAST(N'2022-07-16T16:28:44.393' AS DateTime), 2141, N'Web Hotel', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (61, N'kjhgfd', N'haoctua1k5@gmail.com', N'https://webhotel.vn/', CAST(N'2022-07-16T16:30:26.333' AS DateTime), 2142, N'Web Hotel', N'en')
INSERT [dbo].[Comment] ([ID], [Comment], [Email], [Website], [CreateDate], [ArticleID], [Name], [languageID]) VALUES (62, N'jhgfd', N'haoctua1k5@gmail.com', N'https://webhotel.vn/', CAST(N'2022-07-16T16:30:57.683' AS DateTime), 2141, N'Web Hotel', N'en')
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[ConfigWebsite] ON 

INSERT [dbo].[ConfigWebsite] ([ID], [Port], [Email], [Password], [Host]) VALUES (2, 25, N'xspamx001@gmail.com', N'h8HFwul9dZCX93sKC/2bYQ==', N'smtp.gmail.com')
SET IDENTITY_INSERT [dbo].[ConfigWebsite] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID], [CreateDate], [Gender], [FullName], [Email], [Country], [Request]) VALUES (2040, CAST(N'2022-07-09T19:01:58.480' AS DateTime), N'Mr', N'ha tu', N'hatu@gmail', N'viet nam', N'gggggg')
INSERT [dbo].[Contact] ([ID], [CreateDate], [Gender], [FullName], [Email], [Country], [Request]) VALUES (2041, CAST(N'2022-07-09T19:14:19.393' AS DateTime), N'Mr', N'ha tu', N'hatu@gmail.com', N'viet nam', N'test')
INSERT [dbo].[Contact] ([ID], [CreateDate], [Gender], [FullName], [Email], [Country], [Request]) VALUES (2042, CAST(N'2022-07-09T19:16:48.077' AS DateTime), N'Mr', N'ha tu', N'hatu@gmail.com', N'viet nam', N'test')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Enquiry] ON 

INSERT [dbo].[Enquiry] ([ID], [Name], [Email], [Enquiry], [CreateDate]) VALUES (1, N'sá', N'hatu@gmail', N'âsa', CAST(N'2022-07-14T23:02:36.530' AS DateTime))
SET IDENTITY_INSERT [dbo].[Enquiry] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedBack] ON 

INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (2, N'oke', 2, N'tu', CAST(N'2022-07-15T11:29:59.687' AS DateTime), 2019, N'/files/images/avatar.png', N'en', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (3, N'oke', 5, N'asasa', CAST(N'2022-07-15T11:42:42.263' AS DateTime), 2020, N'/files/images/avatar.png', N'en', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (4, N'oke đấy', 5, N'ha tu', CAST(N'2022-07-15T14:09:52.950' AS DateTime), 2019, N'/files/images/avatar.png', N'en', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (5, N'ưeew', 3, N'tu', CAST(N'2022-07-15T14:15:25.577' AS DateTime), 2019, N'/files/images/avatar.png', N'en', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (6, N'nice', 5, N'tu', CAST(N'2022-07-15T14:16:12.393' AS DateTime), 2020, N'/files/images/avatar.png', N'en', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (7, N'Tuyệt', 5, N'Hà Ngọc Tú', CAST(N'2022-07-16T06:26:16.437' AS DateTime), 2028, N'/files/images/avatar.png', N'vi', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (8, N'Tuyệt', 4, N'ha tu', CAST(N'2022-07-16T06:27:02.670' AS DateTime), 2029, N'/files/images/avatar.png', N'vi', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (9, N'Kh&ocirc;ng giống giới thiệu', 3, N'tu', CAST(N'2022-07-16T06:27:53.797' AS DateTime), 2028, N'/files/images/avatar.png', N'vi', 0)
INSERT [dbo].[FeedBack] ([ID], [Content], [Star], [Name], [CreateDate], [RoomId], [Avatar], [langaugeID], [Index]) VALUES (10, N'Tuyệt', 5, N'sasa', CAST(N'2022-07-16T06:28:18.610' AS DateTime), 2029, N'/files/images/avatar.png', N'vi', 0)
SET IDENTITY_INSERT [dbo].[FeedBack] OFF
GO
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1110, N'insta1', 0, N'/Files/_thumbs/images/insta1.jpg', N'/files/images/insta1.jpg', NULL)
INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1111, N'insta2', 0, N'/Files/_thumbs/images/insta2.jpg', N'/files/images/insta2.jpg', NULL)
INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1112, N'insta3', 0, N'/Files/_thumbs/images/insta3.jpg', N'/files/images/insta3.jpg', NULL)
INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1113, N'4', 0, N'/Files/_thumbs/images/insta4.jpg', N'/files/images/insta4.jpg', NULL)
INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1114, N'5', 0, N'/Files/_thumbs/images/insta5.jpg', N'/files/images/insta5.jpg', NULL)
INSERT [dbo].[Gallery] ([ID], [Title], [Index], [SmallImage], [LargeImage], [MenuId]) VALUES (1115, N'6', 0, N'/Files/_thumbs/images/insta6.jpg', N'/files/images/insta6.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Gallery] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([ID], [LanguageID], [Name], [Logo], [Image], [Tel], [Hotline], [Fax], [Email], [Address], [Location], [CodeBooking], [Website], [Condition], [Tripadvisor], [Facebook], [Instagram], [Twitter], [Youtube], [CopyRight], [MetaTitle], [MetaDescription], [Favicon]) VALUES (3, N'en', N'Web Hotel', N'/files/images/Logotienlocpalace.png', N'/files/images/Logotienlocpalace(1).png', N' (024) 2242 0777', N'0984071155', NULL, N'info@webhotel.com.vn', N'4th Floor, 147 Mai Dich Street, Cau Giay District, Hanoi', N'lat: 21.272348, lng: 106.094957', N'IIT', N'https://webhotel.com.vn/', N'<strong>About payment</strong>
<ul>
	<li>Payment can be made in two ways: direct payment at the hotel (cash, credit card) or bank transfer. All payments should be completed before or immediately upon check out.</li>
	<li>All payments will be subject to 10% Government Tax and 5% service charge</li>
	<li>Payment by credit card will not be charged any additional fee (effective from January 2017)</li>
	<li>The hotel does not accept payment by cheque</li>
</ul>
<br />
<strong>Check-in / Check-out:</strong>

<ul>
	<li>The hotel&#39;s fixed check-in time is 14:00 pm</li>
	<li>The hotel&#39;s fixed check-out time is 12:00 noon</li>
	<li>Guests can check in earlier than the check-in time subject to availability. For early check-in, we recommend you to book a night in advance to make sure your room is available.</li>
	<li>Check-in before 8:00 am will be charged 100% of the room price and include breakfast</li>
	<li>Check-in after 8:00 am will be charged 50% of the room price and exclude breakfast.</li>
	<li>Late check-out before 18:00 will be charged 50% of the room price.</li>
	<li>Late check-out after 18:00 will be charged 100% of the room price.</li>
</ul>
<br />
<strong>Reservation Policy:</strong>

<ul>
	<li>Valid credit card information will be required when making a reservation</li>
	<li>50% of room charge will be required for deposit upon booking</li>
	<li>In case you do not use credit card, please contact us directly via email <span style="color:#0000FF">info@webhotel.vn</span> for further instructions.</li>
	<li>The hotel may cancel the booking without notice if the hotel receives notice of any fraud or criminal activity related to the payments received.</li>
</ul>
<br />
<strong>Children Policy:</strong>

<ul>
	<li>Children under 6 year olds: sharing bed with parents and free breakfast (Maximum 2 children per room)</li>
	<li>Children between 6 and 11 years old: sharing bed with parents and extra charge of USD $8 for breakfast</li>
	<li>Children from 12 years old will be charged as an adults and an extra bed is required (extra bed is USD $18 - breakfast included)</li>
</ul>
', N'https://www.tripadvisor.com.vn/Hotel_Review-g6776104-d21321523-Reviews-Thien_An_Hotel_Bac_Giang-Bac_Giang_Bac_Giang_Province.html', N'https://www.facebook.com', NULL, NULL, NULL, N'Copyright © Web Hotel. 2018 All Rights Reserved', N'Web Hotel', N'Our hotel is located in the heart of the New Forrest. A five stars lifestyle surrounded by the forest.', NULL)
INSERT [dbo].[Hotel] ([ID], [LanguageID], [Name], [Logo], [Image], [Tel], [Hotline], [Fax], [Email], [Address], [Location], [CodeBooking], [Website], [Condition], [Tripadvisor], [Facebook], [Instagram], [Twitter], [Youtube], [CopyRight], [MetaTitle], [MetaDescription], [Favicon]) VALUES (4, N'vi', N'Web Hotel', N'/files/files/logo1.png', N'/files/files/logo1.png', N'(024) 2242 0777', N'0984071155', NULL, N'info@webhotel.com.vn', N'Tầng 4, 147 Mai Dịch, Cầu Giấy, Hà Nội', N'lat: 21.272348, lng: 106.094957', N'IIT', N'https://webhotel.com.vn/', N'<strong>Quy định thanh to&aacute;n:</strong>
<ul>
	<li>Việc thanh to&aacute;n c&oacute; thể th&ocirc;ng qua 2 h&igrave;nh thức: thanh to&aacute;n trực tiếp tại kh&aacute;ch sạn (tiền mặt, thẻ ng&acirc;n h&agrave;ng) hoặc chuyển khoản. Mọi khoản thanh to&aacute;n cần được ho&agrave;n th&agrave;nh trước hoặc ngay khi trả ph&ograve;ng.</li>
	<li>Mọi khoản thanh to&aacute;n sẽ t&iacute;nh th&ecirc;m 10% thuế Gi&aacute; trị gia tăng (VAT) v&agrave; 5% ph&iacute; dịch vụ</li>
	<li>Việc thanh to&aacute;n qua thẻ sẽ kh&ocirc;ng bị t&iacute;nh th&ecirc;m bất cứ phụ ph&iacute; n&agrave;o (&aacute;p dụng từ th&aacute;ng 01 năm 2017)</li>
	<li>Kh&aacute;ch sạn kh&ocirc;ng nhận thanh to&aacute;n bằng s&eacute;c (Cheque)</li>
</ul>
<br />
<strong>Quy định về nhận/trả ph&ograve;ng:</strong>

<ul>
	<li>Giờ nhận ph&ograve;ng cố định của kh&aacute;ch sạn l&agrave; 14:00 chiều</li>
	<li>Giờ trả ph&ograve;ng cố định của kh&aacute;ch sạn l&agrave; 12:00 trưa</li>
	<li>Kh&aacute;ch c&oacute; thể nhận ph&ograve;ng sớm hơn qui định trong điều kiện c&oacute; ph&ograve;ng sẵn s&agrave;ng. Đối với những trường hợp nhận ph&ograve;ng sớm n&agrave;y, ch&uacute;ng t&ocirc;i khuy&ecirc;n qu&yacute; kh&aacute;ch n&ecirc;n đặt ph&ograve;ng cả đ&ecirc;m trước đ&oacute; để đảm bảo lu&ocirc;n c&oacute; ph&ograve;ng sẵn s&agrave;ng.</li>
	<li>Nhận ph&ograve;ng trước 8:00 s&aacute;ng t&iacute;nh 100% gi&aacute; trị tiền ph&ograve;ng c&oacute; bao gồm ăn s&aacute;ng</li>
	<li>Nhận ph&ograve;ng sau 8:00 s&aacute;ng t&iacute;nh 50% gi&aacute; trị tiền ph&ograve;ng v&agrave; kh&ocirc;ng bao gồm ăn s&aacute;ng.</li>
	<li>Trả ph&ograve;ng trễ trước 18:00 t&iacute;nh 50% gi&aacute; trị tiền ph&ograve;ng</li>
	<li>Trả ph&ograve;ng trễ sau 18:00 t&iacute;nh 100% gi&aacute; trị tiền ph&ograve;ng</li>
</ul>
<br />
<strong>Quy định về đảm bảo đặt ph&ograve;ng:</strong>

<ul>
	<li>Th&ocirc;ng tin thẻ t&iacute;n dụng hợp lệ sẽ được y&ecirc;u cầu khi tạo đặt ph&ograve;ng</li>
	<li>50% tiền ph&ograve;ng sẽ được y&ecirc;u cầu đặt cọc khi thực hiện đặt ph&ograve;ng</li>
	<li>Trong trường hợp qu&yacute; kh&aacute;ch kh&ocirc;ng d&ugrave;ng thẻ t&iacute;n dụng, vui l&ograve;ng li&ecirc;n hệ trực tiếp qua email <span style="color:#0000FF">info@webhotel.vn</span> để được hướng dẫn th&ecirc;m.</li>
	<li>Kh&aacute;ch sạn c&oacute; thể hủy bỏ đặt ph&ograve;ng m&agrave; kh&ocirc;ng th&ocirc;ng b&aacute;o nếu kh&aacute;ch sạn nhận được th&ocirc;ng b&aacute;o về bất cứ gian lận hay c&aacute;c hoạt động phạm ph&aacute;p c&oacute; li&ecirc;n quan đến c&aacute;c khoản thanh to&aacute;n đ&atilde; nhận được.</li>
</ul>
<br />
<strong>Ch&iacute;nh s&aacute;ch &aacute;p dụng cho trẻ em:</strong>

<ul>
	<li>Trẻ dưới 6 tuổi sẽ ngủ chung giường c&ugrave;ng bố mẹ v&agrave; được miễn ph&iacute; ăn s&aacute;ng (Tối đa 2 trẻ/ph&ograve;ng)</li>
	<li>Trẻ từ 6 đến 11 tuổi sẽ ngủ chung giường c&ugrave;ng bố mẹ v&agrave; phụ thu th&ecirc;m 180,000 VND ph&iacute; ăn s&aacute;ng</li>
	<li>Trẻ từ 12 tuổi trở l&ecirc;n sẽ được t&iacute;nh như một người lớn v&agrave; y&ecirc;u cầu phải đặt th&ecirc;m giường phụ (ph&iacute; giường phụ l&agrave; 400,000 VND - bao gồm ph&iacute; ăn s&aacute;ng)</li>
</ul>
', N'https://www.tripadvisor.com.vn/Hotel_Review-g6776104-d21321523-Reviews-Thien_An_Hotel_Bac_Giang-Bac_Giang_Bac_Giang_Province.html', N'https://www.facebook.com/ThienAnHotelBacGiang', NULL, NULL, NULL, N'Copyright © Web Hotel  . 2018 All Rights Reserved', N'Web Hotel', N'Khách sạn của chúng tôi nằm ở trung tâm của New Forrest. Một lối sống năm sao được bao quanh bởi khu rừng.', NULL)
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[HotelRule] ON 

INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (1, N'Smoking not allowed', 1, 0, N'en')
INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (2, N'Pets not allowed', 1, 0, N'en')
INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (3, N'Swimming pool closed from 8.00pm - 6.00am', 1, 0, N'en')
INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (4, N'Không được phép hút thuốc', 1, 0, N'vi')
INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (5, N'Vật nuôi không được phép', 1, 0, N'vi')
INSERT [dbo].[HotelRule] ([ID], [Rule], [Status], [Index], [languageID]) VALUES (6, N'Hồ bơi đóng cửa từ 8.00 tối - 6.00 sáng', 1, 0, N'vi')
SET IDENTITY_INSERT [dbo].[HotelRule] OFF
GO
INSERT [dbo].[Language] ([ID], [Name], [Icon], [Default]) VALUES (N'en', N'English', N'/files/images/comment/English.png', 1)
INSERT [dbo].[Language] ([ID], [Name], [Icon], [Default]) VALUES (N'vi', N'Vietnamese', N'/files/images/comment/vietnamese.png', 1)
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3235, N'en', N'Home', N'', 0, 1, 0, 1, 0, NULL, N'Book Your Vacation', N'Home', 1, NULL, N'<span style="color:rgb(10, 10, 10)">Our hotel is located in the heart of the New Forrest. A five stars lifestyle surrounded by the forest.</span>')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3236, N'en', N'Rooms', N'rooms', 0, 3, 2, 1, 0, NULL, N'Rooms', N'Rooms', 1, NULL, N'<span style="color:rgb(137, 137, 137)">A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of soul.</span>')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3237, N'en', N'Pages', N'pages', 0, 2, 1, 1, 0, NULL, N'Pages', N'Pages', 1, NULL, N'A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3238, N'en', N'About us', N'about-us', 3237, 10, 1, 1, 1, NULL, N'About us', N'Visit Our Famous Facilities', 1, NULL, N'<span style="color:rgb(137, 137, 137)">A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.</span>')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3239, N'en', N'Gallery', N'gallery', 3237, 7, 2, 1, 1, NULL, N'Gallery', N'Gallery', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3240, N'en', N'Reservation', N'reservation', 0, 12, 3, 1, 0, NULL, N'Reservation', N'Reservation', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3241, N'en', N'Blogs', N'blogs', 0, 2, 4, 1, 0, NULL, N'Blog Full Right Sidebar', N'Blogs', 1, NULL, N'A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3242, N'en', N'Contact', N'contact', 0, 5, 5, 1, 0, NULL, N'Contact', N'Contact', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3244, N'en', N'Planning', N'planning', 0, 2, 0, 1, 0, NULL, N'Planning', N'Planning', 0, NULL, N'A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3245, N'en', N'Tips', N'tips', 0, 2, 0, 1, 0, NULL, N'Tips', N'Tips', 0, NULL, N'A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3246, N'vi', N'Trang chủ', N'', 0, 1, 0, 1, 0, NULL, N'Đặt kỳ nghỉ của bạn', N'Trang chủ', 1, NULL, N'<span style="background-color:rgb(248, 249, 250); color:rgb(32, 33, 36)">Kh&aacute;ch sạn của ch&uacute;ng t&ocirc;i nằm ở trung t&acirc;m của New Forrest. Một lối sống năm sao được bao quanh bởi khu rừng.</span><span style="background-color:rgb(248, 249, 250); color:rgb(32, 33, 36)">Kh&aacute;ch sạn của ch&uacute;ng t&ocirc;i nằm ở trung t&acirc;m của New Forrest. Một lối sống năm sao được bao quanh bởi khu rừng.</span><span style="background-color:rgb(248, 249, 250); color:rgb(32, 33, 36)">Kh&aacute;ch sạn của ch&uacute;ng t&ocirc;i nằm ở trung t&acirc;m của New Forrest. Một lối sống năm sao được bao quanh bởi khu rừng.</span>')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3247, N'vi', N'Khác', N'khac', 0, 2, 0, 1, 0, NULL, N'Khác', N'Khác', 1, NULL, N'Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3248, N'vi', N'Về chúng tôi', N've-chung-toi', 3247, 10, 0, 1, 1, NULL, N'Về chúng tôi', N'Ghé Thăm Các Cơ Sở Nổi Tiếng Của Chúng Tôi', 1, NULL, N'<span style="background-color:rgb(248, 249, 250); color:rgb(32, 33, 36)">Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh.</span><span style="background-color:rgb(248, 249, 250); color:rgb(32, 33, 36)">Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh.</span>')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3249, N'vi', N'Phòng trưng bày', N'phong-trung-bay', 3247, 7, 0, 1, 1, NULL, N'Phòng trưng bày', N'Phòng trưng bày', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3250, N'vi', N'Phòng', N'phong', 0, 3, 0, 1, 0, NULL, N'Phòng', N'Phòng', 1, NULL, N'Một sự thanh thản tuyệt vời đ&atilde; chiếm hữu to&agrave;n bộ t&acirc;m hồn t&ocirc;i, như những buổi s&aacute;ng m&ugrave;a xu&acirc;n ngọt ng&agrave;o m&agrave; t&ocirc;i tận hưởng bằng cả tr&aacute;i tim m&igrave;nh. T&ocirc;i chỉ c&oacute; một m&igrave;nh, v&agrave; cảm nhận được sức hấp dẫn của sự tồn tại ở nơi n&agrave;y, nơi được tạo ra để mang lại niềm hạnh ph&uacute;c cho t&acirc;m hồn.')
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3251, N'vi', N'Tìm phòng', N'tim-phong', 0, 12, 0, 1, 0, NULL, N'Tìm phòng', N'Tìm phòng', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3252, N'vi', N'Bài viết', N'bai-viet', 0, 2, 0, 1, 0, NULL, N'Bài viết', N'Bài viết', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3253, N'vi', N'Liên hệ', N'lien-he', 0, 5, 0, 1, 0, NULL, N'Liên hệ chúng tôi', N'Liên hệ', 1, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3254, N'vi', N'Kế hoạch', N'ke-hoach', 0, 2, 0, 1, 0, NULL, N'Kế hoạch', N'Kế hoạch', 0, NULL, NULL)
INSERT [dbo].[Menu] ([ID], [LanguageID], [Title], [Alias], [ParentID], [Type], [Index], [Location], [Level], [Link], [MetaTitle], [MetaDescription], [Status], [Image], [Description]) VALUES (3255, N'vi', N'Mẹo hay', N'meo-hay', 0, 2, 0, 1, 0, NULL, N'Mẹo hay', N'Mẹo hay', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Plugin] ON 

INSERT [dbo].[Plugin] ([ID], [CSS], [JS], [SideBar]) VALUES (2, NULL, N'<!-- Load Facebook SDK for JavaScript -->
      <div id="fb-root"></div>
      <script>
        window.fbAsyncInit = function() {
          FB.init({
            xfbml            : true,
            version          : ''v9.0''
          });
        };

        (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = ''https://connect.facebook.net/vi_VN/sdk/xfbml.customerchat.js'';
        fjs.parentNode.insertBefore(js, fjs);
      }(document, ''script'', ''facebook-jssdk''));</script>

      <!-- Your Chat Plugin code -->
      <div class="fb-customerchat"
        attribution=setup_tool
        page_id="119675056359570"
  theme_color="#2d5a6d"
  logged_in_greeting="Welcome to Thien An Hotel!!! Can I Help You???"
  logged_out_greeting="Welcome to Thien An Hotel!!! Can I Help You???">
      </div>', NULL)
SET IDENTITY_INSERT [dbo].[Plugin] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([ID], [LanguageID], [Title], [Alias], [Image], [MaxPeople], [Price], [PriceNet], [Index], [Description], [Content], [MetaTitle], [MetaDescription], [Status], [Home], [Roomspace], [Roomview], [Typebed], [Numofbed]) VALUES (2019, N'en', N'Luxury Suite', N'luxury-suite', N'/files/images/gll-ho4.jpg', 3, CAST(90 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 0, N'<span style="color:rgb(101, 101, 101)">Room Features</span>', N'<p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar.</p>

<p>The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn&rsquo;t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown</p>
', N'xcxc', N'xcxc', 1, 1, CAST(40 AS Decimal(18, 0)), N'hgfhg', N'king', 2)
INSERT [dbo].[Room] ([ID], [LanguageID], [Title], [Alias], [Image], [MaxPeople], [Price], [PriceNet], [Index], [Description], [Content], [MetaTitle], [MetaDescription], [Status], [Home], [Roomspace], [Roomview], [Typebed], [Numofbed]) VALUES (2020, N'en', N'Premium Room', N'premium-room', N'/files/images/room1.jpg', 2, CAST(80 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 0, N's&aacute;as', N'&acirc;sasas', N'Premium Room', N'Premium Room', 1, 1, CAST(80 AS Decimal(18, 0)), N'beach', N'single bed', 2)
INSERT [dbo].[Room] ([ID], [LanguageID], [Title], [Alias], [Image], [MaxPeople], [Price], [PriceNet], [Index], [Description], [Content], [MetaTitle], [MetaDescription], [Status], [Home], [Roomspace], [Roomview], [Typebed], [Numofbed]) VALUES (2028, N'vi', N'Phòng sang trọng', N'phong-sang-trong', N'/files/images/gll-ho4.jpg', 2, CAST(60 AS Decimal(18, 0)), NULL, 0, N'​Xa xa, đằng sau những ngọn n&uacute;i chữ, xa những quốc gia Vokalia v&agrave; Consonantia, c&oacute; những văn tự m&ugrave; mịt.', N'Xa xa, đằng sau những ngọn n&uacute;i chữ, xa những quốc gia Vokalia v&agrave; Consonantia, c&oacute; những văn tự m&ugrave; mịt. T&aacute;ch ra, họ sống trong Bookmarksgrove ngay tại bờ biển Semantics, một đại dương ng&ocirc;n ngữ rộng lớn. Một con s&ocirc;ng nhỏ c&oacute; t&ecirc;n Duden chảy qua nơi họ ở v&agrave; cung cấp cho n&oacute; những chất dinh dưỡng cần thiết. Đ&oacute; l&agrave; một đất nước hoang tưởng, trong đ&oacute; c&aacute;c phần rang của c&acirc;u bay v&agrave;o miệng của bạn. Ngay cả Pointing to&agrave;n năng cũng kh&ocirc;ng kiểm so&aacute;t được c&aacute;c văn bản m&ugrave;, n&oacute; gần như l&agrave; một cuộc sống gần như kh&ocirc;ng c&oacute; thần thoại Một ng&agrave;y nọ, một d&ograve;ng văn bản m&ugrave; nhỏ mang t&ecirc;n Lorem Ipsum quyết định rời đến Thế giới Ngữ ph&aacute;p xa x&ocirc;i.<br />
<br />
Big Oxmox khuy&ecirc;n c&ocirc; kh&ocirc;ng n&ecirc;n l&agrave;m như vậy, bởi v&igrave; c&oacute; h&agrave;ng ng&agrave;n Dấu phẩy xấu, Dấu hỏi hoang d&atilde; v&agrave; Semikoli ranh ma, nhưng Little Blind Text kh&ocirc;ng nghe. C&ocirc; đ&oacute;ng g&oacute;i bảy Versalia của m&igrave;nh, đặt ban đầu của m&igrave;nh v&agrave;o thắt lưng v&agrave; tự m&igrave;nh l&ecirc;n đường. Khi đến những ngọn đồi đầu ti&ecirc;n của D&atilde;y n&uacute;i Italic, c&ocirc; ấy đ&atilde; c&oacute; c&aacute;i nh&igrave;n cuối c&ugrave;ng về đường ch&acirc;n trời của qu&ecirc; hương m&igrave;nh', N'Phòng tiêu chuẩn sang trọng', N'Phòng tiêu chuẩn sang trọng', 1, 1, CAST(80 AS Decimal(18, 0)), N'Biển', N'Giường vua', 1)
INSERT [dbo].[Room] ([ID], [LanguageID], [Title], [Alias], [Image], [MaxPeople], [Price], [PriceNet], [Index], [Description], [Content], [MetaTitle], [MetaDescription], [Status], [Home], [Roomspace], [Roomview], [Typebed], [Numofbed]) VALUES (2029, N'vi', N'Phòng cao cấp', N'phong-cao-cap', N'/files/images/room1.jpg', 3, CAST(70 AS Decimal(18, 0)), NULL, 0, N'Xa xa, đằng sau những ngọn n&uacute;i chữ, xa những quốc gia Vokalia v&agrave; Consonantia, c&oacute; những văn tự m&ugrave; mịt.', N'Xa xa, đằng sau những ngọn n&uacute;i chữ, xa những quốc gia Vokalia v&agrave; Consonantia, c&oacute; những văn tự m&ugrave; mịt. T&aacute;ch ra, họ sống trong Bookmarksgrove ngay tại bờ biển Semantics, một đại dương ng&ocirc;n ngữ rộng lớn. Một con s&ocirc;ng nhỏ c&oacute; t&ecirc;n Duden chảy qua nơi họ ở v&agrave; cung cấp cho n&oacute; những chất dinh dưỡng cần thiết. Đ&oacute; l&agrave; một đất nước hoang tưởng, trong đ&oacute; c&aacute;c phần rang của c&acirc;u bay v&agrave;o miệng của bạn. Ngay cả Pointing to&agrave;n năng cũng kh&ocirc;ng kiểm so&aacute;t được c&aacute;c văn bản m&ugrave;, n&oacute; gần như l&agrave; một cuộc sống gần như kh&ocirc;ng c&oacute; thần thoại Một ng&agrave;y nọ, một d&ograve;ng văn bản m&ugrave; nhỏ mang t&ecirc;n Lorem Ipsum quyết định rời đến Thế giới Ngữ ph&aacute;p xa x&ocirc;i.<br />
<br />
Big Oxmox khuy&ecirc;n c&ocirc; kh&ocirc;ng n&ecirc;n l&agrave;m như vậy, bởi v&igrave; c&oacute; h&agrave;ng ng&agrave;n Dấu phẩy xấu, Dấu hỏi hoang d&atilde; v&agrave; Semikoli ranh ma, nhưng Little Blind Text kh&ocirc;ng nghe. C&ocirc; đ&oacute;ng g&oacute;i bảy Versalia của m&igrave;nh, đặt ban đầu của m&igrave;nh v&agrave;o thắt lưng v&agrave; tự m&igrave;nh l&ecirc;n đường. Khi đến những ngọn đồi đầu ti&ecirc;n của D&atilde;y n&uacute;i Italic, c&ocirc; ấy đ&atilde; c&oacute; c&aacute;i nh&igrave;n cuối c&ugrave;ng về đường ch&acirc;n trời của qu&ecirc; hương m&igrave;nh', N'Premium Room', N'Premium Room', 1, 1, CAST(80 AS Decimal(18, 0)), N'Biển', N'Giường đôi', 2)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomAmenity] ON 

INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (31, 2019, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (32, 2019, 3)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (33, 2019, 6)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (34, 2019, 10)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (35, 2019, 11)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (36, 2020, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (37, 2020, 3)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (38, 2020, 6)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (39, 2020, 10)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (40, 2020, 11)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (81, 2028, 14)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (82, 2028, 20)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (83, 2028, 21)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (84, 2028, 22)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (85, 2028, 23)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (86, 2029, 14)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (87, 2029, 20)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (88, 2029, 21)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (89, 2029, 22)
INSERT [dbo].[RoomAmenity] ([RoomAmenityID], [RoomID], [AmenityID]) VALUES (90, 2029, 23)
SET IDENTITY_INSERT [dbo].[RoomAmenity] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomGallery] ON 

INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4655, 2019, N'/Files/_thumbs/images/gll-ho3.jpg', N'/files/images/gll-ho3.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4656, 2019, N'/Files/_thumbs/images/gll-ho7.jpg', N'/files/images/gll-ho7.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4657, 2019, N'/Files/_thumbs/images/gll-ho6.jpg', N'/files/images/gll-ho6.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4658, 2019, N'/Files/_thumbs/images/gll-ho9.jpg', N'/files/images/gll-ho9.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4659, 2020, N'/Files/_thumbs/images/grid4.jpg', N'/files/images/grid4.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4660, 2020, N'/Files/_thumbs/images/grid2.jpg', N'/files/images/grid2.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4661, 2020, N'/Files/_thumbs/images/gll-ho4.jpg', N'/files/images/gll-ho4.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4662, 2020, N'/Files/_thumbs/images/gll-ho9.jpg', N'/files/images/gll-ho9.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4696, 2028, N'/Files/_thumbs/images/gll-ho9.jpg', N'/files/images/gll-ho9.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4697, 2028, N'/Files/_thumbs/images/gll-ho7.jpg', N'/files/images/gll-ho7.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4698, 2028, N'/Files/_thumbs/images/gll-ho1.jpg', N'/files/images/gll-ho1.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4699, 2028, N'/Files/_thumbs/images/gll-ho6.jpg', N'/files/images/gll-ho6.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4700, 2028, N'/Files/_thumbs/images/gll-ho2.jpg', N'/files/images/gll-ho2.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4701, 2029, N'/Files/_thumbs/images/gll-ho1.jpg', N'/files/images/gll-ho1.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4702, 2029, N'/Files/_thumbs/images/bl-img.jpg', N'/files/images/bl-img.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4703, 2029, N'/Files/_thumbs/images/gll-ho7.jpg', N'/files/images/gll-ho7.jpg')
INSERT [dbo].[RoomGallery] ([RoomGalleryId], [RoomId], [ImageSmall], [ImageLarge]) VALUES (4704, 2029, N'/Files/_thumbs/images/gll-ho9.jpg', N'/files/images/gll-ho9.jpg')
SET IDENTITY_INSERT [dbo].[RoomGallery] OFF
GO
SET IDENTITY_INSERT [dbo].[SendEmail] ON 

INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (1, N'Your contact at {NameHotel}', 1, N'en', N'<h2>Dear {Gender}. {FullName},</h2>
<span style="color:rgb(34, 34, 34); font-family:arial,sans-serif; font-size:14px">Your information has been submitted successfully. We will get back to you within 24 hours!&nbsp;</span>

<h3>Info contact</h3>
<strong>Fullname</strong>: {FullName}<br />
<strong>Email</strong>:&nbsp;<a href="mailto:{Email}?subject=%7BEmail%7D&amp;body=%7BEmail%7D">{Email}</a><br />
<strong>Country</strong>: {Country}<br />
<strong>Message</strong>: {Request}

<p>Thanks for your contact!<br />
<br />
<strong>{NameHotel}</strong><br />
Tel: {TelHotel}<br />
Email:&nbsp;<a href="mailto:{EmailHotel}?subject=%7BEmailHotel%7D&amp;body=%7BEmailHotel%7D">{EmailHotel}</a><br />
Add: {AddressHotel}<br />
Website:&nbsp;<a href="http://{Website}">{Website}</a></p>

<p>&nbsp;</p>', N'Dear&nbsp;{FullName},<br />
<br />
Webhotel&nbsp;đ&atilde; nhận&nbsp;được y&ecirc;u cầu li&ecirc;n hệ của bạn, ch&uacute;ng t&ocirc;i sẽ phản hồi lại bạn trong thời gian sớm nhất<br />
Th&ocirc;ng tin li&ecirc;n hệ:<br />
Full name:&nbsp;<strong>&nbsp;{FullName},</strong><br />
Content:&nbsp;{OrtherRequest}<br />
<br />
Tạm&nbsp;biệt', N'<span style="color:rgb(34, 34, 34); font-family:arial,sans-serif; font-size:14px">Your information has been submitted successfully. We will get back to you within 24 hours!&nbsp;</span>', N'Contact failed!')
INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (2, N'Booking Room from {HotelName}', 3, N'en', N'<table align="left" border="0" cellpadding="10" cellspacing="0" style="margin-left:6.75pt; margin-right:6.75pt; width:887px">
	<tbody>
		<tr>
			<td>
			<h2>{HotelName}</h2>
			</td>
		</tr>
		<tr>
			<td style="width:865px">
			<table border="0" cellpadding="10" style="background:rgb(193, 193, 193); width:863px">
				<tbody>
					<tr>
						<td style="width:536px"><strong>Your booking is confirmed.</strong>
						<p style="margin-left:0cm">For booking enquires, cancellations or amendments please contact us directly at&nbsp;<a href="mailto:{HotelEmail}" target="_blank">{HotelEmail}</a>&nbsp;or&nbsp;<a href="tel:{HotelTel}">{HotelTel}</a>.</p>
						</td>
						<td style="width:277px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:275px">
							<tbody>
								<tr>
									<td>
									<p style="text-align:right">Booking Code: {Code}</p>
									</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td><br />
			<strong>Your Booking</strong><br />
			&nbsp;
			<table border="0" cellpadding="6" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:159px"><strong>Guest</strong>:</td>
						<td style="width:678px">{Gender}. {FullName}</td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="mailto:{Email}" target="_blank">{Email}</a></td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="tel:{tel}">{Tel}</a></td>
					</tr>
					<tr>
						<td style="width:159px">Smoking</td>
						<td style="width:678px">{Smoking}</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Details</strong>:</td>
						<td style="width:678px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:676px">
							<tbody>
								<tr>
									<td style="width:505px">{InfoBooking}</td>
									<td style="text-align:right; width:167px"><strong>VND$ {TotalPrice}</strong></td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Check-in</strong>:</td>
						<td style="width:678px">{CheckIn} from 14:00</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Check-out</strong>:</td>
						<td style="width:678px">{CheckOut} until 12:00</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Adult</strong>:</td>
						<td style="width:678px">{Adult}</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Child</strong>:</td>
						<td style="width:678px">{Child}</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Arrival with flight</strong>:</td>
						<td style="width:678px">{ArrivalFlight}</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Arrival Time</strong>:</td>
						<td style="width:678px">{ArrivalTime}</td>
					</tr>
					<tr>
						<td style="width:159px"><strong>Status</strong>:</td>
						<td style="width:678px"><strong>Confirmed</strong></td>
					</tr>
					<tr>
						<td><strong>Additional comments</strong>:</td>
						<td style="width:678px">{Request}</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td><strong>Payment Details</strong>
			<table border="0" cellpadding="0" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:646px"><strong>Booking value</strong>:</td>
						<td style="text-align:right; width:37px"><strong>VND$ {TotalPrice}</strong></td>
					</tr>
					<tr>
						<td colspan="2">
						<p><strong>Cancellation/Amendment Policy : This policy defines how to handle cancellations:</strong><br />
						- If cancellation/amendment is made 03 days prior to your arrival date, no fee will be charged and the deposit is refundable.&nbsp;<br />
						- If cancellation/amendment is made less than 03 days of your arrival or in case of no-show, the deposit is NOT refundable.&nbsp;</p>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
	</tbody>
</table>
', N'test', N'Your booking send completed', N'Reservation failed!')
INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (3, N'Your booking tour at Golden Rooster Hotel', 2, N'en', N'<h4>Booking Tour Confimation</h4>

<p>Dear&nbsp;<strong>{Gender}.</strong>&nbsp;<strong>{FullName}</strong>,</p>

<p>We would be very happy to assist you with our services at our utmost. Be noticed that we have well received your request and will get back to you with an offer in detail within 24 hours or earlier<br />
<br />
<strong>BOOKING TOUR DETAILS</strong></p>

<div>
<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Departure</strong></div>
&nbsp;{Departure}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Full Name</strong></div>

<div style="width: 320px; float: right;">{FullName}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 5px;">
<div style="width: 175px; float: left;"><strong>Phone Number</strong></div>
&nbsp;&nbsp;{Tel}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Email Address</strong></div>
&nbsp;&nbsp;{Email}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Address</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Address}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Country</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Country}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Messages</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Request}</div>
</div>
</div>

<p><br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<strong>Best regards,</strong></p>
', N'Thong bao dăt tour', N'We would be very happy to assist you with our services at our utmost. Be noticed that we have well received your request and will get back to you with an offer in detail within 24 hours or earlier', N'Booking Error!')
INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (4, N'​Phòng đặt phòng từ {HotelName}', 3, N'vi', N'<table align="left" border="0" cellpadding="10" cellspacing="0" style="margin-left:6.75pt; margin-right:6.75pt; width:887px">
	<tbody>
		<tr>
			<td>
			<h2><span style="font-size:13px">{HotelName}</span></h2>
			</td>
		</tr>
		<tr>
			<td style="width:865px">
			<table border="0" cellpadding="10" style="background:rgb(193, 193, 193); width:863px">
				<tbody>
					<tr>
						<td style="width:536px">Đặt ph&ograve;ng của bạn đ&atilde; được x&aacute;c nhận.<br />
						Để đặt ph&ograve;ng, hủy hoặc sửa đổi đặt ph&ograve;ng, vui l&ograve;ng li&ecirc;n hệ trực tiếp với ch&uacute;ng t&ocirc;i tại {HotelEmail} hoặc {HotelTel}.</td>
						<td style="width:277px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:275px">
							<tbody>
								<tr>
									<td>
									<p style="text-align:right">M&atilde; đặt chỗ:&nbsp;{Code}</p>
									</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td><br />
			Đặt ph&ograve;ng của bạn<br />
			&nbsp;
			<table border="0" cellpadding="6" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:159px">Kh&aacute;ch:</td>
						<td style="width:678px">{Gender}. {FullName}</td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="mailto:{Email}" target="_blank">{Email}</a></td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="tel:{tel}">{Tel}</a></td>
					</tr>
					<tr>
						<td style="width:159px">H&uacute;t thuốc</td>
						<td style="width:678px">{Smoking}</td>
					</tr>
					<tr>
						<td style="width:159px">Chi tiết:</td>
						<td style="width:678px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:676px">
							<tbody>
								<tr>
									<td style="width:505px">{InfoBooking}</td>
									<td style="text-align:right; width:167px"><strong>VND</strong>&nbsp;{TotalPrice}</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
					<tr>
						<td style="width:159px">Nhận ph&ograve;ng:</td>
						<td style="width:678px">{CheckIn} từ14:00</td>
					</tr>
					<tr>
						<td style="width:159px">Kiểm tra:</td>
						<td style="width:678px">{CheckOut} Cho đến12:00</td>
					</tr>
					<tr>
						<td style="width:159px">Người lớn:</td>
						<td style="width:678px">{Adult}</td>
					</tr>
					<tr>
						<td style="width:159px">Đứa trẻ:</td>
						<td style="width:678px">{Child}</td>
					</tr>
					<tr>
						<td style="width:159px">Đến với chuyến bay:</td>
						<td style="width:678px">{ArrivalFlight}</td>
					</tr>
					<tr>
						<td style="width:159px">Thời gian đến:</td>
						<td style="width:678px">{ArrivalTime}</td>
					</tr>
					<tr>
						<td style="width:159px">Trạng th&aacute;i:</td>
						<td style="width:678px">X&aacute;c nhận</td>
					</tr>
					<tr>
						<td>&Yacute; kiến kh&aacute;c:</td>
						<td style="width:678px">{Request}</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td>Chi tiết thanh to&aacute;n
			<table border="0" cellpadding="0" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:646px">Gi&aacute; trị đặt chỗ:</td>
						<td style="text-align:right; width:37px"><strong>VND</strong>{TotalPrice}</td>
					</tr>
					<tr>
						<td colspan="2">
						<p style="text-align:justify"><strong>Ch&iacute;nh s&aacute;ch Hủy / Sửa đổi: Ch&iacute;nh s&aacute;ch n&agrave;y x&aacute;c định c&aacute;ch xử l&yacute; việc hủy:</strong><br />
						- Nếu hủy / sửa đổi được thực hiện 03 ng&agrave;y trước ng&agrave;y đến của bạn, kh&ocirc;ng c&oacute; ph&iacute; sẽ được t&iacute;nh v&agrave; khoản tiền gửi c&oacute; thể ho&agrave;n lại.<br />
						- Nếu hủy / sửa đổi được thực hiện &iacute;t hơn 03 ng&agrave;y kể từ ng&agrave;y bạn đến hoặc trong trường hợp kh&ocirc;ng hiển thị, khoản tiền gửi kh&ocirc;ng ho&agrave;n lại.</p>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
	</tbody>
</table>
', N'<table align="left" border="0" cellpadding="10" cellspacing="0" style="margin-left:6.75pt; margin-right:6.75pt; width:887px">
	<tbody>
		<tr>
			<td>
			<h2><span style="font-size:13px">{HotelName}</span></h2>
			</td>
		</tr>
		<tr>
			<td style="width:865px">
			<table border="0" cellpadding="10" style="background:rgb(193, 193, 193); width:863px">
				<tbody>
					<tr>
						<td style="width:536px">Đặt ph&ograve;ng của bạn đ&atilde; được x&aacute;c nhận.<br />
						Để đặt ph&ograve;ng, hủy hoặc sửa đổi đặt ph&ograve;ng, vui l&ograve;ng li&ecirc;n hệ trực tiếp với ch&uacute;ng t&ocirc;i tại {HotelEmail} hoặc {HotelTel}.</td>
						<td style="width:277px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:275px">
							<tbody>
								<tr>
									<td>
									<p style="text-align:right">M&atilde; đặt chỗ:&nbsp;{Code}</p>
									</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td><br />
			Đặt ph&ograve;ng của bạn<br />
			&nbsp;
			<table border="0" cellpadding="6" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:159px">Kh&aacute;ch:</td>
						<td style="width:678px">{Gender}. {FullName}</td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="mailto:{Email}" target="_blank">{Email}</a></td>
					</tr>
					<tr>
						<td style="width:159px">&nbsp;</td>
						<td style="width:678px"><a href="tel:{tel}">{Tel}</a></td>
					</tr>
					<tr>
						<td style="width:159px">H&uacute;t thuốc</td>
						<td style="width:678px">{Smoking}</td>
					</tr>
					<tr>
						<td style="width:159px">Chi tiết:</td>
						<td style="width:678px">
						<table border="0" cellpadding="0" cellspacing="0" style="width:676px">
							<tbody>
								<tr>
									<td style="width:505px">{InfoBooking}</td>
									<td style="text-align:right; width:167px"><strong>VND</strong>&nbsp;{TotalPrice}</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
					<tr>
						<td style="width:159px">Nhận ph&ograve;ng:</td>
						<td style="width:678px">{CheckIn} từ14:00</td>
					</tr>
					<tr>
						<td style="width:159px">Kiểm tra:</td>
						<td style="width:678px">{CheckOut} Cho đến12:00</td>
					</tr>
					<tr>
						<td style="width:159px">Người lớn:</td>
						<td style="width:678px">{Adult}</td>
					</tr>
					<tr>
						<td style="width:159px">Đứa trẻ:</td>
						<td style="width:678px">{Child}</td>
					</tr>
					<tr>
						<td style="width:159px">Đến với chuyến bay:</td>
						<td style="width:678px">{ArrivalFlight}</td>
					</tr>
					<tr>
						<td style="width:159px">Thời gian đến:</td>
						<td style="width:678px">{ArrivalTime}</td>
					</tr>
					<tr>
						<td style="width:159px">Trạng th&aacute;i:</td>
						<td style="width:678px">X&aacute;c nhận</td>
					</tr>
					<tr>
						<td>&Yacute; kiến kh&aacute;c:</td>
						<td style="width:678px">{Request}</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
		<tr>
			<td>Chi tiết thanh to&aacute;n
			<table border="0" cellpadding="0" cellspacing="0" style="border-color:initial; border-style:none; border-width:initial; width:865px">
				<tbody>
					<tr>
						<td style="width:646px">Gi&aacute; trị đặt chỗ:</td>
						<td style="text-align:right; width:37px"><strong>VND</strong>{TotalPrice}</td>
					</tr>
					<tr>
						<td colspan="2">
						<p style="text-align:justify"><strong>Ch&iacute;nh s&aacute;ch Hủy / Sửa đổi: Ch&iacute;nh s&aacute;ch n&agrave;y x&aacute;c định c&aacute;ch xử l&yacute; việc hủy:</strong><br />
						- Nếu hủy / sửa đổi được thực hiện 03 ng&agrave;y trước ng&agrave;y đến của bạn, kh&ocirc;ng c&oacute; ph&iacute; sẽ được t&iacute;nh v&agrave; khoản tiền gửi c&oacute; thể ho&agrave;n lại.<br />
						- Nếu hủy / sửa đổi được thực hiện &iacute;t hơn 03 ng&agrave;y kể từ ng&agrave;y bạn đến hoặc trong trường hợp kh&ocirc;ng hiển thị, khoản tiền gửi kh&ocirc;ng ho&agrave;n lại.</p>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
	</tbody>
</table>
', N'Đặt ph&ograve;ng của bạn đ&atilde; được x&aacute;c nhận. Ch&uacute;ng t&ocirc;i sẽ li&ecirc;n lạc với bạn trong v&ograve;ng 24 giờ.', N'Đặt ph&ograve;ng kh&ocirc;ng th&agrave;nh c&ocirc;ng!')
INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (5, N'Địa chỉ liên hệ của bạn tại {NameHotel}', 1, N'vi', N'<strong><span style="font-size:14px">K&iacute;nh gửi&nbsp;{Gender}. {FullName},</span></strong><br />
<br />
Th&ocirc;ng tin của bạn đ&atilde; được gửi th&agrave;nh c&ocirc;ng. Ch&uacute;ng t&ocirc;i sẽ li&ecirc;n lạc lại với bạn trong v&ograve;ng 24 giờ!<br />
<br />
Th&ocirc;ng tin li&ecirc;n hệ<br />
<br />
<strong>Họ t&ecirc;n:</strong>&nbsp;{FullName}<br />
<strong>Email:</strong>&nbsp;{Email}<br />
<strong>Quốc gia:</strong>&nbsp;{Country}<br />
<strong>Thư:</strong>&nbsp;{Request}<br />
<br />
Cảm ơn bạn đ&atilde; li&ecirc;n hệ!<br />
<br />
<strong>{NameHotel}</strong><br />
Điện thoại: {TelHotel}<br />
Email: {EmailHotel}<br />
Địa chỉ: {AddressHotel}<br />
Website: {Website}', N'<strong><span style="font-size:14px">K&iacute;nh gửi&nbsp;{Gender}. {FullName},</span></strong><br />
<br />
Th&ocirc;ng tin của bạn đ&atilde; được gửi th&agrave;nh c&ocirc;ng. Ch&uacute;ng t&ocirc;i sẽ li&ecirc;n lạc lại với bạn trong v&ograve;ng 24 giờ!<br />
<br />
Th&ocirc;ng tin li&ecirc;n hệ<br />
<br />
<strong>Họ t&ecirc;n:</strong>&nbsp;{FullName}<br />
<strong>Email:</strong>&nbsp;{Email}<br />
<strong>Quốc gia:</strong>&nbsp;{Country}<br />
<strong>Thư:</strong>&nbsp;{Request}<br />
<br />
Cảm ơn bạn đ&atilde; li&ecirc;n hệ!<br />
<br />
<strong>{NameHotel}</strong><br />
Điện thoại: {TelHotel}<br />
Email: {EmailHotel}<br />
Địa chỉ: {AddressHotel}<br />
Website: {Website}', N'Th&ocirc;ng tin của bạn đ&atilde; được gửi th&agrave;nh c&ocirc;ng. Ch&uacute;ng t&ocirc;i sẽ li&ecirc;n lạc lại với bạn trong v&ograve;ng 24 giờ!', N'Li&ecirc;n hệ thất bại!')
INSERT [dbo].[SendEmail] ([ID], [Title], [Type], [LanguageID], [Content], [ContentDefault], [Success], [Error]) VALUES (6, N'Đặt tour tại Khách sạn Golden Rooster', 2, N'vi', N'X&aacute;c nhận đặt tour<br />
<br />
K&iacute;nh gửi&nbsp;<strong>{Gender}.</strong>&nbsp;<strong>{FullName}</strong>,<br />
<br />
Ch&uacute;ng t&ocirc;i sẽ rất vui khi được hỗ trợ bạn với c&aacute;c dịch vụ của ch&uacute;ng t&ocirc;i ở mức tối đa. H&atilde;y nhận thấy rằng ch&uacute;ng t&ocirc;i đ&atilde; nhận được y&ecirc;u cầu của bạn v&agrave; sẽ li&ecirc;n hệ lại với bạn với một ưu đ&atilde;i cụ thể trong v&ograve;ng 24 giờ hoặc sớm hơn<br />
<br />
<strong>​ĐẶT TOUR CHI TIẾT:</strong><br />
&nbsp;
<div style="width: 175px; float: left;">
<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Khởi h&agrave;nh</strong></div>
&nbsp;{Departure}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Họ t&ecirc;n</strong></div>

<div style="width: 320px; float: right;">{FullName}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 5px;">
<div style="width: 175px; float: left;"><strong>Số điện thoại</strong></div>
&nbsp;&nbsp;{Tel}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Địa chỉ email</strong></div>
&nbsp;&nbsp;{Email}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Địa chỉ</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Address}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Quốc gia</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Country}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Th&ocirc;ng b&aacute;o</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Request}</div>

<div>&nbsp;</div>
</div>
</div>
', N'X&aacute;c nhận đặt tour<br />
<br />
K&iacute;nh gửi&nbsp;<strong>{Gender}.</strong>&nbsp;<strong>{FullName}</strong>,<br />
<br />
Ch&uacute;ng t&ocirc;i sẽ rất vui khi được hỗ trợ bạn với c&aacute;c dịch vụ của ch&uacute;ng t&ocirc;i ở mức tối đa. H&atilde;y nhận thấy rằng ch&uacute;ng t&ocirc;i đ&atilde; nhận được y&ecirc;u cầu của bạn v&agrave; sẽ li&ecirc;n hệ lại với bạn với một ưu đ&atilde;i cụ thể trong v&ograve;ng 24 giờ hoặc sớm hơn<br />
<br />
<strong>​ĐẶT TOUR CHI TIẾT:</strong><br />
&nbsp;
<div style="width: 175px; float: left;">
<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Khởi h&agrave;nh</strong></div>
&nbsp;{Departure}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Họ t&ecirc;n</strong></div>

<div style="width: 320px; float: right;">{FullName}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 5px;">
<div style="width: 175px; float: left;"><strong>Số điện thoại</strong></div>
&nbsp;&nbsp;{Tel}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Địa chỉ email</strong></div>
&nbsp;&nbsp;{Email}</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Địa chỉ</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Address}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Quốc gia</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Country}</div>
</div>

<div style="width: 500px; float: left; margin-bottom: 7px;">
<div style="width: 175px; float: left;"><strong>Th&ocirc;ng b&aacute;o</strong></div>

<div style="width: 320px; float: right;">&nbsp;{Request}</div>

<div>&nbsp;</div>
</div>
</div>
', N'Ch&uacute;ng t&ocirc;i sẽ rất vui khi được hỗ trợ bạn với c&aacute;c dịch vụ của ch&uacute;ng t&ocirc;i ở mức tối đa. H&atilde;y nhận thấy rằng ch&uacute;ng t&ocirc;i đ&atilde; nhận được y&ecirc;u cầu của bạn v&agrave; sẽ li&ecirc;n hệ lại với bạn với một ưu đ&atilde;i cụ thể trong v&ograve;ng 24 giờ hoặc sớm hơn.', N'Lỗi đặt ph&ograve;ng!')
SET IDENTITY_INSERT [dbo].[SendEmail] OFF
GO
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([ID], [LanguageID], [Title], [MenuIDs], [Image], [Link], [Index], [ViewAll], [Status], [Content]) VALUES (2070, N'en', N'home', N'3235,', N'/files/images/home-resort-hero-bg.jpg', NULL, 0, 0, 1, NULL)
INSERT [dbo].[Slider] ([ID], [LanguageID], [Title], [MenuIDs], [Image], [Link], [Index], [ViewAll], [Status], [Content]) VALUES (2071, N'en', N'banner2', N'3238,3239,3236,3240,3241,', N'/files/images/resort-title-bg.jpg', NULL, 0, 0, 1, NULL)
INSERT [dbo].[Slider] ([ID], [LanguageID], [Title], [MenuIDs], [Image], [Link], [Index], [ViewAll], [Status], [Content]) VALUES (2072, N'vi', N'trang chủ', N'', N'/files/images/home-resort-hero-bg.jpg', NULL, 0, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Slider] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribe] ON 

INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (1, N'hatu@gmail')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (2, N'hatu@gmail')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (3, N'hatu@gmail')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (4, N'hangoctu@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (5, N'hangoctu@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (6, N'hangoctu@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (7, N'hangoctu@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (8, N'hatua1k5@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (9, N'hangoctu@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (10, N'hatua1k5@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (11, N'hatua1k5@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (12, N'hatua1k5@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (13, N'hatua1k5@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (14, N'hatua1k5dddd@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (15, N'nguyenluantnfgfhgfhg@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (16, N'hangoctuddd@gmail.com')
INSERT [dbo].[Subscribe] ([ID], [Email]) VALUES (17, N'hangoctutttttttttttttt@gmail.com')
SET IDENTITY_INSERT [dbo].[Subscribe] OFF
GO
SET IDENTITY_INSERT [dbo].[Usefullink] ON 

INSERT [dbo].[Usefullink] ([Id], [LanguageID], [Name], [Link], [Image], [Description], [Location], [Index], [Stauts]) VALUES (1, N'vi', N'Rooms & Rates', N'http://venus.webhotel.vn/', N'/files/images/Article/Delux-2.jpg', NULL, 1, 0, 1)
INSERT [dbo].[Usefullink] ([Id], [LanguageID], [Name], [Link], [Image], [Description], [Location], [Index], [Stauts]) VALUES (2, N'en', N'trang so 1', N'http://venus.webhotel.vn/', N'/files/images/Article/Delux-2.jpg', NULL, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Usefullink] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [FullName], [Email], [PasswordOld], [Status]) VALUES (1, N'admin1234', N'c03d31031e6b21386c69101e30a9a76f', N'KHÁCH SẠN THIÊN ÂN', N'nguyenluantn1610@gmail.com', N'h8HFwul9dZA236RYi9fqdw==', 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [FullName], [Email], [PasswordOld], [Status]) VALUES (7, N'admin', N'C03D31031E6B21386C69101E30A9A76F', N'ks', N'abc@gmail.com', N'C03D31031E6B21386C69101E30A9A76F', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Advertising] ADD  CONSTRAINT [DF_Advertising_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Article] ADD  CONSTRAINT [DF_Article_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT ('true') FOR [Customer]
GO
ALTER TABLE [dbo].[Gallery] ADD  CONSTRAINT [DF_Gallery_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Gallery] ADD  CONSTRAINT [DF_Gallery_Image]  DEFAULT ((0)) FOR [SmallImage]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF_Restaurant_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_Index]  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[Advertising]  WITH CHECK ADD  CONSTRAINT [FK_Advertising_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Advertising] CHECK CONSTRAINT [FK_Advertising_Language]
GO
ALTER TABLE [dbo].[Amenities]  WITH CHECK ADD FOREIGN KEY([languageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Menu]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Article] ([ID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([languageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([langaugeID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Language2] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Language2]
GO
ALTER TABLE [dbo].[HotelRule]  WITH CHECK ADD FOREIGN KEY([languageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Language]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Language]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD FOREIGN KEY([AmenityID])
REFERENCES [dbo].[Amenities] ([ID])
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[RoomGallery]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoomGallery_dbo.Room_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[RoomGallery] CHECK CONSTRAINT [FK_dbo.RoomGallery_dbo.Room_RoomId]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Restaurant_Menu]
GO
ALTER TABLE [dbo].[ServiceGallery]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantGallery_Restaurant] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[ServiceGallery] CHECK CONSTRAINT [FK_RestaurantGallery_Restaurant]
GO
ALTER TABLE [dbo].[Slider]  WITH CHECK ADD  CONSTRAINT [FK_Slider_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Slider] CHECK CONSTRAINT [FK_Slider_Language]
GO
ALTER TABLE [dbo].[Usefullink]  WITH CHECK ADD  CONSTRAINT [FK_Usefullink_Language] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[Usefullink] CHECK CONSTRAINT [FK_Usefullink_Language]
GO
