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

