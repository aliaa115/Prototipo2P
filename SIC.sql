DROP DATABASE sic;
CREATE DATABASE sic;
USE sic;
CREATE TABLE bodegas
(
	codigo_bodega VARCHAR(5) PRIMARY KEY,
    nombre_bodega VARCHAR(60),
    estado tinyint
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE lineas
(
	codigo_linea VARCHAR(5) PRIMARY KEY,
    nombre_linea VARCHAR(60),
    estado tinyint
) ENGINE=INNODB DEFAULT CHARSET=latin1;
insert into lineas values ('1', 'zapatos', 1);
CREATE TABLE marcas
(
	codigo_marca VARCHAR(5) PRIMARY KEY,
    nombre_marca VARCHAR(60),
    estado tinyint
) ENGINE=INNODB DEFAULT CHARSET=latin1;
insert into marcas values ('1', 'adidas', 1);
CREATE TABLE productos
(
	codigo_producto VARCHAR(18) PRIMARY KEY,
    nombre_producto VARCHAR(60),
    codigo_linea VARCHAR(5),
    codigo_marca VARCHAR(5),
    existencia_producto FLOAT(10,2),
    estado tinyint,
    FOREIGN KEY (codigo_linea) REFERENCES lineas(codigo_linea),
    FOREIGN KEY (codigo_marca) REFERENCES marcas(codigo_marca)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
insert into marcas values ('1', 'zapato deportivo', '1', '1', 2365, 1);
CREATE TABLE existencias
(
	codigo_bodega VARCHAR(5),
    codigo_producto VARCHAR(18),
    saldo_existencia FLOAT(10,2),
    PRIMARY KEY (codigo_bodega, codigo_producto),
	FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE vendedores
(
	codigo_vendedor VARCHAR(5) PRIMARY KEY,
    nombre_vendedor VARCHAR(60),
    direccion_vendedor VARCHAR(60),
    telefono_vendedor VARCHAR(50),
    nit_vendedor VARCHAR(20),
    estado tinyint
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE clientes
(
	codigo_cliente VARCHAR(5) PRIMARY KEY,
    nombre_cliente VARCHAR(60),
    direccion_cliente VARCHAR(60),
    nit_cliente VARCHAR(20),
    telefono_cliente VARCHAR(50),
    codigo_vendedor VARCHAR(5),
    estado tinyint,
    FOREIGN KEY (codigo_vendedor) REFERENCES vendedores(codigo_vendedor)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE proveedores
(
	codigo_proveedor VARCHAR(5) PRIMARY KEY,
    nombre_proveedor VARCHAR(60),
    direccion_proveedor VARCHAR(60),
    telefono_proveedor VARCHAR(50),
    nit_proveedor VARCHAR(50),
    estado tinyint
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE compras_encabezado
(
	documento_compraenca VARCHAR(10) PRIMARY KEY,
    codigo_proveedor VARCHAR(5),
    fecha_compraenca DATE,
	total_compraenca FLOAT(10,2),
    estado tinyint,
    FOREIGN KEY (codigo_proveedor) REFERENCES proveedores(codigo_proveedor)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE compras_detalle
(
	documento_compraenca VARCHAR(10),
    codigo_producto VARCHAR(18),
    cantidad_compradet FLOAT(10,2),
    costo_compradet FLOAT(10,2),
	codigo_bodega VARCHAR(5),
    PRIMARY KEY (documento_compraenca, codigo_producto),
    FOREIGN KEY (documento_compraenca) REFERENCES compras_encabezado(documento_compraenca),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE ventas_encabezado
(
	documento_ventaenca VARCHAR(10) PRIMARY KEY,
    codigo_cliente VARCHAR(5),
    fecha_ventaenca DATE,
    total_ventaenca FLOAT(10,2),
    estado tinyint,
    FOREIGN KEY (codigo_cliente) REFERENCES clientes(codigo_cliente)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
CREATE TABLE ventas_detalle
(
	documento_ventaenca VARCHAR(10),
    codigo_producto VARCHAR(18),
    cantidad_ventadet FLOAT(10,2),
    costo_ventadet FLOAT(10,2),
    precio_ventadet FLOAT(10,2),
    codigo_bodega VARCHAR(5),
    PRIMARY KEY (documento_ventaenca, codigo_producto),
    FOREIGN KEY (documento_ventaenca) REFERENCES ventas_encabezado(documento_ventaenca),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
    -- -----------------------------------------------------
-- Table `erp`.`ayudas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ayuda` ;

CREATE TABLE `ayuda` (
  	`Id_ayuda` int(11) NOT NULL,
  	`Ruta` text COLLATE utf8_unicode_ci NOT NULL,
 	`indice` text COLLATE utf8_unicode_ci NOT NULL
	) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
INSERT INTO `ayuda` (`Id_ayuda`, `Ruta`, `indice`) VALUES
(1, 'Página web ayuda/ayuda.chm', 'menu.html'),
(2, 'Página web ayuda/ayuda.chm', 'Menúboletos.html');

use sic;

-- MOVIMIENTOS DE INVENTARIO

create table tipo_movimiento(
	codigo_tipo_movimiento int,
    tipo_movimiento int,
    signo varchar(1),
    estado tinyint,
    primary key(codigo_tipo_movimiento)
);
insert into tipo_movimiento values (1, 'suma', '+', 1), (2, 'resta', '-', 1);

create table movimientos_inventario_enc (
	codigo_movimiento int,
    codigo_tipo_movimiento int,
    fecha_movimiento int,
    estado tinyint,
    primary key (codigo_movimiento),
    foreign key (codigo_tipo_movimiento) references tipo_movimiento(codigo_tipo_movimiento)
);
insert into movimientos_inventario_enc values (1, 1, now(), 1), (2, 2, '2010-02-02', 1);

create table movimientos_inventario_det (
	codigo_movimiento int,
    codigo_producto VARCHAR(18),
    cantidad int,
    PRIMARY KEY (codigo_movimiento, codigo_producto),
    foreign key (codigo_movimiento) references movimientos_inventario_enc(codigo_movimiento)
);
insert into movimientos_inventario_det values (1,'1', 10);
insert into movimientos_inventario_det values (2,'1', 20);

