-- Views
-- display category wise count of employees where catgeory is
-- sal>=2500 as RICH else POOR
SELECT ename,IF(sal>=2500,"RICH","POOR") category FROM emp;

SELECT category,COUNT(ename) FROM 
(SELECT ename,IF(sal>=2500,"RICH","POOR") category FROM emp) empcategory 
GROUP BY category;

-- Create a view for the emp and its category
CREATE VIEW v_empcategory AS SELECT ename,IF(sal>=2500,"RICH","POOR") category FROM emp;

SELECT category,COUNT(ename) FROM v_empcategory GROUP BY category;

-- to check how the view is created
SHOW CREATE VIEW v_empcategory;

-- to display the output of the view
SELECT * FROM v_empcategory;

SHOW TABLES;
-- display all the tables that are present along with the views

SHOW FULL TABLES;
-- display the Table_type along with the tables

-- Types of Views
    -- 1. Simple View
        -- The views on which we can perform DML operation are called simple views
    -- 2. Complex View
        -- The views on which we cannot perform DML operation are called complex views


SELECT empno,ename,job,sal FROM emp;

SELECT COUNT(ename),SUM(sal),MAX(sal),MIN(sal),AVG(sal) FROM emp;

-- simple view 
CREATE VIEW v_empdata AS SELECT empno,ename,job,sal FROM emp;
INSERT INTO v_empdata VALUES(1,"JOHN","CLERK",6000); -- OK

-- complex view
CREATE VIEW v_empsummary AS SELECT COUNT(ename),SUM(sal),MAX(sal),MIN(sal),AVG(sal) FROM emp;
INSERT INTO v_empsummary VALUES(100,200,300,400,500); -- NOT OK

-- Create a view for display the empno,name and sal for emps having sal >2500
CREATE VIEW v_richemp AS SELECT empno,ename,sal FROM emp WHERE sal>2500;

-- add a new emp in the view
INSERT INTO v_richemp VALUES(2,"ANIL",3200);

-- add a new emp in the view
INSERT INTO v_richemp VALUES(3,"MUKESH",2200);

ALTER VIEW v_richemp AS SELECT empno,ename,sal FROM emp WHERE sal>2500 WITH CHECK OPTION;
-- add a new emp in the view
INSERT INTO v_richemp VALUES(4,"SHAM",2300);

SELECT * FROM v_richemp;

SELECT ename,sal FROM v_richemp;

CREATE VIEW v_richemp2 AS SELECT ename,sal FROM v_richemp;

SELECT * FROM v_richemp2;

SHOW TABLES;

DROP VIEW v_richemp;

SELECT * FROM v_richemp2; -- ERROR as underlying view(v_richemp) is deleted

DROP VIEW v_richemp2;

-- display empno,ename,deptno and dname of all employees
SELECT e.empno,e.ename,d.deptno,d.dname FROM emp e 
INNER JOIN dept d ON e.deptno=d.deptno;

-- display all employees(empno,ename,deptno) from ACCOUNTING dept 
SELECT e.empno,e.ename,d.deptno,d.dname FROM emp e 
INNER JOIN dept d ON e.deptno=d.deptno
WHERE d.dname="ACCOUNTING";

-- create a view for below requirement
-- display empno,ename,deptno and dname of all employees
CREATE VIEW v_empdept AS
SELECT e.empno,e.ename,d.deptno,d.dname FROM emp e 
INNER JOIN dept d ON e.deptno=d.deptno;

SELECT * FROM v_empdept;

-- display all employees(empno,ename,deptno) from ACCOUNTING dept 
SELECT empno,ename,deptno FROM v_empdept WHERE dname = "ACCOUNTING";

EXPLAIN FORMAT = JSON SELECT e.empno,e.ename,d.deptno,d.dname FROM emp e 
INNER JOIN dept d ON e.deptno=d.deptno
WHERE d.dname="ACCOUNTING";
-- 2.30

EXPLAIN FORMAT = JSON SELECT empno,ename,deptno FROM v_empdept WHERE dname = "ACCOUNTING";
-- 2.30

-- INDEXES

-- 1. Simple Index
-- display all the books of Java Programming
SELECT * FROM books WHERE subject = "JAVA PROGRAMMING";
EXPLAIN FORMAT = JSON SELECT * FROM books WHERE subject = "JAVA PROGRAMMING";
-- 0.35

CREATE INDEX idx_books_subject ON books(subject); 
-- 0.80

-- display all the books of Bjarne Stroustrup
SELECT * FROM books WHERE author = "Bjarne Stroustrup";

EXPLAIN FORMAT = JSON SELECT * FROM books WHERE author = "Bjarne Stroustrup";
-- 0.35

DESC books;

CREATE INDEX idx_books_author ON books(author DESC);

DESC books;

EXPLAIN FORMAT = JSON SELECT * FROM books WHERE author = "Bjarne Stroustrup";
-- 0.35

SHOW INDEXES FROM books;

-- display the empname,deptname for all employees
-- watch the query cost without index on deptno and with index on deptno.
SELECT e.ename,d.dname FROM emp e INNER JOIN dept d ON e.deptno=d.deptno;

EXPLAIN FORMAT = JSON SELECT e.ename,d.dname FROM emp e INNER JOIN dept d ON e.deptno=d.deptno;
-- 6.50

DESC emp;
CREATE INDEX idx_emp_deptno ON emp(deptno);
DESC emp;

EXPLAIN FORMAT = JSON SELECT e.ename,d.dname FROM emp e INNER JOIN dept d ON e.deptno=d.deptno;
-- 4.52

CREATE INDEX idx_emp_deptno ON dept(deptno);
-- 4.52


-- 2. Unique Index
DESC emps;
SHOW INDEXES FROM emps;

CREATE UNIQUE INDEX idx_emps_ename ON emps(ename);

DESC emps;
SHOW INDEXES FROM emps;

-- add 2 emps withs deptno 20 and 30 with the name Rohan, Mayur and empno 6 and 7
INSERT INTO emps(empno,ename,deptno) VALUES(6,"Rohan",20);
INSERT INTO emps(empno,ename,deptno) VALUES(7,"Mayur",30);

-- add rahul with dept 40 and empno as 8
INSERT INTO emps(empno,ename,deptno) VALUES(8,"Rahul",40);
-- error Duplicate entry 'Rahul' for key 'emps.idx_emps_ename'

INSERT INTO emps(empno,deptno) VALUES (9,40);
INSERT INTO emps(empno,deptno) VALUES (10,50);

-- multiple repeated values are not allowed in the col on which unique index is applied
-- however we can keep multiple NULL inside such cols.

-- 3. Composite Index
DROP INDEX idx_emp_deptno ON emp;
SHOW INDEXES FROM emp;
DESC emp;

-- display the emps working in dept 20 as CLERK
SELECT * FROM emp WHERE deptno = 20 and job = "CLERK";

EXPLAIN FORMAT = JSON SELECT * FROM emp WHERE deptno = 20 and job = "CLERK";
--1.65

CREATE INDEX idx_deptno_job ON emp(deptno,job DESC);

EXPLAIN FORMAT = JSON SELECT * FROM emp WHERE deptno = 20 and job = "CLERK";
-- 0.70

DESC emp;

EXPLAIN FORMAT = JSON SELECT * FROM emp WHERE deptno = 20;
-- 1.00

EXPLAIN FORMAT = JSON SELECT * FROM emp WHERE job = "CLERK";
-- 1.65

CREATE INDEX idx_emp_job ON emp(job);

EXPLAIN FORMAT = JSON SELECT * FROM emp WHERE job = "CLERK";
-- 0.90

CREATE TABLE student(
    rollno INT,
    std INT,
    marks INT
);

INSERT INTO student VALUES (1,1,50);
INSERT INTO student VALUES (2,1,60);
INSERT INTO student VALUES (1,2,45);
INSERT INTO student VALUES (2,2,50);

DESC student;
SHOW INDEXES FROM student;

CREATE UNIQUE INDEX idx_rollno_std ON student(rollno,std); 

DESC student;
SHOW INDEXES FROM student;

INSERT INTO student VALUES (2,3,60); -- OK

INSERT INTO student VALUES (1,2,70); -- error
-- Duplicate entry '1-2' for key 'student.idx_rollno_std'

INSERT INTO student(rollno,marks) VALUES(2,70); -- OK
INSERT INTO student(rollno,marks) VALUES(2,80); -- OK

-- update the std to 3 for rollno 2 whose marks are 70
UPDATE student SET std=3 WHERE rollno=2 AND marks=70; -- error
--Duplicate entry '2-3' for key 'student.idx_rollno_std'

INSERT INTO student(marks) VALUES(75); -- OK
INSERT INTO student(marks) VALUES(85); -- OK

-- drop Index
DROP INDEX idx_books_author ON books;

-- Consratints
-- 1. NOT NULL
CREATE TABLE customer(
    name VARCHAR(20),
    mobile CHAR(10),
    email VARCHAR(80) NOT NULL
);

INSERT INTO customer VALUES("anil","987654210","anil@gmail.com");
INSERT INTO customer(name,email) VALUES("Mukesh","mukesh@gmail.com");
INSERT INTO customer(mobile,email) VALUES("7893847563","someone@gmail.com");

INSERT INTO customer(name,mobile) VALUES("Sham","8938475639");
-- Field 'email' doesn't have a default value

--2. UNIQUE
CREATE TABLE temp(
    col1 INT UNIQUE,
    col2 INT
);

DESC temp;
SHOW INDEXES FROM temp;

INSERT INTO temp VALUES (1,1);
INSERT INTO temp VALUES (2,1);

INSERT INTO temp VALUES (2,3);-- ERROR
-- Duplicate entry '2' for key 'temp.col1'

INSERT INTO temp(col2) VALUES(3);
INSERT INTO temp(col2) VALUES(4);

DROP TABLE student;

CREATE TABLE student(
    rollno INT,
    std INT,
    marks INT,
    UNIQUE(rollno,std)
);

DESC student;
SHOW INDEXES FROM student;

INSERT INTO student VALUES (1,1,50);
INSERT INTO student VALUES (2,1,60);
INSERT INTO student VALUES (1,2,45);
INSERT INTO student VALUES (2,2,50);

INSERT INTO student VALUES (2,3,60); -- OK

INSERT INTO student VALUES (1,2,70); -- error
-- Duplicate entry '1-2' for key 'student.idx_rollno_std'

INSERT INTO student(rollno,marks) VALUES(2,70); -- OK
INSERT INTO student(rollno,marks) VALUES(2,80); -- OK

-- update the std to 3 for rollno 2 whose marks are 70
UPDATE student SET std=3 WHERE rollno=2 AND marks=70; -- error
--Duplicate entry '2-3' for key 'student.idx_rollno_std'

INSERT INTO student(marks) VALUES(75); -- OK
INSERT INTO student(marks) VALUES(85); -- OK