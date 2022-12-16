create database ENCUESTAS;
CREATE TABLE dbo.encuesta
    (IdEncuesta int identity(1,1) PRIMARY KEY ,
    nombreEncuesta varchar(50) NOT NULL,
    categoriaEncuesta varchar (50)not NULL,
    estatusEncuesta bit
	)
GO

CREATE TABLE dbo.preguntas
    (IdPregunta int identity(1,1) PRIMARY KEY,
    tipoPregunta bit NOT NULL,
    estatuspregunta bit
	)
GO

CREATE TABLE dbo.usuario
    (IdUsuario int identity(1,1) PRIMARY KEY,
    nombreUsuario varchar(50) NOT NULL,
	apellidoPusuario varchar(50) NOT NULL,
	apellidoMusuario varchar(50) NOT NULL,
    email varchar (50)not NULL,
	contraseña varchar (50) not null,
    estatusUsuario bit
	)
GO	