-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 13, 2018 at 08:11 PM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `acomes`
--

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `ID_Course` int(10) NOT NULL,
  `Course_Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`ID_Course`, `Course_Name`) VALUES
(1, 'Pemrograman Platform Khusus'),
(2, 'Matematika');

-- --------------------------------------------------------

--
-- Table structure for table `forgot_student`
--

CREATE TABLE `forgot_student` (
  `NIS` varchar(25) NOT NULL,
  `Security_Question` varchar(200) NOT NULL,
  `Answer` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `forgot_student`
--

INSERT INTO `forgot_student` (`NIS`, `Security_Question`, `Answer`) VALUES
('165150', 'Siapa nama Ayahmu?', 'dede'),
('1234455', 'Siapa nama Kucingmu?', 'dede'),
('16515', 'Siapa nama Kucingmu?', 'b'),
('12313212', 'Siapa nama Kucingmu?', 'mas bron');

-- --------------------------------------------------------

--
-- Table structure for table `forgot_teacher`
--

CREATE TABLE `forgot_teacher` (
  `NIK` varchar(25) NOT NULL,
  `Security_Question` varchar(200) NOT NULL,
  `Answer` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `forgot_teacher`
--

INSERT INTO `forgot_teacher` (`NIK`, `Security_Question`, `Answer`) VALUES
('09812', 'Siapa nama Ayahmu?', 'budi'),
('123', 'Siapa nama Kucingmu?', 'masbron'),
('a', 'Siapa nama Kucingmu?', 'a');

-- --------------------------------------------------------

--
-- Table structure for table `homework`
--

CREATE TABLE `homework` (
  `ID_Homework` int(10) NOT NULL,
  `ID_Schedule` int(10) NOT NULL,
  `NIS` varchar(25) NOT NULL,
  `NIK` varchar(25) NOT NULL,
  `Notes` varchar(200) NOT NULL,
  `Deadline` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `ID_Schedule` int(10) NOT NULL,
  `Day` varchar(6) NOT NULL,
  `Time` varchar(5) NOT NULL,
  `Room` varchar(15) NOT NULL,
  `Course` varchar(100) NOT NULL,
  `Teacher` varchar(100) NOT NULL,
  `ID_Course` int(10) NOT NULL,
  `NIK` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`ID_Schedule`, `Day`, `Time`, `Room`, `Course`, `Teacher`, `ID_Course`, `NIK`) VALUES
(1, 'Senin', '10:30', 'Room 1', 'Matematika', 'Zakia', 2, 'a');

-- --------------------------------------------------------

--
-- Table structure for table `scores`
--

CREATE TABLE `scores` (
  `Score` float NOT NULL,
  `NIK` varchar(25) NOT NULL,
  `NIS` varchar(25) NOT NULL,
  `ID_Course` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `NIS` varchar(25) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(25) NOT NULL,
  `Password` varchar(16) NOT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Username` varchar(20) NOT NULL,  `Theme` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`NIS`, `Name`, `Email`, `Password`, `Phone`, `Username`,`Theme`) VALUES
('12313212', 'apa yayay', 'asz', 'aa', '098775', '',1),
('1234455', 'fauza', 'fauza@gmail.com', '1234', '09821723', '',1),
('16515', 'Lusiyana', 'b', '', '08', 'a',1),
('165150', 'FAIZAL BACHTIAR', 'faizal123@gmail.com', 'deni', '098217', '',1);

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

CREATE TABLE `teacher` (
  `NIK` varchar(25) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Username` varchar(20) NOT NULL,
  `Email` varchar(20) NOT NULL,
  `Password` varchar(16) NOT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `jk` varchar(10) NOT NULL,  `Theme` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`NIK`, `Name`, `Username`, `Email`, `Password`, `Phone`, `jk`, `Theme`) VALUES
('09812', 'deni', 'awfiadj', 'deni13@gmail.com', '1234', '091872', 'Male', 1),
('123', 'aaaaa', 'asas', 'aa', 'a', '234234', 'Female',1),
('a', 'a', 'a', 'a', 'a', 'a', 'Female',1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`ID_Course`);

--
-- Indexes for table `forgot_student`
--
ALTER TABLE `forgot_student`
  ADD KEY `NIS` (`NIS`);

--
-- Indexes for table `forgot_teacher`
--
ALTER TABLE `forgot_teacher`
  ADD KEY `NIK` (`NIK`);

--
-- Indexes for table `homework`
--
ALTER TABLE `homework`
  ADD PRIMARY KEY (`ID_Homework`),
  ADD KEY `NIS` (`NIS`),
  ADD KEY `ID_Schedule` (`ID_Schedule`),
  ADD KEY `NIK` (`NIK`);

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`ID_Schedule`),
  ADD UNIQUE KEY `ID_Course` (`ID_Course`),
  ADD KEY `NIK` (`NIK`);

--
-- Indexes for table `scores`
--
ALTER TABLE `scores`
  ADD KEY `ID_Course` (`ID_Course`),
  ADD KEY `NIK` (`NIK`),
  ADD KEY `NIS` (`NIS`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`NIS`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `teacher`
--
ALTER TABLE `teacher`
  ADD PRIMARY KEY (`NIK`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `ID_Course` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `schedule`
--
ALTER TABLE `schedule`
  MODIFY `ID_Schedule` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `forgot_student`
--
ALTER TABLE `forgot_student`
  ADD CONSTRAINT `forgot_student_ibfk_1` FOREIGN KEY (`NIS`) REFERENCES `student` (`NIS`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `forgot_teacher`
--
ALTER TABLE `forgot_teacher`
  ADD CONSTRAINT `forgot_teacher_ibfk_1` FOREIGN KEY (`NIK`) REFERENCES `teacher` (`NIK`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `homework`
--
ALTER TABLE `homework`
  ADD CONSTRAINT `homework_ibfk_1` FOREIGN KEY (`NIS`) REFERENCES `student` (`NIS`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `homework_ibfk_2` FOREIGN KEY (`ID_Schedule`) REFERENCES `schedule` (`ID_Schedule`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `homework_ibfk_3` FOREIGN KEY (`NIK`) REFERENCES `teacher` (`NIK`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `schedule`
--
ALTER TABLE `schedule`
  ADD CONSTRAINT `schedule_ibfk_1` FOREIGN KEY (`ID_Course`) REFERENCES `course` (`ID_Course`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `schedule_ibfk_2` FOREIGN KEY (`NIK`) REFERENCES `teacher` (`NIK`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `schedule_ibfk_3` FOREIGN KEY (`NIK`) REFERENCES `teacher` (`NIK`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `scores`
--
ALTER TABLE `scores`
  ADD CONSTRAINT `scores_ibfk_1` FOREIGN KEY (`ID_Course`) REFERENCES `course` (`ID_Course`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `scores_ibfk_2` FOREIGN KEY (`NIK`) REFERENCES `teacher` (`NIK`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `scores_ibfk_3` FOREIGN KEY (`NIS`) REFERENCES `student` (`NIS`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
