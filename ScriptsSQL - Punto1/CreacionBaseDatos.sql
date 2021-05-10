USE [master]
GO
/****** Object:  Database [SistemaFacturacionDigitalDB]    Script Date: 07/05/2021 18:05:20 ******/
CREATE DATABASE [SistemaFacturacionDigitalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaFacturacionDigitalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaFacturacionDigitalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaFacturacionDigitalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SistemaFacturacionDigitalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaFacturacionDigitalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET QUERY_STORE = OFF
GO
USE [SistemaFacturacionDigitalDB]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/05/2021 18:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [uniqueidentifier] NOT NULL,
	[CategoriaNombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 07/05/2021 18:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [bigint] NOT NULL,
	[ClienteTipoIdentificacion] [int] NULL,
	[ClienteNombre] [nvarchar](50) NULL,
	[ClienteDireccion] [nvarchar](100) NULL,
	[ClienteTelefono] [nvarchar](50) NULL,
	[ClienteEdad] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescripcionFactura]    Script Date: 07/05/2021 18:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescripcionFactura](
	[DescripcionFacturaId] [int] NOT NULL,
	[DescripcionFacturaCantidad] [int] NULL,
	[DescripcionFacturaPrecio] [decimal](18, 0) NULL,
	[FacturaId] [int] NULL,
	[ProductoId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_DescripcionFactura] PRIMARY KEY CLUSTERED 
(
	[DescripcionFacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 07/05/2021 18:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] NOT NULL,
	[FacturaFecha] [datetime] NULL,
	[ClienteId] [bigint] NULL,
	[FacturaIVAPorcentaje] [decimal](4, 2) NULL,
	[FacturaSubtotal] [decimal](18, 2) NULL,
	[FacturaTotal] [decimal](18, 2) NULL,
	[FacturaIVATotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 07/05/2021 18:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [uniqueidentifier] NOT NULL,
	[ProductoNombre] [nvarchar](50) NULL,
	[ProductoDescripcion] [nvarchar](max) NULL,
	[ProductoCantidad] [int] NULL,
	[ProductoPrecioUnitario] [decimal](18, 2) NULL,
	[CategoriaId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DescripcionFactura]  WITH CHECK ADD  CONSTRAINT [FK_DescripcionFactura_Factura] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[DescripcionFactura] CHECK CONSTRAINT [FK_DescripcionFactura_Factura]
GO
ALTER TABLE [dbo].[DescripcionFactura]  WITH CHECK ADD  CONSTRAINT [FK_DescripcionFactura_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[DescripcionFactura] CHECK CONSTRAINT [FK_DescripcionFactura_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
USE [master]
GO
ALTER DATABASE [SistemaFacturacionDigitalDB] SET  READ_WRITE 
GO

