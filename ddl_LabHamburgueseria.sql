-- DDL
CREATE DATABASE LabHamburgueseria
GO
USE [master]
GO
CREATE LOGIN [usrhambu] WITH PASSWORD = N'123456',
	DEFAULT_DATABASE = [LabHamburgueseria],
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = ON
GO
USE [LabHamburgueseria]
GO
CREATE USER [usrhambu] FOR LOGIN [usrhambu]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrhambu]
GO

DROP TABLE Pagos;
DROP TABLE Detalles_Pedido;
DROP TABLE Pedidos;
DROP TABLE Usuarios;
DROP TABLE Productos;
DROP TABLE Empleados;
DROP TABLE Clientes;

CREATE TABLE Clientes (
    ID_Cliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Telefono VARCHAR(20) NOT NULL,
    Direccion TEXT NOT NULL,
    Metodo_Preferido_Pago VARCHAR(50) NOT NULL, -- Ej. Tarjeta, Efectivo, PayPal
    Fecha_Registro DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    ID_Empleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Cargo VARCHAR(50) NOT NULL, -- Ej. Vendedor, Cajero
    Telefono VARCHAR(20) NOT NULL,
    Fecha_Contratacion DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Productos
CREATE TABLE Productos (
    ID_Producto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Producto VARCHAR(150) NOT NULL,
    Descripcion TEXT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0, -- Cantidad disponible
    Categoria VARCHAR(50) NOT NULL, -- Ej. Hamburguesas, Bebidas, Postres
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    ID_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Usuario VARCHAR(100) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL, -- Almacenada de forma segura (hashed)
    Rol VARCHAR(50) NOT NULL, -- Admin, Empleado
    Fecha_Registro DATETIME NOT NULL DEFAULT GETDATE(),
    Ultimo_Login DATETIME NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Pedidos
CREATE TABLE Pedidos (
    ID_Pedido INT IDENTITY(1,1) PRIMARY KEY,
    ID_Cliente INT NOT NULL,
    ID_Empleado INT NOT NULL, -- Empleado que gestiona el pedido
    Fecha_Pedido DATETIME NOT NULL DEFAULT GETDATE(),
    Metodo_Pago VARCHAR(50) NOT NULL, -- Tarjeta, Efectivo
    Estado VARCHAR(50) NOT NULL, -- Ej. "Pendiente", "Pagado", "Entregado"
    Total DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente),
    CONSTRAINT FK_Pedidos_Empleados FOREIGN KEY (ID_Empleado) REFERENCES Empleados(ID_Empleado)
);
GO

-- Crear la tabla Detalles_Pedido
CREATE TABLE Detalles_Pedido (
    ID_Detalle INT IDENTITY(1,1) PRIMARY KEY,
    ID_Pedido INT NOT NULL,
    ID_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetallesPedido_Pedidos FOREIGN KEY (ID_Pedido) REFERENCES Pedidos(ID_Pedido),
    CONSTRAINT FK_DetallesPedido_Productos FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto)
);
GO

-- Crear la tabla Pagos
CREATE TABLE Pagos (
    ID_Pago INT IDENTITY(1,1) PRIMARY KEY,
    ID_Pedido INT NOT NULL,
    Metodo_Pago VARCHAR(50) NOT NULL, -- Tarjeta, Efectivo
    Monto DECIMAL(10,2) NOT NULL,
    Fecha_Pago DATETIME NOT NULL DEFAULT GETDATE(),
    Estado_Pago VARCHAR(50) NOT NULL, -- "Completado", "Pendiente"
    CONSTRAINT FK_Pagos_Pedidos FOREIGN KEY (ID_Pedido) REFERENCES Pedidos(ID_Pedido)
);
GO