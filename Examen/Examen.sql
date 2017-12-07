CREATE DATABASE Examen;

USE Examen;

IF EXISTS (SELECT '' FROM sys.objects WHERE TYPE = 'U' AND name = 'catClientes')
	DROP TABLE catClientes;
GO
CREATE TABLE catClientes(
	iduCliente INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(50) NULL,
	apellidoPaterno VARCHAR(50) NULL,
	apellidoMaterno VARCHAR(50) NULL,
	correo VARCHAR(50) NULL
);

GO

IF EXISTS (SELECT '' FROM sys.objects WHERE TYPE = 'P' AND name = 'procConsultarClientes')
	DROP PROC procConsultarClientes;
GO
CREATE PROC procConsultarClientes
	@iduCliente INT
AS
BEGIN
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT '' FROM catClientes NOLOCK WHERE iduCliente = @iduCliente) 
	BEGIN
		SELECT iduCliente, nombre, apellidoPaterno, apellidoMaterno, correo FROM catClientes c WITH(NOLOCK) 
		WHERE c.iduCliente = @iduCliente;
	END
	ELSE
	BEGIN
		SELECT iduCliente, nombre, apellidoPaterno, apellidoMaterno, correo FROM catClientes c WITH(NOLOCK)
	END
END

GO

IF EXISTS (SELECT '' FROM sys.objects WHERE TYPE = 'P' AND name = 'procGuardarCliente')
	DROP PROC procGuardarCliente;
GO
CREATE PROC procGuardarCliente
	@iduCliente INT,
	@nombre VARCHAR(50),
	@apellidoPaterno VARCHAR(50),
	@apellidoMaterno VARCHAR(50),
	@correo VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @resultado INT;
	IF EXISTS(SELECT '' FROM catClientes NOLOCK WHERE iduCliente = @iduCliente) 
	BEGIN
		UPDATE catClientes SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, apellidoMaterno = @apellidoMaterno, correo = @correo WHERE iduCliente = @iduCliente;
		
		SET @resultado = 2;
	END
	ELSE
	BEGIN
		INSERT INTO catClientes(nombre, apellidoPaterno, apellidoMaterno, correo) 
		VALUES(@nombre, @apellidoPaterno, @apellidoMaterno, @correo);
		
		SET @resultado = 1;
	END
	
	SELECT @resultado;
END

GO

IF EXISTS (SELECT '' FROM sys.objects WHERE TYPE = 'P' AND name = 'procEliminarCliente')
	DROP PROC procEliminarCliente;
GO
CREATE PROC procEliminarCliente
	@iduCliente INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @resultado INT;
	IF EXISTS(SELECT '' FROM catClientes NOLOCK WHERE iduCliente = @iduCliente) 
	BEGIN
		DELETE FROM catClientes WHERE iduCliente = @iduCliente;
		
		SET @resultado = 1;
	END
	ELSE
	BEGIN
		SET @resultado = 0;
	END
	
	SELECT @resultado;
END

GO