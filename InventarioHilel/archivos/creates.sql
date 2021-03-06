CREATE TABLE PRODUCTOS(
	ID INTEGER PRIMARY KEY AUTOINCREMENT,
	NOMBRE TEXT NOT NULL UNIQUE,
	TIPO TEXT NOT NULL,
	CANTIDAD_MINIMA INTEGER,
	 CHECK (TIPO = "ALIMENTICIO" OR TIPO = "PAPELERA"));
	 
CREATE TABLE FECHA_PRODUCTOS(
	FECHA_ADQUISICION DATE,
	HORA_ADQUISICION TIME, 
	ID_PRODUCTO INTEGER NOT NULL,
	CANTIDAD_INICIAL NUMBER NOT NULL,
	CANTIDAD_ACTUAL NUMBER NOT NULL,
	FECHA_VENCIMIENTO DATE,
	UBICACION TEXT,
	PRIMARY KEY (FECHA_ADQUISICION,HORA_ADQUISICION),
	FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTOS(ID) ON DELETE CASCADE);
	
CREATE TABLE USUARIO (
	ID INTEGER PRIMARY KEY AUTOINCREMENT,
	NOMBRE TEXT NOT NULL,
	APELLIDO TEXT NOT NULL,
	EMAIL TEXT NOT NULL,
	CONTRASENA TEXT NOT NULL,
	ES_ADMINISTRADOR TEXT NOT NULL,
	NICKNAME TEXT NOT NULL,
	CHECK(ES_ADMINISTRADOR = "SI" OR ES_ADMINISTRADOR = "NO"));
	
CREATE TABLE LOG_HISTORICO (
	FECHA DATE,
	HORA TIME,
	ID_USUARIO NUMBER NOT NULL,
	ID_PRODUCTO NUMBER,
	MENSAJE_ACCION TEXT NOT NULL,
	PRIMARY KEY ("FECHA","HORA"),
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID) ON DELETE CASCADE,
	FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTOS(ID) ON DELETE CASCADE);
