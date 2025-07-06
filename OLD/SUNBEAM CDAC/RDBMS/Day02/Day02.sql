-- steps to import classwork_db
CREATE DATABASE classwork_db;
USE classwork_db;
SOURCE <absolute path of classwork-db.sql>
SHOW TABLES;

-- display all the data from dept table
SELECT * FROM dept;

-- display all the employees
SELECT * FROM emp;

-- display all the books.
-- dispaly all the contents from salgrade table.

-- display detp name and location
SELECT dname,loc from dept;

-- display emp name and salary of the employees
SELECT ename,sal FROM emp;

-- display empno, emp name , job and the comm of all employees
SELECT empno,ename,job,comm FROM emp;

-- display empname, sal, dearness allowance for all employees
-- dearness allowance = 50% of the sal
SELECT ename,sal FROM emp;

-- computed column
-- dearness allowance = sal * 0.5
SELECT ename,sal,sal*0.5 FROM emp;

SELECT ename,sal,sal*0.5 AS da FROM emp;

SELECT ename,sal,sal*0.5 da FROM emp;

-- display empno,empname,job,sal,da, total salary of all employees
SELECT empno,ename,job,sal, sal*0.5,sal+sal*0.5 FROM emp;
SELECT empno,ename,job,sal, sal*0.5 da,sal+sal*0.5 total_salary FROM emp;

-- NOT OK cannot use alias of computed columns in the next projections
SELECT empno,ename,job,sal, sal*0.5 da,sal+da total_salary FROM emp;


-- display all the jobs from emp;
SELECT job FROM emp;
SELECT DISTINCT job FROM emp;

-- display unique deptno from emp;
SELECT deptno FROM emp;
SELECT DISTINCT deptno FROM emp;

-- display unique jobs from every dept
SELECT job,deptno FROM emp;
SELECT DISTINCT job,deptno FROM emp;

-- limit
-- display empno, empname and sal of only 5 employees
SELECT empno,ename,sal FROM emp;
SELECT empno,ename,sal FROM emp LIMIT 5;

-- display empno, empname and sal of only 10 employees
SELECT empno,ename,sal FROM emp LIMIT 10;

-- display empno, ename, sal, skip first 5 employees and display next 3
SELECT empno,ename,sal FROM emp;
SELECT empno,ename,sal FROM emp LIMIT 5,3;

-- Order by
-- display all the emp with their sal in asc order
SELECT ename,sal FROM emp;
SELECT ename,sal FROM emp ORDER BY sal;

-- display all the emp with their deptno in asc order
SELECT ename,deptno FROM emp ORDER BY deptno;

-- display all the jobs and the deptno in asc order
SELECT job,deptno FROM emp;
SELECT job,deptno FROM emp ORDER BY deptno;
SELECT job,deptno FROM emp ORDER BY deptno,job;

-- display emp with their sal sorted in desc order
SELECT ename,sal FROM emp;
SELECT ename,sal FROM emp ORDER BY sal DESC;

-- display job with their deptno and sal sorted on sal and deptno
SELECT job,deptno,sal FROM emp;
SELECT job,deptno,sal FROM emp ORDER BY deptno;
SELECT job,deptno,sal FROM emp ORDER BY deptno,sal;
SELECT job,deptno,sal FROM emp ORDER BY deptno,sal DESC;

-- order by and limit
-- display the emp with the highest paid salary
SELECT ename,sal FROM emp ORDER BY sal DESC;
SELECT ename,sal FROM emp ORDER BY sal DESC LIMIT 1;

-- display the emp with the lowest paid salary
SELECT ename,sal FROM emp ORDER BY sal;
SELECT ename,sal FROM emp ORDER BY sal LIMIT 1;

-- display the emp with second highest salary
SELECT ename,sal FROM emp ORDER BY sal DESC;
SELECT ename,sal FROM emp ORDER BY sal DESC LIMIT 1,1;

-- display the emp with third highest salary
-- produce wrong answer
SELECT ename,sal FROM emp ORDER BY sal DESC LIMIT 2,1;

-- display the highest sal from the emp table
-- for highest sal mentioning DISTINCT is optional as it will always produce correct result
SELECT sal FROM emp ORDER BY sal DESC LIMIT 1;

-- display the second highest sal from the emp table
SELECT DISTINCT sal FROM emp ORDER BY sal DESC LIMIT 1,1;

-- display the third highest sal from the emp table
SELECT DISTINCT sal FROM emp ORDER BY sal DESC LIMIT 2,1;


-- display ename and da sorted on the da.
SELECT ename,sal*0.5 da FROM emp;
SELECT ename,sal*0.5 da FROM emp ORDER BY sal*0.5;
SELECT ename,sal*0.5 da FROM emp ORDER BY da;
-- we can pass the position of col in the projection to the order by clause
SELECT ename AS name,sal*0.5 da FROM emp ORDER BY 2;

-- Where clause
-- display all the emps from dept 30;
SELECT ename,deptno FROM emp ORDER BY deptno;

SELECT ename,deptno FROM emp WHERE deptno=30;

-- display all the emps with sal greater that 2000
SELECT * FROM emp WHERE sal>2000;

-- display all the emps working as analyst
SELECT * FROM emp WHERE job = "ANALYST";

-- display all emps not in dept 30;
SELECT * FROM emp WHERE deptno != 30;
--OR
SELECT * FROM emp WHERE deptno <> 30;

-- display all emps in the sal range of 1000 to 2000
SELECT * FROM emp WHERE sal>=1000 AND sal<=2000;

-- display all emps working as analyst and manager
SELECT * FROM emp WHERE job="ANALYST" OR job = "MANAGER";

-- display all emps who are not working as salesman
SELECT * FROM emp WHERE job != "SALESMAN";
SELECT * FROM emp WHERE job <> "SALESMAN";

-- display all the emps hired in 1982
SELECT * FROM emp WHERE hire = 1982;
SELECT * FROM emp WHERE hire>="1982-01-01" AND hire<="1982-12-31";

-- NULL Values
-- display all emps with no any commission

-- we cannot use NULL with relational operators
SELECT * FROM emp WHERE comm=NULL; -- empty set

-- To check for the NULL values we have to use special operator (IS)
SELECT * FROM emp WHERE comm IS NULL;

-- display all the emp with not null commission
SELECT * FROM emp WHERE comm IS NOT NULL;

-- IN OPERATOR
-- display all emps working as analyst and manager
SELECT * FROM emp WHERE job = "ANALYST" OR job = "MANAGER";
SELECT * FROM emp WHERE job IN("ANALYST","MANAGER");

-- display all the emps working as analyst or they are in dept 30
SELECT * FROM emp WHERE job = "ANALYST" OR deptno = 30;
-- when the condition on are differnt cols then we cannot use IN()

-- display all the emps with sal <1000 or the sal >3000
SELECT * FROM emp WHERE sal <1000 OR sal>3000;
-- when the condition is on same col but for other that equality
-- then IN() cannot be used.

-- display all the emps who are not analyst and manager
SELECT * FROM emp WHERE job NOT IN("ANALYST","MANAGER");
-- OR
SELECT * FROM emp WHERE NOT job IN("ANALYST","MANAGER");

--BETWEEN OPERATOR
-- display all emps in the sal range of 1000 to 2000
SELECT * FROM emp WHERE sal>=1000 AND sal<=2000;
SELECT * FROM emp WHERE sal BETWEEN 1000 AND 2000;

-- display all the emps hired in 1982
SELECT * FROM emp WHERE hire BETWEEN "1982-01-01" AND "1982-12-31";

-- display all emps working as manager in dept 20;
SELECT * FROM emp WHERE job="MANAGER" AND deptno = 20;

-- Insert the below data in your emp table
INSERT INTO emp(empno,ename) VALUES (1,"B"),(2,"J"),(3,"K");

-- display all the emps whose first letter of the name falls between B and J
SELECT ename FROM emp WHERE ename BETWEEN "B" AND "J";
SELECT ename FROM emp WHERE ename BETWEEN "B" AND "K";
SELECT ename FROM emp WHERE ename BETWEEN "B" AND "K" AND ename!="K";
SELECT ename FROM emp WHERE ename>= "B" AND ename <"K";

-- LIKE OPERATOR
--wildcards
    -- % -> O or any(n) characters
    -- _ -> exact 1 char

-- display all the emps whose name starts with b.
SELECT ename FROM emp WHERE ename>= "B" AND ename <"C";
SELECT ename FROM emp WHERE ename LIKE "B%";

-- display all the emps whose name starts with m.
SELECT ename FROM emp WHERE ename LIKE "M%";

-- display all the emps whose name ends with h.
SELECT ename FROM emp WHERE ename LIKE "%H";

-- display all the emps whose name consist of letter U
SELECT ename FROM emp WHERE ename LIKE "%U%";

-- display all the emps whose name consist of letter A atleast twice
SELECT ename FROM emp WHERE ename LIKE "%A%A%";

-- display all the emps with the names with exapct 5 chars
SELECT ename FROM emp WHERE ename LIKE "_____";

-- display all the emps with the letter R on the 3rd position in their names
SELECT ename FROM emp WHERE ename LIKE "__R%";

-- display the emps with 4 letter name with R on 3rd position in their name
SELECT ename FROM emp WHERE ename LIKE "__R_";

-- Practice example
-- display the highest salary of employee in the range of 1000 to 2000
SELECT ename,sal FROM emp ORDER BY sal DESC;

SELECT ename,sal FROM emp WHERE sal BETWEEN 1000 AND 2000;

SELECT ename,sal FROM emp WHERE sal BETWEEN 1000 AND 2000 ORDER BY sal DESC;

SELECT ename,sal FROM emp WHERE sal BETWEEN 1000 AND 2000 ORDER BY sal DESC LIMIT 1;


-- display CLERK with min salary
SELECT ename,sal FROM emp WHERE job="CLERK";

SELECT ename,sal FROM emp WHERE job="CLERK" ORDER BY sal;

SELECT ename,sal FROM emp WHERE job="CLERK" ORDER BY sal LIMIT 1;

-- display 5 lowest salary from dept 20 and 30
SELECT sal FROM emp WHERE deptno IN(20,30);

SELECT DISTINCT sal FROM emp WHERE deptno IN(20,30);

SELECT DISTINCT sal FROM emp WHERE deptno IN(20,30) ORDER BY sal;

SELECT DISTINCT sal FROM emp WHERE deptno IN(20,30) ORDER BY sal LIMIT 4,1;

