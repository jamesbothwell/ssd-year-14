USE [master]
GO
/****** Object:  Database [CA]    Script Date: 18/01/2023 14:50:11 ******/
CREATE DATABASE [CA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CA', FILENAME = N'C:\Users\DevUser\CA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CA_log', FILENAME = N'C:\Users\DevUser\CA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CA] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CA] SET ARITHABORT OFF 
GO
ALTER DATABASE [CA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CA] SET  MULTI_USER 
GO
ALTER DATABASE [CA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CA] SET QUERY_STORE = OFF
GO
USE [CA]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CA]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingNo] [int] IDENTITY(1,1) NOT NULL,
	[DateOfBooking] [date] NULL,
	[Slot] [varchar](255) NULL,
	[CustNo] [int] NULL,
	[StaffNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustNo] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [varchar](128) NULL,
	[CustAddress1] [varchar](128) NULL,
	[CustAddress2] [varchar](128) NULL,
	[CustPostcode] [varchar](8) NULL,
	[CustPhone] [varchar](11) NULL,
	[CustEmail] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[OrderNo] [int] NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[Delivery] [varchar](1) NULL,
	[DateOfDelivery] [datetime] NULL,
	[DeliveryYN] [varchar](1) NULL,
	[CustNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrderStock]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrderStock](
	[OrderNo] [int] NULL,
	[StockNo] [int] NULL,
	[QtyOrdered] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffNo] [int] IDENTITY(1,1) NOT NULL,
	[StaffJob] [varchar](255) NULL,
	[StaffName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockNo] [int] IDENTITY(1,1) NOT NULL,
	[StockDesc] [varchar](255) NULL,
	[StockCategory] [varchar](255) NULL,
	[StockPrice] [decimal](18, 0) NULL,
	[StockSellingPrice] [decimal](18, 0) NULL,
	[StockQty] [int] NULL,
	[StockImage] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeddingList]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeddingList](
	[OrderNo] [int] IDENTITY(1,1) NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[ReferenceName] [varchar](255) NULL,
	[CompletedYN] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeddingListStock]    Script Date: 18/01/2023 14:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeddingListStock](
	[OrderNo] [int] NULL,
	[CustNo] [int] NULL,
	[StockNo] [int] NULL,
	[QtyRequired] [int] NULL,
	[QtyOrdered] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookingNo], [DateOfBooking], [Slot], [CustNo], [StaffNo]) VALUES (1, CAST(N'2023-01-13' AS Date), N'13:00 - 14:00', 1, 1)
INSERT [dbo].[Booking] ([BookingNo], [DateOfBooking], [Slot], [CustNo], [StaffNo]) VALUES (2, CAST(N'2023-01-07' AS Date), N'14:00 - 15:00', 1, 1)
INSERT [dbo].[Booking] ([BookingNo], [DateOfBooking], [Slot], [CustNo], [StaffNo]) VALUES (3, CAST(N'2023-01-07' AS Date), N'11:00 - 12:00', 2, 1)
INSERT [dbo].[Booking] ([BookingNo], [DateOfBooking], [Slot], [CustNo], [StaffNo]) VALUES (4, CAST(N'2023-01-07' AS Date), N'09:00 - 10:00', 3, 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (1, N'edeqfefe', N'efewfefew', N'fwefewfefew', N'qwertyu', N'12345678912', N'wsewfwefew')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (2, N'wefwefew', N'ewfewfewf', N'ewfewfewfw', N'qwertyu', N'12345678989', N'htgteghergreg')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (3, N'rgrgg', N'wegewgewg', N'gegewgewg', N'qwertyu', N'12345678989', N'dvsdvdsvdsvs')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (1, N'job', N'tim')
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (1, N'dscdscd', N'dcdscdsc', CAST(45454 AS Decimal(18, 0)), CAST(54354 AS Decimal(18, 0)), 5453, N'Z:\Pictures\170px-Salvador_Dali_NYWTS.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (2, N'fvfdvfd', N'fvfvf', CAST(45435 AS Decimal(18, 0)), CAST(43545 AS Decimal(18, 0)), 45453, N'Z:\Pictures\stormzy.jpg')
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[WeddingList] ON 

INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (1, CAST(N'2023-01-18T12:46:05.230' AS DateTime), N'edeqfefe', N'N')
INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (2, CAST(N'2023-01-18T12:46:30.790' AS DateTime), N'edeqfefe', N'N')
INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (3, CAST(N'2023-01-18T12:47:13.317' AS DateTime), N'edeqfefe', N'N')
INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (4, CAST(N'2023-01-18T12:48:01.867' AS DateTime), N'edeqfefe', N'N')
INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (5, CAST(N'2023-01-18T12:48:12.507' AS DateTime), N'edeqfefe', N'N')
SET IDENTITY_INSERT [dbo].[WeddingList] OFF
GO
ALTER TABLE [dbo].[CustomerOrder] ADD  DEFAULT (getdate()) FOR [DateOfOrder]
GO
ALTER TABLE [dbo].[CustomerOrder] ADD  DEFAULT ('N') FOR [Delivery]
GO
ALTER TABLE [dbo].[CustomerOrder] ADD  DEFAULT (NULL) FOR [DateOfDelivery]
GO
ALTER TABLE [dbo].[CustomerOrder] ADD  DEFAULT (NULL) FOR [DeliveryYN]
GO
ALTER TABLE [dbo].[WeddingList] ADD  DEFAULT (getdate()) FOR [DateOfOrder]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNo])
REFERENCES [dbo].[Staff] ([StaffNo])
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[CustomerOrderStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[CustomerOrder] ([OrderNo])
GO
ALTER TABLE [dbo].[CustomerOrderStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
/****** Object:  StoredProcedure [dbo].[Check_Availability]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Check_Availability]

@SelectedDate date

as

select Slot from Booking
where DateOfBooking = @SelectedDate
GO
/****** Object:  StoredProcedure [dbo].[Create_Customer]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_Customer]

@CustName varchar(64),
@CustAddress1 varchar(128),
@CustAddress2 varchar(128),
@CustPostcode varchar(128),
@CustPhone varchar(11),
@CustEmail varchar(64)

as

insert into CUSTOMER
values (@CustName, @CustAddress1, @CustAddress2, @CustPostcode, @CustPhone, @CustEmail)

GO
/****** Object:  StoredProcedure [dbo].[Create_Stock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_Stock]

@StockDesc varchar(255),
@StockCategory varchar(255),
@StockPrice decimal,
@StockSellingPrice decimal,
@StockQty int,
@StockImage varchar(255)

as

insert into Stock
values (@StockDesc, @StockCategory, @StockPrice, @StockSellingPrice, @StockQty, @StockImage)

GO
/****** Object:  StoredProcedure [dbo].[Create_WeddingList]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_WeddingList]

@ReferenceName varchar(255),
@CompletedYN varchar(1)

as

insert into WeddingList(ReferenceName, CompletedYN)
values (@ReferenceName, @CompletedYN)

GO
/****** Object:  StoredProcedure [dbo].[Create_WeddingListStock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_WeddingListStock]

@OrderNo int,
@Custno int,
@StockNo int,
@QtyRequired int,
@QtyOrdered int

as

insert into WeddingListStock
values (@OrderNo, @Custno, @StockNo, @QtyRequired, @QtyOrdered)

GO
/****** Object:  StoredProcedure [dbo].[Get_Booking]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_Booking]

as

select
Booking.BookingNo,
Booking.DateOfBooking,
Booking.Slot,
Booking.CustNo,
Booking.StaffNo

from Booking

group by Booking.BookingNo, Booking.DateOfBooking, Booking.Slot, Booking.CustNo, Booking.StaffNo

GO
/****** Object:  StoredProcedure [dbo].[Get_Customers]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_Customers]

as

select
CUSTOMER.CustNo,
CUSTOMER.CustName,
CUSTOMER.CustAddress1,
CUSTOMER.CustAddress2,
CUSTOMER.CustPostcode,
CUSTOMER.CustPhone,
CUSTOMER.CustEmail

from CUSTOMER

group by CUSTOMER.CustNo, CUSTOMER.CustName, CUSTOMER.CustAddress1, CUSTOMER.CustAddress2, CUSTOMER.CustPostcode, CUSTOMER.CustPhone, CUSTOMER.CustEmail

GO
/****** Object:  StoredProcedure [dbo].[Get_Staff]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_Staff]

as

select
Staff.StaffNo,
Staff.StaffName,
Staff.StaffJob

from Staff

group by Staff.StaffNo, Staff.StaffName, Staff.StaffJob

GO
/****** Object:  StoredProcedure [dbo].[Get_Stock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_Stock]

as

select
Stock.StockNo,
Stock.StockDesc,
Stock.StockCategory,
Stock.StockPrice,
Stock.StockSellingPrice,
Stock.StockQty,
Stock.StockImage


from Stock

group by Stock.StockNo, Stock.StockDesc, Stock.StockCategory, Stock.StockPrice, Stock.StockSellingPrice, Stock.StockQty, Stock.StockImage

GO
/****** Object:  StoredProcedure [dbo].[Get_WeddingList]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_WeddingList]

as

select
WeddingList.OrderNo,
WeddingList.DateOfOrder,
WeddingList.ReferenceName,
WeddingList.CompletedYN

from WeddingList

group by WeddingList.OrderNo, WeddingList.DateOfOrder, WeddingList.ReferenceName, WeddingList.CompletedYN

GO
/****** Object:  StoredProcedure [dbo].[Get_WeddingListStock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_WeddingListStock]

as

select
WeddingListStock.OrderNo,
WeddingListStock.CustNo,
WeddingListStock.StockNo,
WeddingListStock.QtyRequired,
WeddingListStock.QtyOrdered

from WeddingListStock

group by WeddingListStock.OrderNo, WeddingListStock.CustNo, WeddingListStock.StockNo, WeddingListStock.QtyRequired, WeddingListStock.QtyOrdered

GO
/****** Object:  StoredProcedure [dbo].[Make_Booking]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Make_Booking]

@Date date,
@Slot varchar (255),
@CustNo int,
@StaffNo int

as

insert into Booking
values (@Date, @Slot, @CustNo, @StaffNo)
GO
/****** Object:  StoredProcedure [dbo].[Search_Customers]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Search_Customers]

@SearchString varchar(130)

as

select
	CUSTOMER.CustNo,
	CUSTOMER.CustName,
	CUSTOMER.CustAddress1,
	CUSTOMER.CustAddress2,
	CUSTOMER.CustPostcode,
	CUSTOMER.CustPhone,
	CUSTOMER.CustEmail
	
from CUSTOMER
where
	lower(CUSTOMER.CustNo) like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustName)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustAddress1)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustAddress2)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustPostcode)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustPhone)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustEmail)  like concat('%', @SearchSTring, '%') 
group by CUSTOMER.CustNo, CUSTOMER.CustName, CUSTOMER.CustAddress1, CUSTOMER.CustAddress2, CUSTOMER.CustPostcode, CUSTOMER.CustPhone, CUSTOMER.CustEmail;

GO
/****** Object:  StoredProcedure [dbo].[Search_Stock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Search_Stock]

@SearchString varchar(130)

as

select
	Stock.StockNo,
	Stock.StockDesc,
	Stock.StockCategory,
	Stock.StockPrice,
	Stock.StockSellingPrice,
	Stock.StockQty,
	Stock.StockImage
	
from Stock
where
	lower(Stock.StockNo) like concat('%', @SearchSTring, '%') or
	lower(Stock.StockDesc)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockCategory)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockPrice)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockSellingPrice)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockQty)  like concat('%', @SearchSTring, '%') or
	lower(Stock.StockImage)  like concat('%', @SearchSTring, '%')
group by Stock.StockNo, Stock.StockDesc, Stock.StockCategory, Stock.StockPrice, Stock.StockSellingPrice, Stock.StockQty, Stock.StockImage;

GO
/****** Object:  StoredProcedure [dbo].[Update_Customer]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_Customer]

@CustNo int,
@CustName varchar (128),
@CustAddress1 varchar(128),
@CustAddress2 varchar(128),
@CustPostcode varchar(8),
@CustPhone varchar(11),
@CustEmail varchar(64)

as

update CUSTOMER
set
CustName = @CustName,
CustAddress1 = @CustAddress1,
CustAddress2 = @CustAddress2,
CustPostcode = @CustPostcode,
CustPhone = @CustPhone,
CustEmail = @CustEmail

where CustNo = @CustNo

GO
/****** Object:  StoredProcedure [dbo].[Update_Stock]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_Stock]

@StockNo int,
@StockDesc varchar (255),
@StockCategory varchar (255),
@StockPrice decimal,
@StockSellingPrice decimal,
@StockQty int,
@StockImage varchar (255)

as

update Stock
set
StockDesc = @StockDesc,
StockCategory = @StockCategory,
StockPrice = @StockPrice,
StockSellingPrice = @StockSellingPrice,
StockQty = @StockQty,
StockImage = @StockImage

where StockNo = @StockNo

GO
/****** Object:  StoredProcedure [dbo].[Update_WeddingList]    Script Date: 18/01/2023 14:50:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_WeddingList]

@OrderNo int,
@DateOfOrder date,
@ReferenceName varchar(255),
@CompletedYN varchar(1)

as

update WeddingList
set
DateOfOrder = @DateOfOrder,
ReferenceName = @ReferenceName,
CompletedYN = @CompletedYN

where OrderNo = @OrderNo

GO
USE [master]
GO
ALTER DATABASE [CA] SET  READ_WRITE 
GO
