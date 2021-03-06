USE [minhsondb]
GO
/****** Object:  Table [dbo].[loaihang]    Script Date: 6/5/2015 1:36:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaihang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENLOAI] [nvarchar](50) NULL,
	[MOTA] [nvarchar](max) NULL,
	[NGAYNHAP] [date] NULL,
 CONSTRAINT [PK_loaihang_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 6/5/2015 1:36:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](50) NULL,
	[MOTA] [nvarchar](max) NULL,
	[NGAYNHAP] [date] NULL,
	[ID_LOAIHANG] [int] NULL,
 CONSTRAINT [PK_sanpham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[loaihang] ON 

INSERT [dbo].[loaihang] ([ID], [TENLOAI], [MOTA], [NGAYNHAP]) VALUES (1, N'MAYPHAY', N'BEN', CAST(N'2015-04-06' AS Date))
SET IDENTITY_INSERT [dbo].[loaihang] OFF
SET IDENTITY_INSERT [dbo].[sanpham] ON 

INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (1, N'FUSIKA', N'ben', CAST(N'2015-04-06' AS Date), 1)
INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (2, N'MONO', N'rio', CAST(N'2015-04-06' AS Date), 1)
INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (3, N'SHOCK', N'mono', CAST(N'2015-04-06' AS Date), 1)
INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (4, N'FUSIKA', N'ben', CAST(N'2015-04-06' AS Date), 1)
INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (5, N'MONO', N'rio', NULL, 1)
INSERT [dbo].[sanpham] ([ID], [TEN], [MOTA], [NGAYNHAP], [ID_LOAIHANG]) VALUES (6, N'SHOCK', N'mono', CAST(N'2015-04-06' AS Date), 1)
SET IDENTITY_INSERT [dbo].[sanpham] OFF
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [FK_sanpham_loaihang] FOREIGN KEY([ID_LOAIHANG])
REFERENCES [dbo].[loaihang] ([ID])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_sanpham_loaihang]
GO
