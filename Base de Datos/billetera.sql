USE [master]
GO
/****** Object:  Database [billetera_virtual]    Script Date: 11/17/2020 11:15:47 PM ******/
CREATE DATABASE [billetera_virtual]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'billetera_virtual', FILENAME = N'C:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\billetera_virtual.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'billetera_virtual_log', FILENAME = N'C:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\billetera_virtual_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [billetera_virtual] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [billetera_virtual].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [billetera_virtual] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [billetera_virtual] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [billetera_virtual] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [billetera_virtual] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [billetera_virtual] SET ARITHABORT OFF 
GO
ALTER DATABASE [billetera_virtual] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [billetera_virtual] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [billetera_virtual] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [billetera_virtual] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [billetera_virtual] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [billetera_virtual] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [billetera_virtual] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [billetera_virtual] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [billetera_virtual] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [billetera_virtual] SET  DISABLE_BROKER 
GO
ALTER DATABASE [billetera_virtual] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [billetera_virtual] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [billetera_virtual] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [billetera_virtual] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [billetera_virtual] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [billetera_virtual] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [billetera_virtual] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [billetera_virtual] SET RECOVERY FULL 
GO
ALTER DATABASE [billetera_virtual] SET  MULTI_USER 
GO
ALTER DATABASE [billetera_virtual] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [billetera_virtual] SET DB_CHAINING OFF 
GO
ALTER DATABASE [billetera_virtual] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [billetera_virtual] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [billetera_virtual] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'billetera_virtual', N'ON'
GO
ALTER DATABASE [billetera_virtual] SET QUERY_STORE = OFF
GO
USE [billetera_virtual]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[estado] [int] NULL,
	[idDireccion] [int] NULL,
	[nroTelefono] [nvarchar](50) NULL,
	[nroDNI] [nchar](10) NULL,
	[frontalDNI] [image] NULL,
	[traseraDNI] [image] NULL,
	[email] [nvarchar](25) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[idEntidadBancaria] [int] NULL,
	[idCliente] [int] NULL,
	[idTipoMoneda] [int] NULL,
	[cvu] [nvarchar](50) NULL,
	[fechaAlta] [date] NULL,
	[estado] [int] NULL,
	[saldo] [numeric](18, 2) NULL,
	[topeDescubierto] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[idDetalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[idFactura] [int] NULL,
	[idServicio] [int] NULL,
	[subTotal] [nchar](10) NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[idDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[idDireccion] [int] IDENTITY(1,1) NOT NULL,
	[calle] [nchar](20) NULL,
	[numero] [nchar](10) NULL,
	[idLocalidad] [int] NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entidad_Bancaria]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entidad_Bancaria](
	[idEntidadBancaria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NULL,
	[idDireccion] [int] NULL,
	[razonSocial] [nchar](10) NULL,
 CONSTRAINT [PK_Entidad_Bancaria] PRIMARY KEY CLUSTERED 
(
	[idEntidadBancaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[fechaElaboracion] [date] NULL,
	[total] [numeric](8, 2) NULL,
	[estado] [int] NULL,
	[fechaVencimiento] [nchar](10) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inversion]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inversion](
	[idInversion] [int] IDENTITY(1,1) NOT NULL,
	[idCuenta] [int] NULL,
	[idTipoInversion] [int] NULL,
	[fechaInicio] [date] NULL,
	[cantidadDias] [int] NULL,
	[montoInicial] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Inversion] PRIMARY KEY CLUSTERED 
(
	[idInversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[idLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](20) NULL,
	[idProvincia] [int] NULL,
	[codigoPostal] [nchar](10) NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[idLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[idOperacion] [int] IDENTITY(1,1) NOT NULL,
	[idTipoOperacion] [int] NULL,
	[idCuenta] [int] NULL,
	[nroOperacion] [nchar](10) NULL,
	[estado] [nchar](10) NULL,
	[fechaOperacion] [date] NULL,
	[horaOperacion] [nchar](10) NULL,
	[monto] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[idOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[idPago] [int] IDENTITY(1,1) NOT NULL,
	[idCuenta] [int] NULL,
	[idFactura] [int] NULL,
	[fecha] [date] NULL,
	[total] [numeric](8, 2) NULL,
	[cantCuotas] [int] NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](20) NULL,
	[descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[idServicio] [int] IDENTITY(1,1) NOT NULL,
	[idTipoServicio] [int] NULL,
	[nombre] [nchar](10) NULL,
	[descripcion] [nchar](10) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[idServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Inversion]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Inversion](
	[idTipoInversion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NULL,
	[descripcion] [nchar](10) NULL,
	[tasa] [numeric](2, 2) NULL,
 CONSTRAINT [PK_Tipo_Inversion] PRIMARY KEY CLUSTERED 
(
	[idTipoInversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Moneda]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Moneda](
	[idTipoMoneda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NULL,
	[descripcion] [nchar](10) NULL,
	[valor] [numeric](10, 3) NULL,
 CONSTRAINT [PK_Tipo_Moneda] PRIMARY KEY CLUSTERED 
(
	[idTipoMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Operacion]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Operacion](
	[idTipoOperacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nchar](10) NULL,
	[tasa] [int] NULL,
 CONSTRAINT [PK_Tipo_Operacion] PRIMARY KEY CLUSTERED 
(
	[idTipoOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Servicio]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Servicio](
	[idTipoServicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NULL,
	[descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_Tipo_Servicio] PRIMARY KEY CLUSTERED 
(
	[idTipoServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencia]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencia](
	[idTransferencia] [int] IDENTITY(1,1) NOT NULL,
	[idCuentaOrigen] [int] NULL,
	[idCuentaDestino] [int] NULL,
	[monto] [numeric](18, 2) NULL,
	[fechaOperacion] [date] NULL,
	[horaOperacion] [nchar](10) NULL,
	[motivo] [nchar](10) NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[idTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/17/2020 11:15:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[nombreUsuario] [nchar](20) NULL,
	[password] [nvarchar](30) NULL,
	[fechaAlta] [date] NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Direccion] FOREIGN KEY([idDireccion])
REFERENCES [dbo].[Direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Direccion]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Entidad_Bancaria] FOREIGN KEY([idEntidadBancaria])
REFERENCES [dbo].[Entidad_Bancaria] ([idEntidadBancaria])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Entidad_Bancaria]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Tipo_Moneda] FOREIGN KEY([idTipoMoneda])
REFERENCES [dbo].[Tipo_Moneda] ([idTipoMoneda])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Tipo_Moneda]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([idDetalleFactura])
REFERENCES [dbo].[Factura] ([idFactura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Servicio] FOREIGN KEY([idServicio])
REFERENCES [dbo].[Servicio] ([idServicio])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Servicio]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Localidad] FOREIGN KEY([idLocalidad])
REFERENCES [dbo].[Localidad] ([idLocalidad])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Localidad]
GO
ALTER TABLE [dbo].[Entidad_Bancaria]  WITH CHECK ADD  CONSTRAINT [FK_Entidad_Bancaria_Direccion] FOREIGN KEY([idEntidadBancaria])
REFERENCES [dbo].[Direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[Entidad_Bancaria] CHECK CONSTRAINT [FK_Entidad_Bancaria_Direccion]
GO
ALTER TABLE [dbo].[Inversion]  WITH CHECK ADD  CONSTRAINT [FK_Inversion_Cuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Inversion] CHECK CONSTRAINT [FK_Inversion_Cuenta]
GO
ALTER TABLE [dbo].[Inversion]  WITH CHECK ADD  CONSTRAINT [FK_Inversion_Tipo_Inversion] FOREIGN KEY([idInversion])
REFERENCES [dbo].[Tipo_Inversion] ([idTipoInversion])
GO
ALTER TABLE [dbo].[Inversion] CHECK CONSTRAINT [FK_Inversion_Tipo_Inversion]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Cuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Cuenta]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Tipo_Operacion] FOREIGN KEY([idOperacion])
REFERENCES [dbo].[Tipo_Operacion] ([idTipoOperacion])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Tipo_Operacion]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Cuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Cuenta]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Factura] FOREIGN KEY([idFactura])
REFERENCES [dbo].[Factura] ([idFactura])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Factura]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_Tipo_Servicio] FOREIGN KEY([idServicio])
REFERENCES [dbo].[Tipo_Servicio] ([idTipoServicio])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_Tipo_Servicio]
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_CuentaDestino] FOREIGN KEY([idCuentaDestino])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_CuentaDestino]
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_CuentaOrigin] FOREIGN KEY([idCuentaOrigen])
REFERENCES [dbo].[Cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_CuentaOrigin]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cliente]
GO
USE [master]
GO
ALTER DATABASE [billetera_virtual] SET  READ_WRITE 
GO
