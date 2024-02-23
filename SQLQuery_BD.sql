USE BD;


INSERT INTO Grupo (Nombre) VALUES ('Limpieza');
INSERT INTO Grupo (Nombre) VALUES ('Bar');
INSERT INTO Grupo (Nombre) VALUES ('Recepcion');
INSERT INTO Grupo (Nombre) VALUES ('Admin');

-- Insertar permisos
INSERT INTO Permiso(Nombre) VALUES ('frmOcupacion');
INSERT INTO Permiso (Nombre) VALUES ('frmHabitaciones');
INSERT INTO Permiso (Nombre) VALUES ('frmClientes');
INSERT INTO Permiso (Nombre) VALUES ('frmReservas');
INSERT INTO Permiso (Nombre) VALUES ('frmCheckIn');
INSERT INTO Permiso (Nombre) VALUES ('frmCheckOut');
INSERT INTO Permiso (Nombre) VALUES ('frmPedidos');
INSERT INTO Permiso (Nombre) VALUES ('frmAdministrador');

-- Insertar usuarios 
-- Usuario con permisos de Limpieza
INSERT INTO Usuario (Nombre, Mail, Clave) VALUES ('Lim', 'usuario_limpieza@example.com', '123');

-- Usuario con permisos de Bar
INSERT INTO Usuario (Nombre, Mail, Clave) VALUES ('Bar', 'usuario_bar@example.com', '456');

-- Usuario con permisos de Recepcion
INSERT INTO Usuario (Nombre, Mail, Clave) VALUES ('Rec', 'usuario_recepcion@example.com', '123');

-- Admin con permisos de los tres grupos
INSERT INTO Usuario (Nombre, Mail, Clave) VALUES ('admin', 'admin@example.com', 'admin');



-- Asignar permisos a los grupos

INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (1, 1); -- PermisoLimpieza - Ocupacion
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (1, 2); -- PermisoLimpieza - Habitaciones

INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (2, 7); -- PermisoBar - frmPedidos

INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 1); -- PermisoRecepcion - Ocupacion
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 2); -- PermisoRecepcion - Habitaciones
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 3); -- PermisoRecepcion - frmClientes
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 4); -- PermisoRecepcion - frmReservas
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 5); -- PermisoRecepcion - frmCheckIn
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 6); -- PermisoRecepcion - frmCheckOut
INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (3, 7); -- PermisoRecepcion - frmPedidos

INSERT INTO GrupoPermiso (Grupo_Id, Permiso_Id) VALUES (4, 8); -- PermisoAdmin


-- Admin (Asociado a los tres grupos)
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (4, 1); -- Admin al Grupo Limpieza
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (4, 2); -- Admin al Grupo Bar
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (4, 3); -- Admin al Grupo Recepcion
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (4, 4); -- Admin al Grupo Recepcion
-- Insertar un usuario en el Grupo Limpieza con los permisos asociados
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (1, 1); -- Asociar usuario al Grupo Limpieza
-- Insertar un usuario en el Grupo Bar con los permisos asociados
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (2, 2); -- Asociar usuario al Grupo Bar
-- Insertar un usuario en el Grupo Recepcion con los permisos asociados
INSERT INTO UsuarioGrupo (Usuario_Id, Grupo_Id) VALUES (3, 3); -- Asociar usuario al Grupo Recepcion



select * from Grupo

select * from Permiso

select * from Reserva

select * from Cliente

select * from Persona

select * from Habitacion

SELECT 
    CONVERT(varchar, FechaLlegada, 103) AS FechaLlegadaFormateada,
    CONVERT(varchar, FechaIda, 103) AS FechaIdaFormateada 
FROM 
    Reserva;


EXEC sp_columns 'Reserva';

EXEC sp_columns 'Persona';

ALTER TABLE Reserva
ALTER COLUMN FechaIda DATE;

EXEC sp_columns N'Reserva';

EXEC sp_configure 'default language';
SELECT * FROM sys.syslanguages;

SELECT * FROM sys.syslanguages WHERE langid = 5;

