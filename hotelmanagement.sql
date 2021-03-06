USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 16/12/2018 8:43:33 PM ******/
CREATE DATABASE [HotelManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagement', FILENAME = N'D:\SQL2014\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\HotelManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HotelManagement_log', FILENAME = N'D:\SQL2014\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\HotelManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HotelManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelManagement] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HotelManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelManagement', N'ON'
GO
USE [HotelManagement]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [nchar](10) NOT NULL,
	[CheckIn] [datetime] NULL,
	[CheckOut] [datetime] NULL,
	[Breakfirst] [int] NULL,
	[Nights] [int] NULL,
	[Comment] [varchar](250) NULL,
	[BookTime] [datetime] NULL,
	[CustomerID] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Booking__73951ACDEFC54DF4] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Booking_Room]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_Room](
	[BookingID] [nchar](10) NOT NULL,
	[RoomNumber] [int] NOT NULL,
 CONSTRAINT [PK__Booking___45C59573096D183F] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC,
	[RoomNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cancellation]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancellation](
	[CancelID] [int] NOT NULL,
	[CancelTime] [datetime] NULL,
	[BookingID] [nchar](10) NOT NULL,
	[CustomerID] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Cancella__E797DA422A545B21] PRIMARY KEY CLUSTERED 
(
	[CancelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [nchar](10) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[RegisTime] [datetime] NULL,
	[Status] [varchar](20) NULL,
	[StaffID] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Customer__A4AE64B87CFC5614] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] NOT NULL,
	[StaffID] [nchar](10) NULL,
	[ActionTime] [datetime] NULL,
	[Main] [varchar](255) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [nchar](10) NOT NULL,
	[Amount] [float] NULL,
	[Paid] [float] NULL,
	[Paytime] [datetime] NULL,
	[Invoice] [varchar](250) NULL,
	[Cancelled] [bit] NULL,
	[CustomerID] [nchar](10) NOT NULL,
	[BookingID] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Payment__9B556A58983461AA] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[RoomNumber] [int] NOT NULL,
	[RoomType] [varchar](50) NULL,
	[PricePerNight] [float] NULL,
	[MaxPerson] [int] NULL,
	[Status] [varchar](20) NULL,
 CONSTRAINT [PK__Room__AE10E07BC022F848] PRIMARY KEY CLUSTERED 
(
	[RoomNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room_Cancellation]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Cancellation](
	[RoomNumber] [int] NOT NULL,
	[CancellationCancelID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomNumber] ASC,
	[CancellationCancelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 16/12/2018 8:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [nchar](10) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[Type] [bit] NULL,
	[Status] [varchar](20) NULL,
	[Username] [nchar](10) NOT NULL,
	[Password] [varchar](30) NULL,
 CONSTRAINT [PK__Staff__96D4AAF7639D769F] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Booking] ([BookingID], [CheckIn], [CheckOut], [Breakfirst], [Nights], [Comment], [BookTime], [CustomerID]) VALUES (N'B001      ', CAST(N'2019-04-04 08:00:00.000' AS DateTime), CAST(N'2019-04-04 23:00:00.000' AS DateTime), 1, 0, N'', CAST(N'2018-11-05 00:43:45.307' AS DateTime), N'C001      ')
INSERT [dbo].[Booking] ([BookingID], [CheckIn], [CheckOut], [Breakfirst], [Nights], [Comment], [BookTime], [CustomerID]) VALUES (N'B002      ', CAST(N'2018-12-09 05:05:00.000' AS DateTime), CAST(N'2018-12-11 05:00:00.000' AS DateTime), 2, 1, N'<3', CAST(N'2018-11-08 06:29:51.993' AS DateTime), N'C002      ')
INSERT [dbo].[Booking] ([BookingID], [CheckIn], [CheckOut], [Breakfirst], [Nights], [Comment], [BookTime], [CustomerID]) VALUES (N'B003      ', CAST(N'2018-11-12 05:00:00.000' AS DateTime), CAST(N'2018-11-12 23:00:00.000' AS DateTime), 1, 0, N'ko', CAST(N'2018-11-11 11:40:14.443' AS DateTime), N'C004      ')
INSERT [dbo].[Booking] ([BookingID], [CheckIn], [CheckOut], [Breakfirst], [Nights], [Comment], [BookTime], [CustomerID]) VALUES (N'B004      ', CAST(N'2018-11-20 05:00:00.000' AS DateTime), CAST(N'2018-11-21 05:00:00.000' AS DateTime), 0, 0, N'', CAST(N'2018-11-14 11:50:36.617' AS DateTime), N'C004      ')
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B001      ', 404)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B002      ', 201)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B002      ', 302)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B002      ', 303)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B003      ', 301)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B003      ', 302)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B003      ', 303)
INSERT [dbo].[Booking_Room] ([BookingID], [RoomNumber]) VALUES (N'B004      ', 102)
INSERT [dbo].[Cancellation] ([CancelID], [CancelTime], [BookingID], [CustomerID]) VALUES (1, CAST(N'2018-11-08 16:47:50.573' AS DateTime), N'B002      ', N'C002      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C001      ', N'Koishi', N'Komeiji', N'Chireiden', N'Japan', N'514@gmail.com', N'09077-51482', CAST(N'2018-05-14 00:00:00.000' AS DateTime), N'Enable', N'S001      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C002      ', N'Einsviesn', N'Illya', N'87 Ren', N'France', N'illya81@gm.com.vn', N'90991-88800', CAST(N'2018-11-07 13:45:55.700' AS DateTime), N'Enable', N'S002      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C003      ', N'Chen', N'Swan Li', N'9 Lin', N'China', N'chen9@gmail.com', N'08091-88729', CAST(N'2018-11-07 13:57:51.880' AS DateTime), N'Disable', N'S002      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C004      ', N'Minh', N'Tran Van', N'89 Dong Da, Ba Dinh Hanoi', N'Vietnam', N'minh_89@gmail.com', N'09076-95112', CAST(N'2018-11-11 11:08:29.897' AS DateTime), N'Enable', N'S004      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C005      ', N'Ren', N'SenGong', N'85 UYE, Seoung', N'Korean', N'uu94-ej@gmail.com', N'19827-73813', CAST(N'2018-11-11 13:53:13.643' AS DateTime), N'Enable', N'S001      ')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [RegisTime], [Status], [StaffID]) VALUES (N'C006      ', N'Sang', N'Tran', N'14 quang Trung', N'India', N'sangt@gmail.com', N'12222-22222', CAST(N'2018-11-14 09:14:13.143' AS DateTime), N'Disable', N'S001      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (1, N'S002      ', CAST(N'2018-11-03 21:09:27.453' AS DateTime), N'Update Receptionist: S001      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (2, N'S002      ', CAST(N'2018-11-03 21:32:53.113' AS DateTime), N'Edit Room: 101 Info')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (3, N'S002      ', CAST(N'2018-11-04 21:58:56.217' AS DateTime), N'Edit Room: 303 Info')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (4, N'S002      ', CAST(N'2018-11-04 21:59:01.560' AS DateTime), N'Edit Room: 303 Info')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (5, N'S002      ', CAST(N'2018-11-05 00:43:47.550' AS DateTime), N'Booking the room: 404 to: B001')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (6, N'S002      ', CAST(N'2018-11-05 10:18:51.993' AS DateTime), N'Update full payment for: B001      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (7, N'S002      ', CAST(N'2018-11-07 13:45:55.700' AS DateTime), N'Add new Customer: C002')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (8, N'S002      ', CAST(N'2018-11-07 13:57:51.910' AS DateTime), N'Add new Customer: C003')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (9, N'S002      ', CAST(N'2018-11-07 13:57:58.707' AS DateTime), N'Update Customer: C003      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (10, N'S002      ', CAST(N'2018-11-07 14:21:53.750' AS DateTime), N'Add new Receptionist: S002')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (11, N'S002      ', CAST(N'2018-11-08 04:42:56.753' AS DateTime), N'Add new Receptionist: S003')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (12, N'S002      ', CAST(N'2018-11-08 05:14:33.963' AS DateTime), N'Update Receptionist: S003      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (13, N'S002      ', CAST(N'2018-11-08 06:29:53.807' AS DateTime), N'Booking the room: 303 to: B002')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (14, N'S002      ', CAST(N'2018-11-08 16:47:57.387' AS DateTime), N'Cancel Booking Id: B002      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (17, N'S004      ', CAST(N'2018-11-11 10:52:56.200' AS DateTime), N'Edit Room: 303 Info')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (18, N'S004      ', CAST(N'2018-11-11 11:08:29.927' AS DateTime), N'Add new Customer: C004')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (19, N'S004      ', CAST(N'2018-11-11 11:40:18.850' AS DateTime), N'Booking the room: 302 to: B003  ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (20, N'S004      ', CAST(N'2018-11-11 11:40:35.710' AS DateTime), N'Booking the room: 301 to: B003      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (21, N'S004      ', CAST(N'2018-11-11 11:41:41.390' AS DateTime), N'Booking the room: 303 to: B003      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (22, N'S001      ', CAST(N'2018-11-11 13:51:33.317' AS DateTime), N'Update full payment for: B003      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (23, N'S001      ', CAST(N'2018-11-11 13:53:13.667' AS DateTime), N'Add new Customer: C005')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (24, N'S005      ', CAST(N'2018-11-11 13:55:40.423' AS DateTime), N'Add new Receptionist: S006')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (25, N'S001      ', CAST(N'2018-11-14 09:14:13.147' AS DateTime), N'Add new Customer: C006')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (26, N'S001      ', CAST(N'2018-11-14 09:36:37.233' AS DateTime), N'Update Customer: C001      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (27, N'S001      ', CAST(N'2018-11-14 09:36:58.113' AS DateTime), N'Update Customer: C006      ')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (28, N'S002      ', CAST(N'2018-11-14 11:46:29.840' AS DateTime), N'Add new Receptionist: S007')
INSERT [dbo].[Log] ([ID], [StaffID], [ActionTime], [Main]) VALUES (29, N'S002      ', CAST(N'2018-11-14 11:50:37.613' AS DateTime), N'Booking the room: 102 to: B004')
INSERT [dbo].[Payment] ([PaymentID], [Amount], [Paid], [Paytime], [Invoice], [Cancelled], [CustomerID], [BookingID]) VALUES (N'P001      ', 4100000, 4100000, CAST(N'2018-11-05 10:18:51.993' AS DateTime), N'IV001', 0, N'C001      ', N'B001      ')
INSERT [dbo].[Payment] ([PaymentID], [Amount], [Paid], [Paytime], [Invoice], [Cancelled], [CustomerID], [BookingID]) VALUES (N'P002      ', 47450000, 14235001, CAST(N'2018-11-08 16:47:50.573' AS DateTime), N'IV002', 1, N'C002      ', N'B002      ')
INSERT [dbo].[Payment] ([PaymentID], [Amount], [Paid], [Paytime], [Invoice], [Cancelled], [CustomerID], [BookingID]) VALUES (N'P003      ', 9300000, 9300000, CAST(N'2018-11-11 13:51:33.317' AS DateTime), N'IV003', 0, N'C004      ', N'B003      ')
INSERT [dbo].[Payment] ([PaymentID], [Amount], [Paid], [Paytime], [Invoice], [Cancelled], [CustomerID], [BookingID]) VALUES (N'P004      ', 3000000, 900000.0625, NULL, N'IV004', 0, N'C004      ', N'B004      ')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (101, N'Single', 1500000, 5, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (102, N'Double', 2000000, 6, N'Booked')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (103, N'Double', 350000, 2, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (201, N'Double', 20000000, 4, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (202, N'Single', 700000, 2, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (203, N'Double', 10000000, 5, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (301, N'Double', 5000000, 2, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (302, N'Single', 1500000, 3, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (303, N'Double', 2500000, 3, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (401, N'Single', 1500000, 3, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (402, N'Single', 500000, 1, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (403, N'Double', 1000000, 2, N'Available')
INSERT [dbo].[Room] ([RoomNumber], [RoomType], [PricePerNight], [MaxPerson], [Status]) VALUES (404, N'Single', 4000000, 1, N'Available')
INSERT [dbo].[Room_Cancellation] ([RoomNumber], [CancellationCancelID]) VALUES (303, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S001      ', N'Minh Anh', N'Nguyen', N'85 Nguyen Ðinh Chieu', N'VietNam', N'ai@gmail.com', N'09010-932', 0, N'Enable', N'MA        ', N'222')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S002      ', N'Thuy Duong', N'Nguyen', N'190 Co Lac, Ha noi', N'VietNam', N'mon@gmail.com', N'09652812', 1, N'Enable', N'TD        ', N'333')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S003      ', N'Huang', N'Chong', N'Sen Won, all way', N'China', N'sen@gmail.com', N'82739-88799', 0, N'Disable', N'Kiwi      ', N'444')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S004      ', N'Ailen', N'Wood', N'984 BA stress, Al', N'America', N'wendywood@eon.edu.us', N'01989-78731', 0, N'Enable', N'Ailen     ', N'666')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S005      ', N'Trang', N'Ho', N'73 stress, Go Vap', N'VietNam', N'hhtt@gmail.com', N'82739-82938', 1, N'Enable', N'chan      ', N'111')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S006      ', N'Sa Sa', N'Tran', N'Yutn 8n, iwuei', N'Italia', N'hilleking@yahoo.com', N'09674-51997', 0, N'Enable', N'Sasa      ', N'100')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [Address], [Country], [Email], [Phone], [Type], [Status], [Username], [Password]) VALUES (N'S007      ', N'sasss', N'sfssds', N'sfasf', N'America', N'as@ds.com', N'33333-33333', 0, N'Enable', N'234a      ', N'123')
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking_Room]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Room_Booking] FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Booking_Room] CHECK CONSTRAINT [FK_Booking_Room_Booking]
GO
ALTER TABLE [dbo].[Booking_Room]  WITH CHECK ADD  CONSTRAINT [FKBooking_Ro107788] FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Room] ([RoomNumber])
GO
ALTER TABLE [dbo].[Booking_Room] CHECK CONSTRAINT [FKBooking_Ro107788]
GO
ALTER TABLE [dbo].[Cancellation]  WITH CHECK ADD  CONSTRAINT [FK_Cancellation_Booking] FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Cancellation] CHECK CONSTRAINT [FK_Cancellation_Booking]
GO
ALTER TABLE [dbo].[Cancellation]  WITH CHECK ADD  CONSTRAINT [FK_Cancellation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Cancellation] CHECK CONSTRAINT [FK_Cancellation_Customer]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Staff]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Staff]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Booking] FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Booking]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Customer]
GO
ALTER TABLE [dbo].[Room_Cancellation]  WITH CHECK ADD  CONSTRAINT [FKRoom_Cance107153] FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Room] ([RoomNumber])
GO
ALTER TABLE [dbo].[Room_Cancellation] CHECK CONSTRAINT [FKRoom_Cance107153]
GO
ALTER TABLE [dbo].[Room_Cancellation]  WITH CHECK ADD  CONSTRAINT [FKRoom_Cance777990] FOREIGN KEY([CancellationCancelID])
REFERENCES [dbo].[Cancellation] ([CancelID])
GO
ALTER TABLE [dbo].[Room_Cancellation] CHECK CONSTRAINT [FKRoom_Cance777990]
GO
USE [master]
GO
ALTER DATABASE [HotelManagement] SET  READ_WRITE 
GO
