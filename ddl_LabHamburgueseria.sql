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
DROP TABLE Producto;
DROP TABLE Categoria;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Cliente;



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
  usuario VARCHAR(15) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  
 
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
    PrecioVenta DECIMAL NOT NULL CHECK (PrecioVenta > 0),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);



-- Tabla Venta
CREATE TABLE Venta (
    IdVenta INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    TipoDocumento VARCHAR(20) NOT NULL,
    DocumentoCliente VARCHAR(20) NOT NULL,
    NombreCliente VARCHAR(100) NOT NULL,
    MontoPago DECIMAL(18, 2) NOT NULL CHECK (MontoPago >= 0),
    MontoCambio DECIMAL(18, 2) NOT NULL CHECK (MontoCambio >= 0),
    MontoTotal DECIMAL(18, 2) NOT NULL CHECK (MontoTotal > 0),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
   
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

ALTER TABLE Cliente ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Usuario ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1: Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Categoria ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Categoria ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Categoria ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Producto ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Venta ADD UsuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1;

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
CREATE PROCEDURE paProductoListar
    @parametro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el parámetro es un código exacto
    IF EXISTS (
        SELECT 1 
        FROM Producto
        WHERE estado != -1 AND Codigo = @parametro
    )
    BEGIN
        -- Buscar por código exacto
        SELECT * 
        FROM Producto
        WHERE estado != -1 AND Codigo = @parametro;
    END
    ELSE
    BEGIN
        -- Buscar por coincidencias en el nombre
        SELECT * 
        FROM Producto
        WHERE estado != -1 AND Nombre LIKE '%' + @parametro + '%';
    END
END
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


-- PROCEDIMIENTO LISTAR EMPLEADOS
CREATE PROC paEmpleadoListar
    @parametro VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Empleado
    WHERE cedulaIdentidad LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
       OR nombres LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
       OR primerApellido LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
       OR segundoApellido LIKE '%' + REPLACE(@parametro, ' ', '%') + '%';
END
GO




-- PROCEDIMIENTO LISTAR VENTAS
CREATE PROC paVentaListar
    @parametro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.IdVenta, v.IdUsuario,v. IdEmpleado, v.TipoDocumento, v.DocumentoCliente, 
           v.NombreCliente, v.MontoPago, v.MontoCambio, v.MontoTotal, 
           v.fechaRegistro, v.estado
    FROM Venta v
    WHERE v.estado != -1
      AND (v.DocumentoCliente LIKE '%' + @parametro + '%'
           OR v.NombreCliente LIKE '%' + @parametro + '%'
           OR v.TipoDocumento LIKE '%' + @parametro + '%');
END
GO




-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Descripcion) VALUES
('Bebidas'),
('Hamburguesas'),
('Postres'),
('Snacks');

--Empleados
INSERT INTO Empleado (cedulaIdentidad, nombres, primerApellido, segundoApellido, direccion, celular, cargo) VALUES
('1234567890', 'Pedro', 'Gómez', 'Martínez', 'Calle del Sabor 10, Ciudad', 9876543210, 'Cocinero'),
('0987654321', 'Lucía', 'Fernández', 'Pérez', 'Avenida del Hambre 20, Ciudad', 9123456789, 'Atención al Cliente');

-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Documento, NombreCompleto, Correo, Telefono) VALUES
('20001', 'Juan Perez', 'juan.perez@example.com', '71234567'),
('20002', 'Maria Lopez', 'maria.lopez@example.com', '72345678'),
('20003', 'Carlos Gomez', 'carlos.gomez@example.com', '73456789');


--DATOS USUARIO
INSERT INTO Usuario( usuario, clave)
VALUES( 'dioni', 'i0hcoO/nssY6WOs9pOp5Xw==');

-- Insertar datos en la tabla Producto
INSERT INTO Producto (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioVenta) VALUES
('P001', 'Coca-Cola 500ml', 'Bebida gaseosa', 1, 50,7.50),
('P002', 'Hamburguesa Clásica', 'Hamburguesa con queso y vegetales', 2, 30, 25.00),
('P003', 'Brownie de Chocolate', 'Postre de chocolate', 3, 20,12.00),
('P004', 'Papas Fritas', 'Papas fritas crocantes', 4, 40,5.00);




-- Insertar datos en la tabla Venta
INSERT INTO Venta(IdUsuario, TipoDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal) VALUES
(1, 'Boleta', '101010', 'Juan Perez', 100.00, 10.00, 90.00);
GO

INSERT INTO Producto (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioVenta) 
VALUES ('P001', 'Hamburguesa Simple', 'Hamburguesa de res con pan', 1, 50, 5.50);


-- Confirmar datos insertados
SELECT * FROM Categoria;
SELECT * FROM Cliente;
SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Producto;
SELECT * FROM Venta;
SELECT * FROM VentaDetalle;

EXEC paCategoriaListar 'Bebidas';
EXEC paVentaListar 'juan';
EXEC paProductoListar 'P002';

EXEC sp_help 'Empleado';
go

CREATE VIEW VistaEmpleado AS
SELECT id AS idEmpleado, nombres, cedulaIdentidad FROM Empleado;
go

SELECT * 
FROM VentaDetalle vd
LEFT JOIN Venta v ON vd.IdVenta = v.IdVenta
WHERE v.IdVenta IS NULL; -- Verifica que todas las IdVenta en VentaDetalle existen en Venta

SELECT * 
FROM VentaDetalle vd
LEFT JOIN Producto p ON vd.IdProducto = p.IdProducto
WHERE p.IdProducto IS NULL; -- Verifica que todas las IdProducto en VentaDetalle existen en Producto

SELECT * FROM Producto WHERE Codigo = 'P001';
