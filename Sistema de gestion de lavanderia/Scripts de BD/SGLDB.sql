create database SGL_DB
GO
    Use  SGL_DB
go


CREATE TABLE CLIENTE (
    ID int IDENTITY(1,1) PRIMARY KEY,
    NombreCompania nvarchar(100) NOT NULL,
    RNC nvarchar(12),
    TelefonoCompania nvarchar(12),
    DireccionRecoleccion nvarchar(MAX),
    NombreContacto nvarchar(50),
    TelefonoContacto nvarchar(12),
    EmailContacto nvarchar(100),
    Estado bit DEFAULT 1, 
    FechaRegistro DATETIME DEFAULT GETDATE(),
    LimiteCredito decimal(10,2) CONSTRAINT DF_Cliente_LimiteCredito DEFAULT 0
);
GO

CREATE TABLE SERVICIO (
    ID int IDENTITY(1,1) PRIMARY KEY,
    NombreServicio nvarchar(100) NOT NULL,
    Descripcion nvarchar(MAX),
    PrecioUnitario decimal(10,2) NOT NULL,
    UnidadMedida nvarchar(20) NOT NULL,
    TiempoEstimadoMinutos int,
    Activo bit DEFAULT 1
);
GO

CREATE TABLE EMPLEADO (
    ID int IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto nvarchar(100) NOT NULL,
    Rol nvarchar(50) NOT NULL, 
    Email nvarchar(100),
    Contrasena nvarchar(max),
    Estado bit DEFAULT 1
);
GO

CREATE TABLE LOTE (
    ID int IDENTITY(1,1) PRIMARY KEY,
    ClienteID int NOT NULL,
    PesoTotal decimal(8,2),
    CantidadArticulos int,
    FechaRecepcion DATETIME DEFAULT GETDATE(),
    FechaEntregaEsperada DATETIME,
    EstadoActual nvarchar(50) DEFAULT 'RECEPCIONADO',
    CONSTRAINT FK_Lote_Cliente FOREIGN KEY (ClienteID) REFERENCES CLIENTE(ID)
);
GO

CREATE TABLE LOTE_SERVICIO (
    LoteID int NOT NULL,
    ServicioID int NOT NULL,
    Cantidad decimal(8,2) DEFAULT 1 NOT NULL,
    PrecioAplicado decimal(10,2) DEFAULT 0 NOT NULL,
    PRIMARY KEY (LoteID, ServicioID),
    CONSTRAINT FK_LS_Lote FOREIGN KEY (LoteID) REFERENCES LOTE(ID),
    CONSTRAINT FK_LS_Servicio FOREIGN KEY (ServicioID) REFERENCES SERVICIO(ID)
);
GO

CREATE TABLE HISTORIAL_ESTADO_LOTE (
    ID int IDENTITY(1,1) PRIMARY KEY,
    LoteID int NOT NULL,
    EstadoAnterior nvarchar(50),
    NuevoEstado nvarchar(50) NOT NULL,
    TiempoTransicion DATETIME DEFAULT GETDATE(),
    OperadorID int NOT NULL, 
    Observaciones nvarchar(MAX),
    CONSTRAINT FK_Historial_Lote FOREIGN KEY (LoteID) REFERENCES LOTE(ID),
    CONSTRAINT FK_Historial_Operador FOREIGN KEY (OperadorID) REFERENCES EMPLEADO(ID)
);
GO

CREATE TABLE ENTREGA (
    ID int IDENTITY(1,1) PRIMARY KEY,
    LoteID int NOT NULL,
    ConductorID int NOT NULL, 
    VehiculoPlaca nvarchar(20),
    HoraProgramada DATETIME,
    HoraEntregaReal DATETIME,
    EstadoEntrega nvarchar(50),
    CONSTRAINT FK_Entrega_Lote FOREIGN KEY (LoteID) REFERENCES LOTE(ID),
    CONSTRAINT FK_Entrega_Conductor FOREIGN KEY (ConductorID) REFERENCES EMPLEADO(ID)
);
GO

CREATE TABLE FACTURA (
    ID int IDENTITY(1,1) PRIMARY KEY,
    ClienteID int NOT NULL,
    LoteID int NOT NULL,
    FechaEmision DATETIME DEFAULT GETDATE(),
    SubTotal decimal(10,2) NOT NULL,
    Impuestos decimal(10,2) NOT NULL,
    Total decimal(10,2) NOT NULL,
    EstadoPago nvarchar(50) DEFAULT 'Pendiente', 
    CONSTRAINT FK_Factura_Cliente FOREIGN KEY (ClienteID) REFERENCES CLIENTE(ID),
    CONSTRAINT FK_Factura_Lote FOREIGN KEY (LoteID) REFERENCES LOTE(ID)
);
GO

--registros
INSERT INTO CLIENTE (NombreCompania, RNC, TelefonoCompania, DireccionRecoleccion, NombreContacto, TelefonoContacto, EmailContacto, LimiteCredito)
VALUES
('Lavanderia Express SRL','101000001','8095550001','Av. Duarte 1','Juan Perez','8095551001','juan@mail.com',5000),
('Hotel Caribe','101000002','8095550002','Zona Colonial','Maria Lopez','8095551002','maria@mail.com',8000),
('Clinica Salud Plus','101000003','8095550003','Av. Independencia','Carlos Ruiz','8095551003','carlos@mail.com',6000),
('Restaurante El Buen Sabor','101000004','8095550004','Av. Venezuela','Ana Diaz','8095551004','ana@mail.com',3000),
('Colegio ABC','101000005','8095550005','Ens. Ozama','Luis Gomez','8095551005','luis@mail.com',7000),
('Empresa Textil RD','101000006','8095550006','Zona Industrial','Rosa Martinez','8095551006','rosa@mail.com',9000),
('Spa Relax','101000007','8095550007','Naco','Pedro Santana','8095551007','pedro@mail.com',2000),
('Gym Power','101000008','8095550008','Piantini','Laura Cruz','8095551008','laura@mail.com',2500),
('Hospital Central','101000009','8095550009','Gazcue','Miguel Torres','8095551009','miguel@mail.com',10000),
('Oficina Legal SRL','101000010','8095550010','Bella Vista','Sofia Reyes','8095551010','sofia@mail.com',4000);

INSERT INTO SERVICIO (NombreServicio, Descripcion, PrecioUnitario, UnidadMedida, TiempoEstimadoMinutos)
VALUES
('Lavado','Lavado general',50,'Kg',60),
('Secado','Secado de ropa',30,'Kg',45),
('Planchado','Planchado profesional',40,'Kg',30),
('Lavado en seco','Prendas delicadas',100,'Unidad',120),
('Desmanchado','Remoción de manchas',70,'Unidad',40),
('Tintoreria','Servicio completo',150,'Unidad',180),
('Doblado','Doblado de ropa',20,'Kg',20),
('Empaque','Empaque especial',10,'Unidad',10),
('Lavado industrial','Grandes volúmenes',60,'Kg',90),
('Desinfeccion','Desinfección profunda',80,'Kg',50);

INSERT INTO EMPLEADO (NombreCompleto, Rol, Email, Contrasena)
VALUES
('Jose Ramirez','Administrador','jose@mail.com','123'),
('Luis Perez','Operador','luis@mail.com','123'),
('Maria Lopez','Operador','maria@mail.com','123'),
('Carlos Diaz','Conductor','carlos@mail.com','123'),
('Ana Gomez','Conductor','ana@mail.com','123'),
('Pedro Ruiz','Supervisor','pedro@mail.com','123'),
('Laura Cruz','Operador','laura@mail.com','123'),
('Miguel Torres','Conductor','miguel@mail.com','123'),
('Sofia Reyes','Operador','sofia@mail.com','123'),
('Juan Santana','Supervisor','juan@mail.com','123');

INSERT INTO LOTE (ClienteID, PesoTotal, CantidadArticulos, FechaEntregaEsperada)
VALUES
(1,20,50,GETDATE()+2),
(2,15,40,GETDATE()+3),
(3,25,60,GETDATE()+1),
(4,10,30,GETDATE()+2),
(5,18,45,GETDATE()+4),
(6,30,70,GETDATE()+5),
(7,12,25,GETDATE()+2),
(8,14,35,GETDATE()+3),
(9,22,55,GETDATE()+2),
(10,16,38,GETDATE()+4);

INSERT INTO LOTE_SERVICIO (LoteID, ServicioID, Cantidad, PrecioAplicado)
VALUES
(1,1,20,50),
(2,2,15,30),
(3,3,25,40),
(4,4,10,100),
(5,5,18,70),
(6,6,30,150),
(7,7,12,20),
(8,8,14,10),
(9,9,22,60),
(10,10,16,80);

INSERT INTO HISTORIAL_ESTADO_LOTE (LoteID, EstadoAnterior, NuevoEstado, OperadorID, Observaciones)
VALUES
(1,'RECEPCIONADO','EN PROCESO',2,'Inicio'),
(2,'RECEPCIONADO','EN PROCESO',3,'Inicio'),
(3,'RECEPCIONADO','FINALIZADO',2,'Completo'),
(4,'RECEPCIONADO','EN PROCESO',7,'Lavado'),
(5,'RECEPCIONADO','FINALIZADO',9,'OK'),
(6,'RECEPCIONADO','EN PROCESO',2,'Proceso'),
(7,'RECEPCIONADO','FINALIZADO',3,'Listo'),
(8,'RECEPCIONADO','EN PROCESO',7,'En curso'),
(9,'RECEPCIONADO','FINALIZADO',9,'Terminado'),
(10,'RECEPCIONADO','EN PROCESO',2,'Trabajando');

INSERT INTO ENTREGA (LoteID, ConductorID, VehiculoPlaca, HoraProgramada, EstadoEntrega)
VALUES
(1,4,'A123BC',GETDATE()+1,'Pendiente'),
(2,5,'B234CD',GETDATE()+1,'Pendiente'),
(3,8,'C345DE',GETDATE()+1,'Entregado'),
(4,4,'D456EF',GETDATE()+2,'Pendiente'),
(5,5,'E567FG',GETDATE()+2,'Pendiente'),
(6,8,'F678GH',GETDATE()+2,'Pendiente'),
(7,4,'G789HI',GETDATE()+1,'Entregado'),
(8,5,'H890IJ',GETDATE()+3,'Pendiente'),
(9,8,'I901JK',GETDATE()+2,'Entregado'),
(10,4,'J012KL',GETDATE()+3,'Pendiente');

INSERT INTO FACTURA (ClienteID, LoteID, SubTotal, Impuestos, Total)
VALUES
(1,1,1000,180,1180),
(2,2,800,144,944),
(3,3,1200,216,1416),
(4,4,500,90,590),
(5,5,900,162,1062),
(6,6,1500,270,1770),
(7,7,400,72,472),
(8,8,600,108,708),
(9,9,1100,198,1298),
(10,10,700,126,826);