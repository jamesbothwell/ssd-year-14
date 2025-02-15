USE [master]
GO
/****** Object:  Database [CA]    Script Date: 08/11/2022 10:54:20 ******/
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
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 08/11/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [varchar](128) NULL,
	[CustAddress1] [varchar](128) NULL,
	[CustAddress2] [varchar](128) NULL,
	[CustPostcode] [varchar](8) NULL,
	[CustPhone] [varchar](11) NULL,
	[CustEmail] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Create_Customer]    Script Date: 08/11/2022 10:54:21 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_Customers]    Script Date: 08/11/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Get_Customers]

as

select
CUSTOMER.CustID,
CUSTOMER.CustName,
CUSTOMER.CustAddress1,
CUSTOMER.CustAddress2,
CUSTOMER.CustPostcode,
CUSTOMER.CustPhone,
CUSTOMER.CustEmail

from CUSTOMER

group by CUSTOMER.CustID, CUSTOMER.CustName, CUSTOMER.CustAddress1, CUSTOMER.CustAddress2, CUSTOMER.CustPostcode, CUSTOMER.CustPhone, CUSTOMER.CustEmail

GO
/****** Object:  StoredProcedure [dbo].[Search_Customers]    Script Date: 08/11/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Search_Customers]

@SearchString varchar(130)

as

select
	CUSTOMER.CustID,
	CUSTOMER.CustName,
	CUSTOMER.CustAddress1,
	CUSTOMER.CustAddress2,
	CUSTOMER.CustPostcode,
	CUSTOMER.CustPhone,
	CUSTOMER.CustEmail
	
from CUSTOMER
where
	lower(CUSTOMER.CustID) like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustName)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustAddress1)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustAddress2)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustPostcode)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustPhone)  like concat('%', @SearchSTring, '%') or
	lower(CUSTOMER.CustEmail)  like concat('%', @SearchSTring, '%') 
group by CUSTOMER.CustID, CUSTOMER.CustName, CUSTOMER.CustAddress1, CUSTOMER.CustAddress2, CUSTOMER.CustPostcode, CUSTOMER.CustPhone, CUSTOMER.CustEmail;

GO
/****** Object:  StoredProcedure [dbo].[Update_Customer]    Script Date: 08/11/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Update_Customer]

@CustID int,
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

where CustID = @CustID

GO
USE [master]
GO
ALTER DATABASE [CA] SET  READ_WRITE 
GO
