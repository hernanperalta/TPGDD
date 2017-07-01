

CREATE TABLE LOS_CHATADROIDES.Usuario
(
	username VARCHAR(50) PRIMARY KEY,
	password VARCHAR(64) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1
);


CREATE TABLE LOS_CHATADROIDES.Turno
(
	hora_inicio_turno NUMERIC(18,0),
	hora_fin_turno NUMERIC(18,0),
	descripcion VARCHAR(255) NOT NULL,
	valor_del_kilometro NUMERIC(18,2) NOT NULL,
	precio_base NUMERIC(18,2) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (hora_inicio_turno, hora_fin_turno)
);

CREATE TABLE LOS_CHATADROIDES.Rol
(
	nombre_del_rol VARCHAR(25) PRIMARY KEY,
	habilitado BIT NOT NULL DEFAULT 1
);

CREATE TABLE LOS_CHATADROIDES.Funcionalidad
(
	codigo_funcionalidad TINYINT IDENTITY(1,1) PRIMARY KEY,
	descripcion VARCHAR(50) NOT NULL
);


CREATE TABLE LOS_CHATADROIDES.Funcionalidad_X_Rol
(
	nombre_del_rol VARCHAR(25) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Rol(nombre_del_rol),
	codigo_funcionalidad TINYINT FOREIGN KEY REFERENCES LOS_CHATADROIDES.Funcionalidad(codigo_funcionalidad), 
	PRIMARY KEY (nombre_del_rol, codigo_funcionalidad)
);


CREATE TABLE LOS_CHATADROIDES.Cliente
(
	telefono NUMERIC(18,0) PRIMARY KEY,
	localidad VARCHAR(20) NOT NULL DEFAULT 'Sin Especificar',
	direccion VARCHAR(255) NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	dni NUMERIC(18,0) NOT NULL,
	fecha_de_nacimiento DATETIME NOT NULL,
	mail VARCHAR(255),
	codigo_postal VARCHAR(5) NOT NULL DEFAULT 'NA',
	depto VARCHAR(3) DEFAULT 'NA',
	nro_piso VARCHAR(3) DEFAULT 'NA',
	username VARCHAR(50) UNIQUE NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Usuario(username),
	habilitado BIT NOT NULL DEFAULT 1
);

CREATE TABLE LOS_CHATADROIDES.Chofer
(
	telefono NUMERIC(18,0) PRIMARY KEY,
	localidad VARCHAR(20) NOT NULL DEFAULT 'Sin Especificar',
	direccion VARCHAR(255) NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	dni NUMERIC(18,0) NOT NULL,
	fecha_de_nacimiento DATETIME NOT NULL,
	mail VARCHAR(50),
	depto VARCHAR(3) DEFAULT 'NA',
	nro_piso VARCHAR(3) DEFAULT 'NA',
	username VARCHAR(50) UNIQUE NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Usuario(username),
	habilitado BIT NOT NULL DEFAULT 1
);

CREATE TABLE LOS_CHATADROIDES.Administrador
(
	telefono NUMERIC(18,0) PRIMARY KEY,
	localidad VARCHAR(20) NOT NULL DEFAULT 'Sin Especificar',
	direccion VARCHAR(255) NOT NULL,
	depto VARCHAR(3) DEFAULT 'NA',
	nro_piso VARCHAR(3) DEFAULT 'NA',
	nombre VARCHAR(255) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	dni NUMERIC(18,0) NOT NULL,
	fecha_de_nacimiento DATETIME NOT NULL,
	mail VARCHAR(50),
	username VARCHAR(50) UNIQUE NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Usuario(username),
	habilitado BIT NOT NULL DEFAULT 1
);

CREATE TABLE LOS_CHATADROIDES.Rol_X_Usuario
(
	username VARCHAR(50) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Usuario(username),
	nombre_del_rol VARCHAR(25) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Rol(nombre_del_rol),
	habilitado BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (username, nombre_del_rol)
);


CREATE TABLE LOS_CHATADROIDES.Factura
(
	id_factura NUMERIC(18,0) PRIMARY KEY,
	telefono_cliente NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Cliente(telefono),
	fecha_facturacion DATETIME NOT NULL,
	fecha_inicio DATETIME NOT NULL,
	fecha_fin DATETIME NOT NULL,
	importe_total FLOAT NOT NULL
);

CREATE TABLE LOS_CHATADROIDES.Automovil
(
	patente VARCHAR(10) PRIMARY KEY,
	telefono_chofer NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Chofer(telefono),
	marca VARCHAR(255) NOT NULL,
	modelo VARCHAR(255) NOT NULL,
	licencia VARCHAR(26),
	rodado VARCHAR(10),
	habilitado BIT NOT NULL DEFAULT 1
);


CREATE TABLE LOS_CHATADROIDES.Auto_X_Turno
(
	hora_inicio_turno NUMERIC(18,0),
	hora_fin_turno NUMERIC(18,0),
	patente VARCHAR(10) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Automovil(patente),
	FOREIGN KEY (hora_inicio_turno, hora_fin_turno) REFERENCES LOS_CHATADROIDES.Turno(hora_inicio_turno, hora_fin_turno),
	PRIMARY KEY (hora_inicio_turno, hora_fin_turno, patente)
);

CREATE TABLE LOS_CHATADROIDES.Rendicion
(
	nro_rendicion NUMERIC(18,0) PRIMARY KEY,
	fecha DATETIME NOT NULL,
	telefono_chofer NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Chofer(telefono),
	importe_total NUMERIC(18,2) NOT NULL,
	hora_inicio_turno NUMERIC(18,0),
	hora_fin_turno NUMERIC(18,0),
	porcentaje_aplicado FLOAT CHECK(porcentaje_aplicado > 0 AND porcentaje_aplicado <= 1),
	FOREIGN KEY (hora_inicio_turno, hora_fin_turno) REFERENCES LOS_CHATADROIDES.Turno(hora_inicio_turno, hora_fin_turno)
);  


CREATE TABLE LOS_CHATADROIDES.Viaje
(
	numero_viaje INTEGER IDENTITY(1,1) PRIMARY KEY,
	nro_rendicion NUMERIC(18,0) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Rendicion(nro_rendicion),
	telefono_chofer NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Chofer(telefono),
	patente VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Automovil(patente),
	id_factura NUMERIC(18,0) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Factura(id_factura),
	telefono_cliente NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Cliente(telefono),
	hora_inicio_turno NUMERIC(18,0) NOT NULL,
	hora_fin_turno NUMERIC(18,0) NOT NULL,
	fecha_y_hora_inicio_viaje DATETIME NOT NULL,
	fecha_y_hora_fin_viaje DATETIME NOT NULL,
	kilometros_del_viaje NUMERIC(18,0) NOT NULL,
	FOREIGN KEY (hora_inicio_turno, hora_fin_turno) REFERENCES LOS_CHATADROIDES.Turno(hora_inicio_turno, hora_fin_turno)
);
GO


CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Turnos
AS
BEGIN
	DECLARE turnos_cursor CURSOR FOR
	SELECT Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base 
	FROM gd_esquema.Maestra 
	GROUP BY Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base 

	DECLARE @hora_inicio NUMERIC(18,0);
	DECLARE @hora_fin NUMERIC(18,0);
	DECLARE @descripcion VARCHAR(255);
	DECLARE @valor_km NUMERIC(18,2);
	DECLARE @precio_base NUMERIC(18,2);

	OPEN turnos_cursor;
	FETCH turnos_cursor INTO @hora_inicio, @hora_fin, @descripcion, @valor_km, @precio_base;

	WHILE (@@FETCH_STATUS = 0)
	BEGIN	
		INSERT INTO LOS_CHATADROIDES.Turno (hora_inicio_turno, hora_fin_turno, descripcion, valor_del_kilometro, precio_base) 
		VALUES (@hora_inicio, @hora_fin, @descripcion, @valor_km, @precio_base);
		FETCH turnos_cursor INTO @hora_inicio, @hora_fin, @descripcion, @valor_km, @precio_base;
	 END 

	 CLOSE turnos_cursor;
	 DEALLOCATE turnos_cursor;
END
GO

CREATE PROCEDURE LOS_CHATADROIDES.Cargar_Funcionalidades_X_Rol
AS
BEGIN
	DECLARE funcs_cursor CURSOR FOR
	SELECT codigo_funcionalidad FROM LOS_CHATADROIDES.Funcionalidad

	DECLARE @cod_func TINYINT;
	
	OPEN funcs_cursor
	FETCH funcs_cursor INTO @cod_func

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Funcionalidad_X_Rol 
			(nombre_del_rol, codigo_funcionalidad) VALUES ('Administrador', @cod_func);

		FETCH funcs_cursor INTO @cod_func
	END

	CLOSE funcs_cursor;
	DEALLOCATE funcs_cursor;
END
GO


CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Clientes
AS
BEGIN
	DECLARE clientes_cursor CURSOR FOR
	SELECT Cliente_Apellido, Cliente_Nombre, Cliente_Direccion, Cliente_Dni, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Telefono
	FROM gd_esquema.Maestra
	GROUP BY Cliente_Apellido, Cliente_Nombre, Cliente_Direccion, Cliente_Dni, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Telefono

	DECLARE @telefono NUMERIC(18,0);
	DECLARE @direccion VARCHAR(255);
	DECLARE @dni NUMERIC(18,0);
	DECLARE @mail VARCHAR(255);
	DECLARE @fecha_de_nac DATETIME;
	DECLARE @nombre VARCHAR(255);
	DECLARE @apellido VARCHAR(255);
	
	OPEN clientes_cursor
	FETCH clientes_cursor INTO @apellido, @nombre, @direccion, @dni, @mail, @fecha_de_nac, @telefono
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF( NOT EXISTS (SELECT username FROM LOS_CHATADROIDES.Usuario WHERE username = @nombre + '_' + @apellido) )
			BEGIN
				INSERT INTO LOS_CHATADROIDES.Usuario (username, password)
					VALUES (@nombre + '_' + @apellido, @nombre + '_' + @apellido);
			END;

		INSERT INTO LOS_CHATADROIDES.Cliente (telefono, direccion, nombre, apellido, dni, fecha_de_nacimiento, mail, username)
			   VALUES (@telefono, @direccion, @nombre, @apellido, @dni, @fecha_de_nac, @mail, @nombre + '_' + @apellido);
		
		FETCH clientes_cursor INTO @apellido, @nombre, @direccion, @dni, @mail, @fecha_de_nac, @telefono;
		
	END
	
	CLOSE clientes_cursor;
	DEALLOCATE clientes_cursor;
END
GO


CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Choferes
AS
BEGIN
	DECLARE choferes_cursor CURSOR FOR
	SELECT Chofer_Apellido, Chofer_Nombre, Chofer_Direccion, Chofer_Dni, Chofer_Fecha_Nac,  Chofer_Telefono, Chofer_Mail
	FROM gd_esquema.Maestra
	GROUP BY Chofer_Apellido, Chofer_Nombre, Chofer_Direccion, Chofer_Dni, Chofer_Fecha_Nac, Chofer_Telefono, Chofer_Mail

	DECLARE @telefono NUMERIC(18,0);
	DECLARE @direccion VARCHAR(255);
	DECLARE @dni NUMERIC(18,0);
	DECLARE @mail VARCHAR(255);
	DECLARE @fecha_de_nac DATETIME;
	DECLARE @nombre VARCHAR(255);
	DECLARE @apellido VARCHAR(255);
	
	OPEN choferes_cursor
	FETCH choferes_cursor INTO @apellido, @nombre, @direccion, @dni, @fecha_de_nac, @telefono, @mail
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF( NOT EXISTS (SELECT username FROM LOS_CHATADROIDES.Usuario WHERE username = @nombre + '_' + @apellido) )
			BEGIN
				INSERT INTO LOS_CHATADROIDES.Usuario (username, password)
					VALUES (@nombre + '_' + @apellido, @nombre + '_' + @apellido);
			END;

		INSERT INTO LOS_CHATADROIDES.Chofer (telefono, direccion, nombre, apellido, dni, fecha_de_nacimiento, mail, username)
				VALUES (@telefono, @direccion, @nombre, @apellido, @dni, @fecha_de_nac, @mail, @nombre + '_' + @apellido);

		FETCH choferes_cursor INTO @apellido, @nombre, @direccion, @dni, @fecha_de_nac, @telefono, @mail;
	END

	CLOSE choferes_cursor;
	DEALLOCATE choferes_cursor;
END
GO
	
		
CREATE PROCEDURE LOS_CHATADROIDES.Cargar_Roles_X_Usuarios
AS
BEGIN
	INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol) VALUES ('admin', 'Administrador')
	
	DECLARE cliente_cursor CURSOR FOR 
	SELECT username FROM LOS_CHATADROIDES.Cliente

	DECLARE @username VARCHAR(50)

	OPEN cliente_cursor
	FETCH cliente_cursor INTO @username
	
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol) VALUES (@username, 'Cliente')
		FETCH cliente_cursor INTO @username
	END;

	CLOSE cliente_cursor
	DEALLOCATE cliente_cursor

	DECLARE chofer_cursor CURSOR FOR
	SELECT username FROM LOS_CHATADROIDES.Chofer

	DECLARE @username2 VARCHAR(50)

	OPEN chofer_cursor
	FETCH chofer_cursor INTO @username2

	WHILE(@@FETCH_STATUS = 0) 
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol) VALUES (@username2, 'Chofer')
		FETCH chofer_cursor INTO @username2
	END;

	CLOSE chofer_cursor
	DEALLOCATE chofer_cursor
END; 
GO


CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Autos
AS
BEGIN
	DECLARE autos_cursor CURSOR FOR
	SELECT Auto_Marca, Auto_Modelo, Auto_Patente, Auto_Licencia, Auto_Rodado, Chofer_Telefono 
	FROM gd_esquema.Maestra 
	GROUP BY Auto_Marca, Auto_Modelo, Auto_Patente, Auto_Licencia, Auto_Rodado, Chofer_Telefono

	DECLARE @marca VARCHAR(255)
	DECLARE @modelo VARCHAR(255)
	DECLARE @patente VARCHAR(10)
	DECLARE @licencia VARCHAR(26)
	DECLARE @rodado VARCHAR(10)
	DECLARE @telefono_chofer NUMERIC(18,0)

	OPEN autos_cursor
	FETCH autos_cursor INTO @marca, @modelo, @patente, @licencia, @rodado, @telefono_chofer

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Automovil (marca, modelo, patente, licencia, rodado, telefono_chofer)
			VALUES (@marca, @modelo, @patente, @licencia, @rodado, @telefono_chofer)

		FETCH autos_cursor INTO @marca, @modelo, @patente, @licencia, @rodado, @telefono_chofer
	END

	CLOSE autos_cursor
	DEALLOCATE autos_cursor	
END
GO

CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Auto_X_Turno
AS
BEGIN

	DECLARE auto_x_turno_cursor CURSOR FOR
	SELECT Turno_Hora_Inicio ,Turno_Hora_Fin, Auto_Patente FROM gd_esquema.Maestra
	GROUP BY Turno_Hora_Inicio, Turno_Hora_Fin, Auto_Patente

	DECLARE @turno_hora_inicio NUMERIC (18,0)
	DECLARE @turno_hora_fin NUMERIC (18,0)
	DECLARE @auto_patente VARCHAR(10)

	OPEN auto_x_turno_cursor
	FETCH auto_x_turno_cursor INTO @turno_hora_inicio, @turno_hora_fin, @auto_patente

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Auto_X_Turno (hora_inicio_turno, hora_fin_turno, patente)
			VALUES (@turno_hora_inicio, @turno_hora_fin, @auto_patente)
		FETCH auto_x_turno_cursor INTO @turno_hora_inicio, @turno_hora_fin, @auto_patente
	END;

	CLOSE auto_x_turno_cursor
	DEALLOCATE auto_x_turno_cursor
END;
GO		

CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Rendicion
AS
BEGIN
	DECLARE rendicion_cursor CURSOR FOR
	SELECT Rendicion_Nro, Rendicion_Fecha, SUM(Rendicion_Importe) importe_total, Turno_Hora_Inicio, Turno_Hora_Fin, Chofer_Telefono 
	FROM gd_esquema.Maestra
	GROUP BY Rendicion_Nro, Rendicion_Fecha, Turno_Hora_Inicio, Turno_Hora_Fin, Chofer_Telefono
	HAVING Rendicion_Nro IS NOT NULL
  
	DECLARE @rendicion_nro NUMERIC(18,0)
	DECLARE @fecha DATETIME
	DECLARE @importe_total NUMERIC(18,2)
	DECLARE @hora_inicio NUMERIC(18,0)
	DECLARE @hora_fin NUMERIC(18,0)
	DECLARE @chofer_telefono NUMERIC(18,0)
 
	OPEN rendicion_cursor
	FETCH rendicion_cursor INTO @rendicion_nro, @fecha, @importe_total, @hora_inicio, @hora_fin, @chofer_telefono
  
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rendicion (nro_rendicion, fecha, telefono_chofer, importe_total, hora_inicio_turno, hora_fin_turno, porcentaje_aplicado)
		VALUES ( @rendicion_nro, @fecha, @chofer_telefono, @importe_total, @hora_inicio, @hora_fin, 0.3)

		FETCH rendicion_cursor INTO @rendicion_nro, @fecha, @importe_total, @hora_inicio, @hora_fin, @chofer_telefono
	END
  
	CLOSE rendicion_cursor
	DEALLOCATE rendicion_cursor
END;  
GO
 

CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Viajes
AS
BEGIN 
  SELECT M1.Chofer_Telefono AS chofer, M2.Cliente_Telefono AS cliente, M1.Viaje_Fecha AS fecha_y_hora_inicio, M2.Viaje_Fecha AS fecha_y_hora_fin 
  INTO LOS_CHATADROIDES.#Viajes_con_inicio_y_fin
  FROM gd_esquema.Maestra M1 LEFT JOIN gd_esquema.Maestra M2
      ON(CONVERT(date, M1.Viaje_Fecha) = CONVERT(date, M2.Viaje_Fecha)
        AND M1.Chofer_Telefono = M2.Chofer_Telefono
	      AND M1.Cliente_Telefono = M2.Cliente_Telefono
        AND M1.Turno_Hora_Inicio = M2.Turno_Hora_Inicio
  	    AND M1.Auto_Patente = M2.Auto_Patente)
  WHERE CONVERT(time, M1.Viaje_Fecha) < CONVERT(time, M2.Viaje_Fecha) 
  GROUP BY M1.Chofer_Telefono, M2.Cliente_Telefono, M1.Viaje_Fecha, M2.Viaje_Fecha
  
  DECLARE cursor_viajes CURSOR FOR 
  SELECT chofer, N.Auto_Patente, cliente, N.Turno_Hora_Inicio, N.Turno_Hora_Fin, fecha_y_hora_inicio, fecha_y_hora_fin, 
	SUM(N.Viaje_Cant_Kilometros) AS cantidad_km_viaje,N.Rendicion_Nro, M.Factura_Nro
    FROM (SELECT chofer, cliente, fecha_y_hora_inicio, MIN(fecha_y_hora_fin) AS fecha_y_hora_fin 
      	  FROM LOS_CHATADROIDES.#Viajes_con_inicio_y_fin
		  GROUP BY chofer, cliente, fecha_y_hora_inicio) AS T 

    	LEFT JOIN 

		 (SELECT Chofer_Telefono, Auto_Patente, Cliente_Telefono, Turno_Hora_Inicio, 
			Turno_Hora_Fin, Viaje_Fecha, Viaje_Cant_Kilometros, Rendicion_Nro, Factura_Nro
	      FROM gd_esquema.Maestra
  	      GROUP BY Chofer_Telefono, Auto_Patente, Cliente_Telefono, Turno_Hora_Inicio, 
    	 	Turno_Hora_Fin, Viaje_Fecha, Viaje_Cant_Kilometros, Rendicion_Nro, Factura_Nro
          HAVING Rendicion_Nro IS NOT NULL) AS N

	      	ON(N.Chofer_Telefono = T.chofer 
				AND N.Cliente_Telefono = T.cliente 
				AND T.fecha_y_hora_inicio = N.Viaje_Fecha) 
						 
		LEFT JOIN

		  (SELECT Chofer_Telefono, Auto_Patente, Cliente_Telefono, Turno_Hora_Inicio, 
			Turno_Hora_Fin, Viaje_Fecha, Rendicion_Nro, Factura_Nro
           FROM gd_esquema.Maestra
		   GROUP BY Chofer_Telefono, Auto_Patente, Cliente_Telefono, Turno_Hora_Inicio, 
			Turno_Hora_Fin, Viaje_Fecha, Rendicion_Nro, Factura_Nro
		   HAVING Factura_Nro IS NOT NULL) AS M
			
			ON(M.Chofer_Telefono = N.Chofer_Telefono 
					AND M.Cliente_Telefono = N.Cliente_Telefono
					AND M.Viaje_Fecha = N.Viaje_Fecha
					AND M.Auto_Patente = N.Auto_Patente)
												
			 GROUP BY chofer, N.Auto_Patente, cliente, N.Turno_Hora_Inicio, N.Turno_Hora_Fin, fecha_y_hora_inicio, fecha_y_hora_fin, N.Rendicion_Nro, M.Factura_Nro
	
	DECLARE @nro_rendicion NUMERIC(18,0);
	DECLARE @telefono_chofer NUMERIC(18,0);
	DECLARE @patente VARCHAR(10);
	DECLARE @id_factura NUMERIC(18,0);
	DECLARE @telefono_cliente NUMERIC(18,0);
	DECLARE @hora_inicio_turno NUMERIC(18,0)
	DECLARE @hora_fin_turno NUMERIC(18,0);
	DECLARE @fecha_y_hora_inicio_viaje DATETIME;
	DECLARE @fecha_y_hora_fin_viaje DATETIME;
	DECLARE @kilometros_del_viaje NUMERIC(18,0);
  
	OPEN cursor_viajes;
	FETCH cursor_viajes INTO 
				@telefono_chofer, 
				@patente, 
				@telefono_cliente, 
				@hora_inicio_turno, 
				@hora_fin_turno, 
				@fecha_y_hora_inicio_viaje, 
				@fecha_y_hora_fin_viaje, 
				@kilometros_del_viaje, 
				@nro_rendicion, 
				@id_factura 

	WHILE (@@FETCH_STATUS = 0)
  	BEGIN
      INSERT INTO LOS_CHATADROIDES.Viaje (nro_rendicion, 
										  telefono_chofer, 
									      patente, 
									      id_factura, 
										  telefono_cliente, 
										  hora_inicio_turno, 
										  hora_fin_turno, 
										  fecha_y_hora_inicio_viaje, 
										  fecha_y_hora_fin_viaje, 
										  kilometros_del_viaje)

      								VALUES (@nro_rendicion,
											@telefono_chofer,
											@patente, 
											@id_factura, 
											@telefono_cliente,
											@hora_inicio_turno,
											@hora_fin_turno,
											@fecha_y_hora_inicio_viaje, 
											@fecha_y_hora_fin_viaje,
											@kilometros_del_viaje)
      
      FETCH cursor_viajes INTO 
					  @telefono_chofer, 
					  @patente, 
					  @telefono_cliente, 
					  @hora_inicio_turno, 
					  @hora_fin_turno, 
					  @fecha_y_hora_inicio_viaje, 
					  @fecha_y_hora_fin_viaje, 
					  @kilometros_del_viaje, 
					  @nro_rendicion, 
					  @id_factura 
    END 
    
  CLOSE cursor_viajes;
  DEALLOCATE cursor_viajes;

  DROP TABLE LOS_CHATADROIDES.#Viajes_con_inicio_y_fin

END
GO


CREATE TRIGGER LOS_CHATADROIDES.Encriptar_Password
ON LOS_CHATADROIDES.Usuario
INSTEAD OF INSERT
AS 
BEGIN    
	DECLARE @password VARCHAR(64)
	DECLARE @username VARCHAR(50)

	SELECT @username = username, @password = password FROM inserted

	INSERT INTO LOS_CHATADROIDES.Usuario (username, password) VALUES ( @username,  LOS_CHATADROIDES.Hashear_Password(@password)) 
END 
GO

CREATE FUNCTION LOS_CHATADROIDES.Hashear_Password
(@password VARCHAR(64))
RETURNS VARCHAR(64)
BEGIN
  RETURN CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @password), 2)  
END
GO

CREATE FUNCTION LOS_CHATADROIDES.calcular_importe_total 
(@mes_factura INTEGER,
@telefono_cliente NUMERIC(18,0))
RETURNS FLOAT
BEGIN 
	DECLARE viajes_para_facturar CURSOR FOR
	SELECT kilometros_del_viaje, T.valor_del_kilometro, T.precio_base
	FROM LOS_CHATADROIDES.Viaje V JOIN LOS_CHATADROIDES.Turno T
		ON(T.hora_inicio_turno = V.hora_inicio_turno AND T.hora_fin_turno = V.hora_fin_turno)
	WHERE MONTH(V.fecha_y_hora_inicio_viaje) = @mes_factura AND V.telefono_cliente = @telefono_cliente
  
	DECLARE @importe_total FLOAT;
	SET @importe_total = 0.0 ;
	DECLARE @kilometros_del_viaje NUMERIC(18,0);
	DECLARE @valor_del_kilometro NUMERIC(18,2);
	DECLARE @precio_base NUMERIC(18,2);
  
  OPEN viajes_para_facturar;
  
  FETCH viajes_para_facturar INTO @kilometros_del_viaje, @valor_del_kilometro, @precio_base;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN 
   	SET @importe_total = @importe_total + @precio_base + @kilometros_del_viaje * @valor_del_kilometro; 
    
   	FETCH viajes_para_facturar INTO @kilometros_del_viaje, @valor_del_kilometro, @precio_base;
  END
	
  CLOSE viajes_para_facturar;
  DEALLOCATE viajes_para_facturar;
  
  RETURN @importe_total;
END
GO


CREATE PROCEDURE LOS_CHATADROIDES.Migrar_Facturas_Sin_Importe
AS
BEGIN
	
	DECLARE factura_cursor CURSOR FOR
	SELECT Factura_Fecha, Factura_Fecha_Fin, Factura_Fecha_Inicio, Factura_Nro, Cliente_Telefono
	FROM gd_esquema.Maestra
	GROUP BY Factura_Fecha, Factura_Fecha_Fin, Factura_Fecha_Inicio, Factura_Nro, Cliente_Telefono
	HAVING Factura_Nro IS NOT NULL

	DECLARE @factura_fecha DATETIME
	DECLARE @factura_fecha_fin DATETIME
	DECLARE @factura_fecha_inicio DATETIME
	DECLARE @factura_nro NUMERIC(18,0)
	DECLARE @cliente_telefono NUMERIC(18,0)

	OPEN factura_cursor
	FETCH factura_cursor INTO @factura_fecha, @factura_fecha_fin, @factura_fecha_inicio, @factura_nro, @cliente_telefono 
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Factura (fecha_facturacion, fecha_fin, fecha_inicio, id_factura, telefono_cliente, importe_total) 
			VALUES (@factura_fecha, @factura_fecha_fin, @factura_fecha_inicio, @factura_nro, @cliente_telefono, 0 )

		FETCH factura_cursor INTO @factura_fecha, @factura_fecha_fin, @factura_fecha_inicio, @factura_nro, @cliente_telefono 
	END;
	
	CLOSE factura_cursor
	DEALLOCATE factura_cursor

END;
GO	


CREATE PROCEDURE LOS_CHATADROIDES.Cargar_Importe_A_Facturas
AS
BEGIN 
	DECLARE factura_cursor CURSOR FOR
	SELECT telefono_cliente, fecha_inicio FROM LOS_CHATADROIDES.Factura

	DECLARE @telefono_cliente NUMERIC(18,0)
	DECLARE @fecha_inicio DATETIME

	OPEN factura_cursor
	FETCH factura_cursor INTO @telefono_cliente, @fecha_inicio

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		UPDATE LOS_CHATADROIDES.Factura
		SET importe_total = LOS_CHATADROIDES.calcular_importe_total(MONTH(@fecha_inicio), @telefono_cliente)
		WHERE telefono_cliente = @telefono_cliente AND fecha_inicio = @fecha_inicio 

		FETCH factura_cursor INTO @telefono_cliente, @fecha_inicio
	END

	CLOSE factura_cursor
	DEALLOCATE factura_cursor
END
GO

EXEC LOS_CHATADROIDES.Migrar_Turnos;

INSERT INTO LOS_CHATADROIDES.Rol (nombre_del_rol) VALUES ('Chofer');
INSERT INTO LOS_CHATADROIDES.Rol (nombre_del_rol) VALUES ('Cliente');
INSERT INTO LOS_CHATADROIDES.Rol (nombre_del_rol) VALUES ('Administrador');

INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('ABM de Rol');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('Registro de Usuario');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('ABM de Cliente');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('ABM de Automovil');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('ABM de Chofer');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('Registro de Viajes');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('Rendicion de cuenta del Chofer');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('Listado Estadistico');
INSERT INTO LOS_CHATADROIDES.Funcionalidad (descripcion) VALUES ('Facturacion a Cliente');

EXEC LOS_CHATADROIDES.Cargar_Funcionalidades_X_Rol;
EXEC LOS_CHATADROIDES.Migrar_Clientes;
EXEC LOS_CHATADROIDES.Migrar_Choferes;

INSERT INTO LOS_CHATADROIDES.Usuario
	(username, password) VALUES ('admin', 'w23e')

INSERT INTO LOS_CHATADROIDES.Administrador 
	(telefono, direccion, nombre, apellido, dni, fecha_de_nacimiento, mail, username) VALUES
		(1, '25 de Mayo 5619', 'Quique', 'Reinosa', 1, '1966-01-01', 'chakl@hotmail.com', 'admin')
	
EXEC LOS_CHATADROIDES.Cargar_Roles_X_Usuarios;
EXEC LOS_CHATADROIDES.Migrar_Autos;
EXEC LOS_CHATADROIDES.Migrar_Auto_X_Turno;
EXEC LOS_CHATADROIDES.Migrar_Rendicion;
EXEC LOS_CHATADROIDES.Migrar_Facturas_Sin_Importe; 
EXEC LOS_CHATADROIDES.Migrar_Viajes;
EXEC LOS_CHATADROIDES.Cargar_Importe_A_Facturas;
GO

CREATE PROCEDURE LOS_CHATADROIDES.Dar_de_alta_chofer
@localidad VARCHAR(20), @direccion VARCHAR(255),
@nro_piso SMALLINT, @depto VARCHAR(3),
@telefono NUMERIC(18,0), @nombre VARCHAR(255), 
@apellido VARCHAR(255), @dni NUMERIC(18,0), 
@fecha_de_nac DATETIME, @mail VARCHAR(50), 
@username VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF( NOT EXISTS (SELECT 1 FROM LOS_CHATADROIDES.Domicilio WHERE localidad = @localidad AND direccion = @direccion) )
			BEGIN
				INSERT INTO LOS_CHATADROIDES.Domicilio (localidad, direccion, nro_piso, depto) 
					VALUES (@localidad, @direccion, @nro_piso, @depto)
			END

			INSERT INTO LOS_CHATADROIDES.Chofer (telefono, localidad, direccion, nombre, apellido, dni, fecha_de_nacimiento, mail, username)
				VALUES (@telefono, @localidad, @direccion, @nombre, @apellido, @dni, @fecha_de_nac, @mail, @username)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
END
GO


CREATE PROCEDURE LOS_CHATADROIDES.Dar_de_alta_cliente
@localidad VARCHAR(20), @direccion VARCHAR(255),
@nro_piso SMALLINT, @depto VARCHAR(3),
@telefono NUMERIC(18,0), @nombre VARCHAR(255), 
@apellido VARCHAR(255), @dni NUMERIC(18,0), 
@fecha_de_nac DATETIME, @codigo_postal SMALLINT,
@mail VARCHAR(50), @username VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO LOS_CHATADROIDES.Cliente (telefono, localidad, direccion, nombre, apellido, dni, fecha_de_nacimiento, mail, username, codigo_postal)
				VALUES (@telefono, @localidad, @direccion, @nombre, @apellido, @dni, @fecha_de_nac, @mail, @username, @codigo_postal)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
END
GO

CREATE TRIGGER LOS_CHATADROIDES.Agregar_Rol_Cliente
ON LOS_CHATADROIDES.Cliente
AFTER INSERT
AS
BEGIN
	DECLARE @username VARCHAR(50)
	DECLARE @habilitado BIT

	SELECT @username=username, @habilitado=habilitado FROM inserted
	
	IF(@habilitado = 1)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol, habilitado)
			VALUES (@username, 'Cliente', 1)
	END
END
GO

CREATE TRIGGER LOS_CHATADROIDES.Agregar_Rol_Chofer
ON LOS_CHATADROIDES.Chofer
AFTER INSERT
AS
BEGIN
	DECLARE @username VARCHAR(50)
	DECLARE @habilitado BIT

	SELECT @username=username, @habilitado=habilitado FROM inserted
	
	IF(@habilitado = 1)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol, habilitado)
			VALUES (@username, 'Chofer', 1)
	END
END
GO
CREATE PROCEDURE LOS_CHATADROIDES.Actualizar_Cliente
	 @nombre VARCHAR(255),
	 @apellido VARCHAR(255),
	 @telefono NUMERIC(18,0),
	 @dni NUMERIC(18,0),
	 @mail VARCHAR(255),
	 @localidad VARCHAR(20),	
	 @direccion VARCHAR(255),
	 @depto VARCHAR(3),
	 @nro_piso VARCHAR(3),
	 @codPostal VARCHAR(5),
	 @fecha_de_nac DATETIME, 
	 @telAnterior NUMERIC(18,0)
AS
BEGIN

	UPDATE LOS_CHATADROIDES.Cliente
	SET telefono = @telefono, @direccion = direccion, @dni = dni, @mail = mail, @fecha_de_nac = fecha_de_nacimiento,
			@nombre = nombre, @apellido = apellido, @localidad = localidad, @nro_piso = nro_piso, @depto = depto, @codPostal = codigo_postal
	WHERE telefono = @telAnterior

		UPDATE LOS_CHATADROIDES.Factura
	SET telefono_cliente = @telefono
	WHERE telefono_cliente = @telAnterior

	UPDATE LOS_CHATADROIDES.Viaje
	SET telefono_cliente = @telefono
	WHERE telefono_cliente = @telAnterior

END

CREATE PROCEDURE LOS_CHATADROIDES.Dar_de_alta_automovil
@patente varchar(10), @numero_chofer numeric(18,0), 
@marca varchar(255), @modelo varchar(255),
@hora_inicio_turno numeric(18,0), @hora_fin_turno numeric(18,0)
AS 
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO LOS_CHATADROIDES.Automovil
				(patente, telefono_chofer, marca, modelo)
			VALUES (@patente, @numero_chofer, @marca, @modelo)

			INSERT INTO LOS_CHATADROIDES.Auto_X_Turno
				(patente, hora_inicio_turno, hora_fin_turno)
			VALUES(@patente, @hora_inicio_turno, @hora_fin_turno)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
END
GO



/*
CREATE TABLE LOS_CHATADROIDES.Automovil
(
	patente VARCHAR(10) PRIMARY KEY,
	telefono_chofer NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Chofer(telefono),
	marca VARCHAR(255) NOT NULL,
	modelo VARCHAR(255) NOT NULL,
	licencia VARCHAR(26),
	rodado VARCHAR(10),
	habilitado BIT NOT NULL DEFAULT 1
);


CREATE TABLE LOS_CHATADROIDES.Auto_X_Turno
(
	hora_inicio_turno NUMERIC(18,0),
	hora_fin_turno NUMERIC(18,0),
	patente VARCHAR(10) FOREIGN KEY REFERENCES LOS_CHATADROIDES.Automovil(patente),
	FOREIGN KEY (hora_inicio_turno, hora_fin_turno) REFERENCES LOS_CHATADROIDES.Turno(hora_inicio_turno, hora_fin_turno),
	PRIMARY KEY (hora_inicio_turno, hora_fin_turno, patente)
);




 auto.patente + ", "
+ auto.telefono_chofer + ", "
+ auto.marca + ", "
+ auto.modelo + ", "
+ auto.licencia + ", "
+ auto.rodado + ", "
+ auto.habilitado 

*/

CREATE TRIGGER LOS_CHATADROIDES.Dar_de_baja_automovil 
ON LOS_CHATADROIDES.Automovil
INSTEAD OF DELETE
AS 
BEGIN  
	DECLARE @patente VARCHAR(10)
	SET @patente = (SELECT patente FROM deleted)
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM LOS_CHATADROIDES.Auto_X_Turno 
			WHERE patente = @patente

			UPDATE LOS_CHATADROIDES.Automovil
			SET habilitado = 0
			WHERE patente = @patente

		 COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END
GO


CREATE FUNCTION LOS_CHATADROIDES.Esta_en_trimestre
(@mes INTEGER, @trimestre INTEGER)
RETURNS BIT
AS
BEGIN
	IF(@trimestre = 1 AND @mes BETWEEN 1 AND 3 
	OR @trimestre = 2 AND @mes BETWEEN 4 AND 6
	OR @trimestre = 3 AND @mes BETWEEN 7 AND 9
	OR @trimestre = 4 AND @mes BETWEEN 10 AND 12) 
		RETURN 1
	RETURN 0
END
GO







SELECT TOP 5 telefono, nombre, apellido, dni, COUNT(DISTINCT patente) as 'Veces que uso el mis auto'
FROM LOS_CHATADROIDES.Cliente C
JOIN LOS_CHATADROIDES.Viaje V
	ON(C.telefono = V.telefono_cliente)
WHERE YEAR(V.fecha_y_hora_inicio_viaje) = 2015
	AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), 1) = 1
GROUP BY telefono, nombre, apellido, dni
ORDER BY 5 DESC
GO


CREATE PROCEDURE LOS_CHATADROIDES.Dar_de_alta_usuario
@username VARCHAR(50), @password VARCHAR(64), @rol VARCHAR(25)
AS 
BEGIN
	INSERT INTO LOS_CHATADROIDES.Usuario (username, password)
		VALUES (@username, LOS_CHATADROIDES.Hashear_Password(@password))


	IF(@rol IS NOT NULL)
	BEGIN
		INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol)
			VALUES (@username, @rol)
	END

END
GO





CREATE FUNCTION LOS_CHATADROIDES.Ultima_factura()
RETURNS NUMERIC(18,0)
AS
BEGIN 
	DECLARE @ultimaFactura NUMERIC(18,0)
	SELECT @ultimaFactura = MAX(id_factura)
	FROM LOS_CHATADROIDES.Factura
	
RETURN @ultimaFactura + 1 
END
GO


CREATE PROCEDURE LOS_CHATADROIDES.Crear_factura
@telefono NUMERIC(18,0), @importeTotal FLOAT, @fecha_facturacion VARCHAR(20),
@fecha_inicio VARCHAR(20), @fecha_fin VARCHAR(20)
AS 
BEGIN
	INSERT INTO LOS_CHATADROIDES.Factura (id_factura, telefono_cliente, fecha_facturacion, fecha_inicio, fecha_fin, importe_total)
		VALUES (LOS_CHATADROIDES.Ultima_factura(), @telefono, @fecha_facturacion, @fecha_inicio, @fecha_fin, @importeTotal)
END
GO

CREATE TRIGGER LOS_CHATADROIDES.Actualizar_Viajes_Facturados
ON LOS_CHATADROIDES.Factura
AFTER INSERT 
AS 
BEGIN
DECLARE @id_factura NUMERIC(18,0), @telefono_cliente NUMERIC(18,0)
SELECT @id_factura = id_factura, @telefono_cliente = telefono_cliente 
FROM inserted
	
UPDATE LOS_CHATADROIDES.Viaje 
	SET id_factura = @id_factura
	WHERE telefono_cliente = @telefono_cliente AND 
		   Id_factura IS NULL
END
GO
/*
CREATE FUNCTION LOS_CHATADROIDES.Ultimo_telefono_chofer()
RETURNS NUMERIC(18,0)
AS
BEGIN
	DECLARE @telefono_mas_grande NUMERIC(18,0)

	SET @telefono_mas_grande = (SELECT MAX(telefono) FROM LOS_CHATADROIDES.Chofer)

	RETURN @telefono_mas_grande
END
GO*/

CREATE TRIGGER LOS_CHATADROIDES.Actualizar_telefono_chofer
ON LOS_CHATADROIDES.Chofer
INSTEAD OF UPDATE
AS
BEGIN
	DECLARE @telefono_viejo NUMERIC(18,0),
			@nombre_viejo VARCHAR(255),
			@apellido_viejo VARCHAR(255),
			@fecha_nac_vieja DATETIME,
			@dni_viejo NUMERIC(18,0),
			@mail_viejo VARCHAR(50),
			@dir_vieja VARCHAR(255),
			@depto_viejo VARCHAR(3),
			@nro_piso_viejo VARCHAR(3),
			@localidad_vieja VARCHAR(20),
			@usuario_viejo VARCHAR(50),
			@habilitado_viejo BIT

	DECLARE @telefono_nuevo NUMERIC(18,0),
			@nombre_nuevo VARCHAR(255),
			@apellido_nuevo VARCHAR(255),
			@fecha_nac_nueva DATETIME,
			@dni_nuevo NUMERIC(18,0),
			@mail_nuevo VARCHAR(50),
			@dir_nueva VARCHAR(255),
			@depto_nuevo VARCHAR(3),
			@nro_piso_nuevo VARCHAR(3),
			@localidad_nueva VARCHAR(20),
			@usuario_nuevo VARCHAR(50),
			@habilitado_nuevo BIT

	SELECT @telefono_nuevo = telefono, @nombre_nuevo = nombre, @apellido_nuevo = apellido, 
		@fecha_nac_nueva = fecha_de_nacimiento, @dni_nuevo = dni, @mail_nuevo = mail, @dir_nueva = direccion,
		@nro_piso_nuevo = nro_piso, @localidad_nueva = localidad, @usuario_nuevo = username, @habilitado_nuevo = habilitado
	FROM inserted

	SELECT @telefono_viejo = telefono, @nombre_viejo = nombre, @apellido_viejo = apellido, 
		@fecha_nac_vieja = fecha_de_nacimiento, @dni_viejo = dni, @mail_viejo = mail, @dir_vieja = direccion,
		@nro_piso_viejo = nro_piso, @localidad_vieja = localidad, @usuario_viejo = username, @habilitado_viejo = habilitado
	FROM deleted

	IF(@telefono_nuevo = @telefono_viejo)
	BEGIN
		print 'estoy aca en el if'		
		UPDATE LOS_CHATADROIDES.Chofer
			SET	nombre = @nombre_nuevo,
				apellido = @apellido_nuevo,
				fecha_de_nacimiento = @fecha_nac_nueva,
				dni = @dni_nuevo,
				mail = @mail_nuevo,
				direccion = @dir_nueva,
				depto = @depto_nuevo,
				nro_piso = @nro_piso_nuevo,
				localidad = @localidad_nueva,
				habilitado = @habilitado_nuevo,
				username = @usuario_nuevo
		WHERE telefono = @telefono_viejo
	END
	ELSE
	BEGIN
		BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE 
		BEGIN TRANSACTION
			DECLARE @telefonoDummie NUMERIC(18,0), @username VARCHAR(50), @usernameDummie VARCHAR(50)

			SET @username = (SELECT username FROM LOS_CHATADROIDES.Chofer WHERE telefono = @telefono_viejo)

			SET @usernameDummie = '$dummie'--le pongo $ porque desde la bd no te deja hacer usuarios con el char '$'
	
			INSERT INTO LOS_CHATADROIDES.Usuario (username, password, habilitado) VALUES (@usernameDummie, 'NA', 0)

			INSERT INTO LOS_CHATADROIDES.Chofer 
				(telefono, nombre, apellido, dni, fecha_de_nacimiento, localidad, direccion, depto, nro_piso, mail, username, habilitado)
					VALUES
				(@telefono_nuevo, @nombre_nuevo, @apellido_nuevo, @dni_nuevo, @fecha_nac_nueva, @localidad_nueva, @dir_nueva, @depto_nuevo, @nro_piso_nuevo, @mail_nuevo, @usernameDummie, @habilitado_nuevo)
	
			UPDATE LOS_CHATADROIDES.Viaje
				SET telefono_chofer = @telefono_nuevo
			WHERE telefono_chofer = @telefono_viejo

			UPDATE LOS_CHATADROIDES.Automovil
				SET telefono_chofer = @telefono_nuevo
			WHERE telefono_chofer = @telefono_viejo

			UPDATE LOS_CHATADROIDES.Rendicion
				SET telefono_chofer = @telefono_nuevo
			WHERE telefono_chofer = @telefono_viejo

			DELETE FROM LOS_CHATADROIDES.Chofer WHERE telefono = @telefono_viejo
			
			UPDATE LOS_CHATADROIDES.Chofer
				SET username = @username
			WHERE telefono = @telefono_nuevo
			
			DELETE FROM LOS_CHATADROIDES.Rol_X_Usuario WHERE username = @usernameDummie

			DELETE FROM LOS_CHATADROIDES.Usuario WHERE username = @usernameDummie
		COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
	END
END
GO

