USE [PERFILESSA]

DROP TABLE IF EXISTS ca_empleados

-- Crear tabla ca_empleados con codigoEmpleado como varchar(5)
CREATE TABLE [dbo].[ca_empleados](
    [codigoEmpleado] [varchar](5) NOT NULL,
    [nombres] [varchar](50) NOT NULL,
    [apellidos] [varchar](50) NOT NULL,
	[correo][varchar](50)NOT NULL,
	[password][varchar](50)NOT NULL,
    [DPI] [varchar](20) NOT NULL,
    [fechaNacimiento] [date] NOT NULL,
    [sexo] [char](1) NOT NULL,
    [fechaIngreso] [date] NOT NULL,
    [direccion] [varchar](512) NULL,
    [NIT] [varchar](15) NULL,
    [codigoDepartamento] [int] NOT NULL,
	[rol] varchar (10) NOT NULL,
    [edad] AS (DATEDIFF(YEAR, [fechaNacimiento], GETDATE())),
    CONSTRAINT [pk_ca_empleados] PRIMARY KEY CLUSTERED (
        [codigoEmpleado] ASC
    ),
    CONSTRAINT [fk_ca_empleados_departamento] FOREIGN KEY ([codigoDepartamento]) REFERENCES [dbo].[ca_departamentoArea]([codigoDepartamento])
);
select * from ca_empleados

-- Procedimientos almaceados (CRUD)


--Crear Empleado
DROP PROCEDURE IF EXISTS sp_CreateEmpleado
GO
CREATE PROCEDURE sp_CreateEmpleado
       @nombres varchar(50),
       @apellidos varchar(50),
       @correo varchar(50),
       @password varchar(50),
       @DPI varchar(20),
       @fechaNacimiento date,
       @sexo char(1),
       @fechaIngreso date,
       @direccion varchar(512),
       @NIT varchar(15),
       @codigoDepartamento int,
       @codigoEmpleadoGenerated varchar(5) OUTPUT,
       @rol varchar(10)
   AS
   BEGIN
       SET @codigoEmpleadoGenerated = LEFT(CONVERT(varchar(255), NEWID()), 5);

       INSERT INTO [dbo].[ca_empleados] (codigoEmpleado, nombres, apellidos, correo, password, DPI, fechaNacimiento, sexo, fechaIngreso, direccion, NIT, codigoDepartamento, rol)
       VALUES (@codigoEmpleadoGenerated, @nombres, @apellidos, @correo, @password, @DPI, @fechaNacimiento, @sexo, @fechaIngreso, @direccion, @NIT, @codigoDepartamento, @rol);
   END;

-- Ejemplo de llamada
DECLARE @newCodigoEmpleado varchar(5);

EXEC sp_CreateEmpleado 
    @nombres = 'Mario',
    @apellidos = 'Loco',
    @correo = 'mario.loco@example.com',
    @password = 'password123',
    @DPI = '1234567890123',
    @fechaNacimiento = '1990-05-15',
    @sexo = 'M',
    @fechaIngreso = '2010-01-01',
    @direccion = 'Dirección 123',
    @NIT = '12345678901234',
    @codigoDepartamento = 1,
    @rol = 'admin',
    @codigoEmpleadoGenerated = @newCodigoEmpleado OUTPUT;
PRINT 'Nuevo Código de Empleado: ' + @newCodigoEmpleado;


-- Obtener Empleado por Código
DROP PROCEDURE IF EXISTS sp_GetEmpleadoByCodigo
GO
CREATE PROCEDURE sp_GetEmpleadoByCodigo
    @codigoEmpleado varchar(5) 
AS
BEGIN
    SELECT * FROM [dbo].[ca_empleados] WHERE codigoEmpleado = @codigoEmpleado;
END

-- Ejemplo de llamada
EXEC sp_GetEmpleadoByCodigo @codigoEmpleado = 'FBA6A';




-- Actualizar Empleado
DROP PROCEDURE IF EXISTS sp_UpdateEmpleado
GO
CREATE PROCEDURE sp_UpdateEmpleado
    @codigoEmpleado varchar(5),
    @nombres varchar(50),
    @apellidos varchar(50),
    @correo varchar(50),
    @password varchar(50),
    @DPI varchar(20),
    @fechaNacimiento date,
    @sexo char(1),
    @fechaIngreso date,
    @direccion varchar(512),
    @NIT varchar(15),
    @codigoDepartamento int
AS
BEGIN
    UPDATE [dbo].[ca_empleados]
    SET nombres = @nombres,
        apellidos = @apellidos,
        correo = @correo,
        password = @password,
        DPI = @DPI,
        fechaNacimiento = @fechaNacimiento,
        sexo = @sexo,
        fechaIngreso = @fechaIngreso,
        direccion = @direccion,
        NIT = @NIT,
        codigoDepartamento = @codigoDepartamento
    WHERE codigoEmpleado = @codigoEmpleado;
END

-- Ejemplo de llamada
EXEC sp_UpdateEmpleado 
    @codigoEmpleado = 'FBA6A',
    @nombres = 'Mani',
    @apellidos = 'Perez',
    @correo = 'mani.perez@example.com',
    @password = 'newpassword456',
    @DPI = '9876543210123',
    @fechaNacimiento = '1985-08-20',
    @sexo = 'F',
    @fechaIngreso = '2008-03-10',
    @direccion = 'Nueva Dirección',
    @NIT = '56789012345678',
    @codigoDepartamento = 3;


-- Eliminar Empleado
DROP PROCEDURE IF EXISTS sp_DeleteEmpleado
GO
CREATE PROCEDURE sp_DeleteEmpleado
    @codigoEmpleado varchar(5)
AS
BEGIN
    DELETE FROM [dbo].[ca_empleados] WHERE codigoEmpleado = @codigoEmpleado;
END

-- Ejemplo de llamada
EXEC sp_DeleteEmpleado @codigoEmpleado = 'FBA6A';




-- Crear procedimiento almacenado para validar correo y contraseña
DROP PROCEDURE IF EXISTS sp_Login
GO
CREATE PROCEDURE sp_Login
    @correo varchar(50),
    @password varchar(50)
AS
BEGIN
    DECLARE @validacion int;

    -- Verificar si el correo y la contraseña son válidos
    SELECT @validacion = COUNT(*)
    FROM [dbo].[ca_empleados]
    WHERE correo = @correo AND password = @password;

    -- Devolver 1 si son válidos, 0 si no son válidos
    SELECT @validacion AS Validacion;
END;

-- Ejemplo de llamada al procedimiento de login
DECLARE @resultado int;

EXEC sp_Login 
    @correo = 'mario.loco@example.com',
    @password = 'password123';

-- Obtener el resultado
SELECT @resultado AS Resultado;



-- Crear procedimiento almacenado para listar empleados
DROP PROCEDURE IF EXISTS sp_ListarEmpleados
GO
CREATE PROCEDURE sp_ListarEmpleados
AS
BEGIN
    -- Seleccionar todos los empleados
    SELECT *
    FROM [dbo].[ca_empleados];
END;
-- Ejemplo de llamada al procedimiento de listar empleados
EXEC sp_ListarEmpleados;

SELECT @@SERVERNAME AS 'Nombre del Servidor';