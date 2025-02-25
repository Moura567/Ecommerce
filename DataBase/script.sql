USE [master]
GO
/****** Object:  Database [cristDB]    Script Date: 1/29/2025 5:34:25 PM ******/
CREATE DATABASE [cristDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cristDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\cristDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cristDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\cristDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [cristDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cristDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cristDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cristDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cristDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cristDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cristDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [cristDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cristDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cristDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cristDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cristDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cristDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cristDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cristDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cristDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cristDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [cristDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cristDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cristDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cristDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cristDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cristDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [cristDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cristDB] SET RECOVERY FULL 
GO
ALTER DATABASE [cristDB] SET  MULTI_USER 
GO
ALTER DATABASE [cristDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cristDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cristDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cristDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cristDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cristDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'cristDB', N'ON'
GO
ALTER DATABASE [cristDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [cristDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [cristDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[address] [nvarchar](max) NULL,
	[fullname] [nvarchar](max) NOT NULL,
	[CartId] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CartId] [int] NOT NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carts]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[createdat] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CartId] [int] NOT NULL,
	[OrderId] [int] NULL,
	[OrderItemId] [int] NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[MobileNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[PaymentMethod] [nvarchar](30) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[orderstate] [nvarchar](max) NOT NULL,
	[productId] [int] NULL,
	[OrderPrice] [decimal](18, 2) NOT NULL,
	[orderdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 1/29/2025 5:34:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[categoryId] [int] NOT NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250117190307_init', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250126011725_addprice', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250126013940_removestateId', N'8.0.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3655dd80-f32c-4310-a526-1164e18428f8', N'dealer', N'DEALER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca', N'User', N'USER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b37e5052-c015-4f8e-bed9-cb21132d390b', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'596d2432-d320-4533-b079-767ceb7ed91e', N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b458c46-cf48-4b2e-b1f0-3ed040f00183', N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9fc6f972-9669-4f6a-9fd7-c929ee69e3a7', N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd4d8030f-7978-43f4-a78a-84ee638b2e60', N'98e4d31e-5cbc-4c8b-82fd-43c58abeb5ca')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9fc6f972-9669-4f6a-9fd7-c929ee69e3a7', N'b37e5052-c015-4f8e-bed9-cb21132d390b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [address], [fullname], [CartId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'596d2432-d320-4533-b079-767ceb7ed91e', N'nemr makar', N'pedri gonzaliz', 67, N'pedri gonzaliz', N'PEDRI GONZALIZ', N'pedrigonzaliz@gmail.com', N'PEDRIGONZALIZ@GMAIL.COM', 0, NULL, N'MRYZ5MYBOXC67MAQ46DCAJF2ZPLNWZMH', N'bb0e5d4f-ace4-4abd-849c-60ee5f3319b5', N'01124273671', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [address], [fullname], [CartId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', N'nemr makar', N'Hager', 2, N'Hager', N'HAGER', N'saratancriedy@gmail.com', N'SARATANCRIEDY@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMouwAgkkfoW+qiHIZ3ZrB4p9sHosjQfx4p8F1upC6LRU+BG7qjUuP237ukiludKtA==', N'TBHPGAQJNOK2WIAM2I4HJJ7BZ62ZUXYC', N'b3e0ffe8-fcb2-43d5-bc32-238a7f4c2333', N'01124273671', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [address], [fullname], [CartId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8b458c46-cf48-4b2e-b1f0-3ed040f00183', N'cairo', N'Reiima', 3, N'Reiima', N'REIIMA', N'Reiima@gmail.com', N'REIIMA@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGcmnajglcYPQmEQZH/IxKATSVY3hpORuXXTr6lezLGT7xkh8+U5ElqsgwcRE5NTFg==', N'JZSBNJKZLRRK3IJ77MJCCLLSSVQZBIAD', N'da15d54c-fd1c-4060-b0dd-51bef9c27bce', N'01116991818', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [address], [fullname], [CartId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9fc6f972-9669-4f6a-9fd7-c929ee69e3a7', N'nemr makar', N'Maha', 1, N'Maha', N'MAHA', N'mrm417190@gmail.com', N'MRM417190@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMzxvD4pQg3ZfHCp7w81rdRWokZbMtink1DLvPihzqsp1XxcLOOa/o2dvsUPpNK2zA==', N'K3TY4EPCJ4EBH54KPJNYE57FKGO3LDP6', N'e056c228-8d17-40be-94fc-c73b65829e45', N'01124273671', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [address], [fullname], [CartId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd4d8030f-7978-43f4-a78a-84ee638b2e60', N'عين شمس', N'hima am', 68, N'hima am', N'HIMA AM', N'himaam791@gmail.com', N'HIMAAM791@GMAIL.COM', 0, NULL, N'WQB27OM5EYSAK2CYLDLVFIPWV4RO5XPZ', N'0b427326-e990-46ed-a6b7-1015ea7f6773', N'01124273671', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([Id], [ProductId], [Quantity], [CartId]) VALUES (233, 2, 1, 68)
INSERT [dbo].[CartItems] ([Id], [ProductId], [Quantity], [CartId]) VALUES (245, 1, 1, 3)
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[carts] ON 

INSERT [dbo].[carts] ([Id], [UserId], [createdat]) VALUES (1, N'9fc6f972-9669-4f6a-9fd7-c929ee69e3a7', CAST(N'2025-01-17T21:38:06.1393094' AS DateTime2))
INSERT [dbo].[carts] ([Id], [UserId], [createdat]) VALUES (2, N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', CAST(N'2025-01-22T03:12:01.1908094' AS DateTime2))
INSERT [dbo].[carts] ([Id], [UserId], [createdat]) VALUES (3, N'8b458c46-cf48-4b2e-b1f0-3ed040f00183', CAST(N'2025-01-23T19:00:22.9750021' AS DateTime2))
INSERT [dbo].[carts] ([Id], [UserId], [createdat]) VALUES (67, N'596d2432-d320-4533-b079-767ceb7ed91e', CAST(N'2025-01-28T06:29:40.2105686' AS DateTime2))
INSERT [dbo].[carts] ([Id], [UserId], [createdat]) VALUES (68, N'd4d8030f-7978-43f4-a78a-84ee638b2e60', CAST(N'2025-01-29T05:58:34.4430128' AS DateTime2))
SET IDENTITY_INSERT [dbo].[carts] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([Id], [Name], [Description]) VALUES (1, N'Tvs', N'entertainment')
INSERT [dbo].[categories] ([Id], [Name], [Description]) VALUES (2, N'Phones', N'Mobail and accessories')
INSERT [dbo].[categories] ([Id], [Name], [Description]) VALUES (3, N'LabTops', N'Technologies')
SET IDENTITY_INSERT [dbo].[categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (29, 0, 0, 1, 2, 41, NULL, CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (30, 0, 0, 1, 3, 42, NULL, CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (31, 0, 0, 1, 3, 42, NULL, CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (32, 0, 0, 1, 2, 43, NULL, CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (33, 0, 0, 1, 2, 44, NULL, CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [ProductId], [CategoryId], [Quantity], [CartId], [OrderId], [OrderItemId], [Price]) VALUES (40, 0, 0, 1, 67, 51, NULL, CAST(35000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([Id], [UserId], [CreateDate], [IsDeleted], [Email], [MobileNumber], [Address], [PaymentMethod], [IsPaid], [orderstate], [productId], [OrderPrice], [orderdate]) VALUES (41, N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', CAST(N'2025-01-29T07:24:06.9745803' AS DateTime2), 0, N'saratancriedy@gmail.com', N'01124273671', N'nemr makar', N'Cash', 0, N'Pending', NULL, CAST(35000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[orders] ([Id], [UserId], [CreateDate], [IsDeleted], [Email], [MobileNumber], [Address], [PaymentMethod], [IsPaid], [orderstate], [productId], [OrderPrice], [orderdate]) VALUES (42, N'8b458c46-cf48-4b2e-b1f0-3ed040f00183', CAST(N'2025-01-29T07:24:27.0171537' AS DateTime2), 0, N'Reiima@gmail.com', N'01116991818', N'cairo', N' ', 0, N'Pending', NULL, CAST(59000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[orders] ([Id], [UserId], [CreateDate], [IsDeleted], [Email], [MobileNumber], [Address], [PaymentMethod], [IsPaid], [orderstate], [productId], [OrderPrice], [orderdate]) VALUES (43, N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', CAST(N'2025-01-29T10:39:07.1423941' AS DateTime2), 0, N'saratancriedy@gmail.com', N'01124273671', N'nemr makar', N'Cash', 0, N'Pending', NULL, CAST(24000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[orders] ([Id], [UserId], [CreateDate], [IsDeleted], [Email], [MobileNumber], [Address], [PaymentMethod], [IsPaid], [orderstate], [productId], [OrderPrice], [orderdate]) VALUES (44, N'6c0fb3b6-7fc5-468b-b4a1-5e367f7efa5c', CAST(N'2025-01-29T11:43:29.4822124' AS DateTime2), 0, N'saratancriedy@gmail.com', N'01124273671', N'nemr makar', N'Cash', 0, N'Pending', NULL, CAST(24000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[orders] ([Id], [UserId], [CreateDate], [IsDeleted], [Email], [MobileNumber], [Address], [PaymentMethod], [IsPaid], [orderstate], [productId], [OrderPrice], [orderdate]) VALUES (51, N'596d2432-d320-4533-b079-767ceb7ed91e', CAST(N'2025-01-29T12:22:28.6527844' AS DateTime2), 0, N'pedrigonzaliz@gmail.com', N'01124273671', N'nemr makar', N'Cash', 0, N'Pending', NULL, CAST(35000.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([Id], [Name], [Description], [price], [amount], [categoryId], [image]) VALUES (1, N'Samsung Tv', N'good tv', CAST(24000.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), 1, N'fe406984-5c11-4277-acaf-89c1f12e25dc_71rXN1Ku5MS.jpg')
INSERT [dbo].[products] ([Id], [Name], [Description], [price], [amount], [categoryId], [image]) VALUES (2, N'Iphone 16', N'good phone', CAST(35000.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)), 2, N'150a125e-3591-4af8-b2c9-4f9867e249a3_Apple-iPhone-16-Pro-hero-geo-240909_inline.jpg.large.jpg')
INSERT [dbo].[products] ([Id], [Name], [Description], [price], [amount], [categoryId], [image]) VALUES (3, N'Asus Tuf F15', N'Gaming Labtop', CAST(35000.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 3, N'5940c414-b87a-4d40-9467-d45e37ed5536_txtoikqtdnbk6die_setting_xxx_0_90_end_2000.png')
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_CartId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUsers_CartId] ON [dbo].[AspNetUsers]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_CartId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_CartId] ON [dbo].[CartItems]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_ProductId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_ProductId] ON [dbo].[CartItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderItemId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderItemId] ON [dbo].[OrderItems]
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_orders_productId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_orders_productId] ON [dbo].[orders]
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_products_categoryId]    Script Date: 1/29/2025 5:34:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_products_categoryId] ON [dbo].[products]
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[orders] ADD  DEFAULT ((0.0)) FOR [OrderPrice]
GO
ALTER TABLE [dbo].[orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [orderdate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_carts_CartId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_carts_CartId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_products_ProductId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_OrderItems_OrderItemId] FOREIGN KEY([OrderItemId])
REFERENCES [dbo].[OrderItems] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_OrderItems_OrderItemId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_orders_OrderId]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_products_productId] FOREIGN KEY([productId])
REFERENCES [dbo].[products] ([Id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_products_productId]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_categories_categoryId] FOREIGN KEY([categoryId])
REFERENCES [dbo].[categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_categories_categoryId]
GO
USE [master]
GO
ALTER DATABASE [cristDB] SET  READ_WRITE 
GO
