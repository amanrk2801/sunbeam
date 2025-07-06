DROP DATABASE classwork_db;

CREATE DATABASE classwork_db;

USE classwork_db;

SOURCE <path to classwork-db.sql>
SOURCE <path to joins.sql>

-- 3. Primary Key
-- Primary Key = NOT NULL + UNIQUE


CREATE TABLE customer(
    email VARCHAR(50) PRIMARY KEY,
    mobile CHAR(10),
    name VARCHAR(15),
    address VARCHAR(50)
);

CREATE TABLE Orders(
    oid INT PRIMARY KEY
    cid INT,
    pid INT,
    amount DOUBLE,
    odate DATE
);


DESC customer;

SHOW INDEXES FROM customer;

INSERT INTO customer VALUES("anil@gmail.com","9876543210","Anil","Mumbai");
INSERT INTO customer VALUES("mukesh@gmail.com","8765432109","Mukesh","Mumbai");

INSERT INTO customer VALUES("mukesh@gmail.com","7654321089","Sham","Pune");--error
-- Duplicate entry 'mukesh@gmail.com' for key 'customer.PRIMARY'

INSERT INTO customer(mobile,name,address) VALUES("7654321089","Sham","Pune");-- error
-- Field 'email' doesn't have a default value


CREATE Table student(
    std INT,
    rollno INT,
    name VARCHAR(20),
    marks INT,
    PRIMARY KEY (std,rollno) 
);

DESC student;

SHOW INDEXES FROM student;

INSERT INTO student VALUES(1,1,"s1",50);
INSERT INTO student VALUES(1,2,"s2",60);
INSERT INTO student VALUES(2,1,"s3",70);
INSERT INTO student VALUES(2,2,"s4",80);

INSERT INTO student VALUES(1,2,"s5",90); -- error
--Duplicate entry '1-2' for key 'student.PRIMARY'

INSERT INTO student(std,name,marks) VALUES(1,"s5",90); -- error
--Field 'rollno' doesn't have a default value

CREATE TABLE cdac_student(
    prn INT PRIMARY KEY,
    name VARCHAR(15) NOT NULL,
    email VARCHAR(25) NOT NULL UNIQUE,
    mobile VARCHAR(10) NOT NULL UNIQUE,
    address VARCHAR(50) NOT NULL,
    totalpercent DOUBLE,
    course CHAR(10) NOT NULL
);

CREATE TABLE sunbeam_student(
    RegNo INT PRIMARY KEY
    email VARCHAR(50),
    mobile VARCHAR(10),
    name VARCHAR(20),
    address VARCHAR(50),
    course CHAR(15)
);

-- Surrogate Primary Key
-- It is a way/key used to generate unique + not null values for the provided primary key
-- AUTO_INCREMENT

CREATE TABLE product(
    pid INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(20),
    price INT
);

INSERT INTO product(name,price) VALUES("Pen",10);
INSERT INTO product(name,price) VALUES("Pencil",5);
INSERT INTO product(name,price) VALUES("Eraser",5);
INSERT INTO product(name,price) VALUES("Sharpner",10);


INSERT INTO product(pid,name,price) VALUES(10,"100 Page NoteBook",50);--OK

INSERT INTO product(pid,name,price) VALUES(2,"200 Page NoteBook",100);
-- Duplicate entry '2' for key 'product.PRIMARY'

INSERT INTO product(pid,name,price) VALUES(6,"200 Page NoteBook",100);

INSERT INTO product(name,price) VALUES("Water Color",110);
INSERT INTO product(name,price) VALUES("Marker",25);

INSERT INTO product(name,price) VALUES("GUM",30);


CREATE TABLE product2(
    pid CHAR(10) PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(20),
    price INT
); -- error Incorrect column specifier for column 'pid'

CREATE TABLE product2(
    pid DOUBLE PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(20),
    price INT
);

INSERT INTO product2(name,price) VALUES("Pen",10);
INSERT INTO product2(name,price) VALUES("Pencil",5);
INSERT INTO product2(name,price) VALUES("Eraser",5);
INSERT INTO product2(name,price) VALUES("Sharpner",10);

SELECT * FROM product2;

-- 4. Foreign Key
CREATE TABLE depts(
    deptno INT PRIMARY KEY,
    dname VARCHAR(20)
);

INSERT INTO depts VALUES(10,"DEV");
INSERT INTO depts VALUES(20,"QA");
INSERT INTO depts VALUES(30,"OPS");
INSERT INTO depts VALUES(40,"ACC");

SELECT * FROM depts;

CREATE TABLE emps(
    empno INT PRIMARY KEY,
    ename VARCHAR(20),
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES depts(deptno)
);

DESC emps;

SHOW INDEXES FROM emps;

INSERT INTO emps VALUES(1,"Amit",10);
INSERT INTO emps VALUES(2,"Rahul",10);
INSERT INTO emps VALUES(3,"Nilesh",20);


INSERT INTO emps VALUES(4,"Nitin",50); -- error
-- Cannot add or update a child row: 
-- a foreign key constraint fails

INSERT INTO emps VALUES(4,"Nitin",40); -- OK

INSERT INTO emps(empno,ename) VALUES(5,"Sarang");

-- update the emp sarang to dept 50 and check if it is possible

DELETE FROM depts WHERE deptno=30;

-- delete the dept 40
DELETE FROM depts WHERE deptno=40; -- error

-- update the deptno from 40 to 30
UPDATE depts SET deptno = 30 WHERE deptno=40; -- error

-- update the name of dept 40 to ACCOUNTING
UPDATE depts SET dname = "ACCOUNTING" WHERE deptno=40;

TRUNCATE TABLE depts;

DROP TABLE depts;

DROP TABLE emps;

DROP TABLE depts;

CREATE TABLE depts(
    deptno INT PRIMARY KEY,
    dname VARCHAR(20)
);

INSERT INTO depts VALUES(10,"DEV");
INSERT INTO depts VALUES(20,"QA");
INSERT INTO depts VALUES(30,"OPS");
INSERT INTO depts VALUES(40,"ACC");

SELECT * FROM depts;

CREATE TABLE emps(
    empno INT PRIMARY KEY,
    ename VARCHAR(20),
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES depts(deptno) ON DELETE CASCADE ON UPDATE CASCADE
);

DESC emps;

SHOW INDEXES FROM emps;

INSERT INTO emps VALUES(1,"Amit",10);
INSERT INTO emps VALUES(2,"Rahul",10);
INSERT INTO emps VALUES(3,"Nilesh",20);
INSERT INTO emps VALUES(4,"Nitin",40);
INSERT INTO emps VALUES(5,"Sarang",40);

-- delete the dept 30;
DELETE FROM depts WHERE deptno=30;

-- delete the dept 40;
DELETE FROM depts WHERE deptno=40;

-- update the dept 10 to 30;
UPDATE depts SET deptno=30 WHERE deptno=10; 

DROP TABLE depts; -- error
TRUNCATE TABLE depts; -- error

DELETE FROM depts; -- OK
-- DML operations Update and Delete have cascading effects on the emps table

DROP TABLE emps;
DROP TABLE depts;

CREATE TABLE student(
    std INT,
    rollno INT,
    name VARCHAR(20),
    mobile VARCHAR(10),
    address VARCHAR(50),
    PRIMARY KEY (std,rollno)
);

CREATE TABLE marks(
    std INT,
    rollno INT,
    subject VARCHAR(20),
    score INT,
    FOREIGN KEY (std,rollno) REFERENCES student(std,rollno)
);

-- TO-DO 
-- Test by adding all the required entries in both the above tables

CREATE TABLE depts(
    deptno INT PRIMARY KEY,
    dname VARCHAR(20)
);

INSERT INTO depts VALUES(10,"DEV");
INSERT INTO depts VALUES(20,"QA");
INSERT INTO depts VALUES(30,"OPS");
INSERT INTO depts VALUES(40,"ACC");

SELECT * FROM depts;

CREATE TABLE emps(
    empno INT PRIMARY KEY,
    ename VARCHAR(20),
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES depts(deptno) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO emps VALUES(1,"Amit",10);
INSERT INTO emps VALUES(2,"Rahul",50); -- error

SELECT @@foreign_key_ckecks; -- 1

SET @@foreign_key_ckecks=0;

SELECT @@foreign_key_ckecks; -- 0

INSERT INTO emps VALUES(2,"Rahul",50);

-- Self Refrencing foreign keys
DROP TABLE emps;

CREATE TABLE emps(
    empno INT PRIMARY KEY,
    ename VARCHAR(20),
    deptno INT,
    mgr INT,
    FOREIGN KEY (deptno) REFERENCES depts(deptno),
    FOREIGN KEY (mgr) REFERENCES emps(empno)
);

INSERT INTO emps VALUES(1,"Amit",10,4);-- error

INSERT INTO emps VALUES(5,"Sarang",40,NULL); -- OK
INSERT INTO emps VALUES(4,"Nitin",40,5); -- OK

-- 5. CHECK
CREATE TABLE labours(
    name VARCHAR(15) CHECK(LENGTH(name)>1),
    age INT CHECK(age>18),
    salary INT CHECK(salary > 2000)
);

INSERT INTO labours VALUES("Anil",30,3000);

INSERT INTO labours VALUES("M",30,3000);-- error
-- Check constraint 'labours_chk_1' is violated.

INSERT INTO labours VALUES("Mukesh",16,3000);-- error
--Check constraint 'labours_chk_2' is violated.

INSERT INTO labours VALUES("Mukesh",35,1000);-- error
-- Check constraint 'labours_chk_3' is violated.

SHOW CREATE TABLE emps;
SHOW CREATE TABLE labours;

-- Alter Table
-- Not recommended in the production level databases

-- add a column job in the emps table
ALTER TABLE emps ADD COLUMN job VARCHAR(20);

-- update the job to manager
UPDATE emps SET job = "MANAGER";

--change the datatytpe of job to char(20)
ALTER TABLE emps MODIFY job CHAR(20);

--change the datatytpe of job to INT
ALTER TABLE emps MODIFY job INT;

-- change the name of col mgr to manager
ALTER TABLE emps CHANGE mgr manager INT;

-- remove the column job
ALTER TABLE emps DROP COLUMN job;

-- add the unique contraint to ename
ALTER TABLE emps ADD CONSTRAINT UNIQUE(ename); 

-- Remove the constarints from emps;
ALTER TABLE emps DROP CONSTRAINT ename;
ALTER TABLE emps DROP CONSTRAINT emps_ibfk_1;
ALTER TABLE emps DROP CONSTRAINT emps_ibfk_2;
ALTER TABLE emps DROP PRIMARY KEY;



