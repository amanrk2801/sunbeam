-- Window Function
-- 1. Aggegrate Function

-- display ename,sal against the maximum sal from the emp table
SELECT ename,sal,(SELECT MAX(sal) FROM emp) AS maxsal FROM emp;

SELECT ename,sal,MAX(sal) AS maxsal FROM emp GROUP BY ename,sal;
-- not correct output

SELECT MAX(sal) AS maxsal FROM emp;
-- 1 output row

SELECT MAX(sal) OVER() AS maxsal FROM emp;
-- 14 output rows

SELECT ename,sal,MAX(sal) OVER() AS maxsal FROM emp;

-- display the ename,sal out of total salary of all employees
SELECT ename,sal,(SELECT SUM(sal) FROM emp) AS total FROM emp;

SELECT ename,sal,SUM(sal) OVER() AS total FROM emp;

-- display the ename,sal out of total salary for all employees from his dept
-- clark - 2450 - 8750
-- JONES - 2975 - 10875
SELECT ename,sal,(SELECT SUM(sal) FROM emp e2 WHERE e2.deptno = e1.deptno) AS total FROM emp e1;

SELECT ename,sal, SUM(sal) OVER(PARTITION BY deptno) AS total FROM emp;

-- display the ename,sal out of total salary for all employees from his job
-- TO-DO


-- 2. Non Aggegrate Function
-- display the ename,sal FROM emps along with their row numbers
SELECT ROW_NUMBER() OVER() AS rno, ename,sal FROM emp;

SELECT ROW_NUMBER() OVER() AS rno, ename,sal FROM emp ORDER BY sal;

SELECT ROW_NUMBER() OVER(ORDER BY sal) AS rno, ename,sal FROM emp;

SELECT ROW_NUMBER() OVER(ORDER BY sal) AS rno, ename,sal,deptno FROM emp;

SELECT ROW_NUMBER() OVER(ORDER BY deptno) AS rno, ename,sal,deptno FROM emp;

SELECT ROW_NUMBER() OVER(PARTITION BY deptno) AS rno, ename,sal,deptno FROM emp;


-- dispaly the ename,sal and their ranks based on salary
SELECT ename,sal,DENSE_RANK() OVER() AS rnk FROM emp;
SELECT ename,sal,DENSE_RANK() OVER() AS rnk FROM emp ORDER BY sal;
SELECT ename,sal,DENSE_RANK() OVER(ORDER BY sal) AS rnk FROM emp ;
SELECT ename,sal,DENSE_RANK() OVER(ORDER BY sal DESC) AS rnk FROM emp;

SELECT ename,sal,deptno, DENSE_RANK() OVER(PARTITION BY deptno) AS rnk FROM emp ;
SELECT ename,sal,deptno, DENSE_RANK() OVER(PARTITION BY deptno ORDER BY sal DESC) AS rnk FROM emp ;

SELECT ename,sal,RANK() OVER(ORDER BY sal DESC) AS rnk FROM emp;
SELECT ename,sal,deptno, RANK() OVER(PARTITION BY deptno ORDER BY sal DESC) AS rnk FROM emp ;

LEAD()

LAG()

SELECT ename,sal,LEAD(sal) OVER() FROM emp;
SELECT ename,sal,LAG(sal) OVER() FROM emp;


SELECT ename,sal,LEAD(sal) OVER(ORDER BY sal) AS lead_sal FROM emp;
SELECT ename,sal,LAG(sal) OVER(ORDER BY sal) AS lag_sal FROM emp;


DROP TABLE IF EXISTS transactions;
CREATE TABLE transactions (accid INT, txdate DATETIME, amount DOUBLE);
INSERT INTO transactions VALUES
(1, '2000-01-01', 1000),
(1, '2000-01-02', 2000),
(1, '2000-01-03', -500),
(1, '2000-01-04', -300),
(1, '2000-01-05', 4000),
(1, '2000-01-06', -2000),
(1, '2000-01-07', -200),
(2, '2000-01-02', 3000),
(2, '2000-01-04', 2000),
(2, '2000-01-06', -1000),
(3, '2000-01-01', 2000),
(3, '2000-01-03', -1000),
(3, '2000-01-05', 500);

SELECT * FROM transactions;
SELECT * , SUM(amount) OVER() balance FROM transactions WHERE accid=1;

SELECT *, SUM(amount) OVER() AS balance FROM transactions;

SELECT *, SUM(amount) OVER(PARTITION BY txdate) AS balance FROM transactions; 

SELECT *, SUM(amount) OVER(PARTITION BY txdate) AS balance FROM transactions WHERE accid = 1;

SELECT *, SUM(amount) OVER(PARTITION BY accid) AS balance FROM transactions; 
SELECT *, SUM(amount) OVER(PARTITION BY accid) AS balance FROM transactions WHERE accid = 1; 

SELECT *, SUM(amount) OVER() AS balance FROM transactions WHERE accid = 1; 

SELECT *, SUM(amount) OVER(ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS balance
FROM transactions WHERE accid = 1;

INSERT INTO transactions VALUES(1,'2000-01-08',1000);
INSERT INTO transactions VALUES(1,'2000-01-08',2000);

SELECT *, SUM(amount) OVER(ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS balance
FROM transactions WHERE accid = 1;


-- display emps with highest salary
SELECT * FROM emp WHERE sal = (SELECT MAX(sal) FROM emp);

-- display count of employees category wise.
-- category is sal>=2500 "Rich" else "Poor"
SELECT ename, IF(sal>=2500,"RICH","POOR") AS category FROM emp;

SELECT category,COUNT(ename) AS empcount FROM 
(SELECT ename, IF(sal>=2500,"RICH","POOR") AS category FROM emp) 
AS ec GROUP BY category;

WITH ec AS (SELECT ename, IF(sal>=2500,"RICH","POOR") AS category FROM emp)
SELECT category,COUNT(ename) AS empcount FROM ec GROUP BY category;

-- display emps with highest salary from every dept
SELECT deptno,MAX(sal) FROM emp GROUP BY deptno;

SELECT ename,deptno,sal FROM emp ORDER BY deptno,sal DESC;

SELECT * FROM emp WHERE sal IN (SELECT MAX(sal) FROM emp GROUP BY deptno);

WITH md AS (SELECT deptno,MAX(sal) AS maxsal FROM emp GROUP BY deptno)
SELECT * FROM emp e;

WITH md AS (SELECT deptno,MAX(sal) AS maxsal FROM emp GROUP BY deptno)
SELECT * FROM emp e INNER JOIN md ON e.deptno = md.deptno WHERE e.sal = md.maxsal;

-- display emp with 3rd highest salary
SELECT *, DENSE_RANK() OVER(ORDER BY sal DESC) AS rnk FROM emp;

WITH highsal AS (SELECT *, DENSE_RANK() OVER(ORDER BY sal DESC) AS rnk FROM emp)
SELECT * FROM highsal WHERE rnk=3;

-- display emps with highest salary from every dept
SELECT *,DENSE_RANK() OVER(PARTITION BY deptno ORDER BY sal DESC) AS rnk FROM emp;

WITH ms AS (SELECT *,DENSE_RANK() OVER(PARTITION BY deptno ORDER BY sal DESC) AS rnk FROM emp)
SELECT * FROM ms WHERE rnk = 1;

-- display 1 to 5 numbers in the output
WITH RECURSIVE seq AS (
    (SELECT 1 AS n)   -- anchor
    UNION
    (SELECT n+1 FROM seq -- recursive member 
    WHERE n<5)  --  base condition
)
SELECT * FROM seq;


WITH RECURSIVE seq(n) AS (
    (SELECT 1)   
    UNION
    (SELECT n+1 FROM seq 
    WHERE n<5) 
)
SELECT * FROM seq;

-- display years in which employees were hired
SELECT YEAR(hire) as hired_years FROM emp;

SELECT DISTINCT YEAR(hire) as hired_years FROM emp; 

-- display the years from 1975 to 1982 where the hiring was done
SELECT DISTINCT YEAR(hire) as hired_years FROM emp WHERE YEAR(hire) BETWEEN 1975 AND 1982; 

-- display the years from 1975 to 1982 where the hiring was done using CTE
WITH RECURSIVE years(n) AS (
    (SELECT 1975)
    UNION
    (SELECT n+1 FROM years WHERE n<1982)
)
SELECT * FROM years WHERE n IN (SELECT YEAR(hire) FROM emp);

--display name of empno,empname and the mgrno and manager name
SELECT e.empno,e.ename AS empname ,m.empno,m.ename AS mgrname FROM emp e 
INNER JOIN emp m ON e.mgr = m.empno;

-- Display level of every employee as per their reporting manager
WITH RECURSIVE eh AS(
    (SELECT empno,ename,mgr, 1 AS level FROM emp WHERE mgr IS NULL)
    UNION
    (SELECT e.empno,e.ename,e.mgr,level+1 FROM emp e INNER JOIN eh ON eh.empno = e.mgr)
)
SELECT * FROM eh;
