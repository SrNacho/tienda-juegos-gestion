-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-04-2021 a las 00:46:59
-- Versión del servidor: 10.4.17-MariaDB
-- Versión de PHP: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `juegos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `consola`
--

CREATE TABLE `consola` (
  `id` int(11) NOT NULL,
  `nombre_consola` varchar(11) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `consola`
--

INSERT INTO `consola` (`id`, `nombre_consola`) VALUES
(1, 'PS4'),
(2, 'XBOX'),
(3, 'XBOXONE'),
(4, 'PC');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `juego`
--

CREATE TABLE `juego` (
  `id_juego` int(11) NOT NULL,
  `id_consola` int(11) NOT NULL,
  `nombre_juego` varchar(25) COLLATE utf8_spanish_ci NOT NULL,
  `stock_juego` int(7) NOT NULL,
  `precio_juego` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `juego`
--

INSERT INTO `juego` (`id_juego`, `id_consola`, `nombre_juego`, `stock_juego`, `precio_juego`) VALUES
(1, 1, 'PESS', 1, 3500),
(2, 2, 'FIFA21', 0, 2500),
(3, 1, 'FIFA21', 3196, 250),
(6, 4, 'FORTNITEX', 0, 300),
(7, 2, 'BOCA2121', 0, 3213);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_venta` int(11) NOT NULL,
  `dni_cliente` int(8) NOT NULL,
  `id_juego` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `nombre_cliente` varchar(16) COLLATE utf8_spanish_ci NOT NULL,
  `telefono_cliente` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`id_venta`, `dni_cliente`, `id_juego`, `fecha`, `nombre_cliente`, `telefono_cliente`) VALUES
(34, 21342143, 3, '2021-04-21', '0', 123213242),
(35, 32142314, 1, '2021-04-21', '0', 2147483647),
(36, 15324235, 1, '2021-04-21', 'GERARDER', 2147483647),
(37, 44444444, 3, '2021-04-21', 'RWEREWRW', 1231231231),
(38, 33333333, 2, '2021-04-21', 'REWRWERE', 1231243123),
(39, 41234312, 6, '2021-04-21', 'RFWERWED', 1231231231),
(40, 12333333, 7, '2021-04-21', 'RFWEDRWE', 2147483647),
(41, 12331231, 1, '2021-04-21', 'FWEDRFWE', 2147483647),
(42, 12331231, 2, '2021-04-21', 'FWEDRFWE', 2147483647),
(43, 12331231, 3, '2021-04-21', 'FWEDRFWE', 2147483647),
(44, 12331231, 6, '2021-04-21', 'FWEDRFWE', 2147483647),
(45, 12331231, 3, '2021-04-21', 'FWEDRFWE', 2147483647),
(46, 12331231, 2, '2021-04-21', 'FWEDRFWE', 2147483647),
(47, 31231231, 6, '2021-04-21', 'DASDASDS', 1231231231),
(48, 31231231, 6, '2021-04-21', 'DASDASDS', 1231231231),
(49, 31231231, 6, '2021-04-21', 'DASDASDS', 1231231231),
(50, 31231231, 2, '2021-04-21', 'DASDASDS', 1231231231),
(51, 31231231, 6, '2021-04-21', 'EQWEWQEQ', 2147483647),
(52, 31231231, 6, '2021-04-21', 'EQWEWQEQ', 2147483647),
(53, 31231231, 6, '2021-04-21', 'EQWEWQEQ', 2147483647),
(54, 31231231, 2, '2021-04-21', 'EQWEWQEQ', 2147483647),
(55, 31231231, 2, '2021-04-21', 'EQWEWQEQ', 2147483647),
(56, 31231231, 6, '2021-04-21', 'EWFREWRW', 2147483647),
(57, 31231231, 6, '2021-04-21', 'EWFREWRW', 2147483647),
(58, 31231231, 6, '2021-04-21', 'EWFREWRW', 2147483647),
(59, 31231231, 6, '2021-04-21', 'EWFREWRW', 2147483647),
(60, 31231231, 6, '2021-04-21', 'EWFREWRW', 2147483647),
(61, 31231231, 6, '2021-04-21', 'REWRWE', 2147483647),
(62, 31231231, 6, '2021-04-21', 'REWRWE', 2147483647),
(63, 31231231, 6, '2021-04-21', 'REWRWE', 2147483647),
(64, 31231231, 6, '2021-04-21', 'REWRWE', 2147483647),
(65, 31232131, 7, '2021-04-21', 'EWDSRDWE', 2147483647),
(66, 31232131, 7, '2021-04-21', 'EWDSRDWE', 2147483647),
(67, 31232131, 6, '2021-04-21', 'EWDSRDWE', 2147483647),
(68, 31232131, 6, '2021-04-21', 'EWDSRDWE', 2147483647),
(69, 31232131, 3, '2021-04-21', 'EWDSRDWE', 2147483647),
(70, 31232131, 6, '2021-04-21', 'EWDSRDWE', 2147483647),
(71, 31232131, 7, '2021-04-21', 'EWDSRDWE', 2147483647),
(72, 32131231, 6, '2021-04-21', 'DFWSEDQW', 2147483647),
(73, 32131231, 7, '2021-04-21', 'DFWSEDQW', 2147483647),
(74, 32131231, 6, '2021-04-21', 'DFWSEDQW', 2147483647),
(75, 43213421, 7, '2021-04-21', 'EEWRF', 2132131231),
(76, 31231231, 6, '2021-04-21', 'EWDFWE', 1231231231),
(77, 23121312, 1, '2021-04-21', 'DWSWQ', 2147483647),
(78, 23121312, 3, '2021-04-21', 'DWSWQ', 2147483647),
(79, 23121312, 1, '2021-04-21', 'DWSWQ', 2147483647),
(80, 23121312, 3, '2021-04-21', 'DWSWQ', 2147483647),
(81, 23121312, 1, '2021-04-21', 'DWSWQ', 2147483647),
(82, 31231232, 6, '2021-04-21', 'FDSDSA', 2131232131),
(83, 31232132, 6, '2021-04-21', 'FSDFSDF', 2147483647),
(84, 31232132, 7, '2021-04-21', 'FSDFSDF', 2147483647),
(85, 31232132, 6, '2021-04-21', 'FSDFSDF', 2147483647),
(86, 31232132, 7, '2021-04-21', 'FSDFSDF', 2147483647),
(87, 31232132, 1, '2021-04-21', 'FSDFSDF', 2147483647),
(88, 31231231, 6, '2021-04-21', 'FSDFSDFS', 1231231231),
(89, 12312312, 6, '2021-04-22', 'DSADASDA', 2147483647),
(90, 12312312, 7, '2021-04-22', 'DSADASDA', 2147483647),
(91, 12312312, 6, '2021-04-22', 'DSADASDA', 2147483647),
(92, 12312312, 7, '2021-04-22', 'DSADASDA', 2147483647),
(93, 12312312, 6, '2021-04-22', 'DSADASDA', 2147483647),
(94, 12312312, 7, '2021-04-22', 'DSADASDA', 2147483647),
(95, 12312312, 1, '2021-04-22', 'DSADASDA', 2147483647),
(96, 12312312, 3, '2021-04-22', 'DSADASDA', 2147483647),
(97, 12312312, 1, '2021-04-22', 'DSADASDA', 2147483647),
(98, 31231231, 6, '2021-04-22', 'EWQRWRRE', 2147483647),
(99, 31231231, 7, '2021-04-22', 'EWQRWRRE', 2147483647),
(100, 31231231, 3, '2021-04-22', 'EWQRWRRE', 2147483647),
(101, 31231231, 1, '2021-04-22', 'EWQRWRRE', 2147483647),
(102, 31231231, 3, '2021-04-22', 'EWQRWRRE', 2147483647),
(103, 31231231, 7, '2021-04-22', 'EWQRWRRE', 2147483647),
(104, 31231231, 6, '2021-04-22', 'EWQRWRRE', 2147483647),
(105, 31231231, 7, '2021-04-22', 'EWQRWRRE', 2147483647),
(106, 31231231, 6, '2021-04-22', 'EWQRWRRE', 2147483647),
(107, 31231231, 6, '2021-04-22', 'FSDRFSDF', 2147483647),
(108, 31231231, 7, '2021-04-22', 'FSDRFSDF', 2147483647),
(109, 31231231, 6, '2021-04-22', 'FSDRFSDF', 2147483647),
(110, 31231231, 1, '2021-04-22', 'FSDRFSDF', 2147483647),
(111, 31231231, 3, '2021-04-22', 'FSDRFSDF', 2147483647),
(112, 31231231, 6, '2021-04-22', 'FSDRFSDF', 2147483647),
(113, 31231231, 7, '2021-04-22', 'FSDRFSDF', 2147483647),
(114, 31231231, 6, '2021-04-22', 'FSDRFSDF', 2147483647),
(115, 31231231, 7, '2021-04-22', 'FSDRFSDF', 2147483647),
(116, 31231231, 6, '2021-04-22', 'FSDRFSDF', 2147483647),
(117, 31231231, 7, '2021-04-22', 'FSDRFSDF', 2147483647),
(118, 13213123, 7, '2021-04-22', 'RFESRWER', 2147483647),
(119, 13213123, 6, '2021-04-22', 'RFESRWER', 2147483647),
(120, 13213123, 7, '2021-04-22', 'RFESRWER', 2147483647),
(121, 13213123, 6, '2021-04-22', 'RFESRWER', 2147483647),
(122, 13213123, 7, '2021-04-22', 'RFESRWER', 2147483647),
(123, 13213123, 6, '2021-04-22', 'RFESRWER', 2147483647),
(124, 13213123, 7, '2021-04-22', 'RFESRWER', 2147483647),
(125, 13213123, 6, '2021-04-22', 'RFESRWER', 2147483647),
(126, 13213123, 1, '2021-04-22', 'RFESRWER', 2147483647),
(127, 13213123, 3, '2021-04-22', 'RFESRWER', 2147483647),
(128, 13213123, 1, '2021-04-22', 'RFESRWER', 2147483647),
(129, 23132131, 6, '2021-04-22', 'FSADSDAS', 2147483647),
(130, 23132131, 7, '2021-04-22', 'FSADSDAS', 2147483647),
(131, 23132131, 6, '2021-04-22', 'FSADSDAS', 2147483647),
(132, 23132131, 7, '2021-04-22', 'FSADSDAS', 2147483647),
(133, 23132131, 6, '2021-04-22', 'FSADSDAS', 2147483647),
(134, 23132131, 7, '2021-04-22', 'FSADSDAS', 2147483647),
(135, 23132131, 1, '2021-04-22', 'FSADSDAS', 2147483647),
(136, 23132131, 3, '2021-04-22', 'FSADSDAS', 2147483647),
(137, 23132131, 1, '2021-04-22', 'FSADSDAS', 2147483647),
(138, 23132131, 3, '2021-04-22', 'FSADSDAS', 2147483647),
(139, 23132131, 6, '2021-04-22', 'FSADSDAS', 2147483647),
(140, 23132131, 7, '2021-04-22', 'FSADSDAS', 2147483647),
(141, 23132131, 6, '2021-04-22', 'FSADSDAS', 2147483647),
(142, 31231231, 6, '2021-04-22', 'FDWFEWFE', 1231231231),
(143, 31231231, 6, '2021-04-22', 'FDWFEWFE', 1231231231),
(144, 31231231, 6, '2021-04-22', 'FDWFEWFE', 1231231231),
(145, 31231231, 6, '2021-04-22', 'FDWFEWFE', 1231231231),
(146, 21312312, 6, '2021-04-22', 'FWERWERW', 1231231231),
(147, 21312312, 6, '2021-04-22', 'FWERWERW', 1231231231),
(148, 21312312, 6, '2021-04-22', 'FWERWERW', 1231231231),
(149, 21312312, 6, '2021-04-22', 'FWERWERW', 1231231231),
(150, 31231231, 6, '2021-04-22', 'FDSFSFSD', 2131231231),
(151, 31231231, 6, '2021-04-22', 'FDSFSFSD', 2131231231),
(152, 31231231, 6, '2021-04-22', 'FDSFSFSD', 2131231231),
(153, 42343432, 6, '2021-04-22', 'FDSFSDFS', 1231231231),
(154, 42343432, 6, '2021-04-22', 'FDSFSDFS', 1231231231),
(155, 42343432, 6, '2021-04-22', 'FDSFSDFS', 1231231231),
(156, 42343432, 6, '2021-04-22', 'FDSFSDFS', 1231231231),
(157, 42343432, 6, '2021-04-22', 'FDSFSDFS', 1231231231),
(158, 12312312, 6, '2021-04-22', 'ERFWERWE', 2147483647),
(159, 12312312, 7, '2021-04-22', 'ERFWERWE', 2147483647),
(160, 12312312, 6, '2021-04-22', 'ERFWERWE', 2147483647),
(161, 12312312, 7, '2021-04-22', 'ERFWERWE', 2147483647),
(162, 12312312, 6, '2021-04-22', 'ERFWERWE', 2147483647),
(163, 12312312, 7, '2021-04-22', 'ERFWERWE', 2147483647),
(164, 12312312, 6, '2021-04-22', 'ERFWERWE', 2147483647),
(165, 12312312, 7, '2021-04-22', 'ERFWERWE', 2147483647),
(166, 32133333, 6, '2021-04-22', 'EEEEEEEE', 2147483647),
(167, 32133333, 7, '2021-04-22', 'EEEEEEEE', 2147483647),
(168, 32133333, 6, '2021-04-22', 'EEEEEEEE', 2147483647),
(169, 32133333, 7, '2021-04-22', 'EEEEEEEE', 2147483647),
(170, 32133333, 6, '2021-04-22', 'EEEEEEEE', 2147483647),
(171, 32133333, 7, '2021-04-22', 'EEEEEEEE', 2147483647),
(172, 32133333, 6, '2021-04-22', 'EEEEEEEE', 2147483647),
(173, 32133333, 7, '2021-04-22', 'EEEEEEEE', 2147483647),
(174, 32133333, 6, '2021-04-22', 'EEEEEEEE', 2147483647),
(175, 31231231, 6, '2021-04-22', 'DFSADASD', 2147483647),
(176, 31231231, 6, '2021-04-22', 'DFSADASD', 2147483647),
(177, 31231231, 6, '2021-04-22', 'DFSADASD', 2147483647),
(178, 31231231, 6, '2021-04-22', 'DFSADASD', 2147483647),
(179, 31231231, 3, '2021-04-22', 'DFSADASD', 2147483647),
(180, 31231231, 1, '2021-04-22', 'DFSADASD', 2147483647),
(181, 32131231, 7, '2021-04-22', 'EWRWERWE', 2131231231),
(182, 32131231, 6, '2021-04-22', 'EWRWERWE', 2131231231),
(183, 32131231, 7, '2021-04-22', 'EWRWERWE', 2131231231),
(184, 32131231, 6, '2021-04-22', 'EWRWERWE', 2131231231),
(185, 32131231, 7, '2021-04-22', 'EWRWERWE', 2131231231),
(186, 32131231, 6, '2021-04-22', 'EWRWERWE', 2131231231),
(187, 32131231, 6, '2021-04-22', 'EWRWERWE', 2131231231),
(188, 43123123, 6, '2021-04-22', 'DSADASDA', 2147483647),
(189, 43123123, 7, '2021-04-22', 'DSADASDA', 2147483647),
(190, 43123123, 6, '2021-04-22', 'DSADASDA', 2147483647),
(191, 43123123, 7, '2021-04-22', 'DSADASDA', 2147483647),
(192, 43123123, 3, '2021-04-22', 'DSADASDA', 2147483647),
(193, 43123123, 1, '2021-04-22', 'DSADASDA', 2147483647),
(194, 43123123, 1, '2021-04-22', 'DSADASDA', 2147483647),
(195, 43123123, 6, '2021-04-22', 'DSADASDA', 2147483647),
(196, 43123123, 7, '2021-04-22', 'DSADASDA', 2147483647),
(197, 43123123, 6, '2021-04-22', 'DSADASDA', 2147483647),
(198, 43123123, 7, '2021-04-22', 'DSADASDA', 2147483647),
(199, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(200, 32131231, 7, '2021-04-22', 'ESDAWADA', 2131231231),
(201, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(202, 32131231, 7, '2021-04-22', 'ESDAWADA', 2131231231),
(203, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(204, 32131231, 7, '2021-04-22', 'ESDAWADA', 2131231231),
(205, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(206, 32131231, 7, '2021-04-22', 'ESDAWADA', 2131231231),
(207, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(208, 32131231, 7, '2021-04-22', 'ESDAWADA', 2131231231),
(209, 32131231, 6, '2021-04-22', 'ESDAWADA', 2131231231),
(210, 32131231, 1, '2021-04-22', 'ESDAWADA', 2131231231),
(211, 11111111, 6, '2021-04-22', 'DASDASDA', 2147483647),
(212, 32131231, 7, '2021-04-22', 'DWEDWEED', 2147483647),
(213, 12312312, 6, '2021-04-22', 'DASDAWDA', 2147483647),
(214, 12312312, 6, '2021-04-22', 'DASDAWDA', 2147483647),
(215, 42343242, 6, '2021-04-22', 'RETERTGE', 1111111111),
(216, 42343242, 6, '2021-04-22', 'RETERTGE', 1111111111),
(217, 31231231, 6, '2021-04-22', 'BOCA', 1323232323),
(218, 31231231, 6, '2021-04-22', 'BOCA', 1323232323);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `consola`
--
ALTER TABLE `consola`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `juego`
--
ALTER TABLE `juego`
  ADD PRIMARY KEY (`id_juego`),
  ADD KEY `id_consola` (`id_consola`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id_venta`),
  ADD KEY `id_juego` (`id_juego`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `consola`
--
ALTER TABLE `consola`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `juego`
--
ALTER TABLE `juego`
  MODIFY `id_juego` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id_venta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=219;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `juego`
--
ALTER TABLE `juego`
  ADD CONSTRAINT `juego_ibfk_1` FOREIGN KEY (`id_consola`) REFERENCES `consola` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`id_juego`) REFERENCES `juego` (`id_juego`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
