USE [ADDDA_WEB]
GO
/****** Object:  Table [dbo].[address]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_name] [varchar](50) NULL,
	[customer_id] [int] NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[boocking_order]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[boocking_order](
	[boocking_order_id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [varchar](20) NULL,
	[start_time] [varchar](20) NULL,
	[end_date] [varchar](20) NULL,
	[end_time] [varchar](20) NULL,
	[total] [int] NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](255) NULL,
	[complete_flg] [int] NULL,
	[boocking_status_id] [int] NULL,
	[create_by] [int] NULL,
	[car_id] [int] NULL,
 CONSTRAINT [PK_BOOCKING_ORDER] PRIMARY KEY CLUSTERED 
(
	[boocking_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[boocking_status]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[boocking_status](
	[boocking_status_id] [int] IDENTITY(1,1) NOT NULL,
	[boocking_status_name] [varchar](50) NULL,
 CONSTRAINT [PK_boocking_status] PRIMARY KEY CLUSTERED 
(
	[boocking_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brand]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand_name] [varchar](255) NULL,
 CONSTRAINT [PK_BRAND] PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car](
	[car_id] [int] IDENTITY(1,1) NOT NULL,
	[price] [float] NULL,
	[year_manufacture] [int] NULL,
	[number_plate] [varchar](255) NULL,
	[description] [text] NULL,
	[address] [varchar](255) NULL,
	[image] [varchar](255) NULL,
	[is_delete] [int] NULL,
	[car_status_id] [int] NULL,
	[brand_id] [int] NULL,
	[model_id] [int] NULL,
	[car_type_id] [int] NULL,
	[customer_id] [int] NULL,
	[vehicle_registration_id] [int] NULL,
 CONSTRAINT [PK_CAR] PRIMARY KEY CLUSTERED 
(
	[car_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car_status]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car_status](
	[car_status_id] [int] IDENTITY(1,1) NOT NULL,
	[car_status_name] [varchar](50) NULL,
 CONSTRAINT [PK_car_status] PRIMARY KEY CLUSTERED 
(
	[car_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[car_type]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car_type](
	[car_type_id] [int] IDENTITY(1,1) NOT NULL,
	[car_type_name] [varchar](255) NULL,
	[number_seats] [int] NULL,
 CONSTRAINT [PK_CAR_TYPE] PRIMARY KEY CLUSTERED 
(
	[car_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[phone] [varchar](20) NULL,
	[email] [varchar](255) NULL,
	[name_display] [varchar](50) NULL,
	[full_name] [varchar](50) NULL,
	[birthday] [varchar](255) NULL,
	[password] [varchar](50) NULL,
	[role_name] [varchar](20) NULL,
	[id_number] [varchar](255) NULL,
	[id_frontside] [varchar](255) NULL,
	[id_backside] [varchar](255) NULL,
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
/****** Object:  Table [dbo].[favorite_car]    Script Date: 12/10/2023 22:20:35 ******/
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
/****** Object:  Table [dbo].[feeback]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feeback](
	[feeback_id] [int] IDENTITY(1,1) NOT NULL,
	[rate] [int] NULL,
	[comment] [text] NULL,
	[create_at] [varchar](20) NULL,
	[create_by] [int] NULL,
	[car_id] [int] NULL,
 CONSTRAINT [PK_FEEBACK] PRIMARY KEY CLUSTERED 
(
	[feeback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[model]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[model](
	[model_id] [int] IDENTITY(1,1) NOT NULL,
	[model_name] [varchar](255) NULL,
	[brand_id] [int] NULL,
 CONSTRAINT [PK_MODEL] PRIMARY KEY CLUSTERED 
(
	[model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehicle_registration]    Script Date: 12/10/2023 22:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle_registration](
	[vehicle_registration_id] [int] NOT NULL,
	[vehicle_registration_image] [varchar](255) NULL,
	[vehicle_inspection_image] [varchar](255) NULL,
 CONSTRAINT [PK_VEHICLE_REGISTRATION] PRIMARY KEY CLUSTERED 
(
	[vehicle_registration_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[address]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([customer_id])
GO
ALTER TABLE [dbo].[boocking_order]  WITH CHECK ADD FOREIGN KEY([boocking_status_id])
REFERENCES [dbo].[boocking_status] ([boocking_status_id])
GO
ALTER TABLE [dbo].[boocking_order]  WITH CHECK ADD FOREIGN KEY([car_id])
REFERENCES [dbo].[car] ([car_id])
GO
ALTER TABLE [dbo].[boocking_order]  WITH CHECK ADD FOREIGN KEY([create_by])
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
