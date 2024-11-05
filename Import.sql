-- If you like to follow the database so much, here's an empty version that creates the table for your usage.
-- The official sql file is not for public viewing. Sorry!

DROP DATABASE IF EXISTS `aerthius_world`;

CREATE DATABASE `aerthius_world`;

USE `aerthius_world`;

CREATE TABLE `players` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    race VARCHAR(100) NOT NULL,
    alignment VARCHAR(20) NOT NULL,
    class VARCHAR(20) NOT NULL,
    level INT(2) NOT NULL,
    special_rulings VARCHAR(500) NOT NULL
);

CREATE TABLE `realms` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    realm_name VARCHAR(100) NOT NULL,
    description VARCHAR(500) NOT NULL
)