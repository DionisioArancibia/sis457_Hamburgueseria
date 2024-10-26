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

-- Eliminación de tablas si existen
DROP TABLE DetallePedido;
DROP TABLE Pedidos;
DROP TABLE Productos;
DROP TABLE Clientes;
DROP TABLE Usuarios;
GO

-- Tabla Usuarios
CREATE TABLE Usuarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombreUsuario NVARCHAR(50) NOT NULL,
    password NVARCHAR(100) NOT NULL,
    rol NVARCHAR(20) NOT NULL,
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Tabla Clientes
CREATE TABLE Clientes (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(15) NULL,
    direccion NVARCHAR(200) NULL,
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Tabla Productos
CREATE TABLE Productos (
    id INT PRIMARY KEY IDENTITY(1,1),
    codigo NVARCHAR(20) NOT NULL,
    descripcion NVARCHAR(250) NOT NULL,
    unidadMedida NVARCHAR(20) NOT NULL,
    saldo DECIMAL(10,2) NOT NULL DEFAULT 0,
    precioVenta DECIMAL(10,2) NOT NULL CHECK (precioVenta > 0),
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Tabla Pedidos
CREATE TABLE Pedidos (
    id INT PRIMARY KEY IDENTITY(1,1),
    idCliente INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_Pedido_Cliente FOREIGN KEY (idCliente) REFERENCES Clientes(id)
);
GO

-- Tabla DetallePedido
CREATE TABLE DetallePedido (
    id INT PRIMARY KEY IDENTITY(1,1),
    idPedido INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad DECIMAL(10,2) NOT NULL CHECK (cantidad > 0),
    precioUnitario DECIMAL(10,2) NOT NULL CHECK (precioUnitario > 0),
    total AS (cantidad * precioUnitario) PERSISTED,
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_DetallePedido_Pedido FOREIGN KEY (idPedido) REFERENCES Pedidos(id),
    CONSTRAINT fk_DetallePedido_Producto FOREIGN KEY (idProducto) REFERENCES Productos(id)
);
GO


-- Procedimientos almacenados para listar activos por búsqueda
CREATE PROCEDURE paProductoListar @parametro NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Productos
    WHERE estado <> -1 AND descripcion LIKE '%' + @parametro + '%'
    ORDER BY descripcion;
END;
GO

CREATE PROCEDURE paClienteListar @parametro NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Clientes
    WHERE estado <> -1 AND nombre LIKE '%' + @parametro + '%'
    ORDER BY nombre;
END;
GO

-- DML de ejemplo
INSERT INTO Productos (codigo, descripcion, unidadMedida, saldo, precioVenta)
VALUES ('HBC123', 'Hamburguesa de Res', 'Unidad', 50, 35.00);

INSERT INTO Productos (codigo, descripcion, unidadMedida, saldo, precioVenta)
VALUES ('DRK001', 'Coca-Cola Lata', 'Unidad', 100, 10.00);

INSERT INTO Clientes (nombre, telefono, direccion)
VALUES ('Ana Gomez', '78451234', 'Calle Arce #123');


-- Consultas de prueba
EXEC paProductoListar 'Hamburguesa';
EXEC paClienteListar 'Ana';
