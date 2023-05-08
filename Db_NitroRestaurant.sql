-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         10.6.8-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para db_nitrorestaurant
CREATE DATABASE IF NOT EXISTS `db_nitrorestaurant` /*!40100 DEFAULT CHARACTER SET utf16 */;
USE `db_nitrorestaurant`;

-- Volcando estructura para tabla db_nitrorestaurant.categorias
CREATE TABLE IF NOT EXISTS `categorias` (
  `ID_CATEGORIA` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `IMG_URL` varchar(100) DEFAULT NULL,
  `id_sucursal` int(11) NOT NULL,
  PRIMARY KEY (`ID_CATEGORIA`),
  KEY `FK_categorias_sucursales` (`id_sucursal`),
  CONSTRAINT `FK_categorias_sucursales` FOREIGN KEY (`id_sucursal`) REFERENCES `sucursales` (`ID_SUCURSAL`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.categorias: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.detalle_pedidos
CREATE TABLE IF NOT EXISTS `detalle_pedidos` (
  `ID_DETALLE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PRODUCTO` int(11) NOT NULL,
  `ID_PEDIDO` int(11) NOT NULL,
  `CANTIDAD` int(11) NOT NULL,
  PRIMARY KEY (`ID_DETALLE`),
  KEY `FK_REFERENCE_1` (`ID_PRODUCTO`),
  KEY `FK_REFERENCE_2` (`ID_PEDIDO`),
  CONSTRAINT `FK_REFERENCE_1` FOREIGN KEY (`ID_PRODUCTO`) REFERENCES `productos` (`ID_PRODUCTO`),
  CONSTRAINT `FK_REFERENCE_2` FOREIGN KEY (`ID_PEDIDO`) REFERENCES `pedidos` (`ID_PEDIDO`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.detalle_pedidos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `detalle_pedidos` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_pedidos` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.empleados
CREATE TABLE IF NOT EXISTS `empleados` (
  `ID_EMPLEADO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_TIPO_EMPLEADO` int(11) NOT NULL,
  `ID_SUCURSAL` int(11) NOT NULL,
  `NOMBRE` varchar(50) NOT NULL,
  `PATERNO` varchar(50) NOT NULL,
  `MATERNO` varchar(50) NOT NULL,
  `TELEFONO` varchar(50) NOT NULL,
  `USUARIO` varchar(30) NOT NULL,
  `CONTRASENIA` varchar(64) NOT NULL,
  `CONTRASENIA_ANTERIOR` varchar(64) DEFAULT NULL,
  `ACTIVO` bit(1) NOT NULL,
  PRIMARY KEY (`ID_EMPLEADO`),
  KEY `FK_REFERENCE_18` (`ID_SUCURSAL`),
  KEY `FK_REFERENCE_5` (`ID_TIPO_EMPLEADO`),
  CONSTRAINT `FK_REFERENCE_18` FOREIGN KEY (`ID_SUCURSAL`) REFERENCES `sucursales` (`ID_SUCURSAL`),
  CONSTRAINT `FK_REFERENCE_5` FOREIGN KEY (`ID_TIPO_EMPLEADO`) REFERENCES `tipo_empleados` (`ID_TIPO_EMPLEADO`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.empleados: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` (`ID_EMPLEADO`, `ID_TIPO_EMPLEADO`, `ID_SUCURSAL`, `NOMBRE`, `PATERNO`, `MATERNO`, `TELEFONO`, `USUARIO`, `CONTRASENIA`, `CONTRASENIA_ANTERIOR`, `ACTIVO`) VALUES
	(1, 1, 1, 'string', 'string', 'string', 'string', 'string', '473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8', NULL, b'1'),
	(2, 2, 1, 'Henry', 'Canales', 'Valles', '9932107321', 'Henrisin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', NULL, b'1');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.entradas
CREATE TABLE IF NOT EXISTS `entradas` (
  `ID_ENTRADA` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PRODUCTO` int(11) NOT NULL,
  `ID_PROVEEDOR` int(11) DEFAULT NULL,
  `CANTIDAD` int(11) NOT NULL,
  `FECHA_HORA` datetime NOT NULL,
  PRIMARY KEY (`ID_ENTRADA`),
  KEY `FK_REFERENCE_13` (`ID_PRODUCTO`),
  KEY `FK_REFERENCE_14` (`ID_PROVEEDOR`),
  CONSTRAINT `FK_REFERENCE_13` FOREIGN KEY (`ID_PRODUCTO`) REFERENCES `productos` (`ID_PRODUCTO`),
  CONSTRAINT `FK_REFERENCE_14` FOREIGN KEY (`ID_PROVEEDOR`) REFERENCES `proveedores` (`ID_PROVEEDOR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.entradas: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `entradas` DISABLE KEYS */;
/*!40000 ALTER TABLE `entradas` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.mesas
CREATE TABLE IF NOT EXISTS `mesas` (
  `ID_SUCURSAL` int(11) NOT NULL,
  `ID_EMPLEADO` int(11) DEFAULT NULL,
  `ID_MESA` int(11) NOT NULL AUTO_INCREMENT,
  `NUM_MESA` varchar(3) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID_MESA`),
  KEY `FK_REFERENCE_15` (`ID_SUCURSAL`),
  KEY `FK_REFERENCE_16` (`ID_EMPLEADO`),
  CONSTRAINT `FK_REFERENCE_15` FOREIGN KEY (`ID_SUCURSAL`) REFERENCES `sucursales` (`ID_SUCURSAL`),
  CONSTRAINT `FK_REFERENCE_16` FOREIGN KEY (`ID_EMPLEADO`) REFERENCES `empleados` (`ID_EMPLEADO`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.mesas: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mesas` DISABLE KEYS */;
INSERT INTO `mesas` (`ID_SUCURSAL`, `ID_EMPLEADO`, `ID_MESA`, `NUM_MESA`) VALUES
	(1, 1, 1, '1');
/*!40000 ALTER TABLE `mesas` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.modulos
CREATE TABLE IF NOT EXISTS `modulos` (
  `ID_MODULO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_MODULO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.modulos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `modulos` DISABLE KEYS */;
/*!40000 ALTER TABLE `modulos` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.operaciones
CREATE TABLE IF NOT EXISTS `operaciones` (
  `ID_OPERACION` int(11) NOT NULL AUTO_INCREMENT,
  `ID_MODULO` int(11) NOT NULL,
  `NOMBRE` int(11) NOT NULL,
  PRIMARY KEY (`ID_OPERACION`),
  KEY `FK_REFERENCE_6` (`ID_MODULO`),
  CONSTRAINT `FK_REFERENCE_6` FOREIGN KEY (`ID_MODULO`) REFERENCES `modulos` (`ID_MODULO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.operaciones: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `operaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `operaciones` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.pedidos
CREATE TABLE IF NOT EXISTS `pedidos` (
  `ID_PEDIDO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_EMPLEADO` int(11) NOT NULL,
  `ID_SUCURSAL` int(11) NOT NULL,
  `ID_TIPO_PEDIDO` int(11) NOT NULL,
  `FECHA_HORA` datetime NOT NULL,
  `TERMINADO` bit(1) DEFAULT NULL,
  `COMENTARIO` varchar(100) NOT NULL,
  `ID_MESA` int(11) NOT NULL,
  PRIMARY KEY (`ID_PEDIDO`),
  KEY `FK_REFERENCE_11` (`ID_SUCURSAL`),
  KEY `FK_REFERENCE_12` (`ID_TIPO_PEDIDO`),
  KEY `FK_REFERENCE_20` (`ID_MESA`),
  KEY `FK_REFERENCE_9` (`ID_EMPLEADO`),
  CONSTRAINT `FK_REFERENCE_11` FOREIGN KEY (`ID_SUCURSAL`) REFERENCES `sucursales` (`ID_SUCURSAL`),
  CONSTRAINT `FK_REFERENCE_12` FOREIGN KEY (`ID_TIPO_PEDIDO`) REFERENCES `tipo_pedidos` (`ID_TIPO_PEDIDO`),
  CONSTRAINT `FK_REFERENCE_20` FOREIGN KEY (`ID_MESA`) REFERENCES `mesas` (`ID_MESA`),
  CONSTRAINT `FK_REFERENCE_9` FOREIGN KEY (`ID_EMPLEADO`) REFERENCES `empleados` (`ID_EMPLEADO`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.pedidos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `ID_PRODUCTO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_CATEGORIA` int(11) NOT NULL,
  `NOMBRE` varchar(50) NOT NULL,
  `INVERSION` decimal(8,2) NOT NULL,
  `PRECIO` decimal(8,2) NOT NULL,
  `CONTABLE` bit(1) NOT NULL,
  `IMG_URL` varchar(100) DEFAULT NULL,
  `CANTIDAD` int(11) NOT NULL,
  `ID_UM` int(11) NOT NULL,
  `ID_SUCURSAL` int(11) NOT NULL,
  PRIMARY KEY (`ID_PRODUCTO`),
  KEY `FK_REFERENCE_10` (`ID_UM`),
  KEY `FK_REFERENCE_19` (`ID_SUCURSAL`),
  KEY `FK_REFERENCE_8` (`ID_CATEGORIA`),
  CONSTRAINT `FK_REFERENCE_10` FOREIGN KEY (`ID_UM`) REFERENCES `unidad_medidas` (`ID_UM`),
  CONSTRAINT `FK_REFERENCE_19` FOREIGN KEY (`ID_SUCURSAL`) REFERENCES `sucursales` (`ID_SUCURSAL`),
  CONSTRAINT `FK_REFERENCE_8` FOREIGN KEY (`ID_CATEGORIA`) REFERENCES `categorias` (`ID_CATEGORIA`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.productos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.proveedores
CREATE TABLE IF NOT EXISTS `proveedores` (
  `ID_PROVEEDOR` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_PROVEEDOR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.proveedores: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.sucursales
CREATE TABLE IF NOT EXISTS `sucursales` (
  `ID_SUCURSAL` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(50) NOT NULL,
  `NUM_MESAS` varchar(3) NOT NULL,
  `UBICACION` varchar(100) NOT NULL,
  PRIMARY KEY (`ID_SUCURSAL`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.sucursales: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` (`ID_SUCURSAL`, `NOMBRE`, `NUM_MESAS`, `UBICACION`) VALUES
	(1, '1', '20', 'en casa de manu');
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.tipoe_operaciones
CREATE TABLE IF NOT EXISTS `tipoe_operaciones` (
  `ID_TIPOE_OPERACIONES` int(11) NOT NULL AUTO_INCREMENT,
  `ID_TIPO_EMPLEADO` int(11) NOT NULL,
  `ID_TIPO_OPERACION` int(11) NOT NULL,
  PRIMARY KEY (`ID_TIPOE_OPERACIONES`),
  KEY `FK_REFERENCE_3` (`ID_TIPO_EMPLEADO`),
  KEY `FK_REFERENCE_4` (`ID_TIPO_OPERACION`),
  CONSTRAINT `FK_REFERENCE_3` FOREIGN KEY (`ID_TIPO_EMPLEADO`) REFERENCES `tipo_empleados` (`ID_TIPO_EMPLEADO`),
  CONSTRAINT `FK_REFERENCE_4` FOREIGN KEY (`ID_TIPO_OPERACION`) REFERENCES `operaciones` (`ID_OPERACION`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.tipoe_operaciones: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `tipoe_operaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipoe_operaciones` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.tipo_empleados
CREATE TABLE IF NOT EXISTS `tipo_empleados` (
  `ID_TIPO_EMPLEADO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_TIPO_EMPLEADO`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.tipo_empleados: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `tipo_empleados` DISABLE KEYS */;
INSERT INTO `tipo_empleados` (`ID_TIPO_EMPLEADO`, `NOMBRE`) VALUES
	(1, 'Admin'),
	(2, 'User');
/*!40000 ALTER TABLE `tipo_empleados` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.tipo_pedidos
CREATE TABLE IF NOT EXISTS `tipo_pedidos` (
  `ID_TIPO_PEDIDO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(20) NOT NULL,
  PRIMARY KEY (`ID_TIPO_PEDIDO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.tipo_pedidos: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `tipo_pedidos` DISABLE KEYS */;
INSERT INTO `tipo_pedidos` (`ID_TIPO_PEDIDO`, `NOMBRE`) VALUES
	(1, 'Para llevar'),
	(2, 'Para comer aqui'),
	(3, 'Merma');
/*!40000 ALTER TABLE `tipo_pedidos` ENABLE KEYS */;

-- Volcando estructura para tabla db_nitrorestaurant.unidad_medidas
CREATE TABLE IF NOT EXISTS `unidad_medidas` (
  `ID_UM` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(20) NOT NULL,
  PRIMARY KEY (`ID_UM`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf16;

-- Volcando datos para la tabla db_nitrorestaurant.unidad_medidas: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `unidad_medidas` DISABLE KEYS */;
INSERT INTO `unidad_medidas` (`ID_UM`, `NOMBRE`) VALUES
	(1, 'Pieza');
/*!40000 ALTER TABLE `unidad_medidas` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
