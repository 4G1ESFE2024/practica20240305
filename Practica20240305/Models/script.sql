-- Crear la base de datos
CREATE DATABASE Practica20240305DB;
GO

-- Usar la base de datos recién creada
USE Practica20240305DB;
GO

-- Crear la tabla FacturaVenta
CREATE TABLE FacturaVentas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATE NOT NULL,
    Correlativo VARCHAR(20) NOT NULL,
	Cliente VARCHAR(100) NOT NULL,
    TotalVenta DECIMAL(10,2) NOT NULL
);
GO

-- Crear la tabla DetFacturaVenta
CREATE TABLE DetFacturaVentas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdFacturaVenta INT NOT NULL,
    Producto VARCHAR(100) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdFacturaVenta) REFERENCES FacturaVentas(Id) ON DELETE CASCADE
);
GO

