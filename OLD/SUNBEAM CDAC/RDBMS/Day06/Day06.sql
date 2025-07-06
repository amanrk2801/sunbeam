-- display emp name and deptname.
SELECT e.ename,d.dname FROM emps e
INNER JOIN depts d ON e.deptno=d.deptno;

-- Non Standard Joins
SELECT e.ename,d.dname FROM emps e
JOIN depts d ON e.deptno=d.deptno;

SELECT e.ename,d.dname FROM emps e
JOIN depts d USING(deptno);

SELECT e.ename,d.dname FROM emps e
CROSS JOIN depts d ON e.deptno = d.deptno;

SELECT e.ename,d.dname FROM emps e
CROSS JOIN depts d WHERE e.deptno = d.deptno;

SELECT e.ename,d.dname FROM emps e,depts d WHERE e.deptno = d.deptno;
-- old style join

SELECT e.ename,d.dname FROM emps e NATURAL JOIN depts d;

-- display the all possible combination of depts for Amit and Nilesh
SELECT e.ename,d.dname FROM emps e
CROSS JOIN depts d;

SELECT e.ename,d.dname FROM emps e
CROSS JOIN depts d WHERE e.ename IN("AMIT","NILESH");

-- CREATE USER
CREATE USER 'dev1'@'localhost' IDENTIFIED BY 'dev1';

SELECT user,host FROM mysql.user;

CREATE USER 'teamlead'@'localhost' IDENTIFIED BY 'teamlead';

SELECT user,host FROM mysql.user;

CREATE USER 'mgr' IDENTIFIED BY 'mgr';
SELECT user,host FROM mysql.user;

GRANT ALL PRIVILEGES ON classwork_db.* TO 'mgr';
-- login using mgr and check if the database and all the tables are visible to mgr

GRANT ALL PRIVILEGES ON classwork_db.emps TO 'teamlead'@'localhost';
GRANT ALL PRIVILEGES ON classwork_db.depts TO 'teamlead'@'localhost'
-- login using teamlead and check if the database and emps,depts tables are visible to teamlead

-- to check for which privileges are provided for the users
-- give the below commands from root user. 
SHOW GRANTS FOR mgr;
SHOW GRANTS FOR 'teamlead'@'localhost';
SHOW GRANTS FOR 'dev1'@'localhost';

-- give the below commands from the respective login of the users
SHOW GRANTS;

GRANT SELECT,INSERT ON classwork_db.books TO 'dev1'@'localhost';
-- login using dev1 and check if the database and books table is visible to dev1

-- in the dev1 login
dev1>DELETE FROM books WHERE id = 4003;
-- ERROR - DELETE command denied to user

dev1>INSERT INTO books(id,name,price) VALUES(4004,"book1",100);
-- OK

-- from root login
REVOKE INSERT ON classwork_db.books FROM 'dev1'@'localhost';

-- from dev1 login
dev1>INSERT INTO books(id,name,price) VALUES(4004,"book1",100);
-- ERROR - INSERT command denied to user

-- to remove the user from the database
DROP USER 'dev1'@'localhost';
DROP USER 'teamlead'@'localhost';

CREATE TABLE accounts(
    id INT PRIMARY KEY,
    type VARCHAR(10),
    balance DECIMAL(9,2)
);

INSERT INTO accounts VALUES(1,"Savings",10000);
INSERT INTO accounts VALUES(2,"Savings",20000);
INSERT INTO accounts VALUES(3,"Current",30000);
INSERT INTO accounts VALUES(4,"Savings",40000);
INSERT INTO accounts VALUES(5,"Current",50000);

SELECT * FROM accounts;

SELECT @@autocommit;

DELETE FROM books WHERE id = 4003;

ROLLBACK;

SELECT @@autocommit;
SET autocommit=0;
SELECT @@autocommit;

DELETE FROM books;
SELECT * FROM books;
ROLLBACK;

DELETE FROM books WHERE id = 4002;
COMMIT;
SELECT * FROM books;
ROLLBACK; -- nothing will change
SELECT * FROM books;

SELECT @@autocommit;
SET autocommit=1;
SELECT @@autocommit;

CREATE USER 'anil' IDENTIFIED BY 'anil';
CREATE USER 'mukesh' IDENTIFIED BY 'mukesh';

GRANT ALL PRIVILEGES ON classwork_db.accounts TO anil;
GRANT ALL PRIVILEGES ON classwork_db.accounts TO mukesh;

-- perform below queries using the user anil
START TRANSACTION;

DELETE FROM accounts WHERE id = 4;

SELECT @@autocommit;

SELECT * FROM accounts;

ROLLBACK;

SELECT * FROM accounts;

-- SAVEPOINTS
START TRANSACTION;

UPDATE accounts SET balance = balance-3000 WHERE id = 4;
-- balance -> 37000

SAVEPOINT s1;

UPDATE accounts SET balance = balance-2000 WHERE id = 3;
-- balance -> 28000

SAVEPOINT s2;

UPDATE accounts SET balance = balance-1000 WHERE id = 2;
-- balance -> 19000

SAVEPOINT s3;

ROLLBACK TO s2; -- account 2 balance will be rolled back

ROLLBACK TO s3; -- savepoint does not exists

ROLLBACK TO s1; -- account 3 balance will be rolled back;

COMMIT;

GRANT ALL PRIVILEGES ON classwork_db.emps TO anil;
GRANT ALL PRIVILEGES ON classwork_db.emps TO mukesh;

-- ROW LOCKING
    -- If the table have a primary key then during transaction the row gets locked 
-- TABLE LOCKING
    -- If the table does not have a primary key then the entire table gets locked
    -- during the transaction.
-- Pissimistic Locking
SELECT * FROM emps WHERE empno=4 FOR UPDATE;
