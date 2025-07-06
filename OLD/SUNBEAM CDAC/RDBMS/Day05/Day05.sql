SOURCE <path to the joins.sql file>

SELECT * FROM emps;
SELECT * FROM depts;
SELECT * FROM addr;
SELECT * FROM emp_meeting;
SELECT * FROM meeting;

-- Cross Join
-- display name of an emp and all possible depts that the emp can be added in
SELECT ename FROM emps;
SELECT dname FROM depts;

SELECT ename,dname FROM emps CROSS JOIN depts;
SELECT ename,depts.deptno, dname FROM emps CROSS JOIN depts;

SELECT emps.ename,emps.deptno,depts.dname FROM emps CROSS JOIN depts;

SELECT e.ename,e.deptno,d.dname FROM emps AS e CROSS JOIN depts AS d;

SELECT e.ename,e.deptno,d.dname FROM emps e CROSS JOIN depts d;
SELECT e.ename,d.deptno,d.dname FROM emps e CROSS JOIN depts d;

-- display the empname and deptname of that employee
SELECT ename,deptno FROM emps;
SELECT deptno,dname FROM depts;

SELECT e.ename, d.dname FROM emps e INNER JOIN depts d ON e.deptno=d.deptno;

-- display the empname and deptname of that employee. display the employess
-- even if the emps deptno doen not exists in the depts table.
SELECT e.ename, d.dname FROM emps e LEFT OUTER JOIN depts d ON e.deptno=d.deptno;
SELECT e.ename, d.dname FROM emps e LEFT JOIN depts d ON e.deptno=d.deptno;

-- display the empname and deptname of that employee. display the depts
-- even if the emps doen not exists in those depts.
SELECT e.ename, d.dname FROM emps e RIGHT OUTER JOIN depts d ON e.deptno=d.deptno;
SELECT e.ename, d.dname FROM emps e RIGHT JOIN depts d ON e.deptno=d.deptno;

-- FULL OUTER JOIN
-- This keyword is not supported in mysql however we can implement it using the set operators
SELECT e.ename,d.dname FROM emps e LEFT JOIN depts d ON e.deptno = d.deptno
UNION ALL
SELECT e.ename,d.dname FROM emps e RIGHT JOIN depts d ON e.deptno = d.deptno;

SELECT e.ename,d.dname FROM emps e LEFT JOIN depts d ON e.deptno = d.deptno
UNION
SELECT e.ename,d.dname FROM emps e RIGHT JOIN depts d ON e.deptno = d.deptno;

-- SELF JOIN
-- display name of an employee and his manager name
SELECT e.ename emp,m.ename mgr FROM emps e INNER JOIN emps m ON e.mgr = m.empno;
SELECT e.ename emp,m.ename mgr FROM emps e LEFT JOIN emps m ON e.mgr = m.empno;

-- Joins Practice
--1. display the name of emp and the dept name if the dept exists
SELECT e.ename,d.dname FROM emps e INNER JOIN depts d ON e.deptno=d.deptno;

--2. display the name of emp,deptname and the district of the employee
SELECT * FROM emps; 
SELECT * FROM depts; 
SELECT * FROM addr; 

SELECT e.ename,a.dist FROM emps e INNER JOIN addr a ON e.empno = a.empno;

SELECT e.ename,a.dist,d.dname FROM emps e 
INNER JOIN addr a ON e.empno = a.empno
LEFT JOIN depts d ON e.deptno = d.deptno;

--3. display empname and the meeting topics the emp is attending
SELECT e.ename,em.meetno FROM emps e 
INNER JOIN emp_meeting em ON e.empno = em.empno;

SELECT m.topic, em.empno FROM meeting m
INNER JOIN emp_meeting em ON m.meetno = em.meetno;

SELECT e.ename,m.topic FROM emps e 
INNER JOIN emp_meeting em ON e.empno = em.empno
INNER JOIN meeting m ON em.meetno = m.meetno;

--4. display empname,meeting topic and the dist of the employee 
SELECT e.ename,m.topic,a.dist FROM emps e 
INNER JOIN emp_meeting em ON e.empno = em.empno
INNER JOIN meeting m ON em.meetno = m.meetno
INNER JOIN addr a ON e.empno = a.empno;

--5. display empname,meeting topic,deptname and the dist of the employee 
SELECT e.ename,d.dname,m.topic,a.dist FROM emps e 
INNER JOIN emp_meeting em ON e.empno = em.empno
INNER JOIN meeting m ON em.meetno = m.meetno
INNER JOIN addr a ON e.empno = a.empno
LEFT JOIN depts d ON e.deptno = d.deptno;

-- 6. display deptname and count of employees in that dept.
SELECT deptno,COUNT(empno) FROM emps GROUP BY deptno;

SELECT d.dname,COUNT(e.empno) FROM emps e
INNER JOIN depts d ON e.deptno = d.deptno
GROUP BY d.dname;

SELECT d.dname,COUNT(e.empno) FROM emps e
LEFT JOIN depts d ON e.deptno = d.deptno
GROUP BY d.dname;

SELECT d.dname,COUNT(e.empno) FROM emps e
RIGHT JOIN depts d ON e.deptno = d.deptno
GROUP BY d.dname;

-- display the ename and no of meetings attended in descending order 
-- of meeting count
SELECT e.ename,em.meetno FROM emps e
INNER JOIN emp_meeting em ON e.empno = em.empno;

SELECT e.ename,COUNT(em.meetno) FROM emps e
INNER JOIN emp_meeting em ON e.empno = em.empno;

SELECT e.ename,COUNT(em.meetno) FROM emps e
INNER JOIN emp_meeting em ON e.empno = em.empno
GROUP BY e.ename;

SELECT e.ename,COUNT(em.meetno) empcount FROM emps e
INNER JOIN emp_meeting em ON e.empno = em.empno
GROUP BY e.ename
ORDER BY empcount DESC;

-- display all the employees from DEV dept 
SELECT e.ename,d.dname FROM emps e 
INNER JOIN depts d ON e.deptno = d.deptno;

SELECT e.ename,d.dname FROM emps e 
INNER JOIN depts d ON e.deptno = d.deptno
WHERE d.dname = "DEV";