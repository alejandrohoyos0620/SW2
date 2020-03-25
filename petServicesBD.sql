USE [master]
GO
/** Object:  Database [petServices]    Script Date: 23/03/2020 2:51:11 a. m. **/
CREATE DATABASE [petServices]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'petServices', FILENAME = N'C:\Users\Usuario\petServices.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'petServices_log', FILENAME = N'C:\Users\Usuario\petServices_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [petServices] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [petServices].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [petServices] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [petServices] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [petServices] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [petServices] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [petServices] SET ARITHABORT OFF 
GO
ALTER DATABASE [petServices] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [petServices] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [petServices] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [petServices] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [petServices] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [petServices] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [petServices] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [petServices] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [petServices] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [petServices] SET  DISABLE_BROKER 
GO
ALTER DATABASE [petServices] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [petServices] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [petServices] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [petServices] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [petServices] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [petServices] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [petServices] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [petServices] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [petServices] SET  MULTI_USER 
GO
ALTER DATABASE [petServices] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [petServices] SET DB_CHAINING OFF 
GO
ALTER DATABASE [petServices] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [petServices] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [petServices] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [petServices] SET QUERY_STORE = OFF
GO
USE [petServices]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [petServices]
GO

/** Object:  Table [dbo].[calificaciones]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calificaciones](
	[id_calificacion] [int] IDENTITY(1,1) NOT NULL,
	[id_servicio] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[calificacion] [int] NOT NULL,
	[comentario] [nvarchar](max) NULL,
 CONSTRAINT [PK_calificaciones] PRIMARY KEY CLUSTERED 
(
	[id_calificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/** Object:  Table [dbo].[cliente]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[correo] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id_cliente], [direccion], [correo]) VALUES (1, N'CLL23', N'ALEJITO@HOLI.COM')
INSERT [dbo].[cliente] ([id_cliente], [direccion], [correo]) VALUES (2, N'CLL45', N'MARCE@HI.COM')
INSERT [dbo].[cliente] ([id_cliente], [direccion], [correo]) VALUES (3, N'CLL34', N'ROLO@HOLIBITIS.COM')
INSERT [dbo].[cliente] ([id_cliente], [direccion], [correo]) VALUES (4, N'CRA78', N'MANUEL@MONKEY.COM')
SET IDENTITY_INSERT [dbo].[cliente] OFF

/** Object:  Table [dbo].[mascotas]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mascotas](
	[id_dueño] [int] NOT NULL,
	[id_mascota] [int] IDENTITY(1,1) NOT NULL,
	[nombre_mascota] [varchar](50) NOT NULL,
	[raza] [varchar](50) NOT NULL,
	[pdf_canet] [varchar](50) NULL,
 CONSTRAINT [PK_mascotas] PRIMARY KEY CLUSTERED 
(
	[id_mascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[mascotas] ON 

INSERT [dbo].[mascotas] ([id_dueño], [id_mascota], [nombre_mascota], [raza], [pdf_canet]) VALUES (1, 1, N'CALIA', N'GOLDEN', N'PATH/HI')
INSERT [dbo].[mascotas] ([id_dueño], [id_mascota], [nombre_mascota], [raza], [pdf_canet]) VALUES (1, 2, N'REX', N'PASTOR',N'PATH/HII')
SET IDENTITY_INSERT [dbo].[mascotas] OFF

/** Object:  Table [dbo].[reserva]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reserva](
	[id_reservacion] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_reservaservicio] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
	[total] [int] NOT NULL,
	[estadoreserva] [nchar](2) NOT NULL,
	[tipopago] [nvarchar](50) NOT NULL,
	[factura] [nchar](1) NOT NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[id_reservacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/** Object:  Table [dbo].[servicios]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicios](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre_servicio] [nvarchar](50) NOT NULL,
	[descripcion_servicio] [nvarchar](max) NOT NULL,
	[imagen_servicio] [nvarchar](100) NOT NULL,
	[precio] [int] NOT NULL,
 CONSTRAINT [PK_servicios] PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[servicios] ON 
INSERT [dbo].[servicios] ([id_servicio], [nombre_servicio], [descripcion_servicio],[imagen_servicio],[precio]) VALUES (1, N'Hotel', N'¿Necesitas salir de viaje y no sabes con quién dejar a tu mascota? Nuestro hotel es la mejor opción para ti. Un hotel o pensión para mascotas es un lugar con las instalaciones y el personal adecuado para que tu mascota se sienta como en casa mientras tú no estás. 
Las largas jornadas laborales hacen que no podamos estar todo el tiempo que quisiéramos con nuestras mascotas. En muchas ocasiones, dejar a tu mascota sola en casa no es una opción, ya sea por su tamaño, porque es muy inquieto o porque tiene algunos problemas de comportamiento que ocasionan que tu casa o departamento luzca como un campo de batalla cuando regresas de trabajar.
Brindamos espacios abiertos en los que tu mascota pueda convivir con otros animales; lugares de descanso limpios y amplios; así como con veterinarios y personal capacitado para atender a tu mascota, los precios y beneficios de nuestro hotel varían dependiendo de su ubicación y de los servicios que ofrecemos. 
',N'hotel.png',80000)
INSERT [dbo].[servicios] ([id_servicio], [nombre_servicio], [descripcion_servicio],[imagen_servicio],[precio]) VALUES (2, N'Veterinaria', N'En la veterinaria mi mejor amigo, contamos con excelentes programas de medicina preventiva como es la aplicación de vacunas para perros, gatos y otras mascotas de los laboratorios más reconocidos, cuenta con médicos veterinarios expertos en diferentes disciplinas y con la metodología necesaria para llegar a los diagnósticos que permitirán enfocar los tratamientos de manera eficiente y oportuna, seguimos a detalle el expediente clínico orientado a problemas, en el que al conjuntar los datos generales, la historia clínica y el examen clínico podemos arrojar la lista de problemas que nos permitirá agrupar los signos de acuerdo a problemas específicos y recomendar las pruebas de laboratorio e imageniología complementarias.
Además tenemos servicio de Hospitalización, Medicina Interna, Laboratorio de análisis clínico, Etología, Reproducción, Servicio a domicilio, entre otras.
', N'veterinaria.png',20000)
INSERT [dbo].[servicios] ([id_servicio], [nombre_servicio], [descripcion_servicio],[imagen_servicio],[precio]) VALUES (3, N'Transporte', N'Si no cuentas con un automóvil que te permita transportar a tu mascota a donde quieras, estoy seguro de que te has enfrentado al problema de no encontrar a un taxista que se apiade de ti y te deje subir con ella. La necesidad de llevar a tu mascota al veterinario, a la estética o a pasear cerca de la ciudad no debería ser un problema. Existen diversos servicios que te ayudan a mover a tu mascota de un lugar a otro tanto dentro de la ciudad como fuera de ella. 
Mi mejor amigo te ayudará a transportar a tu mascota a donde sea que vayas. 
', N'transporte.png',35000)
INSERT [dbo].[servicios] ([id_servicio], [nombre_servicio], [descripcion_servicio],[imagen_servicio],[precio]) VALUES (4, N'Peluquería', N'Nuestras mascotas pueden sufrir estrés, depresión o nerviosismo. Además de ejercitarse, puedes optar por otras opciones de tratamiento para que tu perro o gato esté lo más tranquilo posible. Un spa para mascotas es un lugar en el que puedes llevar a tu animalito a disfrutar de un masaje o de un delicioso baño con sales y aceites hidratantes, además de música ambiental, para que salga con el pelo brillante y con una actitud relajada.
También ofrecemos en nuestros establecimientos estética para las mascotas, en donde bañarán a tu mascota, le cortarán las uñas, le lavarán los dientes y las glándulas (grooming), además de que le harán el corte de pelo que esté de moda en ese momento. 
', N'peluqueria.png',28000)
INSERT [dbo].[servicios] ([id_servicio], [nombre_servicio], [descripcion_servicio],[imagen_servicio],[precio]) VALUES (5, N'Paseador', N'¿Necesitas un niñero de mascota? Nuestros cuidadores están capacitados para cuidar de tu mascota y enseñarles buenas conductas. 
Las mascotas de los dueños son un miembro más de su familia y al dejarlas con una persona desconocida por primera vez, es normal que estén preocupados o se pregunten si le estarás brindando la atención y el cuidado que la mascota necesita, por eso nos aseguramos de generarte confianza, permanecer en contactos contigo, enviar noticias de tu mascota por medio de fotos y vídeos.
', N'paseador.png',40000)
SET IDENTITY_INSERT [dbo].[servicios] OFF

/** Object:  Table [dbo].[reservaServico]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservaServico](
	[id_reservaservicio] [int] IDENTITY(1,1) NOT NULL,
	[id_servicio] [int] NOT NULL,
	[id_mascota] [int] NOT NULL,
 CONSTRAINT [PK_reservaServico] PRIMARY KEY CLUSTERED 
(
	[id_reservaservicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[reservaServico] ON 
INSERT [dbo].[reservaServico] ([id_reservaservicio], [id_servicio], [id_mascota]) VALUES (2, 1, 1)
INSERT [dbo].[reservaServico] ([id_reservaservicio], [id_servicio], [id_mascota]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[reservaServico] OFF

/** Object:  Table [dbo].[usuarios]    Script Date: 3/21/2020 9:38:29 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre], [contraseña]) VALUES (1, N'AlejandroVelez', N'1234')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [contraseña]) VALUES (2, N'pedro', N'12345')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [contraseña]) VALUES (3, N'manuelty', N'8907')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [contraseña]) VALUES (4, N'ASD', N'ASDF')
SET IDENTITY_INSERT [dbo].[usuarios] OFF
ALTER TABLE [dbo].[calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_calificaciones_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[calificaciones] CHECK CONSTRAINT [FK_calificaciones_cliente]
GO
ALTER TABLE [dbo].[calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_calificaciones_servicios] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[servicios] ([id_servicio])
GO
ALTER TABLE [dbo].[calificaciones] CHECK CONSTRAINT [FK_calificaciones_servicios]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_usuario] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_usuario]
GO
ALTER TABLE [dbo].[mascotas]  WITH CHECK ADD  CONSTRAINT [FK_mascotas_dueñoCL] FOREIGN KEY([id_dueño])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[mascotas] CHECK CONSTRAINT [FK_mascotas_dueñoCL]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_cliente]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_reservaServicio] FOREIGN KEY([id_reservaservicio])
REFERENCES [dbo].[reservaServico] ([id_reservaservicio])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_reservaServicio]
GO
ALTER TABLE [dbo].[reservaServico]  WITH CHECK ADD  CONSTRAINT [FK_reservaServico_mascota] FOREIGN KEY([id_mascota])
REFERENCES [dbo].[mascotas] ([id_mascota])
GO
ALTER TABLE [dbo].[reservaServico] CHECK CONSTRAINT [FK_reservaServico_mascota]
GO
ALTER TABLE [dbo].[reservaServico]  WITH CHECK ADD  CONSTRAINT [FK_reservaServico_servico] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[servicios] ([id_servicio])
GO
ALTER TABLE [dbo].[reservaServico] CHECK CONSTRAINT [FK_reservaServico_servico]
GO
USE [master]
GO
ALTER DATABASE [petServices] SET  READ_WRITE 
GO