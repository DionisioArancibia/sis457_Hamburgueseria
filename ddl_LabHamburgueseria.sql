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
DROP TABLE DetalleVenta;
DROP TABLE Venta;
DROP TABLE DetallePedido;
DROP TABLE Pedido;
DROP TABLE Producto;
DROP TABLE Cliente;
DROP TABLE Usuario;
GO

-- Tabla Usuarios
CREATE TABLE Usuario (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombreUsuario NVARCHAR(15) NOT NULL,
    clave NVARCHAR(150) NOT NULL,
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Tabla Clientes
CREATE TABLE Cliente (
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
CREATE TABLE Producto (
    id INT PRIMARY KEY IDENTITY(1,1),
    codigo NVARCHAR(20) NOT NULL UNIQUE,
    descripcion NVARCHAR(250) NOT NULL, -- Ej: Hamburguesa de res, papas fritas
    categoria NVARCHAR(50) NOT NULL, -- Ej: Hamburguesa, Bebida, Complemento
    precioVenta DECIMAL(10,2) NOT NULL CHECK (precioVenta > 0),
    stock INT NOT NULL DEFAULT 0, -- Cantidad disponible
    estado SMALLINT DEFAULT 1, -- -1: Eliminado, 0: Inactivo, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Tabla Pedidos
CREATE TABLE Pedido (
    id INT PRIMARY KEY IDENTITY(1,1),
    idCliente INT NOT NULL,
    fechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    estado SMALLINT DEFAULT 1, -- -1: Cancelado, 0: Pendiente, 1: Completado
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_Pedido_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(id)
);
GO

-- Tabla DetallePedido
CREATE TABLE DetallePedido (
    id INT PRIMARY KEY IDENTITY(1,1),
    idPedido INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precioUnitario DECIMAL(10,2) NOT NULL CHECK (precioUnitario > 0),
    total AS (cantidad * precioUnitario) PERSISTED,
    estado SMALLINT DEFAULT 1, -- -1: Cancelado, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_DetallePedido_Pedido FOREIGN KEY (idPedido) REFERENCES Pedido(id),
    CONSTRAINT fk_DetallePedido_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);
GO

-- Tabla Ventas
CREATE TABLE Venta (
    id INT PRIMARY KEY IDENTITY(1,1),
    idCliente INT NOT NULL,
    idUsuario INT NOT NULL,
    fechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL,
    metodoPago NVARCHAR(20) NOT NULL, -- Ej: Efectivo, Tarjeta
    estado SMALLINT DEFAULT 1, -- -1: Cancelada, 0: Pendiente, 1: Completada
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_Venta_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(id),
    CONSTRAINT fk_Venta_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(id)
);
GO

-- Tabla DetalleVenta
CREATE TABLE DetalleVenta (
    id INT PRIMARY KEY IDENTITY(1,1),
    idVenta INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precioUnitario DECIMAL(10,2) NOT NULL CHECK (precioUnitario > 0),
    total AS (cantidad * precioUnitario) PERSISTED,
    estado SMALLINT DEFAULT 1, -- -1: Cancelado, 1: Activo
    usuarioRegistro NVARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fk_DetalleVenta_Venta FOREIGN KEY (idVenta) REFERENCES Venta(id),
    CONSTRAINT fk_DetalleVenta_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);
GO

-- Procedimientos almacenados para listar registros activos

-- Listar productos activos
CREATE PROCEDURE paProductoListar @parametro NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Producto
    WHERE estado <> -1 AND descripcion LIKE '%' + @parametro + '%'
    ORDER BY descripcion;
END;
GO

-- Listar clientes activos
CREATE PROCEDURE paClienteListar @parametro NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Cliente
    WHERE estado <> -1 AND nombre LIKE '%' + @parametro + '%'
    ORDER BY nombre;
END;
GO

-- Listar pedidos activos
CREATE PROCEDURE paPedidoListar
AS
BEGIN
    SELECT * FROM Pedido
    WHERE estado <> -1
    ORDER BY fechaPedido DESC;
END;
GO

-- Listar ventas activas
CREATE PROCEDURE paVentaListar
AS
BEGIN
    SELECT * FROM Venta
    WHERE estado <> -1
    ORDER BY fechaVenta DESC;
END;
GO

-- Insertar datos de prueba
INSERT INTO Producto (codigo, descripcion, categoria, precioVenta, stock)
VALUES ('HBG001', 'Hamburguesa Clásica', 'Hamburguesa', 35.00, 100);

INSERT INTO Producto (codigo, descripcion, categoria, precioVenta, stock)
VALUES ('FRI001', 'Papas Fritas', 'Complemento', 10.00, 200);

INSERT INTO Producto (codigo, descripcion, categoria, precioVenta, stock)
VALUES ('BEB001', 'Refresco', 'Bebida', 8.00, 300);

INSERT INTO Cliente (nombre, telefono, direccion)
VALUES ('Juan Perez', '78912345', 'Calle Falsa #123');

INSERT INTO Cliente (nombre, telefono, direccion)
VALUES ('Maria Gomez', '67894512', 'Av. Siempre Viva #456');
GO
INSERT INTO Producto (codigo, descripcion, categoria, precioVenta, stock)
VALUES 
('HBG002', 'Hamburguesa BBQ', 'Hamburguesa', 40.00, 80),
('HBG003', 'Hamburguesa Vegana', 'Hamburguesa', 38.00, 70),
('BEB002', 'Agua Mineral', 'Bebida', 5.00, 250),
('FRI002', 'Aros de Cebolla', 'Complemento', 12.00, 150);
GO

INSERT INTO Cliente (nombre, telefono, direccion)
VALUES 
('Carlos López', '72123456', 'Av. Los Pinos #789'),
('Lucía Fernández', '76123456', 'Calle Las Rosas #101'),
('Miguel Ortega', '75123456', 'Av. Los Olivos #102'),
('Ana Rojas', '70123456', 'Calle Los Jazmines #202');
GO

INSERT INTO Pedido (idCliente, total, estado)
VALUES 
(1, 58.00, 1), -- Pedido completado
(2, 45.00, 1), -- Pedido completado
(3, 26.00, 0), -- Pedido pendiente
(4, 18.00, 1); -- Pedido completado
GO

-- Consultas de prueba
EXEC paProductoListar 'Hamburguesa';
EXEC paClienteListar 'Juan';
EXEC paPedidoListar;
EXEC paVentaListar;
GO
