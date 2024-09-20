using System.Collections.Generic;
using System.Text.Unicode;

--phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
--Host: localhost: 8889
-- Tempo de geração: 20 / 09 / 2024 às 16:42
-- Versão do servidor: 5.7.39
-- Versão do PHP: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */
;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */
;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */
;
/*!40101 SET NAMES utf8mb4 */
;

--
--Banco de dados: `inovamobil`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `uuid` varchar(100) NOT NULL,
  `name` varchar(300) NOT NULL,
  `email` varchar(200) NOT NULL,
  `documentType` varchar(4) NOT NULL,
  `document` varchar(50) NOT NULL,
  `areacode` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

--
--Despejando dados para a tabela `client`
--

INSERT INTO `client` (`id`, `uuid`, `name`, `email`, `documentType`, `document`, `areacode`, `number`, `status`) VALUES
(1, '0362e4d7e5f64369a47da6a748ac5698', 'string', 'string', 'cpf', 'string', 0, 0, 0),
(5, '46f1eb1db4164591bbb8efbc750f5149', 'Thiago', 'thiago@live.com', 'CPF', '43207064709', 11, 984331513, 1),
(6, '5eaab7370bf84ed9bc682ec08fa69f0f', 'Bruno Muniz', 'bgmuniz@live.com', 'CPF', '3207301831', 11, 984311412, 1);

----------------------------------------------------------

--
--Estrutura para tabela `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `uuid` varchar(100) NOT NULL,
  `name` varchar(300) NOT NULL,
  `batery` double NOT NULL,
  `image` longtext NOT NULL,
  `status` enum('livre', 'alugado', 'manutencao') NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

--
--Despejando dados para a tabela `products`
--

INSERT INTO `products` (`id`, `uuid`, `name`, `batery`, `image`, `status`) VALUES
(3, 'd00539a958eb4532974a12f7a668bb03', 'Monociclo 2', 100, '', 'alugado');

----------------------------------------------------------

--
--Estrutura para tabela `sales`
--

CREATE TABLE `sales` (
  `id` int(11) NOT NULL,
  `id_client` varchar(100) NOT NULL,
  `id_product` varchar(100) NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

--
--Despejando dados para a tabela `sales`
--

INSERT INTO `sales` (`id`, `id_client`, `id_product`) VALUES
(8, '46f1eb1db4164591bbb8efbc750f5149', 'd00539a958eb4532974a12f7a668bb03'),
(9, 'mocked-client-id-123', 'd00539a958eb4532974a12f7a668bb03'),
(10, 'mocked-client-id-123', 'd00539a958eb4532974a12f7a668bb03'),
(11, 'mocked-client-id-123', 'd00539a958eb4532974a12f7a668bb03');

--
--Índices para tabelas despejadas
--

--
-- Índices de tabela `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`);

--
--Índices de tabela `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
--Índices de tabela `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`);

--
--AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 7;

--
--AUTO_INCREMENT de tabela `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 4;

--
--AUTO_INCREMENT de tabela `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */
;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */
;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */
;
