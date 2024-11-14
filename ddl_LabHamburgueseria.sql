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
DROP TABLE Empleado;
DROP TABLE Usuario;
DROP TABLE Cliente;
DROP TABLE Proveedor;

-- Crear tablas
CREATE TABLE Proveedor (
    idProveedor INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    documento VARCHAR(20) NOT NULL,
    razonSocial VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NULL,
    telefono VARCHAR(15) NULL
);

CREATE TABLE Cliente (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    documento VARCHAR(20) NOT NULL,
    nombreCompleto VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NULL,
    telefono VARCHAR(15) NULL
);

CREATE TABLE Empleado (
  idEmpleado INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  cedulaIdentidad VARCHAR(12) NOT NULL,
  nombres VARCHAR(30) NOT NULL,
  primerApellido VARCHAR(30) NULL,
  segundoApellido VARCHAR(30) NULL,
  direccion VARCHAR(250) NOT NULL,
  celular BIGINT NOT NULL,
  cargo VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario (
  IdUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(15) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado) -- Corregido aquí
); 

CREATE TABLE Categoria (
    IdCategoria INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE Producto (
    IdProducto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(250) NULL,
    IdCategoria INT NOT NULL,
    Stock DECIMAL NOT NULL DEFAULT 0,
    PrecioCompra DECIMAL NOT NULL CHECK (PrecioCompra > 0),
    PrecioVenta DECIMAL NOT NULL CHECK (PrecioVenta > 0),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);

CREATE TABLE Compra (
    idCompra INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idUsuario INT NOT NULL,
    idProveedor INT NOT NULL,
    tipoDocumento VARCHAR(20) NOT NULL,
    numeroDocumento VARCHAR(50) NOT NULL,
    montoTotal DECIMAL(18, 2) NOT NULL CHECK (montoTotal > 0),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor)
);

CREATE TABLE CompraDetalle (
    IdDetalleCompra INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    PrecioCompra DECIMAL(18, 2) NOT NULL CHECK (PrecioCompra > 0),
    PrecioVenta DECIMAL(18, 2) NOT NULL CHECK (PrecioVenta > 0),
    Cantidad DECIMAL NOT NULL CHECK (Cantidad > 0),
    MontoTotal DECIMAL(18, 2) NOT NULL CHECK (MontoTotal > 0),
    FOREIGN KEY (IdCompra) REFERENCES Compra(idCompra),
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

ALTER TABLE Empleado ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Categoria ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Categoria ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
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
ALTER TABLE CompraDetalle ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE VentaDetalle ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE VentaDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE VentaDetalle ADD estado SMALLINT NOT NULL DEFAULT 1;
GO

-- PROCEDIMIENTO LISTAR CATEGORIA
CREATE PROC paCategoriaListar @parametro VARCHAR(100)
AS
BEGIN
    SELECT * 
    FROM Categoria
    WHERE estado <> -1 
      AND descripcion LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END
GO

EXEC paCategoriaListar 'Poll';
GO

-- PROCEDIMIENTO LISTAR PRODUCTOS
CREATE PROC paProductoListar 
    @parametro VARCHAR(100)
AS
BEGIN
    SELECT * 
    FROM Producto
    WHERE estado <> -1 
      AND Nombre LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END
GO

EXEC paProductoListar 'soda';
GO

-- PROCEDIMIENTO LISTAR CLIENTES
CREATE PROC paClienteListar
    @parametro VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Cliente
    WHERE estado <> -1 
      AND (documento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' 
           OR nombreCompleto LIKE '%' + REPLACE(@parametro, ' ', '%') + '%');
END
GO

-- PROCEDIMIENTO LISTAR PROVEEDORES
CREATE PROC paProveedorListar 
    @parametro VARCHAR(100)
AS
BEGIN
    SELECT * 
    FROM Proveedor
    WHERE estado <> -1 
      AND (documento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' 
           OR razonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
    ORDER BY razonSocial;
END
GO

-- PROCEDIMIENTO LISTAR COMPRAS
CREATE PROC paCompraListar 
    @parametro VARCHAR(100)
AS
BEGIN
    SELECT c.idCompra, 
           c.numeroDocumento,
           ISNULL(u.usuario, '') AS Usuario,
           ISNULL(p.razonSocial, '') AS Proveedor,
           c.montoTotal,
           c.fechaRegistro 
    FROM Compra c
    LEFT JOIN Usuario u ON c.idUsuario = u.IdUsuario
    LEFT JOIN Proveedor p ON c.idProveedor = p.idProveedor
    WHERE c.estado <> -1 
      AND (c.numeroDocumento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' 
           OR p.razonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
    ORDER BY c.fechaRegistro DESC;
END
GO

-- PROCEDIMIENTO LISTAR VENTAS
CREATE PROC paVentaListar 
    @parametro VARCHAR(100)
AS
BEGIN
    SELECT v.idVenta,
           v.numeroDocumento,
           v.nombreCliente,
           v.montoTotal,
           v.fechaRegistro 
    FROM Venta v
    WHERE v.estado <> -1 
      AND (v.numeroDocumento LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' 
           OR v.nombreCliente LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
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

--DATOS EMPLEADO
INSERT INTO Empleado(cedulaIdentidad, nombres, primerApellido, segundoApellido, direccion, celular, cargo)
VALUES('7246542','Sebastian ','Palacios', 'Cueca', 'Calle oruro', 77364656, 'cajero');

--DATOS USUARIO
INSERT INTO Usuario(idEmpleado, usuario, clave)
VALUES(1, 'Dioni', 'i0hcoO/nssY6WOs9pOp5Xw==');

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
(1, 'Boleta', 'B001', '20001', 'Juan Perez', 100.00, 10.00, 90.00);


-- Insertar datos en la tabla VentaDetalle
INSERT INTO CompraDetalle (IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal) VALUES
-- Ejemplo para la compra con IdCompra = 1
(1, 1, 5.00, 7.50, 10, 50.00),      -- Compra de 10 unidades del producto con IdProducto 1 a $5 cada una
(1, 2, 8.00, 12.00, 15, 120.00),    -- Compra de 15 unidades del producto con IdProducto 2 a $8 cada una

-- Ejemplo para la compra con IdCompra = 2
(2, 1, 5.00, 7.50, 20, 100.00),     -- Compra de 20 unidades del producto con IdProducto 1 a $5 cada una
(2, 3, 6.50, 10.00, 25, 162.50),    -- Compra de 25 unidades del producto con IdProducto 3 a $6.50 cada una

-- Ejemplo para la compra con IdCompra = 3
(3, 2, 8.00, 12.00, 10, 80.00),     -- Compra de 10 unidades del producto con IdProducto 2 a $8 cada una
(3, 4, 10.00, 15.00, 5, 50.00),     -- Compra de 5 unidades del producto con IdProducto 4 a $10 cada una

-- Ejemplo para la compra con IdCompra = 4
(4, 3, 6.50, 10.00, 12, 78.00),     -- Compra de 12 unidades del producto con IdProducto 3 a $6.50 cada una
(4, 5, 9.00, 13.50, 8, 72.00);      -- Compra de 8 unidades del producto con IdProducto 5 a $9 cada una


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