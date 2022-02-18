-- =============================================  
-- Author:      Jesus Roberto Hernandez 
-- Create date: 07 02 2022
-- Description: Control Escolar
-- =============================================  

GO
--CREATE DATABASE SistemaEscolar;
--USE SistemaEscolar;


--tablas
IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Alumno')
BEGIN
	CREATE TABLE Alumno(
		idAlumno INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		nombre VARCHAR(50) NOT NULL,
		apellidos VARCHAR(50) NOT NULL,
		telefono INT NOT NULL,
		correo VARCHAR(50) NOT NULL,
		sexo VARCHAR(10) NOT NULL
	);
END

IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Maestro')
BEGIN
	CREATE TABLE Maestro(
		idMaestro INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		nombre VARCHAR(50) NOT NULL,
		apellidos VARCHAR(50) NOT NULL,
		telefono INT NOT NULL,
		correo VARCHAR(50) NOT NULL,
		sexo VARCHAR(10) NOT NULL
	);
END

IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Materia')
BEGIN
	CREATE TABLE Materia(
		idMateria INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		nombre VARCHAR(50) NOT NULL
	);
END

IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Periodo')
BEGIN
	CREATE TABLE Periodo(
		idPeriodo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		nombre VARCHAR(50) NOT NULL,
		fechaInicio DATE DEFAULT GETDATE() NOT NULL,
		fechaFin DATE DEFAULT GETDATE() NOT NULL
	);
END

IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Clase')
BEGIN
	CREATE TABLE Clase(
		idClase INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		idMateria INT NOT NULL FOREIGN KEY (idMateria) REFERENCES Materia(idMateria),
		idMaestro INT NOT NULL FOREIGN KEY (idMaestro) REFERENCES Maestro(idMaestro),
		idPeriodo INT NOT NULL FOREIGN KEY (idPeriodo) REFERENCES Periodo(idPeriodo),
		capacidad SMALLINT DEFAULT 0 NOT NULL
	);
END

IF NOT EXISTS (SELECT '' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AlumnoClase')
BEGIN
	CREATE TABLE AlumnoClase(
		idAlumnoClase INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		idAlumno INT NOT NULL FOREIGN KEY (idAlumno) REFERENCES Alumno(idAlumno),
		idPeriodo INT NOT NULL FOREIGN KEY (idPeriodo) REFERENCES Periodo(idPeriodo),
		idClase INT NOT NULL FOREIGN KEY (idClase) REFERENCES Clase(idClase),
		calificacion SMALLINT DEFAULT 0 NOT NULL 
	);
END

--procedimientos almacenados
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC CrudAlumno
	@idAlumno INT,
	@nombre VARCHAR(50),
	@apellidos VARCHAR(50),
	@telefono VARCHAR(10),
	@correo VARCHAR(50),
	@sexo VARCHAR(10),
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;
	
	IF @tipoOperacion = 1
	BEGIN
		INSERT INTO Alumno(nombre, apellidos, telefono, correo, sexo)
		VALUES (@nombre, @apellidos, @telefono, @correo, @sexo);
			
		SET @Resultado = 1;
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM Alumno (NOLOCK))
		BEGIN
			UPDATE Alumno SET nombre = @nombre, apellidos = @apellidos, telefono = @telefono, correo = @correo, sexo = @sexo		
			WHERE idAlumno = @idAlumno;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM Alumno (NOLOCK))
		BEGIN
			DELETE FROM Alumno WHERE idAlumno = @idAlumno;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END
GO

CREATE PROC ConsultarAlumnos
	@idAlumno INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idAlumno, nombre, apellidos, telefono, correo, sexo FROM Alumno (NOLOCK);
		RETURN;
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idAlumno, nombre, apellidos, telefono, correo, sexo FROM Alumno (NOLOCK) WHERE idAlumno = @idAlumno;
		RETURN;
	END
END
GO	

CREATE PROC CrudMaestro
	@idMaestro INT,
	@nombre VARCHAR(50),
	@apellidos VARCHAR(50),
	@telefono VARCHAR(10),
	@correo VARCHAR(50),
	@sexo VARCHAR(10),
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;

	IF @tipoOperacion = 1
	BEGIN
		INSERT INTO Maestro(nombre, apellidos, telefono, correo, sexo)
		VALUES (@nombre, @apellidos, @telefono, @correo, @sexo);
			
		SET @Resultado = 1;
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM Maestro (NOLOCK))
		BEGIN
			UPDATE Maestro SET nombre = @nombre, apellidos = @apellidos, telefono = @telefono, correo = @correo, sexo = @sexo		
			WHERE idMaestro = @idMaestro;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM Maestro (NOLOCK))
		BEGIN
			DELETE FROM Maestro WHERE idMaestro = @idMaestro;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END

CREATE PROC ConsultarMaestros
	@idMaestro INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idMaestro, nombre, apellidos, telefono, correo, sexo FROM Maestro (NOLOCK)
		RETURN;
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idMaestro, nombre, apellidos, telefono, correo, sexo FROM Maestro (NOLOCK) WHERE idMaestro = @idMaestro
		RETURN;
	END
END
GO	

CREATE PROC CrudMateria
	@idMateria INT,
	@nombre VARCHAR(50),
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;

	IF @tipoOperacion = 1
	BEGIN
		INSERT INTO Materia(nombre)
		VALUES (@nombre);
			
		SET @Resultado = 1;
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM Materia (NOLOCK))
		BEGIN
			UPDATE Materia SET nombre = @nombre		
			WHERE idMateria = @idMateria;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM Materia (NOLOCK))
		BEGIN
			DELETE FROM Materia WHERE idMateria = @idMateria;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END

CREATE PROC ConsultarMateria
	@idMateria INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idMateria, nombre FROM Materia (NOLOCK)
		RETURN;
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idMateria, nombre FROM Materia (NOLOCK) WHERE idMateria = @idMateria
		RETURN;
	END
END
GO	

CREATE PROC CrudPeriodo
	@idPeriodo INT,
	@nombre VARCHAR(50),
	@fechaInicio DATE,
	@fechaFin DATE,
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;

	IF @tipoOperacion = 1
	BEGIN
		INSERT INTO Periodo(nombre, fechaInicio, fechaFin)
		VALUES (@nombre, @fechaInicio, @fechaFin);
			
		SET @Resultado = 1;
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM Periodo (NOLOCK))
		BEGIN
			UPDATE Periodo SET nombre = @nombre, fechaInicio = @fechaInicio, fechaFin = @fechaFin	
			WHERE idPeriodo = @idPeriodo;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM Periodo (NOLOCK))
		BEGIN
			DELETE FROM Periodo WHERE idPeriodo = @idPeriodo;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END

CREATE PROC ConsultarPeriodo
	@idPeriodo INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idPeriodo, nombre, fechaInicio, fechaFin FROM Periodo (NOLOCK)
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idPeriodo, nombre, fechaInicio, fechaFin FROM Periodo (NOLOCK) WHERE idPeriodo = @idPeriodo
	END
END
GO	

CREATE PROC CrudAlumnoClase
	@idAlumnoClase INT,
	@idAlumno INT,
	@idPeriodo INT,
	@idClase INT,
	@calificacion SMALLINT,
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;

	IF @tipoOperacion = 1
	BEGIN
		IF NOT EXISTS (SELECT '' FROM AlumnoClase (NOLOCK))
		BEGIN
			INSERT INTO AlumnoClase(idAlumno, idPeriodo, idClase, calificacion)
			VALUES (@idAlumno, @idPeriodo, @idClase, @calificacion);
			
			SET @Resultado = 1;
		END
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM AlumnoClase (NOLOCK))
		BEGIN
			UPDATE AlumnoClase SET idAlumno = @idAlumno, idPeriodo = @idPeriodo, idClase = @idClase, calificacion = @calificacion
			WHERE idAlumnoClase = @idAlumnoClase;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM AlumnoClase (NOLOCK))
		BEGIN
			DELETE FROM AlumnoClase WHERE idAlumnoClase = @idAlumnoClase;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END


CREATE PROC ConsultarAlumnoClase
	@idAlumnoClase INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idAlumnoClase, mt.idAlumno AS idMateria, mt.nombre AS Materia, 
			P.idPeriodo AS idPeriodo, p.nombre AS Periodo, c.idClase, calificacion FROM AlumnoClase ac (NOLOCK)
		INNER JOIN Alumno mt on ac.idAlumno = mt.idAlumno
		INNER JOIN Periodo p on ac.idPeriodo = p.idPeriodo
		INNER JOIN Clase c on ac.idClase = c.idClase
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idAlumnoClase, mt.idAlumno AS idMateria, mt.nombre AS Materia, 
			P.idPeriodo AS idPeriodo, p.nombre AS Periodo, c.idClase, calificacion FROM AlumnoClase ac (NOLOCK)
		INNER JOIN Alumno mt on ac.idAlumno = mt.idAlumno
		INNER JOIN Periodo p on ac.idPeriodo = p.idPeriodo
		INNER JOIN Clase c on ac.idClase = c.idClase
		WHERE ac.idAlumnoClase = @idAlumnoClase
	END
END
GO

CREATE PROC CrudClase
	@idClase INT,
	@idMateria VARCHAR(50),
	@idMaestro INT,
	@idPeriodo INT,
	@capacidad SMALLINT,
    @tipoOperacion SMALLINT
AS
BEGIN
	--Retorna 1 si guardo un nuevo registro, 2 si fue actualización
	SET NOCOUNT ON; 
	DECLARE @Resultado SMALLINT = 0;

	IF @tipoOperacion = 1
	BEGIN
		IF NOT EXISTS (SELECT '' FROM Clase (NOLOCK))
		BEGIN
			INSERT INTO Clase(idMateria, idMaestro, idPeriodo, capacidad)
			VALUES (@idMateria, @idMaestro, @idPeriodo, @capacidad);
			
			SET @Resultado = 1;
		END
	END
	
	IF @tipoOperacion = 2
	BEGIN
		IF EXISTS (SELECT '' FROM Clase (NOLOCK))
		BEGIN
			UPDATE Clase SET idMateria = @idMateria, idMaestro = @idMaestro, idPeriodo = @idPeriodo, capacidad = @capacidad
			WHERE idClase = @idClase;
			
			SET @Resultado = 2;
		END
	END
	
	IF @tipoOperacion = 3
	BEGIN
		IF EXISTS (SELECT '' FROM Clase (NOLOCK))
		BEGIN
			DELETE FROM Clase WHERE idClase = @idClase;
			
			SET @Resultado = 3;
		END
	END
	
	SELECT @Resultado AS Resultado;
END
GO

CREATE PROC ConsultarClase
	@idClase INT,
	@tipoConsulta SMALLINT
AS
BEGIN
	IF @tipoConsulta = 1
	BEGIN
		SELECT idClase, mt.idMateria AS idMateria, mt.nombre AS Materia, me.idMaestro AS idMaestro, me.nombre AS Maestro, 
			P.idPeriodo AS idPeriodo, p.nombre AS Periodo, capacidad FROM Clase c (NOLOCK)
		INNER JOIN Materia mt on c.idMateria = mt.idMateria
		INNER JOIN Maestro me on c.idMaestro = me.idMaestro
		INNER JOIN Periodo P on c.idPeriodo = P.idPeriodo
	END
	
	IF @tipoConsulta = 2
	BEGIN
		SELECT idClase, mt.idMateria AS idMateria, mt.nombre AS Materia, me.idMaestro AS idMaestro, me.nombre AS Maestro, 
			P.idPeriodo AS idPeriodo, p.nombre AS Periodo, capacidad FROM Clase c (NOLOCK)
		INNER JOIN Materia mt on c.idMateria = mt.idMateria
		INNER JOIN Maestro me on c.idMaestro = me.idMaestro
		INNER JOIN Periodo P on c.idPeriodo = P.idPeriodo
		WHERE idClase = @idClase
	END
END
GO