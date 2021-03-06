USE [master]
GO
/****** Object:  Database [AngularHeroes]    Script Date: 22/04/2020 11:35:42 ******/
CREATE DATABASE [AngularHeroes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AngularHeroes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AngularHeroes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AngularHeroes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AngularHeroes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AngularHeroes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AngularHeroes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AngularHeroes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AngularHeroes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AngularHeroes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AngularHeroes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AngularHeroes] SET ARITHABORT OFF 
GO
ALTER DATABASE [AngularHeroes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AngularHeroes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AngularHeroes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AngularHeroes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AngularHeroes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AngularHeroes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AngularHeroes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AngularHeroes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AngularHeroes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AngularHeroes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AngularHeroes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AngularHeroes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AngularHeroes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AngularHeroes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AngularHeroes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AngularHeroes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AngularHeroes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AngularHeroes] SET RECOVERY FULL 
GO
ALTER DATABASE [AngularHeroes] SET  MULTI_USER 
GO
ALTER DATABASE [AngularHeroes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AngularHeroes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AngularHeroes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AngularHeroes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AngularHeroes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AngularHeroes', N'ON'
GO
ALTER DATABASE [AngularHeroes] SET QUERY_STORE = OFF
GO
USE [AngularHeroes]
GO
/****** Object:  User [IIS APPPOOL\HeroBusinessLayer]    Script Date: 22/04/2020 11:35:42 ******/
CREATE USER [IIS APPPOOL\HeroBusinessLayer] FOR LOGIN [IIS APPPOOL\HeroBusinessLayer] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\HeroBusinessLayer]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\HeroBusinessLayer]
GO
/****** Object:  Table [dbo].[Heroes]    Script Date: 22/04/2020 11:35:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heroes](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Heroes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AngularHeroes] SET  READ_WRITE 
GO
