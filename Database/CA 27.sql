USE [master]
GO
/****** Object:  Database [CA]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[Booking]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 09/02/2023 12:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[OrderNo] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[CustomerOrderStock]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[WeddingList]    Script Date: 09/02/2023 12:53:08 ******/
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
/****** Object:  Table [dbo].[WeddingListPurchase]    Script Date: 09/02/2023 12:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeddingListPurchase](
	[OrderNo] [int] NULL,
	[CustNo] [int] NULL,
	[StockNo] [int] NULL,
	[QtyRequired] [int] NULL,
	[QtyOrdered] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeddingListStock]    Script Date: 09/02/2023 12:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeddingListStock](
	[OrderNo] [int] NULL,
	[CustNo] [int] NULL,
	[StockNo] [int] NULL,
	[QtyOrdered] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (1, N'Joe Bloggs', N'123 Main St', N'Apt 4B', N'SW129AB', N'07123456789', N'joebloggs@gmail.com')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (2, N'Jane Smith', N'456 Park Ave', N'Suite 5C', N'NW311AB', N'07987654321', N'janesmith@gmail.com')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (3, N'Mike Johnson', N'789 Oak St', N'Floor 3', N'SE212AB', N'07567891234', N'mikejohnson@email.com')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (4, N'David Brown', N'123 Elm St', N'Apt 1A', N'BE214AB', N'07401234567', N'davidbrown@gmail.com')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (5, N'John Doe', N'111 Maple Dr', N'Building 2', N'NG133AB', N'07012345678', N'johndoe@gmail.com')
INSERT [dbo].[Customer] ([CustNo], [CustName], [CustAddress1], [CustAddress2], [CustPostcode], [CustPhone], [CustEmail]) VALUES (6, N'Sophie Taylor', N'456 Birch Ave', N'Suite 2B', N'WC175AB', N'07509876543', N'sophietaylor@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (2, N'Team Leader', N'Frank Taylor')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (3, N'Sales Staff', N'Alice Johnson')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (4, N'Sales Staff', N'Bob Smith')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (5, N'Sales Staff', N'Charlie Brown')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (6, N'Sales Staff', N'David Wilson')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (7, N'Sales Staff', N'Emily Davis')
INSERT [dbo].[Staff] ([StaffNo], [StaffJob], [StaffName]) VALUES (8, N'Sales Staff', N'Grace Clarke')
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (1, N'Egyptian Cotton Sheets', N'Bedding', CAST(50 AS Decimal(18, 0)), CAST(75 AS Decimal(18, 0)), 20, N'Z:\Pictures\170px-Salvador_Dali_NYWTS.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (2, N'Fine China Dinner Set', N'China', CAST(100 AS Decimal(18, 0)), CAST(150 AS Decimal(18, 0)), 10, N'Z:\Pictures\stormzy.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (3, N'Stainless Steel Cutlery Set', N'Cutlery', CAST(25 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), 30, N'Z:\Pictures\170px-Salvador_Dali_NYWTS.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (4, N'2-Slice Toaster', N'Appliances', CAST(15 AS Decimal(18, 0)), CAST(20 AS Decimal(18, 0)), 40, N'Z:\Pictures\stormzy.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (5, N'Microwave Oven', N'Appliances', CAST(60 AS Decimal(18, 0)), CAST(80 AS Decimal(18, 0)), 10, N'Z:\Pictures\dead boi ting.jpg')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (6, N'Blender', N'Appliances', CAST(40 AS Decimal(18, 0)), CAST(60 AS Decimal(18, 0)), 5, N'Z:\Pictures\ChickenLittle-0.png')
INSERT [dbo].[Stock] ([StockNo], [StockDesc], [StockCategory], [StockPrice], [StockSellingPrice], [StockQty], [StockImage]) VALUES (7, N'King Size Duvet', N'Bedding', CAST(30 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)), 5, N'Z:\Pictures\stormzy.jpg')
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[WeddingList] ON 

INSERT [dbo].[WeddingList] ([OrderNo], [DateOfOrder], [ReferenceName], [CompletedYN]) VALUES (1, CAST(N'2023-02-09T12:02:19.610' AS DateTime), N'Joe Bloggs', N'N')
SET IDENTITY_INSERT [dbo].[WeddingList] OFF
GO
INSERT [dbo].[WeddingListStock] ([OrderNo], [CustNo], [StockNo], [QtyOrdered]) VALUES (1, 1, 6, 5)
INSERT [dbo].[WeddingListStock] ([OrderNo], [CustNo], [StockNo], [QtyOrdered]) VALUES (1, 1, 5, 5)
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
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNo])
REFERENCES [dbo].[Staff] ([StaffNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNo])
REFERENCES [dbo].[Staff] ([StaffNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNo])
REFERENCES [dbo].[Staff] ([StaffNo])
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
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListPurchase]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([CustNo])
REFERENCES [dbo].[Customer] ([CustNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([OrderNo])
REFERENCES [dbo].[WeddingList] ([OrderNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
ALTER TABLE [dbo].[WeddingListStock]  WITH CHECK ADD FOREIGN KEY([StockNo])
REFERENCES [dbo].[Stock] ([StockNo])
GO
/****** Object:  StoredProcedure [dbo].[Check_Availability]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Create_Booking]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_Booking]

@DateOfBooking date,
@Slot varchar (255),
@CustNo int,
@StaffNo int

as

insert into Booking
values (@DateOfBooking, @Slot, @CustNo, @StaffNo)
GO
/****** Object:  StoredProcedure [dbo].[Create_Customer]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Create_CustomerOrder]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_CustomerOrder]

@CustNo int

as

insert into CustomerOrder(CustNo)
values (@CustNo)

GO
/****** Object:  StoredProcedure [dbo].[Create_CustomerOrderStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_CustomerOrderStock]

@OrderNo int,
@StockNo int,
@QtyOrdered int

as

insert into CustomerOrderStock
values (@OrderNo, @StockNo, @QtyOrdered)

GO
/****** Object:  StoredProcedure [dbo].[Create_Stock]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Create_WeddingList]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Create_WeddingListPurchase]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_WeddingListPurchase]

@OrderNo int,
@Custno int,
@StockNo int,
@QtyRequired int,
@QtyOrdered int

as

insert into WeddingListPurchase
values (@OrderNo, @Custno, @StockNo, @QtyRequired, @QtyOrdered)

GO
/****** Object:  StoredProcedure [dbo].[Create_WeddingListStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Create_WeddingListStock]

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

insert into WeddingListStock
values (@OrderNo, @CustNo, @StockNo, @QtyOrdered)

GO
/****** Object:  StoredProcedure [dbo].[Delete_WeddingListStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Delete_WeddingListStock]

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

delete from WeddingListStock
where OrderNo = @OrderNo AND CustNo = @CustNo  AND StockNo = @StockNo AND QtyOrdered = @QtyOrdered

GO
/****** Object:  StoredProcedure [dbo].[Get_Booking]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_CustomerOrder]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_CustomerOrder]

as

select
CustomerOrder.OrderNo,
CustomerOrder.DateOfOrder,
CustomerOrder.Delivery,
CustomerOrder.DateOfDelivery,
CustomerOrder.DeliveryYN,
CustomerOrder.CustNo

from CustomerOrder

group by CustomerOrder.OrderNo, CustomerOrder.DateOfOrder, CustomerOrder.Delivery, CustomerOrder.DateOfDelivery, CustomerOrder.DeliveryYN, CustomerOrder.CustNo

GO
/****** Object:  StoredProcedure [dbo].[Get_CustomerOrderStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_CustomerOrderStock]

as

select
CustomerOrderStock.OrderNo,
CustomerOrderStock.StockNo,
CustomerOrderStock.QtyOrdered

from CustomerOrderStock

group by CustomerOrderStock.OrderNo, CustomerOrderStock.StockNo, CustomerOrderStock.QtyOrdered

GO
/****** Object:  StoredProcedure [dbo].[Get_Customers]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_Staff]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_Stock]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_WeddingList]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_WeddingListPurchase]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_WeddingListPurchase]

as

select
WeddingListPurchase.OrderNo,
WeddingListPurchase.CustNo,
WeddingListPurchase.StockNo,
WeddingListPurchase.QtyRequired,
WeddingListPurchase.QtyOrdered

from WeddingListPurchase

group by WeddingListPurchase.OrderNo, WeddingListPurchase.CustNo, WeddingListPurchase.StockNo, WeddingListPurchase.QtyRequired, WeddingListPurchase.QtyOrdered

GO
/****** Object:  StoredProcedure [dbo].[Get_WeddingListStock]    Script Date: 09/02/2023 12:53:09 ******/
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
WeddingListStock.QtyOrdered

from WeddingListStock

group by WeddingListStock.OrderNo, WeddingListStock.CustNo, WeddingListStock.StockNo, WeddingListStock.QtyOrdered

GO
/****** Object:  StoredProcedure [dbo].[Search_Customers]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Search_Stock]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Customer]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_CustomerOrder]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_CustomerOrder]

@OrderNo int,
@DateOfOrder datetime,
@Delivery varchar(1),
@DateOfDelivery datetime,
@DeliveryYN varchar(1),
@CustNo int 

as

update CustomerOrder
set
DateOfOrder = @DateOfOrder,
Delivery = @Delivery,
DateOfDelivery = @DateOfDelivery,
DeliveryYN = @DeliveryYN,
CustNo = @CustNo

where OrderNo = @OrderNo

GO
/****** Object:  StoredProcedure [dbo].[Update_CustomerOrderStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_CustomerOrderStock]

@OrderNo int,
@StockNo int,
@QtyOrdered int

as

update CustomerOrderStock
set
QtyOrdered = @QtyOrdered

where OrderNo = @OrderNo AND StockNo = @StockNo

GO
/****** Object:  StoredProcedure [dbo].[Update_Stock]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_WeddingList]    Script Date: 09/02/2023 12:53:09 ******/
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
/****** Object:  StoredProcedure [dbo].[Update_WeddingListStock]    Script Date: 09/02/2023 12:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_WeddingListStock]

@OrderNo int,
@CustNo int,
@StockNo int,
@QtyOrdered int

as

update WeddingListStock
set
QtyOrdered = @QtyOrdered

where OrderNo = @OrderNo AND CustNo = @CustNo  AND StockNo = @StockNo

GO
USE [master]
GO
ALTER DATABASE [CA] SET  READ_WRITE 
GO
