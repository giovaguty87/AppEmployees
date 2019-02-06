USE [master]
GO
/****** Object:  Database [GlobalGio]    Script Date: 06/02/2019 9:18:07 a. m. ******/
CREATE DATABASE [GlobalGio] ON  PRIMARY 
( NAME = N'GlobalGio', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\GlobalGio.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GlobalGio_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\GlobalGio_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GlobalGio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GlobalGio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GlobalGio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GlobalGio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GlobalGio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GlobalGio] SET ARITHABORT OFF 
GO
ALTER DATABASE [GlobalGio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GlobalGio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GlobalGio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GlobalGio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GlobalGio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GlobalGio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GlobalGio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GlobalGio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GlobalGio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GlobalGio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GlobalGio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GlobalGio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GlobalGio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GlobalGio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GlobalGio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GlobalGio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GlobalGio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GlobalGio] SET  MULTI_USER 
GO
ALTER DATABASE [GlobalGio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GlobalGio] SET DB_CHAINING OFF 
GO
USE [GlobalGio]
GO
/****** Object:  Table [dbo].[ContractType]    Script Date: 06/02/2019 9:18:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContractType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 06/02/2019 9:18:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [nchar](10) NULL,
	[ContractType] [int] NULL,
	[hourlySalary] [varchar](50) NULL,
	[monthlySalary] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 06/02/2019 9:18:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Gio Gutierrez
-- Create date: 05/02/2019
-- Description:	Obtiene la lista de los comprobantes pendientes por publicar
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployees]
  @Id int = null
AS

declare
@sql varchar(5000),
@where varchar(5000)

BEGIN
	SET NOCOUNT ON;

	SET @where = ' WHERE ';
	IF (@Id <> '0')
	begin 
		SET @where = @where +' E.Id = ' + CAST(@Id AS varchar);
	end
	else
	begin
		SET @where = @where +' 1 = 1 ';
	end

	SET @sql = 'SELECT Name, LastName, CT.Description,HourlySalary,MonthlySalary
  FROM [dbo].[Employee] E WITH(NOLOCK)
  inner join ContractType CT on E.ContractType = CT.Id
  ' + @where;	

  
	print(@sql);

    --Execute query
	EXEC(@sql)
	  
END




GO
/****** Object:  StoredProcedure [dbo].[SaveEmployee]    Script Date: 06/02/2019 9:18:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Gio
-- Create date: 2019-02-05
-- Description:	Add new employee.
-- =============================================
CREATE PROCEDURE [dbo].[SaveEmployee]
	@name	varchar(50),
	@lastName varchar(50),	
	@typeContract int,
	@HourSalary varchar(50),
	@MonthSalary varchar(50)
AS
BEGIN
	-- grabar un nuevo empleado
	INSERT
		INTO Employee
			([Name],[LastName],[ContractType],[HourlySalary],[MonthlySalary])
		VALUES
			(@name, @lastName, @typeContract,@HourSalary,@MonthSalary)
END

GO
INSERT INTO [dbo].[ContractType]([Description])
VALUES('HourlySalaryEmployee')
GO
INSERT INTO [dbo].[ContractType]([Description])
VALUES('MonthlySalaryEmployee')
GO

USE [master]
GO
ALTER DATABASE [GlobalGio] SET  READ_WRITE 
GO