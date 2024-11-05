-- If you like to follow the database so much, here's an empty version that creates the table for your usage.
-- The official sql file is not for public viewing. Sorry!

DROP DATABASE IF EXISTS `aerthius_world`;

CREATE DATABASE `aerthius_world`;

USE `aerthius_world`;

CREATE TABLE `players` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    race VARCHAR(100) NOT NULL,
    alignment INT NOT NULL,
    class VARCHAR(20) NOT NULL,
    level INT(2) NOT NULL,
    special_rulings VARCHAR(500) NOT NULL
);

CREATE TABLE `realms` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    realm_name VARCHAR(100) NOT NULL,
    description VARCHAR(500) NOT NULL
);

CREATE TABLE `locations` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    location_name VARCHAR(200) NOT NULL,
    description VARCHAR(200) NOT NULL,
    governing_body INT NOT NULL,
    realm INT NOT NULL
);

CREATE TABLE `leonarian_titles` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    title VARCHAR (100) NOT NULL,
    translation VARCHAR(100) NOT NULL,
    description VARCHAR(500) NOT NULL
);

CREATE TABLE `alignments` (
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    alignment VARCHAR(20) NOT NULL
);

INSERT INTO `alignments` (alignment) VALUES 
("Lawful Good"), ("Neutral Good"), ("Chaotic Good"), ("Lawful Neutral"), ("True Neutral"), 
("Chaotic Neutral"), ("Lawful Evil"), ("Neutral Evil"), ("Chaotic Evil");

ALTER TABLE `players` ADD CONSTRAINT (`alignment`) FOREIGN KEY (alignment) REFERENCES alignments(id);