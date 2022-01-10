

<-- CREANDO LA BASE DE DATOS-->

CREATE DATABASE CAPA01
GO

USE CAPA01


<-- TABLAS-->

CREATE TABLE tbl_TipoDocumento(

	Id int identity (1,1) PRIMARY KEY NOT NULL,
	Abreviatura varchar (20) NULL,
	Nombre varchar (100) NOT NULL,
	Activo bit NOT NULL

	)




CREATE TABLE tbl_Persona(


	id int identity (1,1) PRIMARY KEY NOT NULL,
	TipoDocumentoId int NOT NULL ,
	Nombre varchar (200) NOT NULL,
	ApellidoPaterno varchar (200) NOT NULL,
	ApellidoMaterno varchar (200) NOT NULL,
	Registro datetime NOT NULL,
	Nacimiento date NULL,
	NroDocumento varchar (100) NULL,
	Sueldo decimal (20,2) NULL,

	CONSTRAINT FK_Persona_TipoDocumento FOREIGN KEY (TipoDocumentoId) References tbl_TipoDocumento(Id)
	)

GO




<-- PARA CREAR LOS DIAGRAMAS EN LA BD-->
	ALTER AUTHORIZATION ON DATABASE ::CAPA01 TO SA

<-- PARA QUE LA TABLA PERSONA EXTRAIGA LA FECHA POR DEFECTO-->
	ALTER TABLE tbl_Persona ADD CONSTRAINT DF_Persona DEFAULT GETDATE() FOR Registro


<-- PROCEDIMIENTO ALACENADO PARA LISTAR PERSONA-->

CREATE PROCEDURE USP_PERSONA
AS
BEGIN
	SELECT * FROM tbl_Persona
END
GO
<-- EJECUTANDO EL PROCEDIMIENTO-->
	
EXEC USP_PERSONA


<-- INSERTANDO DATOS EN LA TABLA tbl_TipoDocumento-->

INSERT INTO tbl_TipoDocumento Values ( 'DNI','Documento_Identidad',1)
INSERT INTO tbl_TipoDocumento Values ( 'EXT','EXTRANJERIA',0)



<-- INSERTANDO DATOS EN LA TABLA tbl_PERSONA-->

INSERT INTO tbl_Persona (TipoDocumentoId,Nombre,ApellidoPaterno,ApellidoMaterno,Nacimiento,NroDocumento,Sueldo) Values(1,'Andree','Tejada','Apaico','1989-11-18','46182329',500.50)

INSERT INTO tbl_Persona (TipoDocumentoId,Nombre,ApellidoPaterno,ApellidoMaterno,Nacimiento,NroDocumento,Sueldo) Values(2,'Harold','Tejada','Apaico','1989-11-18','46182329',500.50)

INSERT INTO tbl_Persona (TipoDocumentoId,Nombre,ApellidoPaterno,ApellidoMaterno,Nacimiento,NroDocumento,Sueldo) Values(2,'CESAR','FUENTE','INKA','1989-11-18','48598745',1000.00)

INSERT INTO tbl_Persona (TipoDocumentoId,Nombre,ApellidoPaterno,ApellidoMaterno,Nacimiento,NroDocumento,Sueldo) Values(1,'VICTOR','GARCIA','FARO','1989-11-18','98745841',2000.00)



select * from tbl_TipoDocumento

select * from tbl_Persona



<-- PROCEDIMIENTO ALACENADO PARA REGISTRAR PERSONA-->

CREATE PROCEDURE USP_PERSONA_ADD
@Id Int,
@TipoDoc INT,
@Nombre VARCHAR(200),
@Apellido_Pa VARCHAR(200),
@Apellid_Ma VARCHAR(200),
@Registro DateTime,
@Nacimiento DATE,
@NroDoc VARCHAR(100),
@Sueldo decimal(20,2)
AS
BEGIN
	INSERT INTO tbl_Persona VALUES(@Id,@TipoDoc, @Nombre, @Apellido_Pa, @Apellid_Ma,@Registro,@Nacimiento, @NroDoc,@Sueldo)
END
GO



CREATE PROCEDURE USP_TIPODOC
AS
BEGIN
	SELECT  id,Abreviatura   FROM tbl_TipoDocumento
END
GO

EXEC USP_TIPODOC


<-- PROCEDIMIENTO ALACENADO PARA BORRAR PERSONA POR ID-->

CREATE PROCEDURE DELETE_PERSONA
@Id Int
AS
BEGIN
	DELETE FROM tbl_Persona where id = @Id
END


<-- PROBANDO EL PROCEDIMIENTO ALMACENADO-->
EXEC DELETE_PERSONA 1
EXEC DELETE_PERSONA 2

SELECT * FROM tbl_Persona


<-- PROCEDIMIENTO ALACENADO PARA ACTUALIZAR PERSONA-->

CREATE PROCEDURE UPDATE_PERSONA
@Id INT,
@TipoDoc INT,
@Nombre VARCHAR(200),
@Apellido_Pa VARCHAR(200),
@Apellid_Ma VARCHAR(200),
@Registro DateTime,
@Nacimiento DATE,
@NroDoc VARCHAR(100),
@Sueldo decimal(20,2)
AS
BEGIN 
	UPDATE tbl_Persona SET TipoDocumentoId = @TipoDoc,Nombre = @Nombre,ApellidoPaterno=@Apellido_Pa,ApellidoMaterno=@Apellid_Ma,Registro=@Registro,Nacimiento=@Nacimiento,NroDocumento=@NroDoc,
							Sueldo=@Sueldo WHERE id=@id
END
GO