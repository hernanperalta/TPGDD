-- DELETE's en orden
DELETE FROM LOS_CHATADROIDES.Administrador;
DELETE FROM LOS_CHATADROIDES.Funcionalidad_X_Rol;
DELETE FROM LOS_CHATADROIDES.Rol_X_Usuario;
DELETE FROM LOS_CHATADROIDES.Auto_X_Turno;
DELETE FROM LOS_CHATADROIDES.Viaje;
DELETE FROM LOS_CHATADROIDES.Automovil;
DELETE FROM LOS_CHATADROIDES.Rendicion;
DELETE FROM LOS_CHATADROIDES.Chofer;
DELETE FROM LOS_CHATADROIDES.Factura;
DELETE FROM LOS_CHATADROIDES.Cliente;
DELETE FROM LOS_CHATADROIDES.Domicilio;
DELETE FROM LOS_CHATADROIDES.Funcionalidad;
DELETE FROM LOS_CHATADROIDES.Rol;
DELETE FROM LOS_CHATADROIDES.Turno;
DELETE FROM LOS_CHATADROIDES.Usuario;

-- DROP's de tablas, en orden
DROP TABLE LOS_CHATADROIDES.Administrador;
DROP TABLE LOS_CHATADROIDES.Funcionalidad_X_Rol;
DROP TABLE LOS_CHATADROIDES.Rol_X_Usuario;
DROP TABLE LOS_CHATADROIDES.Auto_X_Turno;
DROP TABLE LOS_CHATADROIDES.Viaje;
DROP TABLE LOS_CHATADROIDES.Automovil;
DROP TABLE LOS_CHATADROIDES.Rendicion;
DROP TABLE LOS_CHATADROIDES.Chofer;
DROP TABLE LOS_CHATADROIDES.Factura;
DROP TABLE LOS_CHATADROIDES.Cliente;
DROP TABLE LOS_CHATADROIDES.Domicilio;
DROP TABLE LOS_CHATADROIDES.Funcionalidad;
DROP TABLE LOS_CHATADROIDES.Rol;
DROP TABLE LOS_CHATADROIDES.Turno;
DROP TABLE LOS_CHATADROIDES.Usuario;

-- DROP's de procedures, funciones y triggers
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Domicilios;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Turnos;
DROP PROCEDURE LOS_CHATADROIDES.Cargar_Funcionalidades_X_Rol;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Clientes;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Choferes;
DROP PROCEDURE LOS_CHATADROIDES.Cargar_Roles_X_Usuarios; 
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Autos;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Auto_X_Turno; 
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Rendicion;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Viajes;
DROP FUNCTION LOS_CHATADROIDES.calcular_importe_total;
DROP PROCEDURE LOS_CHATADROIDES.Migrar_Facturas_Sin_Importe;
DROP PROCEDURE LOS_CHATADROIDES.Cargar_Importe_A_Facturas;

DROP PROCEDURE LOS_CHATADROIDES.Dar_de_alta_cliente;
DROP PROCEDURE LOS_CHATADROIDES.Dar_de_alta_chofer;
DROP PROCEDURE LOS_CHATADROIDES.Insertar_domicilio_si_no_existe;
DROP TRIGGER LOS_CHATADROIDES.Encriptar_Password;
DROP FUNCTION LOS_CHATADROIDES.Hashear_Password;