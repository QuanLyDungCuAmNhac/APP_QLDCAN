USE [QL_DCAN]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_ManHinh]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_ManHinh](
	[MaManHinh] [varchar](50) NOT NULL,
	[TenManHinh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DM_] PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(100,1) NOT NULL,
	[MaKH] [int] NULL,
	[DiaChiGiaoHang] [nvarchar](200) NULL,
	[NgayDat] [date] NULL,
	[GhiChu] [nvarchar](100) NULL,
	[TongTien] [decimal](18, 0) NULL,
	[HinhThucThanhToan] [nvarchar](200) NULL,
	[TinhTrang] [nvarchar](100) NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[SDT] [nchar](11) NULL,
	[Email] [nchar](100) NULL,
	[Username] [char](100) NULL,
	[Password] [varchar](500) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoHang]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoHang](
	[MaKho] [int] IDENTITY(1,1) NOT NULL,
	[MaNCC] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[NgayNhap] [date] NULL,
	[GiaNhap] [float] NULL,
 CONSTRAINT [PK_KhoHang] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [nchar](11) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[SDT] [char](11) NULL,
	[Email] [nchar](100) NULL,
	[Username] [char](100) NULL,
	[Password] [char](200) NULL,
	[HoatDong] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_NguoiDungNhomNguoiDung]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_NguoiDungNhomNguoiDung](
	[MaNV] [int] NOT NULL,
	[MaNhomNguoiDung] [varchar](20) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_QL_NguoiDungNhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_NhomNguoiDung]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_NhomNguoiDung](
	[MaNhom] [varchar](20) NOT NULL,
	[TenNhom] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_QL_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_PhanQuyen]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_PhanQuyen](
	[MaNhomNguoiDung] [varchar](20) NOT NULL,
	[MaManHinh] [varchar](50) NOT NULL,
	[CoQuyen] [bit] NOT NULL,
 CONSTRAINT [PK_QL_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaNhomNguoiDung] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[SoLuong] [int] NULL,
	[MoTa] [nvarchar](500) NULL,
	[HinhAnh] [nchar](200) NULL,
	[TrangThai] [int] NULL,
	[MaTH] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 8/9/2024 3:09:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaTH] [int] IDENTITY(1,1) NOT NULL,
	[TenTH] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[MaTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (100, 3, 1, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (101, 4, 1, CAST(7400000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (102, 4, 1, CAST(7400000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (103, 2, 1, CAST(4560000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (104, 6, 1, CAST(5430000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (105, 4, 1, CAST(7400000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (106, 1, 3, CAST(9000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (107, 11, 1, CAST(7900000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (108, 12, 6, CAST(6000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (109, 1, 2, CAST(6000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (110, 1, 1, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (111, 21, 1, CAST(9000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (111, 24, 3, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (112, 1, 1, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (112, 2, 1, CAST(4560000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (113, 6, 1, CAST(5430000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (113, 7, 2, CAST(3900000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (114, 1, 1, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (114, 2, 1, CAST(4560000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (115, 21, 1, CAST(9000000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (116, 28, 1, CAST(4500000 AS Decimal(18, 0)))
GO
INSERT [dbo].[DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'MH001', N'Màn hình bán hàng')
INSERT [dbo].[DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'MH002', N'Màn hình sản phẩm')
INSERT [dbo].[DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'MH003', N'Màn hình đăng nhập')
INSERT [dbo].[DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'MH004', N'Màn hình kho')
INSERT [dbo].[DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'MH005', N'Màn hình thống kê')
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (100, 1, N'Nha Trang', CAST(N'2024-01-21' AS Date), N'Giao Nhanh', CAST(9000000 AS Decimal(18, 0)), N'Tiền Mặt', N'Chờ xác nhận', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (101, 2, N'Nha Trang', CAST(N'2024-04-05' AS Date), N'Giao Nhanh', CAST(13760000 AS Decimal(18, 0)), N'Tiền Mặt', N'Đang giao hàng', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (102, 4, N'Nha Trang', CAST(N'2024-05-05' AS Date), N'Giao Nhanh', CAST(21160000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (103, 3, N'Nha Trang', CAST(N'2024-06-05' AS Date), N'Giao Nhanh', CAST(4560000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (104, 1, N'Nha Trang', CAST(N'2024-07-05' AS Date), N'Giao Nhanh', CAST(3000000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (105, 2, N'Nha Trang', CAST(N'2024-10-21' AS Date), N'Giao Nhanh', CAST(9000000 AS Decimal(18, 0)), N'Chờ xác nhận', N'Chờ xác nhận', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (106, 4, N'Nha Trang', CAST(N'2024-12-21' AS Date), N'Giao Nhanh', CAST(9000000 AS Decimal(18, 0)), N'Chờ xác nhận', N'Chờ xác nhận', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (107, 1, N'Nha Trang', CAST(N'2024-03-21' AS Date), N'Giao Nhanh', CAST(3000000 AS Decimal(18, 0)), N'Tiền Mặt', N'Đang giao hàng', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (108, 1, N'Nha Trang', CAST(N'2024-08-05' AS Date), N'Giao Nhanh', CAST(9000000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (109, 2, N'Nha Trang', CAST(N'2024-08-05' AS Date), N'Giao Nhanh', CAST(7560000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (110, 2, N'33, Xã Tràng An, Huyện Bình Lục, Tỉnh Hà Nam', CAST(N'2024-08-05' AS Date), N'Giao Nhanh', CAST(3000000 AS Decimal(18, 0)), N'Chuyển khoản', N'Chờ xác nhận', NULL)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (111, 3, N'37, Xã Phú Yên, Huyện Phú Xuyên, Thành phố Hà Nội', CAST(N'2024-08-05' AS Date), N'Giao Nhanh', CAST(18000000 AS Decimal(18, 0)), N'COD', N'Chờ xác nhận', NULL)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (112, 5, NULL, CAST(N'2024-08-05' AS Date), NULL, CAST(7560000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (113, 6, NULL, CAST(N'2024-08-05' AS Date), NULL, CAST(13230000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (114, 7, NULL, CAST(N'2024-08-05' AS Date), NULL, CAST(7560000 AS Decimal(18, 0)), N'Tiền Mặt', N'Mua thành công', 1)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (115, 1, N'33, Xã Mỹ Khánh, Huyện Phong Điền, Thành phố Cần Thơ', CAST(N'2024-08-08' AS Date), NULL, CAST(9000000 AS Decimal(18, 0)), N'COD', N'Chờ xác nhận', NULL)
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [DiaChiGiaoHang], [NgayDat], [GhiChu], [TongTien], [HinhThucThanhToan], [TinhTrang], [MaNV]) VALUES (116, 1, N'33, Xã Viên An Đông, Huyện Ngọc Hiển, Tỉnh Cà Mau', CAST(N'2024-08-08' AS Date), NULL, CAST(4500000 AS Decimal(18, 0)), N'COD', N'Chờ xác nhận', NULL)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (1, N'Đỗ Thành Huy', N'0337841105 ', N'Thanhhuy9b@gmail.com                                                                                ', N'dothanhhuy123                                                                                       ', N'AJVJpZg3PXG+tOx28FqvJltt34MxDG0TRAMnhU4Aq/Lcwsm1wxop2GiKwE2d/t7D/Q==')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (2, N'Trần Nhật Vy', N'0919551661 ', N'Vytn@gmail.com                                                                                      ', N'trannhatvy123                                                                                       ', N'AC/ORZL7MWWUe5SWeZGWLWpRvJp5vhLG+g9eLKePiupYVtCFAGpykAq9nvg6TN6sXQ==')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (3, N'Nguyễn Văn Nam', N'0999888777 ', N'nam@gmail.com                                                                                       ', N'Nam123                                                                                              ', N'AK/++i3KY2PBrOojs107DYom78JDPvcYspLwQDLP3u7D5unWp1zmZADzkVDrmDG3pw==')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (4, N'Trần Văn Hoàng', N'0975441442 ', N'hoang123@gmail.com                                                                                  ', N'Hoang123                                                                                            ', N'AKNkuLWYItW69kL/s7WmviAfZr+OfXvz086fZrnC9TcreAytrMs/Nu7i8AuII2UjVg==')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (5, N'Cao Văn Tú', N'0979556665 ', N'Tu@gmail.com                                                                                        ', NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (6, N'Trần Văn B', N'031445678  ', N'Be@gmail.com                                                                                        ', NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [Username], [Password]) VALUES (7, N'Phan Văn A', N'033444111  ', N'phan@gmail.com                                                                                      ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[KhoHang] ON 

INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (1, 1, 1, 30, CAST(N'2024-07-10' AS Date), 300000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (2, 2, 4, 4, CAST(N'2024-06-12' AS Date), 300000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (3, 2, 1, 9, CAST(N'2024-08-05' AS Date), 500000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (4, 3, 1, 3, CAST(N'2024-08-05' AS Date), 3000000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (5, 2, 4, 4, CAST(N'2024-08-05' AS Date), 300000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (6, 1, 3, 1, CAST(N'2024-08-05' AS Date), 200000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (7, 1, 1, 1, CAST(N'2024-08-05' AS Date), 30000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (8, 1, 2, 1, CAST(N'2024-08-05' AS Date), 50000)
INSERT [dbo].[KhoHang] ([MaKho], [MaNCC], [MaSP], [SoLuongNhap], [NgayNhap], [GiaNhap]) VALUES (9, 1, 3, 1, CAST(N'2024-08-05' AS Date), 60000)
SET IDENTITY_INSERT [dbo].[KhoHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai]) VALUES (1, N'Loa và micro')
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai]) VALUES (2, N'Piano')
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai]) VALUES (3, N'Trống và bộ gõ')
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai]) VALUES (4, N'Guitar')
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoai]) VALUES (5, N'Phụ kiện')
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT]) VALUES (1, N'Nhạc Việt', N'0939398387 ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT]) VALUES (2, N'Hoàng Huy Music', N'0939488322 ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT]) VALUES (3, N'Nhạc cụ Quảng Hợp', N'0399485833 ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT]) VALUES (4, N'Nhạc cụ Quảng Hợp', N'0399485833 ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT]) VALUES (5, N'Âm nhạc Việt Thanh', N'0939817991 ')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SDT], [Email], [Username], [Password], [HoatDong]) VALUES (1, N'Nhat Vy', N'0314441765 ', N'vytn2812@gmail.com                                                                                  ', N'Vy123                                                                                               ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b                                                                                                                                        ', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SDT], [Email], [Username], [Password], [HoatDong]) VALUES (2, N'Duy', N'0509088880 ', N'duy@gmail.com                                                                                       ', N'Duy123                                                                                              ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b                                                                                                                                        ', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SDT], [Email], [Username], [Password], [HoatDong]) VALUES (3, N'Huy', N'0919991117 ', N'huy@gmail.com                                                                                       ', N'Huy123                                                                                              ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b                                                                                                                                        ', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SDT], [Email], [Username], [Password], [HoatDong]) VALUES (4, N'Thanh', N'0347441653 ', N'Thanh@gmail.com                                                                                     ', N'thanh123                                                                                            ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b                                                                                                                                        ', 1)
GO
INSERT [dbo].[QL_NguoiDungNhomNguoiDung] ([MaNV], [MaNhomNguoiDung], [GhiChu]) VALUES (1, N'N001', NULL)
INSERT [dbo].[QL_NguoiDungNhomNguoiDung] ([MaNV], [MaNhomNguoiDung], [GhiChu]) VALUES (2, N'N002', NULL)
INSERT [dbo].[QL_NguoiDungNhomNguoiDung] ([MaNV], [MaNhomNguoiDung], [GhiChu]) VALUES (3, N'N003', NULL)
GO
INSERT [dbo].[QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N001', N'Quản lí', N'Quản lí toàn bộ cửa hàng')
INSERT [dbo].[QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N002', N'Nhân viên bán hàng', N'Chịu trách nhiệm bán hàng')
INSERT [dbo].[QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N003', N'Nhân viên kho', N'Quản lí  nhập kho')
INSERT [dbo].[QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'N004', N'Nhan cong', N'abc')
GO
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N001', N'MH001', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N001', N'MH002', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N001', N'MH003', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N001', N'MH004', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N001', N'MH005', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N002', N'MH001', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N002', N'MH002', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N002', N'MH003', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N002', N'MH004', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N002', N'MH005', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N003', N'MH002', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N003', N'MH003', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N003', N'MH004', 1)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N003', N'MH005', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N004', N'MH001', 0)
INSERT [dbo].[QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'N004', N'MH004', 0)
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (1, N'Fender Stratocaster', 4, CAST(3000000 AS Decimal(18, 0)), 30, N'Player Plus Stratocaster là một nhạc cụ hoàn hảo để khơi dậy sự sáng tạo của bạn và giúp bạn nổi bật giữa đám đông.', N'sp5_tnay2q.jpg                                                                                                                                                                                          ', 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (2, N'Gibson Les Paul', 4, CAST(4560000 AS Decimal(18, 0)), 30, N'Originally introduced in 1988, the CE has become an essential part of the PRS line-up, offering the snap and response of bolt-on construction.', N'sp4_wd54ns.jpg                                                                                                                                                                                          ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (3, N'Squier Sonic Precision Bass', 4, CAST(6200000 AS Decimal(18, 0)), 8, N'Squier Sonic™ Precision Bass® đồng hành cùng bạn trên hành trình âm nhạc độc đáo với tốc độ chớp nhoáng', N'sp1_rxw26z.jpg                                                                                                                                                                                          ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (4, N'Jackson JS Series', 4, CAST(7400000 AS Decimal(18, 0)), 22, N'Swift, deadly and affordable, Jackson® JS Series guitars take an epic leap forward, making it easier than ever to get classic Jackson tone, looks and playability without breaking the bank.', N'sp40_u6mxkz.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (5, N'Jackson Pro Plus', 4, CAST(4570000 AS Decimal(18, 0)), 11, N'With premium features catering to highly-technical playing, multi-dimensional tone and ergonomic design, the brand-new Jackson Pro Plus Dinky® MDK HT7 model provides the ultimate high-performance experience for today''s modern players.', N'sp39_lu2vlt.jpg                                                                                                                                                                                         ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (6, N'Jackson X Series Soloist', 4, CAST(5430000 AS Decimal(18, 0)), 13, N'Distinctive and affordable, Jackson''s X Series Soloist models are built for speed and comfort! ', N'sp38_e9hnfl.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (7, N'Jackson X Series', 4, CAST(3900000 AS Decimal(18, 0)), 41, N'Boasting an electrifying offset angular shape and lightning-fast neck, Jackson X Series Kelly™ models exude metal sophistication', N'sp37_xuzzoq.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (8, N'Akai MPC Key 61 ', 2, CAST(2500000 AS Decimal(18, 0)), 12, N'Inside MPC Key 61, experience a new dimension of sound like never before. Powered by 25 plugin instrument engines at your fingertips', N'sp18_zek7km.jpg                                                                                                                                                                                         ', 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (9, N'Arturia KeyLab', 2, CAST(4000000 AS Decimal(18, 0)), 10, N'KeyLab MkII kết hợp kiểm soát toàn diện của KeyLab nguyên bản cổ điển của Arturia với quy trình làm việc hợp lý và các tính năng thông minh của KeyLab Essential', N'sp19_x5rqie.jpg                                                                                                                                                                                         ', 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (10, N'Yamaha PSR-E273 ', 2, CAST(5700000 AS Decimal(18, 0)), 5, N'Vừa là một công cụ giáo dục, vừa là một nhạc cụ tuyệt vời, PSR-E273 kết hợp Voice và Style chất lượng của Yamaha với các chức năng học tập và thực hành tinh tế', N'sp20_k0ssow.jpg                                                                                                                                                                                         ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (11, N'Novation MiniNova 37', 2, CAST(7900000 AS Decimal(18, 0)), 19, N'Đừng để kích thước đánh lừa bạn; MiniNova sở hữu công cụ âm thanh mạnh nhất và hiệu ứng của mọi synth micro. Đa âm hơn, nhiều bộ lọc hơn, nhiều hiệu ứng hơn, nhiều biến điệu hơn', N'sp21_pqloqj.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (12, N'Novation 61SL MKIII', 2, CAST(1000000 AS Decimal(18, 0)), -2, N'Novation SL MKIII là thiết bị quan trọng hoạt động hoàn hảo cùng DAW giúp bạn điều khiển toàn bộ phòng thu của mình', N'sp23_y6uo2h.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (13, N'Arturia MiniBrute 2', 2, CAST(4590000 AS Decimal(18, 0)), 5, N'MiniBrute 2 được phát triển từ bộ monosynth huyền thoại - một nhạc cụ đã cách mạng hoá chất âm analog với waveform, bộ lọc Steiner-Parker và Brute Factor có thể kết hợp với nhau. ', N'sp14_gmflha.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (14, N'TAMA SU42RS-AQM', 3, CAST(4100000 AS Decimal(18, 0)), 10, N'TAMA''s iconic sound returns with the limited edition Superstar Reissue, a revival after 40 years.', N'sp3_umz3wt.jpg                                                                                                                                                                                          ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (15, N'Gretsch RGE625RS', 3, CAST(12000000 AS Decimal(18, 0)), 9, N'The Gretsch Renegade series is a complete drum set package designed specifically for the entry-level drummer and packed with value. ', N'sp22_mlw6kw.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (16, N'Gretsch RGE625BS', 3, CAST(3000000 AS Decimal(18, 0)), 15, N'The Gretsch Renegade series is a complete drum set package designed specifically for the entry-level drummer and packed with value.', N'sp24_enkiqa.jpg                                                                                                                                                                                         ', 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (17, N'Gretsch GE4605R', 3, CAST(6400000 AS Decimal(18, 0)), 20, N'Gretsch’s ready-to-play Energy drum set now has more signature Gretsch features, more Gretsch sound and more Gretsch performance', N'sp26_dz63qq.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (18, N'Gretsch RGE625BM', 3, CAST(5400000 AS Decimal(18, 0)), 30, N'The Gretsch Renegade series is a complete drum set package designed specifically for the entry-level drummer and packed with value.', N'sp25_acpcfp.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (19, N'TAMA IP62H6W', 3, CAST(3800000 AS Decimal(18, 0)), 8, N'Imperialstar was further refined with matching wood hoops on the bass drum, newly-designed tom brackets and double-braced hardware, thus bringing Imperialstar up to a whole new level.', N'sp28_mjx39e.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (20, N'Marshall MX412AR', 1, CAST(4000000 AS Decimal(18, 0)), 50, N'Sheer power and fantastic quality, these 240w 4x12’s are compatible with most Marshall heads and are fitted with four Celestion G12E-60 speakers that can handle any genre.', N'sp2_srvclm.jpg                                                                                                                                                                                          ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (21, N'Fender 68 Custom', 1, CAST(9000000 AS Decimal(18, 0)), 28, N'''68 Customs đã trở thành dòng amp cực kỳ phổ biến dành cho những nghệ sĩ guitar yêu thích chất âm Fender cổ điển và có những chỉnh sửa phù hợp với người chơi ngày nay.', N'sp31_wxfg6g.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (22, N'Rode Podcaster', 1, CAST(3000000 AS Decimal(18, 0)), 20, N'RØDE Podcaster là micro điện động USB bắt âm theo hướng trực diện (end-address), kết hợp audio chất lượng broadcast cùng kết nối USB đơn giản', N'sp35_x3illw.jpg                                                                                                                                                                                         ', 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (23, N'Shure Beta', 1, CAST(4450000 AS Decimal(18, 0)), 10, N'Shure BETA 58A là vocal mic điện động định hướng supercardioid có output cao sử dụng khi tăng cường âm thanh chuyên nghiệp và thu âm studio đã trở thành lựa chọn hàng đầu', N'sp34_hkzyvo.jpg                                                                                                                                                                                         ', 1, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (24, N'Rode NT1-Kit Large', 1, CAST(3000000 AS Decimal(18, 0)), 26, N'NT1 là micro cực kỳ yên ắng, mức đo độ ồn tầm chỉ 4.5dBA. Thân mic gia công bằng máy từ nhôm 6061 và sau đó mạ nickel nhằm chống oxi hoá', N'sp33_bl2h4a.jpg                                                                                                                                                                                         ', 1, 4)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLoai], [DonGia], [SoLuong], [MoTa], [HinhAnh], [TrangThai], [MaTH]) VALUES (28, N'ABC', 1, CAST(4500000 AS Decimal(18, 0)), 11, N'abc', N'miusic.jpg                                                                                                                                                                                              ', 2, 1)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (1, N'Fender')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (2, N'Gibson')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (3, N'Ibanez')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (4, N'Focusrite')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (5, N'Squier')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (6, N'Marshall')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon1] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon1]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK_KhoHang_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK_KhoHang_NhaCungCap]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK_KhoHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK_KhoHang_SanPham]
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_NhanVien]
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[QL_NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NhomNguoiDung]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QL_PhanQuyen_DM_ManHinh] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[DM_ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_QL_PhanQuyen_DM_ManHinh]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QL_PhanQuyen_QL_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[QL_NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_QL_PhanQuyen_QL_NhomNguoiDung]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSP]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu] FOREIGN KEY([MaTH])
REFERENCES [dbo].[ThuongHieu] ([MaTH])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu]
GO
