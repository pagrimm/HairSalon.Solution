# Eau Claire's Salon
**Weekly Independent Project for Epicodus**  
**By Peter Grimm, 07.31.2020**

## Description

Weekly project independent for Epicodus, an MVC web application to track stylists and their clients for a Salon. Designed to showcase my knowledge and skills with MySQL and the Entity Framework.

## Specifications
User Stories
* As the salon owner, I need to be able to see a list of all stylists.
* As the salon owner, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As the salon owner, I need to add new stylists to our system when they are hired.
* As the salon owner, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

## Setup/Installation Requirements
* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* Install MySQL and set the system path, more information on how to do that can be found here: https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql
* Run MySQL by entering `mysql -uroot -pepicodus` in the terminal
* Enter the following commands to create the necessary database and tables:
```
DROP DATABASE IF EXISTS `best_restaurants`;
CREATE DATABASE `best_restaurants`;
USE DATABASE `best_restaurants`;
CREATE TABLE `cuisines` (
  `CuisineId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CuisineId`)
);
CREATE TABLE `restaurants` (
  `RestaurantId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `CuisineId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`RestaurantId`)
);
CREATE TABLE `reviews` (
  `ReviewId` int NOT NULL AUTO_INCREMENT,
  `ReviewerName` varchar(255) DEFAULT NULL,
  `ReviewText` varchar(255) DEFAULT NULL,
  `Rating` int NOT NULL DEFAULT '0',
  `RestaurantId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`ReviewId`)
);
```
* Clone the GitHub repository by running `git clone https://github.com/pagrimm/BestRestaurants.Solution.git` in the terminal
* Navigate to the newly created `BestRestaurants.Solution` folder
* Navigate to the `BestRestaurants` subfolder and run `dotnet restore`
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser

## Technologies Used

C#  
.NET Core 2.2  
ASP.NET Core MVC
Entity Framework Core 2.2.6 

## Legal

Copyright (c) 2020, Peter Grimm  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) This software is licensed under the MIT license.