
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
/****** Object:  Table [dbo].[booking]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[booking_status]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[brand]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[car]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[car_status]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[car_type]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[customer]    Script Date: 28/10/2023 14:46:06 ******/
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
	[password] [nvarchar](100) NULL,
	[role_id] [int] NULL,
	[id_number] [nvarchar](255) NULL,
	[id_frontside] [nvarchar](255) NULL,
	[id_backside] [nvarchar](255) NULL,
	[verify_flg] [int] NULL,
	[sex] [nchar](10) NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[favorite_car]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[feeback]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[model]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[role]    Script Date: 28/10/2023 14:46:06 ******/
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
/****** Object:  Table [dbo].[vehicle_registration]    Script Date: 28/10/2023 14:46:06 ******/
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
SET IDENTITY_INSERT [dbo].[address] ON 

INSERT [dbo].[address] ([address_id], [address_name], [customer_id]) VALUES (2, N'HN2e2e2', 1)
INSERT [dbo].[address] ([address_id], [address_name], [customer_id]) VALUES (3, N'HNN', 2)
INSERT [dbo].[address] ([address_id], [address_name], [customer_id]) VALUES (4, N'HB', 1)
INSERT [dbo].[address] ([address_id], [address_name], [customer_id]) VALUES (5, N'TT', 1)
SET IDENTITY_INSERT [dbo].[address] OFF
GO
SET IDENTITY_INSERT [dbo].[booking_status] ON 

INSERT [dbo].[booking_status] ([booking_status_id], [booking_status_name]) VALUES (1, N'Chờ xác nhận')
INSERT [dbo].[booking_status] ([booking_status_id], [booking_status_name]) VALUES (2, N'Đang giao xe')
INSERT [dbo].[booking_status] ([booking_status_id], [booking_status_name]) VALUES (3, N'Đã hoàn thành')
SET IDENTITY_INSERT [dbo].[booking_status] OFF
GO
SET IDENTITY_INSERT [dbo].[brand] ON 

INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (1, N'Audi')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (2, N'Baic')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (3, N'Bentley')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (4, N'BMW')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (5, N'Brilliance')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (6, N'Buick')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (7, N'Chevrolet')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (8, N'Daewoo')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (9, N'Daihatsu')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (10, N'Dongfeng')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (11, N'Fiat')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (12, N'Ford')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (13, N'Geely')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (14, N'Haima')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (15, N'Honda')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (16, N'Hyundai')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (17, N'Isuzu')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (18, N'Jaguar')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (19, N'Kenbo')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (20, N'Kia')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (21, N'Land Rover')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (22, N'Lexus')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (23, N'Luxgen')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (24, N'Mazda')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (25, N'Mercedes')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (26, N'Mitsubishi')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (27, N'Morris Garages')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (28, N'Nissan')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (29, N'Peugeot')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (30, N'Porsche')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (31, N'Renault')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (32, N'Riich')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (33, N'Samsung')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (34, N'SsangYong')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (35, N'Subaru')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (36, N'Suzuki')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (37, N'Tobe')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (38, N'Toyota')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (39, N'UAZ')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (40, N'Vinfast')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (41, N'Volkswagen')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (42, N'Volvo')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (43, N'Zotye')
INSERT [dbo].[brand] ([brand_id], [brand_name]) VALUES (44, N'')
SET IDENTITY_INSERT [dbo].[brand] OFF
GO
SET IDENTITY_INSERT [dbo].[car] ON 

INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (1, 800000, 2022, N'29K-99999', NULL, N'Huyện Hóc Môn, Hồ Chí Minh', N'car_1_1.jpg-car_1_2.jpg-car_1_3.jpg-car_1_4.jpg', 0, 1, 27, 242, 1, 1, NULL, 10000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (2, 1200000, 2018, N'51G-557.94', N'Toyota Camry s? t? d?ng dang ký nam 2018
Xe ch?y gia dình, n?i th?t nguyên b?n, s?ch s?, b?o du?ng d?nh k? thu?ng xuyên, xe du?c r?a và v? sinh s?ch s? tru?c khi giao cho khách.
Xe n?i th?t r?ng rãi, máy l?nh t?t, ti?n nghi, phù h?p di gia dình.', N'
Quận 7, Hồ Chí Minh', N'car_2_1.jpg-car_2_2.jpg-car_2_3.jpg-car_2_4.jpg', 0, 1, 38, 296, 1, 2, NULL, 20000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (3, 820000, 2017, N'51G-371.10', N'Xe Innova s? t? d?ng . Form m?i. Ð?y d? ti?n nghi . B?o hi?m 2 chi?u . N?i th?t d?p.có th? an ninh sân bay. Ðóng ti?n phí c?u du?ng online
', N'
Quận Tân Bình, Hồ Chí Minh', N'car_3_1.jpg-car_3_2.jpg-car_3_3.jpg-car_3_4.jpg', 0, 1, 38, 310, 1, 3, NULL, 15000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (4, 800000, 2009, N'29E-213.12', N'TOYOTA HILUX G 2010', N'Quận Gò Vấp, Hồ Chí Minh', N'car_4_1.jpg-car_4_2.jpg-car_4_3.jpg-car_4_4.jpg
', 0, 1, 38, 307, 2, 2, NULL, 12000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (5, 1100000, 2018, N'51G-793.30', N'TOYOTA FORTUNER G 2018', N'
Quận 10, Hồ Chí Minh', N'car_5_1.jpg-car_5_2.jpg-car_5_3.jpg-car_5_4.jpg', 0, 1, 38, 304, 2, 2, NULL, 8000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (6, 1250000, 2019, N'51H-031.58', N'Xe Honda CRV-L 2019 B?ng L nh?p kh?u.
Xe m?i ít di êm ít hao xang.
Xe ph?c v? gia dình là chính.Nay cho thuê thêm cho ngu?i c?n s? d?ng.
Th? t?c thuê nhanh g?n h?p lý ti?n cho 2 bên.
Giao nh?n xe t?i nhà.
Thuê có tài ho?c t? lái d?u du?c
Ph?c v? xuyên su?t L? T?t 24/7.
R?t mong ph?c v? m?i ngu?i.
Không s? d?ng xe m?c dich v?n chuy?n v?n t?i các v?t d?ng s?t nh?n dài không quá 1m và cao không quá 80cm.
Các hàng hoá gây cháy n? ch?t c?m.
B?o d?m tuân th? s? ngu?i cung nhu tr?ng t?i cho phép c?a nhà s?n xu?t.', N'Quận Tân Bình, Hồ Chí Minh', N'car_6_1.jpg-car_6_2.jpg-car_6_3.jpg-car_6_4.jpg', 0, 1, 15, 99, 2, 3, NULL, 10000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (7, 900000, 2020, N'51H-642.32', N'HONDA CITY 2020
Khách thuê d? l?i tài s?n c?c là xe máy + cavet g? có giá tr? trên 20tr ho?c ti?n m?t 20tr', N'Quận Tân Bình, Hồ Chí Minh', N'car_7_1.jpg-car_7_2.jpg-car_7_3.jpg-car_7_4.jpg', 0, 1, 15, 93, 1, 1, NULL, 5000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (8, 1000000, 2018, N'73A-105.09', N'Honda civic d?i 2018, xe gia dình s?ch s? ít di nên cho thuê', N'Quận Tân Bình, Hồ Chí Minh', N'car_8_1.jpg-car_8_2.jpg-car_8_3.jpg-car_8_4.jpg', 0, 1, 15, 95, 2, 1, NULL, 14000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (9, 1100000, 2022, N'51H-861.35', N'HONDA HRV G 2021
Màn hình android 
Youtube
Vietmaps
Sim 4G s?n mi?n phí', N'Quận 12, Hồ Chí Minh', N'car_9_1.jpg-car_9_2.jpg-car_9_3.jpg-car_9_4.jpg', 0, 1, 15, 100, 2, 2, NULL, 9000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (10, 700000, 2020, N'51H-314.25', N'Xa màu d?, s? sàn, 2020!
Khách thuê d? l?i tài s?n c?c là xe máy + cavet g? có giá tr? trên 20tr ho?c ti?n m?t 20tr', N'Quận Tân Bình, Hồ Chí Minh', N'car_10_1.jpg-car_10_2.jpg-car_10_3.jpg-car_10_4.jpg', 0, 1, 20, 170, 1, 1, NULL, 11000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (11, 800000, 2012, N'51A-099.85', N'kia caren s? t? d?ng , xe gia dinh di it , n?i th?t nguyên b?n , s?ch s? , b?o du?ng thu?ng xuyên , xe rông rai , an toàn , tiên nghi , phù h?p cho gia dinh di du l?ch , xe trang bi h? th?ng c?m bi?n lùi , g?t mua t? d?ng , h? th?ng giai tri AV, c?a s? tr?i ghê trinh diên và nhiêu tiên nghi khác', N'Quận Gò Vấp, Hồ Chí Minh', N'car_11_1.jpg-car_11_2.jpg-car_11_3.jpg-car_11_4.jpg', 0, 1, 20, 146, 4, 3, NULL, 15000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (12, 900000, 2022, N'51A-011.32', N'Kia Cerato xe dang kí 2021
Xe gia dình m?i d?p, n?i th?t nguyên b?n, s?ch s?, b?o du?ng thu?ng xuyên...
Xe r?ng rãi, an toàn, ti?n nghi, phù h?p cho gia dình du l?ch.
Xe trang b? c?m bi?n, camera lùi, b?n d? Gps, h? th?ng gi?i trí AV cùng nhi?u ti?n nghi khác.', N'
Quận Tân Bình, Hồ Chí Minh', N'car_12_1.jpg-car_12_2.jpg-car_12_3.jpg-car_12_4.jpg', 0, 1, 20, 151, 2, 3, NULL, 12000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (13, 1250000, 2019, N'51H-542.78', N'TH? T?C THUÊ XE :H? kh?u tphcm ho?c KT3, h? chi?u
Xe máy tr? giá > 30tr ho?c c?c 30tr
Giao nh?n xe t? 19h-21h
Mang b?ng lái theo d? d?i chi?u', N'
Quận Gò Vấp, Hồ Chí Minh', N'car_13_1.jpg-car_13_2.jpg-car_13_3.jpg-car_13_4.jpg', 0, 1, 20, 175, 4, 3, NULL, 12500)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (14, 1600000, 2022, N'51H-360.93', N'Xe VinFast Lux SA 2.07 ch? dang ký r?t m?i tháng 09/2020. Xe s? d?ng gia dình nên r?t m?i, s?ch s?, an toàn và du?c trang b? d?y d? ti?n nghi n?i th?t h? tr? cho gia dình có nhung chuy?n du l?ch cu?i tu?n tho?i mái, ti?n nghi', N'
Quận Tân Bình, Hồ Chí Minh', N'car_14_1.jpg-car_14_2.jpg-car_14_3.jpg-car_14_4.jpg', 0, 1, 40, 318, 4, 1, NULL, 7000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (15, 1200000, 2022, N'60K-128-14', N'Xe m?i s?ch d?p và trang tr?ng
Phù h?p ti?c, event, g?p d?i tác và các s? ki?n', N'Quận Tân Bình, Hồ Chí Minh', N'car_15_1.jpg-car_15_2.jpg-car_15_3.jpg-car_15_4.jpg', 0, 1, 40, 317, 2, 1, NULL, 9000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (16, 1050000, 2020, N'51K-265.53', N'Xe di?n VF E34 màu den còn m?i nhu v?a xu?t xu?ng.', N'Quận Tân Bình, Hồ Chí Minh', N'car_16_1.jpg-car_16_2.jpg-car_16_3.jpg-car_16_4.jpg', 0, 1, 40, 320, 2, 1, NULL, 10000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (17, 1450000, 2022, N'37K-123.50', N'VINFAST VF8 ECO 2023
Xe không d? xang ko mùi hôi, phí s?c tính theo odo 1200d/km ti?t ki?m 1/3 so v?i xe xang', N'
Quận Tân Bình, Hồ Chí Minh', N'car_17_1.jpg-car_17_2.jpg-car_17_3.jpg-car_17_4.jpg', 0, 1, 40, 322, 2, 1, NULL, 7000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (18, 730000, 2019, N'51H-202.50', N'- Ð?c bi?t trong xe không có mùi hôi gì, k? c? mùi xang... có 1 v? khách thuê xe di TP Vung Tàu, nhung ko xem k? quy d?nh c?a Mioto và ph?n mô t? xe trong app, và h?p d?ng tru?c khi ký, d?n khi tr? xe thì ko ch?u r?a xe ho?c tr? ph? thu phí r?a xe… nên có ý ki?n không dúng v? ch? xe và xe này!
- Quý khách d?t xe g?p trong vòng 2 gi? s? nh?n xe thì không du?c hu? thuê xe, n?u khách hu? s? b? m?t 30% ti?n dã d?t c?c nhé!
- Xe gia dình ít s? d?ng và ít hao xang, ch? 5,75lit/100km.
- Ch? m?i cho khách thuê du?c 15 ngày(m?t s? ngày khách dã d?t c?c thuê xe nhung ko d?n nh?n xe), nên xe còn m?i c?ng, và xe còn thom mùi xe m?i. 
- Xe Vinfast Fadil màu xanh duong, xe s? t? d?ng, có camera lùi, xe có 5 ch? ng?i!
- Màn hình c?m ?ng, USB nghe nh?c và radio, có c? s?c pin di?n tho?i trên xe, có khe c?m USB.
- Xe dang ký ngày 29/12/2019, nên thu?c d?i xe Vinfast 2020. Ð?ng co xang 1.4 lit. Xe ch?y êm, ch?y tang t?c nhanh hon, v?i t?c d? cao hon so v?i  các xe h?ng A khác ch? 1.1lit ho?c 1.2lit. 
- Dòng xe h?ng A có chung 1 thi?t k? cho dèn pha là màu vàng sáng y?u và m?. Xe 51H 20250dã thay dèn pha màu tr?ng r?t sáng d? quý khách quan sát rõ khi ch?y xe vào bu?i t?i!
- Xe có dèn ch?y ban ngày, có k?t n?i di?n tho?i v?i màng hình VCD trong xe qua bluetooth d? nói chuy?n di?n tho?i ? ch? d? r?nh tay(tay không c?m di?n tho?i).
- Thu phí t? d?ng không d?ng(quý khách ch?u phí c?u du?ng).
- Tru?c khi giao xe cho khách thì ch? xe dã r?a xe và v? sinh xe s?ch s?, vì v?y khi khách s? d?ng xe di chuy?n xa hay g?n và dù tr?i n?ng hay mua thì khách thuê xe ph?i r?a xe và v? sinh xe s?ch s? tru?c khi tr? xe l?i cho ch? xe nhé. Chúng ta cùng gi? xe s?ch s? cho nh?ng chuy?n di sau, c?m on r?t nhi?u! 
- Xin quý khách vui lòng không hút thu?c trong xe, trân tr?ng c?m on!', N'Quận Phú Nhuận, Hồ Chí Minh', N'car_18_1.jpg-car_18_2.jpg-car_18_3.jpg-car_18_4.jpg', 0, 1, 40, 316, 1, 2, NULL, 12000)
INSERT [dbo].[car] ([car_id], [price], [year_manufacture], [number_plate], [description], [address], [image], [is_delete], [car_status_id], [brand_id], [model_id], [car_type_id], [customer_id], [vehicle_registration_id], [count_journeys]) VALUES (26, 1100000, 2022, N'29K-9999', N'Xe dinh cap', N'Huu Bang', N'EXTy0_Screenshot (1).png-EXTy0_Screenshot (2).png-EXTy0_Screenshot (3).png-EXTy0_Screenshot (15).png', 1, 1, 1, 2, 2, 18, 1, 0)
SET IDENTITY_INSERT [dbo].[car] OFF
GO
SET IDENTITY_INSERT [dbo].[car_status] ON 

INSERT [dbo].[car_status] ([car_status_id], [car_status_name]) VALUES (1, N'Chờ duyệt')
INSERT [dbo].[car_status] ([car_status_id], [car_status_name]) VALUES (2, N'Bị từ chối')
INSERT [dbo].[car_status] ([car_status_id], [car_status_name]) VALUES (3, N'Chưa có chuyến')
INSERT [dbo].[car_status] ([car_status_id], [car_status_name]) VALUES (4, N'Đang có chuyến')
SET IDENTITY_INSERT [dbo].[car_status] OFF
GO
SET IDENTITY_INSERT [dbo].[car_type] ON 

INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (1, N'Mini', 4)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (2, N'Sedan', 4)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (3, N'Hatchback', 4)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (4, N'CUV Gầm cao', 5)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (5, N'SUV Gầm cao', 7)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (6, N'MPV Gầm thấp', 7)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (7, N'Bán tải', 4)
INSERT [dbo].[car_type] ([car_type_id], [car_type_name], [number_seats]) VALUES (8, N'Minivan Gầm thấp', 7)
SET IDENTITY_INSERT [dbo].[car_type] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (1, N'0123456789', N'duc@gmail.com', N'duc', N'nguyen trung', N'14/05/2003', N'$2a$11$OFsD2igUiXicGSmW6DEcO.lfennKjqkNNCLHUhDRbaybD6DJPDrfW', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (2, N'0987654321', N'duc1@gmail.com', N'trung', N'nguyen duc', N'15/05/2003', N'12345', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (3, N'0111444555', N'duc2@gmail.com', N'nguyen', N'trung duc', N'16/05/2003', N'123456', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (4, N'0999999999', N'duy@gmail.com', N'duy', N'nguyen dinh', N'11/11/2000', N'1234', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (5, N'0123498765', N'wibu@gmail.com', N'wibu', N'lord', N'01/04/1999', N'1111', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[customer] ([customer_id], [phone], [email], [name_display], [full_name], [birthday], [password], [role_id], [id_number], [id_frontside], [id_backside], [verify_flg], [sex]) VALUES (18, N'0866974684', NULL, N'DUCPDxsxs', N'', N'2023-09-30', N'$2a$11$KZFH7H6/rgRx0anx15mWU.qOSzVhlNyN6ONTjxso70nW91xwIJlaK', NULL, N'', N'C3PJr_Screenshot (1).png', N'C3PJr_Screenshot (20).png', 1, N'male      ')
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[model] ON 

INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (1, N'AUDI A1', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (2, N'AUDI A4', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (3, N'AUDI A5', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (4, N'AUDI A6', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (5, N'AUDI Q7', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (6, N'AUDI TTS', 1)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (7, N'BAIC BEIJING U5 PLUS DELUXE', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (8, N'BAIC BEIJING U5 PLUS LUXURY', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (9, N'BAIC BEIJING U5 PLUS STANDARD', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (10, N'BAIC BEIJING X7', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (11, N'BAIC CHANGHE Q7', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (12, N'BAIC X55', 2)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (13, N'BENTLEY CONTINENTAL', 3)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (14, N'BENTLEY GT SPORT', 3)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (15, N'BMW 218I GT LCI', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (16, N'BMW 320i', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (17, N'BMW 325I', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (18, N'BMW 334I SPORT', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (19, N'BMW 420I CABRIOLET', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (20, N'BMW 520i', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (21, N'BMW 523I', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (22, N'BMW 528i', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (23, N'BMW 530i', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (24, N'BMW 730Li', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (25, N'BMW 740Li', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (26, N'BMW 760LI', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (27, N'BMW I8', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (28, N'BMW X1', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (29, N'BMW X5', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (30, N'BMW X6', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (31, N'BMW Z4 SPORT', 4)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (32, N'BRILLIANCE V7', 5)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (33, N'CHEVROLET AVEO', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (34, N'CHEVROLET CAMARO', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (35, N'CHEVROLET CAPTIVA', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (36, N'CHEVROLET COLORADO (MT)', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (37, N'CHEVROLET COLORADO 4X2', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (38, N'CHEVROLET COLORADO 4X4', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (39, N'CHEVROLET CRUZE', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (40, N'CHEVROLET DUO', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (41, N'CHEVROLET LACETTI', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (42, N'CHEVROLET ORLANDO', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (43, N'CHEVROLET SPARK AT', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (44, N'CHEVROLET SPARK MT', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (45, N'CHEVROLET TRAILBLAZER', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (46, N'CHEVROLET TRAX', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (47, N'CHEVROLET VIVANT', 7)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (48, N'DAEWOO DCX', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (49, N'DAEWOO GENTRA', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (50, N'DAEWOO LACETTI', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (51, N'DAEWOO LANOS', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (52, N'DAEWOO MAGNUS', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (53, N'DAEWOO MATIZ', 8)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (54, N'DAIHATSU CHARADE', 9)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (55, N'DAIHATSU TERIOS', 9)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (56, N'DONGFENG LINGZHI M3', 10)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (57, N'FIAT ALBEA', 11)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (58, N'FORD ECOSPORT', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (59, N'FORD ESCAPE', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (60, N'FORD EVEREST', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (61, N'FORD EVEREST AMBIENTE', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (62, N'FORD EVEREST TITANIUM', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (63, N'FORD EVEREST TREND', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (64, N'FORD EXPLODER', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (65, N'FORD F-150 RAPTOR', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (66, N'FORD FIESTA', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (67, N'FORD FIESTA HATCHBACK', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (68, N'FORD FOCUS', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (69, N'FORD FOCUS HATCHBACK', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (70, N'FORD IMAX', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (71, N'FORD LASER', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (72, N'FORD MONDEO', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (73, N'FORD RANGER MT', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (74, N'FORD RANGER LIMITED 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (75, N'FORD RANGER RAFTOR 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (76, N'FORD RANGER SPORT 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (77, N'FORD RANGER WILDTRAK 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (78, N'FORD RANGER XLS 4X2', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (79, N'FORD RANGER XLS 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (80, N'FORD RANGER XLT 4X4', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (81, N'FORD TERRITORY TITANIUM', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (82, N'FORD TERRITORY TREND', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (83, N'FORD TOURNEO TITANIUM', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (84, N'FORD TOURNEO TREND', 12)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (85, N'GEELY EMGRAND EC718', 13)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (86, N'HAIMA 3', 14)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (87, N'HAIMA FREEMA', 14)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (88, N'HONDA ACCORD', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (89, N'HONDA BRIO AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (90, N'HONDA BRIO MT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (91, N'HONDA BRV-G', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (92, N'HONDA BRV-L', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (93, N'HONDA CITY AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (94, N'HONDA CITY MT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (95, N'HONDA CIVIC G AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (96, N'HONDA CIVIC G MT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (97, N'HONDA CIVIC RS AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (98, N'HONDA CIVIS RS MT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (99, N'DONDA CRV', 15)
GO
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (100, N'HONDA HRV G AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (101, N'HONDA HRV L AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (102, N'HONDA HRV RS AT', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (103, N'HONDA JAZZ', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (104, N'HONDA ODYSSEY', 15)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (105, N'HYUNDAI ACCENT AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (106, N'HYUNDAI ACCENT MT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (107, N'HYUNDAI AVANTE', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (108, N'HYUNDAI VRETA', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (109, N'HYUNDAI ELANTRA AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (110, N'HYUNDAI ELANTRA PREMMIUM AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (111, N'HYUNDAI GENESIS', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (112, N'HYUNDAI GETZ', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (113, N'HYUNDAI GRAND I20', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (114, N'HYUNDAI GRAND STAREX', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (115, N'HYUNDAI I10 AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (116, N'HYUNDAI I10 MT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (117, N'HYUNDAI I10 SEDAN AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (118, N'HYUNDAI I10 SEDAN MT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (119, N'HYUNDAI I30 CW', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (120, N'DYUNDAI KONA AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (121, N'HYUNDAI SANTAFE AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (122, N'HYUNDAI SONATA', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (123, N'HYUNDAI STARGAZER AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (124, N'HYUNDAI TUCSON AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (125, N'HYUNDAI TUCSON TURBO AT', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (126, N'HYUNDAI VELOSER', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (127, N'HYUNDAI VERACRZ', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (128, N'HYUNDAI VERNA', 16)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (129, N'ISUZU DMAX MT', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (130, N'ISUZU DMAX 4X2 AT', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (131, N'ISUZU DMAX 4X4 AT', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (132, N'ISUZU HI LANDER', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (133, N'ISUZU MUX', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (134, N'ISUZU TROOPER', 17)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (135, N'JAGUAR E-PACE R-Dynamic 2.0L', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (136, N'JAGUAR E-PACE R-Dynamic S 2.0L', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (137, N'JAGUAR E-PACE 2.0L', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (138, N'JAGUAR F-PACE PRESTIGR', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (139, N'JAGUAR F-PACE PURE', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (141, N'JAGUAR F-PACE R-SPORT', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (142, N'JAGUAR XE', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (143, N'JAGUAR XF', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (144, N'JAGUAR XJL', 18)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (145, N'KENBO', 19)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (146, N'KIA CARENS AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (147, N'KIA CARENS MT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (148, N'KIA CARENS PREMIUM AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (149, N'KIA CARENS SIGNATURE AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (150, N'KIA CARNIVAL AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (151, N'KIA CERATO AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (152, N'KIA CERATO MT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (153, N'KIA FORTE', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (154, N'KIA K3 MT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (155, N'KIA K3 DELUXE AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (156, N'KIA K3 LUXURY', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (157, N'KIA K3 PREMIUM AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (158, N'KIA K5 AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (159, N'KIA MORNING AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (160, N'KIA MORNING MT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (161, N'KIA OPTIMA', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (162, N'KIA PICANTO', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (163, N'KIA RIO', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (164, N'KIA RIO HATCHBACK', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (165, N'KIA RONDO', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (166, N'KIA SEDONA AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (167, N'KIA SELTOS DELUXE AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (168, N'KIA SELTOS LUXURY AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (169, N'KIA SELTOS PREMIUM AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (170, N'KIA SOLUTO AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (171, N'KIA SOLUTO MT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (172, N'KIA SONET DELUXE AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (173, N'KIA SONET LUXURY', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (174, N'KIA SONET PREMIUM', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (175, N'KIA SORENTO AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (176, N'KIA SOUL', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (177, N'KIA SPORTAGE LUXURY AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (178, N'KIA SPORTAGE PREMIUM AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (179, N'KIA SPORTAGE SIGNATURE AT', 20)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (180, N'LAND ROVER RANGE ROVER EVOQUE 2.0 FIRST EDITION', 21)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (181, N'LAND ROVER RANGER ROVER EVOQUE 2.0 S', 21)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (182, N'LAND ROVER RANGE ROVER EVOQUE 2.0 S R-DYNAMIC S', 21)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (183, N'LAND ROVER RANGE ROVER EVOQUE 2.0 S R-DYNAMIC SE', 21)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (184, N'LEXUS ES 250', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (185, N'LEXUS GX', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (186, N'LEXUS IS 250C', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (187, N'LEXUS IS250', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (188, N'LEXUS RX350', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (189, N'LEXUS RX450H', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (190, N'LEXUS SC 430', 22)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (191, N'LUXGEN M7', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (192, N'LUXGEN U7 22T', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (193, N'MAZDA 2 AT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (194, N'MAZDA 2 MT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (195, N'MAZDA 2 HATCHBACK', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (196, N'MAZDA 2 LUXURY AT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (197, N'MAZDA 2 PREMIUM AT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (198, N'MAZDA 3 MT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (199, N'MAZDA 3 DELUXE AT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (200, N'MAZDA 3 LUXYRY', 24)
GO
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (201, N'MAZDA 6 LUXURY AT', 24)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (202, N'MAZDA 6 PREMIUM AT', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (203, N'MAZDA BT50', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (204, N'MAZDA BT 50 4X2', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (205, N'MAZDA CX3', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (206, N'MAZDA CX30', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (207, N'MAZDA CX5 DELUXE AT', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (208, N'MAZDA CX5 LUXURY AT', 23)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (209, N'MERCEDES A200', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (210, N'MERCEDES A250', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (211, N'MERCEDES AMG A45 4MATIC', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (212, N'MERCEDES AMG CLA 45 4MATIC', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (213, N'MERCEDES AMG GLC 43 4MATIC', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (214, N'MERCEDES C180 AT', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (215, N'MERCEDES C180 AMG AT', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (216, N'MERCEDES C200 AT', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (217, N'MERCEDES C200 CARBRIGOLET', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (218, N'MERCEDES C200 EXCLUSIVE', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (219, N'MERCEDES C250', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (220, N'MERCEDES C300', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (221, N'MERCEDES C300 AMG', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (222, N'MERCEDES CLA 200', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (223, N'MERCEDES CLA 250 4MATIC', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (224, N'MERCEDES E180', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (225, N'MERCEDES E200', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (226, N'MERCEDES E200', 25)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (227, N'MITSUBISHI ATTRAGE AT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (228, N'MITSUBISHI ATTRAGE MT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (229, N'MITSUBISHI GRANDIS', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (230, N'MITSUBISHI JOLIE', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (231, N'MITSUBISHI LANCER GALA GLX', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (232, N'MITSUBISHI MIRAGE', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (233, N'MITSUBISHI OUTLANDER AT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (234, N'MITSUBISHI OUTLANDER PREMIUM', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (235, N'MITSUBISHI PAJERO SPORT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (236, N'MITSUBISHI TRITON MT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (237, N'MITSUBISHI TRITON 4X2', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (238, N'MITSUBISHI TRITON 4X4 AT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (239, N'MITSUBISHI XPANDER AT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (240, N'MITSUBISHI XPANDER MT', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (241, N'MITSUBISHI ZINGER', 26)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (242, N'MG 5 LUXURY', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (243, N'MG 5 STANDARD', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (244, N'MORRIS GARAGES HS LUX TROPHY', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (245, N'MORRIS GARAGES HS LUXURY', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (246, N'MORRIS GARAGES HS STANDARD', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (247, N'MORRIS GARAGES MG6', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (248, N'MG ZS LUXYRY AT', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (249, N'MG ZS STANDARD AT', 27)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (250, N'NISSAN ALMERA E', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (251, N'NISSAN ALMERA EL', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (252, N'NISSAN ALMERA VL', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (253, N'NISSAN GEAND LIVINA', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (254, N'NISSAN NAVARA 4X2', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (255, N'NISSAN NAVARA 4X4', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (256, N'NISSAN QASHQAI', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (257, N'NISSAN SUNNY', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (258, N'NISSAN TRANA', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (259, N'NISSAN TERRA', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (260, N'NISSAN X TRAIL', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (261, N'NISSAN Z350', 28)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (262, N'PEUGEOT 107', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (263, N'PEUGEOT 2008 AT', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (264, N'PEUGEOT 208', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (265, N'PEUGEOT 3008', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (266, N'PEUGEOT 308', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (267, N'PEUGEOT 408', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (268, N'PEUGEOT 5008 AT', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (269, N'PEUGEOT 508', 29)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (270, N'PORSCHE CAYENNE GTS', 30)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (271, N'PORSCHE PANAMERA', 30)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (272, N'RENAULT KOLEOS', 31)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (273, N'RIICH M1', 32)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (274, N'SAMSUNG SM3', 33)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (275, N'SSANGYONG REXTON', 34)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (276, N'SSANGYON STAVIC', 34)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (277, N'SSANGYONG TILOVI', 34)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (278, N'SSANGYONG SLV', 34)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (279, N'SUBARU FORESTER 2.0i-L', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (280, N'SUBARU FORESTER 2.0i-S', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (281, N'SUBARU FORESTER 2.0i-S EYESIGHT', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (282, N'SUBARU LEVORG HATCHBACK', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (283, N'SUBARU LEVORG SEDAN', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (284, N'SUBARU OUTBACK 2.5i-EYESIGHT', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (285, N'SUBARU SV 2.0I-S EYESIGHT', 35)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (286, N'SUZUKI APV', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (287, N'SUZUKI CELERIO', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (288, N'SUZUKI CIAZ', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (289, N'SUZUKI ERTIGA AT', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (290, N'SUZUKI ERTIGA MT', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (291, N'SUZUKI SWIFT', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (292, N'SUZUKI VITARA', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (293, N'SUZUKI XL AT', 36)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (294, N'TOBE MCAR', 37)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (295, N'TOYOTA AVANZA', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (296, N'TOYOTA CAMRY AT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (297, N'TOYOTA CAMRY MT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (298, N'TOYOTA COROLLA ALTIS E', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (299, N'TOYOTA COROLLA ALTIS G', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (300, N'TOYOTA COROLLA ALTIS V', 38)
GO
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (301, N'TOYOTA COROLLA CROSS G', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (302, N'TOYOTA COROLLA CROSS HV', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (303, N'TOYOTA COROLLA CROSS V', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (304, N'TOYOTA FORTUNER MT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (305, N'TOYOTA FORTUNER AT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (306, N'TOYOTA FORTUNER LEGEND', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (307, N'TOYOTA HILUX MT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (308, N'TOYOTA HILUX 4X2', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (309, N'TOYOTA HILUX 4X4', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (310, N'TOYOTA INNOVA AT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (311, N'TOYOTA INNOVA MT', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (312, N'TOYOTA INNOVA VENTURER', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (313, N'TOYOTA LAND CRUISER', 38)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (314, N'UAZ PATRIOZ', 39)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (315, N'VINFAST VF9 ECO', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (316, N'VINFAST FADIL AT', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (317, N'VINFAST LUX A AT', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (318, N'VINFAST LUX SA 2.0', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (319, N'VINFAST PRESIDENT', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (320, N'VINFAST VF E34', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (321, N'VINFAST VF5', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (322, N'VINFAST VF8 ECO', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (323, N'VINFAST VF8 PLUS', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (324, N'VINFAST VF9 PLUS', 40)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (325, N'VOLKSWAGEN BEETLE', 41)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (326, N'VOLKSWAGEN POLO', 41)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (327, N'VOLKSWAGEN POLO HATCHBACK', 41)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (328, N'VOLKSWAGEN TERAMONT', 41)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (329, N'VOLVO S90', 42)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (330, N'VOLVO XC90 T6', 42)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (331, N'ZOTYE T600', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (332, N'ZOTYE T600S', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (333, N'ZOTYE T800', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (334, N'ZOTYE Z3 T300', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (335, N'ZOTYE Z300', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (336, N'ZOTYE Z500', 43)
INSERT [dbo].[model] ([model_id], [model_name], [brand_id]) VALUES (337, N'ZOTYE Z8 T700', 43)
SET IDENTITY_INSERT [dbo].[model] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([role_id], [role_name]) VALUES (1, N'User')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (2, N'owner')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (3, N'admin')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
INSERT [dbo].[vehicle_registration] ([vehicle_registration_id], [vehicle_registration_image], [vehicle_inspection_image]) VALUES (1, N'EXTy0_Screenshot (19).png', N'EXTy0_Screenshot (20).png')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__customer__B43B145F52031815]    Script Date: 28/10/2023 14:46:06 ******/
ALTER TABLE [dbo].[customer] ADD UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
