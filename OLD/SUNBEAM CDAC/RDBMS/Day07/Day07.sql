--1. Write a query that produces all pairs of salespeople who are living in the same
-- city.Exclude combinations of salespeople with themselves as well as duplicate rows
-- with the order reversed.
SELECT s1.sname,s1.city, s2.sname,s2.city FROM salespeople s1 
CROSS JOIN salespeople s2
WHERE s1.city = s2.city AND s1.sname > s2.sname;

--2. Display all the Suppliers with the same Status as the supplier, ‘CLARK’.
SELECT s1.sname,s1.status, s2.sname,s2.status FROM S s1 
CROSS JOIN S s2 
WHERE s2.sname = "CLARK" AND s1.status = s2.status AND s1.sname != "CLARK";

--3. Display all the Parts which have more Weight than any Red parts.
SELECT p1.pname,p1.weight,MIN(p2.weight) FROM P p1 CROSS JOIN P p2 WHERE p2.color = "RED
" GROUP BY p2.color,p1.pname,p1.weight HAVING p1.weight>MIN(p2.weight);

--4. Display the name of the Supplier who has sold the maximum Quantity (in onesale).x


-- SubQuery
-- A query inside another query is called as subquery
-- Two types of subqueries
    -- 1. Single Row Subquery
        --It returns Single row from its output 
    -- 2. Multi Row Subquery
        -- It return multiple rows from its output
        -- For multirow subquery we use Any and All operator for condition checking
        -- however we can also use IN operator as well in sub queries

-- display emp with highest salary
SELECT * FROM emp ORDER BY sal DESC LIMIT 1;

SELECT * FROM emp WHERE sal=MAX(sal);
-- error

SET @result = (SELECT MAX(sal) FROM emp);
SELECT @result;
SELECT * FROM emp WHERE sal=@result;

-- OR

SELECT * FROM emp WHERE sal = (SELECT MAX(sal) FROM emp);
-- subquery

-- display all the emps with their details having 2nd highest salary
SELECT sal FROM emp ORDER BY sal DESC;

SELECT DISTINCT sal FROM emp ORDER BY sal DESC LIMIT 1,1;

SELECT * FROM emp WHERE sal = (SELECT DISTINCT sal FROM emp ORDER BY sal DESC LIMIT 1,1);

-- display all the emps with their details having 3rd highest salary
SELECT * FROM emp WHERE sal = (SELECT DISTINCT sal FROM emp ORDER BY sal DESC LIMIT 2,1);

-- display all the emps with the same dept as that of KING
SELECT deptno FROM emp WHERE ename = "KING";

SELECT * FROM emp WHERE deptno = (SELECT deptno FROM emp WHERE ename = "KING");
SELECT * FROM emp WHERE deptno = (SELECT deptno FROM emp WHERE ename = "KING") AND ename!="KING";

-- Multirow subquery
-- display all the emps having sal greater than ALL the salesman

SELECT DISTINCT sal FROM emp WHERE job = "SALESMAN";

SELECT * FROM emp WHERE sal > (SELECT DISTINCT sal FROM emp WHERE job = "SALESMAN");
-- error

SELECT * FROM emp WHERE sal > ALL(SELECT DISTINCT sal FROM emp WHERE job = "SALESMAN");

-- display all the emps having sal less than any if the emp from dept 20
SELECT sal FROM emp WHERE deptno = 20;

SELECT * FROM emp WHERE sal < ANY (SELECT sal FROM emp WHERE deptno = 20);

-- display the depts which have employees
SELECT deptno FROM emp;
SELECT * FROM dept WHERE deptno = ANY (SELECT deptno FROM emp);
-- OR
SELECT * FROM dept WHERE deptno IN (SELECT deptno FROM emp);

-- display the depts which do not have employees
SELECT * FROM dept WHERE deptno != ALL (SELECT deptno FROM emp);
--where deptno!=10 AND deptno!=20 AND deptno!=30

-- CoRelated SubQuery
-- display the depts which have employees
SELECT * FROM dept WHERE deptno = ANY(SELECT deptno FROM emp);

-- subquery in projection
-- display deptwise count of employees along with the total employees
-- 10 -> 3 -> 14
-- 20 -> 5 -> 14
-- 30 -> 6 -> 14
SELECT deptno,COUNT(empno) FROM emp GROUP BY deptno;
SELECT COUNT(empno) FROM emp;
SELECT deptno,COUNT(empno), (SELECT COUNT(empno) FROM emp) FROM emp GROUP BY deptno;
SELECT deptno,CONCAT(COUNT(empno),"/", (SELECT COUNT(empno) FROM emp)) empCount FROM emp GROUP BY deptno;

-- Subquery in FROM clause
-- display empname and its category (2500>= then rich else poor)
SELECT ename,IF(sal>=2500,"RICH","POOR") FROM emp;
SELECT ename,IF(sal>=2500,"RICH","POOR") category FROM emp;

-- display categorywise count of employees
SELECT category,COUNT(ename) FROM 
(SELECT ename,IF(sal>=2500,"RICH","POOR") category FROM emp) empCategory 
GROUP BY category;
-- table created with the help of subquery are called as derived tables or inline view

-- Subquery in DML Operation
-- insert emp JHON with sal 2000 in Operations department
SELECT deptno FROM dept WHERE dname="OPERATIONS";

INSERT INTO emp(ename,sal,deptno) 
VALUES("JHON",2000,(SELECT deptno FROM dept WHERE dname="OPERATIONS"));

-- provide the comm to operations dept employees of 100
UPDATE emp SET comm=100 WHERE deptno = (SELECT deptno FROM dept WHERE dname="OPERATIONS");

-- delete all emps from Operations department
DELETE FROM emp WHERE deptno = (SELECT deptno FROM dept WHERE dname="OPERATIONS");

-- delete the emp with highest salary
DELETE FROM emp WHERE sal = (SELECT MAX(sal) FROM emp);
--- error
-- subquery cannot select from the table on which DML operations are performed


-- Querycost
EXPLAIN FORMAT = JSON SELECT * FROM dept WHERE deptno = ANY(SELECT deptno FROM emp);
--5.10

EXPLAIN FORMAT = JSON SELECT * FROM dept d WHERE d.deptno = ANY(SELECT deptno FROM emp e WHERE e.deptno=d.deptno);
--5.10