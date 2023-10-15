USE [master]
GO
/****** Object:  Database [ADDDA_APP]    Script Date: 15/10/2023 21:55:41 ******/
CREATE DATABASE [ADDDA_APP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ADDDA_APP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ADDDA_APP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ADDDA_APP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ADDDA_APP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ADDDA_APP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ADDDA_APP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ADDDA_APP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ADDDA_APP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ADDDA_APP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ADDDA_APP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ADDDA_APP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ADDDA_APP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ADDDA_APP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ADDDA_APP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ADDDA_APP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ADDDA_APP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ADDDA_APP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ADDDA_APP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ADDDA_APP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ADDDA_APP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ADDDA_APP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ADDDA_APP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ADDDA_APP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ADDDA_APP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ADDDA_APP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ADDDA_APP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ADDDA_APP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ADDDA_APP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ADDDA_APP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ADDDA_APP] SET  MULTI_USER 
GO
ALTER DATABASE [ADDDA_APP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ADDDA_APP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ADDDA_APP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ADDDA_APP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ADDDA_APP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ADDDA_APP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ADDDA_APP] SET QUERY_STORE = OFF
GO
USE [ADDDA_APP]
GO
/****** Object:  Table [dbo].[address]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_name] [nvarchar](50) NULL,
	[customer_id] [int] NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [nvarchar](20) NULL,
	[start_time] [nvarchar](20) NULL,
	[end_date] [nvarchar](20) NULL,
	[end_time] [nvarchar](20) NULL,
	[total] [int] NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](255) NULL,
	[complete_flg] [int] NULL,
	[boocking_status_id] [int] NULL,
	[create_by] [int] NULL,
	[car_id] [int] NULL,
 CONSTRAINT [PK_BOOCKING_ORDER] PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_status]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_status](
	[booking_status_id] [int] IDENTITY(1,1) NOT NULL,
	[booking_status_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_boocking_status] PRIMARY KEY CLUSTERED 
(
	[booking_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brand]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand_name] [nvarchar](255) NULL,
 CONSTRAINT [PK_BRAND] PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car](
	[car_id] [int] IDENTITY(1,1) NOT NULL,
	[price] [float] NULL,
	[year_manufacture] [int] NULL,
	[number_plate] [nvarchar](255) NULL,
	[description] [text] NULL,
	[address] [nvarchar](255) NULL,
	[image] [nvarchar](255) NULL,
	[is_delete] [int] NULL,
	[car_status_id] [int] NULL,
	[brand_id] [int] NULL,
	[model_id] [int] NULL,
	[car_type_id] [int] NULL,
	[customer_id] [int] NULL,
	[vehicle_registration_id] [int] NULL,
	[count_journeys] [int] NULL,
 CONSTRAINT [PK_CAR] PRIMARY KEY CLUSTERED 
(
	[car_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car_status]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car_status](
	[car_status_id] [int] IDENTITY(1,1) NOT NULL,
	[car_status_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_car_status] PRIMARY KEY CLUSTERED 
(
	[car_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car_type]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car_type](
	[car_type_id] [int] IDENTITY(1,1) NOT NULL,
	[car_type_name] [nvarchar](255) NULL,
	[number_seats] [int] NULL,
 CONSTRAINT [PK_CAR_TYPE] PRIMARY KEY CLUSTERED 
(
	[car_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](255) NULL,
	[name_display] [nvarchar](50) NULL,
	[full_name] [nvarchar](50) NULL,
	[birthday] [nvarchar](255) NULL,
	[password] [nvarchar](50) NULL,
	[role_id] [int] NULL,
	[id_number] [nvarchar](255) NULL,
	[id_frontside] [nvarchar](255) NULL,
	[id_backside] [nvarchar](255) NULL,
	[verify_flg] [int] NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[favorite_car]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorite_car](
	[favorite_car_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[car_id] [int] NULL,
 CONSTRAINT [PK_HART_CAR] PRIMARY KEY CLUSTERED 
(
	[favorite_car_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feeback]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feeback](
	[feeback_id] [int] IDENTITY(1,1) NOT NULL,
	[rate] [int] NULL,
	[comment] [text] NULL,
	[create_at] [nvarchar](20) NULL,
	[create_by] [int] NULL,
	[car_id] [int] NULL,
 CONSTRAINT [PK_FEEBACK] PRIMARY KEY CLUSTERED 
(
	[feeback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[model]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[model](
	[model_id] [int] IDENTITY(1,1) NOT NULL,
	[model_name] [nvarchar](255) NULL,
	[brand_id] [int] NULL,
 CONSTRAINT [PK_MODEL] PRIMARY KEY CLUSTERED 
(
	[model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehicle_registration]    Script Date: 15/10/2023 21:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle_registration](
	[vehicle_registration_id] [int] NOT NULL,
	[vehicle_registration_image] [nvarchar](255) NULL,
	[vehicle_inspection_image] [nvarchar](255) NULL,
 CONSTRAINT [PK_VEHICLE_REGISTRATION] PRIMARY KEY CLUSTERED 
(
	[vehicle_registration_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[car] ADD  CONSTRAINT [DF_car_count_journeys]  DEFAULT ((0)) FOR [count_journeys]
GO
ALTER TABLE [dbo].[address]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD FOREIGN KEY([boocking_status_id])
REFERENCES [dbo].[booking_status] ([booking_status_id])
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD FOREIGN KEY([car_id])
REFERENCES [dbo].[car] ([car_id])
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD FOREIGN KEY([create_by])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([brand_id])
REFERENCES [dbo].[brand] ([brand_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([car_status_id])
REFERENCES [dbo].[car_status] ([car_status_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([car_type_id])
REFERENCES [dbo].[car_type] ([car_type_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([model_id])
REFERENCES [dbo].[model] ([model_id])
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD FOREIGN KEY([vehicle_registration_id])
REFERENCES [dbo].[vehicle_registration] ([vehicle_registration_id])
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([role_id])
GO
ALTER TABLE [dbo].[favorite_car]  WITH CHECK ADD FOREIGN KEY([car_id])
REFERENCES [dbo].[car] ([car_id])
GO
ALTER TABLE [dbo].[favorite_car]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[feeback]  WITH CHECK ADD FOREIGN KEY([car_id])
REFERENCES [dbo].[car] ([car_id])
GO
ALTER TABLE [dbo].[feeback]  WITH CHECK ADD FOREIGN KEY([create_by])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[model]  WITH CHECK ADD FOREIGN KEY([brand_id])
REFERENCES [dbo].[brand] ([brand_id])
GO
USE [master]
GO
ALTER DATABASE [ADDDA_APP] SET  READ_WRITE 
GO
