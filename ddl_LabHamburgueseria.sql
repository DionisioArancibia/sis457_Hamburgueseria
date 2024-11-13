-- DDL
CREATE DATABASE LabHamburgueseria;
GO
USE [master];
GO
CREATE LOGIN [usrhambu] WITH PASSWORD = N'123456',
    DEFAULT_DATABASE = [LabHamburgueseria],
    CHECK_EXPIRATION = OFF,
    CHECK_POLICY = ON;
GO
USE [LabHamburgueseria];
GO
CREATE USER [usrhambu] FOR LOGIN [usrhambu];
GO
ALTER ROLE [db_owner] ADD MEMBER [usrhambu];
GO

DROP TABLE VentaDetalle;
DROP TABLE Venta;
DROP TABLE CompraDetalle;
DROP TABLE Compra;
DROP TABLE Producto;
DROP TABLE Categoria;
DROP TABLE Usuario;
DROP TABLE Cliente;
DROP TABLE Proveedor;

-- Crear tablas
CREATE TABLE Proveedor (
    IdProveedor INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Documento VARCHAR(20) NOT NULL,
    RazonSocial VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(15) NULL
);

CREATE TABLE Cliente (
    IdCliente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Documento VARCHAR(20) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(15) NULL
);

CREATE TABLE Usuario (
    IdUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Documento VARCHAR(20) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NULL,
    Clave VARCHAR(250) NOT NULL
);

CREATE TABLE Categoria (
    IdCategoria INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE Producto (
    IdProducto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(250) NULL,
    IdCategoria INT NOT NULL,
    Stock DECIMAL NOT NULL DEFAULT 0,
    PrecioCompra DECIMAL(18, 2) NOT NULL CHECK (PrecioCompra > 0),
    PrecioVenta DECIMAL(18, 2) NOT NULL CHECK (PrecioVenta > 0),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);

CREATE TABLE Compra (
    IdCompra INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    IdProveedor INT NOT NULL,
    TipoDocumento VARCHAR(20) NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    MontoTotal DECIMAL(18, 2) NOT NULL CHECK (MontoTotal > 0),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdProveedor) REFERENCES Proveedor(IdProveedor)
);

CREATE TABLE CompraDetalle (
    IdDetalleCompra INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    PrecioCompra DECIMAL(18, 2) NOT NULL CHECK (PrecioCompra > 0),
    PrecioVenta DECIMAL(18, 2) NOT NULL CHECK (PrecioVenta > 0),
    Cantidad DECIMAL NOT NULL CHECK (Cantidad > 0),
    MontoTotal DECIMAL(18, 2) NOT NULL CHECK (MontoTotal > 0),
    FOREIGN KEY (IdCompra) REFERENCES Compra(IdCompra),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

CREATE TABLE Venta (
    IdVenta INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    TipoDocumento VARCHAR(20) NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    DocumentoCliente VARCHAR(20) NOT NULL,
    NombreCliente VARCHAR(100) NOT NULL,
    MontoPago DECIMAL(18, 2) NOT NULL CHECK (MontoPago >= 0),
    MontoCambio DECIMAL(18, 2) NOT NULL CHECK (MontoCambio >= 0),
    MontoTotal DECIMAL(18, 2) NOT NULL CHECK (MontoTotal > 0),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE VentaDetalle (
    IdDetalleVenta INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL CHECK (PrecioVenta > 0),
    Cantidad DECIMAL NOT NULL CHECK (Cantidad > 0),
    SubTotal DECIMAL(18, 2) NOT NULL CHECK (SubTotal > 0),
    FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

-- Agregar campos de auditoría y estado a las tablas principales
ALTER TABLE Proveedor ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Proveedor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Proveedor ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1: Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Cliente ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Usuario ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1;


ALTER TABLE Categoria ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Producto ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Compra ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Compra ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Compra ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Venta ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE CompraDetalle ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE CompraDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE CompraDetalle ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1: Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE VentaDetalle ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE VentaDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE VentaDetalle ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1: Eliminado, 0: Inactivo, 1: Activo
GO

-- Procedimientos almacenados para listar Productos 
CREATE PROC paProductoListar @parametro VARCHAR(100)
AS
    SELECT * FROM Producto
    WHERE estado <> -1 AND descripcion LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY descripcion;
GO

 --PROCEDIMIENTO LISTAR CATEGORIA
CREATE PROC paCategoriaListar @parametro VARCHAR(100)
AS
  SELECT * FROM Categoria
  WHERE estado<>-1 AND descripcion LIKE '%'+REPLACE(@parametro, ' ', '%')+'%'
GO

--PROCEDIMIENTO LISTAR CLIENTES
CREATE PROC paClienteListar
    @parametro VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Cliente
    WHERE estado <> -1 AND (
        documento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' OR
        nombreCompleto LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    );
END
GO

CREATE PROC paProveedorListar @parametro VARCHAR(100)
AS
BEGIN
    SELECT * FROM Proveedor
    WHERE Estado <> -1 AND (Documento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' OR 
                            RazonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
    ORDER BY RazonSocial;
END
GO

CREATE PROC paCompraListar @parametro VARCHAR(100)
AS
BEGIN
    SELECT c.IdCompra, c.NumeroDocumento,
           ISNULL(u.NombreCompleto, '') AS Usuario,
           ISNULL(p.RazonSocial, '') AS Proveedor,
           c.MontoTotal,
           c.fechaRegistro 
    FROM Compra c
    LEFT JOIN Usuario u ON c.IdUsuario = u.IdUsuario
    LEFT JOIN Proveedor p ON c.IdProveedor = p.IdProveedor
    WHERE c.Estado <> -1 AND (c.NumeroDocumento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' OR 
                              p.RazonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
    ORDER BY c.fechaRegistro DESC;
END
GO

CREATE PROC paVentaListar @parametro VARCHAR(100)
AS
BEGIN
    SELECT v.IdVenta,
           v.NumeroDocumento,
           v.NombreCliente,
           v.MontoTotal,
           v.fechaRegistro 
    FROM Venta v
    WHERE v.Estado <> -1 AND (v.NumeroDocumento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' OR 
                              v.NombreCliente LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
    ORDER BY v.fechaRegistro DESC;
END
GO


-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Descripcion) VALUES
('Bebidas'),
('Hamburguesas'),
('Postres'),
('Snacks');

-- Insertar datos en la tabla Proveedor
INSERT INTO Proveedor (Documento, RazonSocial, Correo, Telefono) VALUES
('10001', 'Distribuidora de Bebidas S.A.', 'contacto@bebidas.com', '78912345'),
('10002', 'Alimentos Gourmet SRL', 'info@alimentosgourmet.com', '65432198'),
('10003', 'Postres y Dulces SRL', 'ventas@postresydulces.com', '76891234');

-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Documento, NombreCompleto, Correo, Telefono) VALUES
('20001', 'Juan Perez', 'juan.perez@example.com', '71234567'),
('20002', 'Maria Lopez', 'maria.lopez@example.com', '72345678'),
('20003', 'Carlos Gomez', 'carlos.gomez@example.com', '73456789');

-- Insertar datos en la tabla Usuario
INSERT INTO Usuario (Documento, NombreCompleto, Correo, Clave) VALUES
('30001', 'Admin User', 'admin@example.com', 'admin123'),
('30002', 'Vendedor1', 'vendedor1@example.com', 'password123'),
('30003', 'Vendedor2', 'vendedor2@example.com', 'password123');

-- Insertar datos en la tabla Producto
INSERT INTO Producto (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta) VALUES
('P001', 'Coca-Cola 500ml', 'Bebida gaseosa', 1, 50, 5.00, 7.50),
('P002', 'Hamburguesa Clásica', 'Hamburguesa con queso y vegetales', 2, 30, 15.00, 25.00),
('P003', 'Brownie de Chocolate', 'Postre de chocolate', 3, 20, 8.00, 12.00),
('P004', 'Papas Fritas', 'Papas fritas crocantes', 4, 40, 3.00, 5.00);

-- Insertar datos en la tabla Compra
INSERT INTO Compra (IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal) VALUES
(1, 1, 'Factura', 'F001', 1000.00),
(2, 2, 'Factura', 'F002', 500.00),
(3, 3, 'Factura', 'F003', 750.00);

-- Insertar datos en la tabla CompraDetalle
INSERT INTO CompraDetalle (IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal) VALUES
(1, 1, 5.00, 7.50, 50, 250.00),
(1, 2, 15.00, 25.00, 30, 450.00),
(2, 3, 8.00, 12.00, 20, 160.00),
(3, 4, 3.00, 5.00, 40, 120.00);

-- Insertar datos en la tabla Venta
INSERT INTO VENTA (IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal) VALUES
(1, 'Boleta', 'B001', '20001', 'Juan Perez', 100.00, 10.00, 90.00),
(2, 'Boleta', 'B002', '20002', 'Maria Lopez', 150.00, 20.00, 130.00),
(3, 'Boleta', 'B003', '20003', 'Carlos Gomez', 80.00, 5.00, 75.00);

-- Insertar datos en la tabla VentaDetalle
INSERT INTO VentaDetalle (IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal) VALUES
(1, 1, 7.50, 10, 75.00),
(1, 2, 25.00, 1, 25.00),
(2, 3, 12.00, 5, 60.00),
(3, 4, 5.00, 3, 15.00);

-- Confirmar datos insertados
SELECT * FROM Categoria;
SELECT * FROM Proveedor;
SELECT * FROM Cliente;
SELECT * FROM Usuario;
SELECT * FROM Producto;
SELECT * FROM Compra;
SELECT * FROM CompraDetalle;
SELECT * FROM Venta;
SELECT * FROM VentaDetalle;

EXEC paCategoriaListar 'Bebidas';
EXEC paVentaListar 'juan';