-- update the smith's (emmpno 7369) salary to 1000.
UPDATE emp SET sal=1000 WHERE empno=7369;

-- update the sal and comm for empno 7900 to 1200 and 300 respectively
UPDATE emp SET sal = 1200, comm=300 WHERE empno = 7900;

-- delete the emp with empno 7934
DELETE FROM emp WHERE empno = 7934;

-- delete all the Managers
DELETE FROM emp WHERE job = "MANAGER";

-- delete all emps from dept 20
DELETE FROM emp WHERE deptno = 20;

-- DELETE, TRUNCATE, DROP
DELETE FROM emp;
-- It is DML Operation
-- All the DML operations can be rollbacked
-- It only deletes the data and not the structure of the table

TRUNCATE TABLE books;
-- It is DDL operation
-- DDL operations cannot be rollbacked. 
-- It only deletes the data and not the structure of the table

DROP TABLE books;
-- It is DDL operation
-- DDL operations cannot be rollbacked. 
-- It deletes the data as well as structure of the table

-- HELP
HELP SELECT;
HELP INSERT;
HELP UPDATE;
HELP DELETE;

-- SQL FUNCTIONS
-- These are categorized as Single Row Functions and Group Function
HELP FUNCTIONS;
HELP Numeric Functions
HELP String Functions
HELP Date and Time Functions
HELP Flow control Functions

-- Single Row Functions
-- 1. Numeric Functions
SELECT ROUND(123); -- 123
SELECT ROUND(123.25); -- 123
SELECT ROUND(123.55); -- 124

SELECT ROUND(123.456,1) -- 123.5
SELECT ROUND(123.456,2) -- 123.46

SELECT ROUND(123.456,-1) -- 120
SELECT ROUND(123.456,-2) -- 100

SELECT name, subject,ROUND(price,2) FROM books;

SELECT POW(3,5);

SELECT POW(3,-5);

SELECT CEIL(2.44); -- 3
SELECT CEIL(-2.44); -- -2
SELECT FLOOR(2.44); -- 2
SELECT FLOOR(-2.44); -- -3

-- 2. String Functions
SELECT "sunbeam";
SELECT UPPER("sunbeam"); -- SUNBEAM
SELECT LOWER("SUNBEAM"); -- sunbeam

SELECT LOWER(job) FROM emp;
SELECT UPPER(subject) FROM books;

SELECT LEFT("sunbeam",2); -- su
SELECT LEFT("sunbeam",3); -- sun
SELECT RIGHT("sunbeam",2); -- am
SELECT RIGHT("sunbeam",3); -- eam

-- display all the emps whose first letter of name falls in the range of B to J
SELECT ename FROM emp WHERE LEFT(ename,1) BETWEEN "B" AND "J";

SELECT SUBSTRING("sunbeam",2);
SELECT SUBSTRING("sunbeam" FROM 2);
SELECT SUBSTRING("sunbeam",2,3);
SELECT SUBSTRING("sunbeam",-2);
SELECT SUBSTRING("sunbeam",-5,3);

SELECT CONCAT("Sunbeam"," Infotech");

-- display the o/p for all emps as below
-- ename is working as job in deptno deptno
-- smith is working as clerk in deptno 20

SELECT CONCAT(ename," is working as ",job," in deptno ",deptno) FROM emp;
SELECT CONCAT(ename," is working as ",job," in deptno ",deptno) AS empDetails FROM emp;

-- display first letter of ename in capital and remaining in small case
-- Smith
SELECT LEFT(ename,1) FROM emp;
SELECT UPPER(LEFT(ename,1)) FROM emp; -- 
SELECT SUBSTRING(ename,2) FROM emp;
SELECT LOWER(SUBSTRING(ename,2)) FROM emp; --

SELECT CONCAT(UPPER(LEFT(ename,1)),LOWER(SUBSTRING(ename,2))) ename FROM emp;

SELECT LENGTH("sunbeam"); -- 7

SELECT LPAD("sunbeam",10,"$");--$$$sunbeam
SELECT RPAD("sunbeam",10,"$");--sunbeam$$$

-- display the o/p as below
-- ***sunbeam***
SELECT RPAD(LPAD("sunbeam",10,"*"),13,"*");

-- 3. Date and Time Functions
SELECT NOW();
SELECT SYSDATE();

SELECT NOW(),SYSDATE(), SLEEP(5), NOW(), SYSDATE();
-- now() gets the date and time when query have started the execution
-- sysdate() feteches the server date and time when the function gets called. 

SELECT DATE("2000-01-15 11:08:45");
SELECT TIME("2000-01-15 11:08:45");

SELECT DATE(NOW());
SELECT TIME(NOW());

SELECT DATE_ADD(NOW(), INTERVAL 3 DAY); -- 2024-06-08 11:17:43
SELECT DATE_ADD(NOW(), INTERVAL 1 YEAR);-- 2025-06-05 11:17:59  

SELECT DATEDIFF(NOW(), "2007-12-30");
-- calculate your no of days on earth

SELECT TIMESTAMPDIFF(MONTH,"2007-12-30",NOW());

-- Calulate the experiance of employees in terms of years and months
-- expreriance -> 44 years 7 months

SELECT TIMESTAMPDIFF(YEAR,hire,NOW()) FROM emp; -- years
SELECT TIMESTAMPDIFF(MONTH,hire,NOW()) FROM emp; -- total months
SELECT TIMESTAMPDIFF(MONTH,hire,NOW())%12 FROM emp; -- remaining months 
SELECT CONCAT(TIMESTAMPDIFF(YEAR,hire,NOW())," ",(TIMESTAMPDIFF(MONTH,hire,NOW())%12)) FROM emp;

SELECT ename, CONCAT(TIMESTAMPDIFF(YEAR,hire,NOW())," years ",(TIMESTAMPDIFF(MONTH,hire,NOW())%12)," Months ") experiance FROM emp;


-- 4. Flow Control Functions
-- display emp name and deptno of all the employees
-- deptno = 10 --> ACCOUNTING
-- deptno = 20 --> RESEARCH
-- deptno = 30 --> SALES

SELECT ename,deptno FROM emp;

SELECT ename,deptno, CASE 
WHEN deptno=10 THEN "ACCOUNTING"
WHEN deptno=20 THEN "RESEARCH"
WHEN deptno=30 THEN "SALES"
ELSE "UNKNOWN"
END AS dname
FROM emp;

-- OR

SELECT ename,deptno, CASE deptno
WHEN 10 THEN "ACCOUNTING"
WHEN 20 THEN "RESEARCH"
WHEN 30 THEN "SALES"
ELSE "UNKNOWN"
END AS dname
FROM emp;

-- display the emp name, sal and category of employee
-- sal >2000  -> RICH, sal<=2000 -> POOR
SELECT ename,sal FROM emp;
SELECT ename,sal,IF(sal<=2000,"POOR","RICH") FROM emp;
SELECT ename,sal,IF(sal<=2000,"POOR","RICH") category FROM emp;

-- dislpay empname,sal and comm of aall emps;
SELECT ename,sal,comm FROM emp;

SELECT comm FROM emp;

SELECT IFNULL(comm,100) FROM emp;

SELECT ename,sal, IFNULL(comm,100) comm FROM emp;
SELECT ename,sal, IFNULL(comm,sal*0.2) comm FROM emp;
SELECT ename,sal, IFNULL(comm,sal) comm FROM emp;

-- Group Functions
-- display the max sal and min sal from the emp table.
SELECT max(sal), min(sal) FROM emp;

-- display total no of employees from the emp table.
SELECT count(empno) FROM emp;

-- display total expenditure on salaries
SELECT SUM(sal) FROM emp;

--display the avg salary from emp;
SELECT AVG(sal) FROM emp; 