-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2023 at 04:11 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `librarymanagementsystem`
--
CREATE DATABASE IF NOT EXISTS `librarymanagementsystem` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `librarymanagementsystem`;

-- --------------------------------------------------------

--
-- Table structure for table `cabe_book`
--

DROP TABLE IF EXISTS `cabe_book`;
CREATE TABLE IF NOT EXISTS `cabe_book` (
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cabe_book`
--

INSERT INTO `cabe_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('1', 'Fundamentals of accountancy, business & management 1', 'Millan, Zeus Vernon B.', 'Norma Dy Lopez-Mariano, Ph. D., FRIEDr', '10'),
('10', 'Bureaucrats in business : the economics and politics of government ownership', 'World Bank', 'Oxford ; New York : Oxford University Press, c1995', '10'),
('2', 'Notes in business law : for accountancy students and CPA reviewees', 'Fidelito R. Soriano', 'Manila : GIC Enterprises & Co., Inc., c2019.', '10'),
('3', 'Advanced accounting', 'Joe B. Hoyle, Thomas F. Schaefer, Timothy S. Doupnik', 'New York : McGraw-Hill Education, 2015.', '10'),
('4', 'Integrated cost accounting : principles and applications', 'Marlon O. Flores', 'Manila : Rex Bookstore, c2016.', '10'),
('5', 'Financial and managerial accounting', 'Carl S. Warren, James M. Reeve, Jonathan E. Duchac', 'Manila : Rex BookMason, Ohio : South-Western Cengage Learning, c2018.store, c2016.', '10'),
('6', 'Business mathematics', 'Laurentina P. Calmorin', 'Mandaluyong City : National Book Store, c2006', '10'),
('7', 'Accounting : an international perspective : a supplement to introductory accounting textbooks', 'Gerhard G. Mueller', 'Burr Ridge, Illinois : Irwin', '10'),
('8', 'Managerial economics : foundations of business analysis and strategy   ', 'Christopher R. Thomas, S. Charles Maurice', 'New York : McGraw-Hill/Irwin, c2016', '10'),
('9', 'Essentials of calculus : As applied to business and economics', 'Joel T. Torrecampo, Ferdinand P. Nocon, Nestor T. Torrecampo, Wilfredo B. Daguia, Pete P. Nocon.', 'Quezon City : Katha Publishing Co., Inc, c2001', '10');

-- --------------------------------------------------------

--
-- Table structure for table `cabe_borrowed_books`
--

DROP TABLE IF EXISTS `cabe_borrowed_books`;
CREATE TABLE IF NOT EXISTS `cabe_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cabe_returned_books`
--

DROP TABLE IF EXISTS `cabe_returned_books`;
CREATE TABLE IF NOT EXISTS `cabe_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cas_book`
--

DROP TABLE IF EXISTS `cas_book`;
CREATE TABLE IF NOT EXISTS `cas_book` (
  `Book_ID` varchar(100) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cas_book`
--

INSERT INTO `cas_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('2', 'Arts management : an entrepreneurial approach', 'Carla Stalling Walter', 'Routledge, c2015 : New York', '10'),
('3', 'The arts in education : an introduction to aesthetics, theory and pedagogy', 'Mike Fleming', 'Milton Park, Abingdon, Oxon ; New York, NY : Routledge, c2012', '10'),
('4', 'The arts and sciences of criticism', 'David Fuller and Patricia Waugh', 'Oxford ; New York : Oxford University Press, [1999]', '10'),
('5', 'Science & society : scientific thought and education for the 21st century', 'Peter A. Daempfle, PhD, State University of New York -- Delhi.', 'Jones and Bartlett Publishers, c2014 : Burlington, MA ', '10'),
('6', 'Science technology, and society', 'Daniel Joseph McNamara, Vida Mia Valverde, Ramon Beleno III', ' C & E Publishing, Inc., c2018 : Quezon City', '10'),
('7', 'The art and science of brief psychotherapies : an illustrated guide', ' Mantosh J. Dewan, Brett N. Steenbarger, Roger P. Greenberg.', ' American Psychiatric Pub., [2012] : Arlington, VA', '10'),
('8', ' The art and science of leadership', 'Afsaneh Nahavandi', 'Pearson Prentice Hall, c2009 : Upper Saddle River, New Jersey', '10'),
('9', 'Culinology : the intersection of culinary art and food science', 'J. Jeffrey Cousminer', ' Wiley, c2017 : Hoboken, New Jersey ', '10');

-- --------------------------------------------------------

--
-- Table structure for table `cas_borrowed_books`
--

DROP TABLE IF EXISTS `cas_borrowed_books`;
CREATE TABLE IF NOT EXISTS `cas_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cas_returned_books`
--

DROP TABLE IF EXISTS `cas_returned_books`;
CREATE TABLE IF NOT EXISTS `cas_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cics_book`
--

DROP TABLE IF EXISTS `cics_book`;
CREATE TABLE IF NOT EXISTS `cics_book` (
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cics_book`
--

INSERT INTO `cics_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('1', 'Information Technology Design and Applications', 'Dr. Javed Khan', 'Delhi, India : Manglam Publications, 2015 copyright', '10'),
('10', 'Object oriented approach using C++ : (for UG & PG students of engineering, computer science, information technology, ECE , EEE, E & I and ICT )', 'D.P. Kothari, V. Subashri, Shriram K. Vasudevan, T. Senthilkumar ', 'New Delhi : Rajan Jain , c2013', '10'),
('2', 'Ethics in information technology', 'George W. Reynolds', 'Boston : Cengage Learning, c2015', '10'),
('3', 'Human resource information systems: basics, applications, and future directions', 'Michael J. Kavanagh, Mohan Thite, and Richard D. Johnson', 'Singapore : SAGE Publications, Inc., c2012', '10'),
('4', 'Information technology project management', 'Kathy Schalbe', 'Boston, USA : Cengage Learning, Inc, 2019', '10'),
('5', 'The world of information technology', 'Kenneth J. Baldauf and Ralph M. Stair.', 'Singapore : Cengage Learning Asia Pte Ltd., c2009', '10'),
('6', 'Cloud Computing for Science and Engineering', 'Ian Foster.,and Dennis B. Gannon', 'Cambridge,Massachusetts The MIT Press., 2017', '10'),
('7', 'The world of information technology', 'Dauksza, Pauline', 'United States of America : Arcler Press, 2015 copyright', '10'),
('8', 'Dictionary of Computer Science and Internet', 'Robert Wharton', 'New Delhi, India : Goodwill Publishing House', '10'),
('9', 'Theory, practice and techniques in computer science', '3G E-Learning', 'USA : 3G E-Learning', '10');

-- --------------------------------------------------------

--
-- Table structure for table `cics_borrowed_books`
--

DROP TABLE IF EXISTS `cics_borrowed_books`;
CREATE TABLE IF NOT EXISTS `cics_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cics_returned_books`
--

DROP TABLE IF EXISTS `cics_returned_books`;
CREATE TABLE IF NOT EXISTS `cics_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cit_book`
--

DROP TABLE IF EXISTS `cit_book`;
CREATE TABLE IF NOT EXISTS `cit_book` (
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cit_book`
--

INSERT INTO `cit_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('1', 'Characterization of nanocomposites: technology and industrial applications', 'Frank Abdi/ Mohit Garg', 'Singapore : Pan Stanford Publishing Pte. Ltd., c2017', '10'),
('10', 'Mechanics of machinery', 'Mahmoud A. Mostafa', 'Boca Raton, FL : CRC Press, 2013', '10'),
('2', 'Industrial fishery technology', 'Stansby, Maurice E', 'New York : Robert E. Krieger Publishing Company', '10'),
('3', 'Industrial fishery technology', 'Vine, Michelle', 'New York, NY : Willford Press, 2016 copyright', '10'),
('4', 'The science and technology of industrial water treatment', 'Zahid Amjad', 'Boca Raton, FL : CRC Press ; London : IWA Pub., c2010', '10'),
('5', 'Communication networks in automation: : bus systems, industrial security and network design', 'Ricarda Koch and Ralph Luefner', 'Germany : Publicis Pixelpark, 2019', '10'),
('6', 'Industrial robotics', 'Keith Dinwiddie', 'Boston : Cengage Learning', '10'),
('7', 'Technology education in the Philippines', 'Fedeserio C. Camarao', 'Metro Manila, Philippines : National Book Store, c1991', '10'),
('8', 'Industrial electronic circuits and applications', 'R. Ralph Benedict, Nathan Weiner', 'Englewood Cliffs, N.J. : Prentice-Hall, c1965', '10'),
('9', ' Robot technology fundamentals', 'James G. Keramas', 'Albany, N.Y. : Delmar Publishers, c1999', '10');

-- --------------------------------------------------------

--
-- Table structure for table `cit_borrowed_books`
--

DROP TABLE IF EXISTS `cit_borrowed_books`;
CREATE TABLE IF NOT EXISTS `cit_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `BOOK_NAME` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cit_returned_books`
--

DROP TABLE IF EXISTS `cit_returned_books`;
CREATE TABLE IF NOT EXISTS `cit_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `coe_book`
--

DROP TABLE IF EXISTS `coe_book`;
CREATE TABLE IF NOT EXISTS `coe_book` (
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `coe_book`
--

INSERT INTO `coe_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('1', 'Engineering: A Beginner\'s Guide', 'Natasha McCarthy', 'Oneworld Publications', '10'),
('10', 'Machine Learning: A Probabilistic Perspective', 'Kevin P. Murphy', 'The MIT Press', '10'),
('2', 'The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution', 'Walter Isaacson', 'Simon & Schuster', '10'),
('3', 'Structures: Or Why Things Don\'t Fall Down', 'J.E. Gordon', 'Da Capo Press', '10'),
('4', 'The Design of Everyday Things', 'Don Norman', 'Basic Books', '10'),
('5', 'The Lean Startup: How Today\'s Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses', ' Eric Ries', 'Crown Business', '10'),
('6', 'Introduction to Robotics: Mechanics and Control', 'John J. Craig', 'Pearson', '10'),
('7', 'Fundamentals of Electric Circuits', 'Charles K. Alexander and Matthew N.O. Sadiku', 'McGraw-Hill Education', '10'),
('8', 'Materials Science and Engineering: An Introduction', 'William D. Callister Jr. and David G. Rethwisch', 'Wiley', '10'),
('9', 'Introduction to Chemical Engineering: Tools for Today and Tomorrow', 'Michael B. Cutlip and Mordechai Shacham', 'Prentice Hall', '10');

-- --------------------------------------------------------

--
-- Table structure for table `coe_borrowed_books`
--

DROP TABLE IF EXISTS `coe_borrowed_books`;
CREATE TABLE IF NOT EXISTS `coe_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `coe_returned_books`
--

DROP TABLE IF EXISTS `coe_returned_books`;
CREATE TABLE IF NOT EXISTS `coe_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cte_book`
--

DROP TABLE IF EXISTS `cte_book`;
CREATE TABLE IF NOT EXISTS `cte_book` (
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Quantity` varchar(255) NOT NULL,
  PRIMARY KEY (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cte_book`
--

INSERT INTO `cte_book` (`Book_ID`, `Book_Name`, `Author`, `Publisher`, `Quantity`) VALUES
('1', 'Teaching and Learning in CTE: Foundation', 'Norman E. Gaines', 'Pearson', '10'),
('10', 'Foundations of Career and Technical Education', 'Howard R. D. Gordon', 'Routledge', '10'),
('2', 'Introduction to Career and Technical Education', 'Dr. Catherine A. Hansman and Dr. Karla R. Taylor', 'Cengage Learning', '10'),
('3', 'Assessment in Career Guidance and Career Education', 'Phil Jarvis and Prue Huddleston', 'Routledge', '10'),
('4', 'Transforming Career and  Technical Education: A Comprehensive Framework for Effective Instruction', 'Thomas Lovitt, Mary Ann Paciello, et al', 'Routledge', '10'),
('5', 'The Role of CTE in College and Career Readiness', 'Kimberly Green', 'Rowman & Littlefield Publishers', '10'),
('6', 'Teaching Career Development: A Primer for Instructors and Presenters', 'Kari F. Henquinet', 'National Career Development Association', '10'),
('7', 'Career and Technical Education in the United States', 'Thomas R. Bailey, Katherine L. Hughes, and David J. Chard ', 'Harvard Education Press', '10'),
('8', 'Teaching CTE: Tips for Success in the Classroom', 'Michael S. Hartoonian and Stephanie J. Jones', 'Goodheart-Willcox Publisher', '10'),
('9', 'Exploring Career and Technical Education', 'Ralph G. Leverett and John M. Leverett', 'Pearson', '10');

-- --------------------------------------------------------

--
-- Table structure for table `cte_borrowed_books`
--

DROP TABLE IF EXISTS `cte_borrowed_books`;
CREATE TABLE IF NOT EXISTS `cte_borrowed_books` (
  `Borrowed_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Borrowed_Date` datetime NOT NULL,
  PRIMARY KEY (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cte_returned_books`
--

DROP TABLE IF EXISTS `cte_returned_books`;
CREATE TABLE IF NOT EXISTS `cte_returned_books` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Borrowed_ID` int(11) NOT NULL,
  `Student_ID` varchar(255) NOT NULL,
  `Book_ID` varchar(255) NOT NULL,
  `Book_Name` varchar(255) NOT NULL,
  `Returned_Date` datetime NOT NULL,
  PRIMARY KEY (`Return_ID`),
  KEY `Borrowed_ID` (`Borrowed_ID`),
  KEY `Book_ID` (`Book_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `librarian`
--

DROP TABLE IF EXISTS `librarian`;
CREATE TABLE IF NOT EXISTS `librarian` (
  `LibrarianID` int(11) NOT NULL AUTO_INCREMENT,
  `Librarian_UserName` varchar(255) NOT NULL,
  `LibrarianName` varchar(255) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `PhoneNumber` varchar(15) NOT NULL,
  PRIMARY KEY (`LibrarianID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `librarian`
--

INSERT INTO `librarian` (`LibrarianID`, `Librarian_UserName`, `LibrarianName`, `Password`, `PhoneNumber`) VALUES
(1, 'Eli_Admin', 'Eli Amazing', 'ELIZAJAM', '0123456');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `Student_ID` int(11) NOT NULL AUTO_INCREMENT,
  `SRCode` varchar(20) NOT NULL,
  `StudentName` varchar(255) NOT NULL,
  `Department` varchar(50) NOT NULL,
  `StudentPhoneNumber` varchar(15) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Password` varchar(50) NOT NULL,
  PRIMARY KEY (`Student_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`Student_ID`, `SRCode`, `StudentName`, `Department`, `StudentPhoneNumber`, `Address`, `Password`) VALUES
(2, '22-13456', 'NEIL', 'CICS', '1234567', '', ''),
(45, '22-31829', 'Eliza Jameah Danlag', 'CICS', '123456789', 'LIPA CITY', 'ELIPOT'),
(46, '22-12345', 'ASDF', 'CIT', '12345678', 'LIPA CITY ', '123456'),
(54, 'zxc', 'zxc', 'zxc', 'zxc', 'zxc', 'zxc'),
(58, '123456', '123456', '123456', '123456', '123456', '123456'),
(59, 'zxcv', 'zxcv', 'zxcv', 'zxcv', 'zxcv', 'zxcv');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cabe_borrowed_books`
--
ALTER TABLE `cabe_borrowed_books`
  ADD CONSTRAINT `cabe_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `cabe_book` (`Book_ID`);

--
-- Constraints for table `cabe_returned_books`
--
ALTER TABLE `cabe_returned_books`
  ADD CONSTRAINT `cabe_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `cabe_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `cabe_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `cabe_book` (`Book_ID`);

--
-- Constraints for table `cas_borrowed_books`
--
ALTER TABLE `cas_borrowed_books`
  ADD CONSTRAINT `cas_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `cas_book` (`Book_ID`);

--
-- Constraints for table `cas_returned_books`
--
ALTER TABLE `cas_returned_books`
  ADD CONSTRAINT `cas_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `cas_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `cas_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `cas_book` (`Book_ID`);

--
-- Constraints for table `cics_borrowed_books`
--
ALTER TABLE `cics_borrowed_books`
  ADD CONSTRAINT `cics_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `cics_book` (`Book_ID`);

--
-- Constraints for table `cics_returned_books`
--
ALTER TABLE `cics_returned_books`
  ADD CONSTRAINT `cics_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `cics_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `cics_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `cics_book` (`Book_ID`);

--
-- Constraints for table `cit_borrowed_books`
--
ALTER TABLE `cit_borrowed_books`
  ADD CONSTRAINT `cit_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `cit_book` (`Book_ID`);

--
-- Constraints for table `cit_returned_books`
--
ALTER TABLE `cit_returned_books`
  ADD CONSTRAINT `cit_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `cit_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `cit_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `cit_book` (`Book_ID`);

--
-- Constraints for table `coe_borrowed_books`
--
ALTER TABLE `coe_borrowed_books`
  ADD CONSTRAINT `coe_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `coe_book` (`Book_ID`);

--
-- Constraints for table `coe_returned_books`
--
ALTER TABLE `coe_returned_books`
  ADD CONSTRAINT `coe_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `coe_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `coe_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `coe_book` (`Book_ID`);

--
-- Constraints for table `cte_borrowed_books`
--
ALTER TABLE `cte_borrowed_books`
  ADD CONSTRAINT `cte_borrowed_books_ibfk_1` FOREIGN KEY (`Book_ID`) REFERENCES `cte_book` (`Book_ID`);

--
-- Constraints for table `cte_returned_books`
--
ALTER TABLE `cte_returned_books`
  ADD CONSTRAINT `cte_returned_books_ibfk_1` FOREIGN KEY (`Borrowed_ID`) REFERENCES `cte_borrowed_books` (`Borrowed_ID`),
  ADD CONSTRAINT `cte_returned_books_ibfk_2` FOREIGN KEY (`Book_ID`) REFERENCES `cte_book` (`Book_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
