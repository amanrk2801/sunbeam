CREATE TABLE budget(
    deptno INT,
    prev_year DOUBLE,
    curr_year DOUBLE
);

INSERT INTO budget VALUES
(10,3000,4000),
(20,2000,2000),
(30,3500,3500),
(40,4000,4500);

SELECT * FROM budget;

-- display the deptno and the budget if it is incremented from previous
-- year otherwise null
SELECT deptno,NULLIF(curr_year,prev_year) changed_budget FROM budget;
SELECT deptno,NULLIF(curr_year,prev_year) - prev_year diff_budget FROM budget;

-- display max sal fro emp table
SELECT MAX(sal) FROM emp;

-- Limitations of Group Functions
--1. Cannot use group functions with non aggegrated(non grouped) columns
SELECT deptno,MAX(sal) FROM emp; -- error

--  2. Cannot use group functions with single row functions.
SELECT LEFT(ename,1),MAX(sal) FROM emp; -- error

-- 3. display all the employees with max salary
-- canot use group functions in where clause
SELECT * FROM emp WHERE sal = MAX(sal);

-- Nesting of Group functions is not allowed
SELECT SUM(MAX(sal)) FROM emp; -- error

-- display deptwise max sal.
SELECT deptno,MAX(sal) FROM emp GROUP BY deptno;

-- display deptwise total sal spent
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno;

-- display jobwise count of employees
SELECT job,ename FROM emp ORDER BY job;
SELECT job,COUNT(empno) FROM emp GROUP BY job;

-- Having clause
-- It is used to provide the condition on group function
-- display deptno where the total salary expenditure is > 9000
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno;
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno HAVING SUM(sal)>9000;

-- display jobwise avg salaies whose avg sal > 2000
SELECT job,AVG(sal) FROM emp GROUP BY job;
SELECT job,AVG(sal) FROM emp GROUP BY job HAVING AVG(sal)>2000;

-- display deptwise max sal for dept 10 and 20
SELECT deptno,MAX(sal) FROM emp GROUP BY deptno HAVING deptno IN (10,20);
-- OR
SELECT deptno,MAX(sal) FROM emp WHERE deptno IN(10,20) GROUP BY deptno;

-- display job with the highest sal
SELECT job,MAX(sal) FROM emp GROUP BY job;
SELECT job,MAX(sal) FROM emp GROUP BY job ORDER BY MAX(sal);
SELECT job,MAX(sal) FROM emp GROUP BY job ORDER BY MAX(sal) LIMIT 1;

-- display the dept which spends lowest on the emp salaries
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno;
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno ORDER BY 2;
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno ORDER BY 2 LIMIT 1;

-- display deptwise, jobwise max sal of an emp
SELECT deptno,job,sal FROM emp ORDER by deptno,job,sal DESC;

SELECT job,deptno,sal FROM emp ORDER by job,deptno,sal DESC;

SELECT deptno,job,MAX(sal) FROM emp GROUP BY deptno,job;
SELECT deptno,job,MAX(sal) FROM emp GROUP BY deptno,job ORDER by deptno,job;

-- display deptwise count of employees
SELECT deptno,COUNT(empno) FROM emp GROUP BY deptno;

-- display deptwise count of employees and the total count of emps at last
SELECT COUNT(empno) FROM emp; -- 14
SELECT NULL,COUNT(empno) FROM emp; -- 14

SELECT deptno,COUNT(empno) FROM emp GROUP BY deptno
UNION
SELECT NULL,COUNT(empno) FROM emp;

-- OR 
SELECT deptno,COUNT(empno) FROM emp GROUP BY deptno WITH ROLLUP;

SELECT IFNULL(deptno,"Total"),COUNT(empno) FROM emp GROUP BY deptno WITH ROLLUP;

SELECT IFNULL(deptno,"Total") deptno,COUNT(empno) count FROM emp GROUP BY deptno WITH ROLLUP;

-- display deptwise total salary and also the total of all departmental salaries
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno;
SELECT deptno,SUM(sal) FROM emp GROUP BY deptno WITH ROLLUP;

-- display deptwise , jobwise, total salary and also display their total and subtotals
SELECT deptno,job, SUM(sal) FROM emp GROUP BY deptno,job;
SELECT deptno,job, SUM(sal) FROM emp GROUP BY deptno,job ORDER BY deptno,job;

SELECT deptno,job, SUM(sal) FROM emp GROUP BY deptno,job WITH ROLLUP;

-- display jobwise , deptwise, total salary and also display their total and subtotals
SELECT job,deptno, SUM(sal) FROM emp GROUP BY job,deptno WITH ROLLUP;

-- Add a new emp in the emp table
INSERT INTO emp(empno,ename,job,sal) VALUES (8000,"Mukesh","MANAGER",4000);''

--display deptwise total count of emps and total emps in organization
SELECT deptno, COUNT(empno) FROM emp GROUP BY deptno WITH ROLLUP;

SELECT IFNULL(deptno,"Total"), COUNT(empno) FROM emp GROUP BY deptno WITH ROLLUP;

SELECT GROUPING(deptno), COUNT(empno) FROM emp GROUP BY deptno WITH ROLLUP;

SELECT IF(GROUPING(deptno)=1,"Total",deptno) deptno, COUNT(empno) count FROM emp GROUP BY deptno WITH ROLLUP;

--display jobwise total count of emps and total emps in organization


