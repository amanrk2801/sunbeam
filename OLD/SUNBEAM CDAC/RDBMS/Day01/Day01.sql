-- Login to mysql
mysql -u root -p

-- to display all the databases
SHOW DATABASES;

-- to explore the database first we have to use the database
USE mobilesdb;

-- to display all the tables from the database
SHOW TABLES;

-- Create a database called as dbda_db;
CREATE DATABASE dbda_db;

USE dbda_db

-- create a table student with columns rollno and name
CREATE TABLE student(rollno INT, name CHAR(15));

-- to display the logged in user
SELECT USER();

-- to display the database that is currently in use
SELECT DATABASE();

CREATE TABLE temp(c1 CHAR(4),c2 VARCHAR(4),c3 TEXT(4));

INSERT INTO temp VALUES("ab","ab","ab"); --OK
INSERT INTO temp VALUES("abc","abc","abc"); --OK
INSERT INTO temp VALUES("abcd","abcd","abcd"); --OK

INSERT INTO temp VALUES("abcde","abcde","abcde"); --NOT OK
-- Data too long for c1

INSERT INTO temp VALUES("abcd","abcde","abcde"); --NOT OK
-- Data too long for c2

INSERT INTO temp VALUES("abcd","abcd","abcde"); -- OK

-- remove(delete) the table temp from the database
DROP TABLE temp;

SHOW TABLES;

-- remove(delete) the table student from the database
DROP TABLE student;

-- remove(delete) the database from the mysql
DROP DATABASE dbda_db;

-- to see which database we re using after deleting the current used db
SELECT DATABASE(); -- NULL

-- create the dbda_db database and create a student table inside it
CREATE DATABASE dbda_db;

USE dbda_db;

CREATE TABLE student(
rollno INT,
name VARCHAR(15),
marks DECIMAL(5,2)
);

-- add some dummy data into the student table
INSERT INTO student VALUES(1,"Anil",70);

SELECT * FROM student;

INSERT INTO student VALUES(2,"Mukesh",80.50);

INSERT INTO student VALUES(3,"Prasad",60);

-- to get the description of the table
DESCRIBE student;

-- add the student with only rollno and name.
INSERT INTO student(rollno,name) VALUES(4,"Sham");

-- add the student with only rollno and marks.
INSERT INTO student(rollno,marks) VALUES(5, 90);

-- delete a student from the table with rollno 5
DELETE FROM student WHERE rollno = 5;

-- delete a student from the table with rollno 1
DELETE FROM student WHERE rollno = 1;

DELETE FROM student;

-- add multiple rows in single query
INSERT INTO student VALUES
(1,"Anil",60),
(2,"Mukesh",70),
(3,"Suresh",80);

-- create a temp table with colname as s#,p#,j# of type int
CREATE TABLE temp(`s#` INT, `p#` INT, `j#` INT);

-- create a temp2 table with colname as first name and last name of char(10) type
CREATE TABLE temp2(`first name` CHAR(10), `last name` CHAR(10));
-- OR
CREATE TABLE temp2(first_name CHAR(10), last_name CHAR(10));

-- create a new database classwork_db and add the tables provided in db file.
CREATE database classwork_db;

USE classwork_db;

SOURCE <absolute path till the .sql file>
-- make sure in the absolyte path their should not any blank spaces