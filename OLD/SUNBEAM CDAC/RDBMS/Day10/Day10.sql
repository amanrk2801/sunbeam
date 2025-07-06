CREATE TABLE result(
    id INT,
    value VARCHAR(100)
);

CREATE TABLE accounts(
    accno INT,
    acc_type CHAR(10),
    balance DECIMAL(12,2)
);

INSERT INTO accounts VALUES (1001,"Saving",10000);
INSERT INTO accounts VALUES (1002,"Current",20000);
INSERT INTO accounts VALUES (1003,"Saving",30000);

SELECT * FROM accounts;

CREATE TABLE transactions(
    tid INT PRIMARY KEY AUTO_INCREMENT,
    amount DECIMAL(12,2),
    tx_type CHAR(10), 
    accid INT
);

SELECT * FROM transactions;

INSERT INTO transactions(amount,tx_type,accid) VALUES(1000,"deposit",1002);
INSERT INTO transactions(amount,tx_type,accid) VALUES(3000,"deposit",1003);
INSERT INTO transactions(amount,tx_type,accid) VALUES(4000,"deposit",1001);

INSERT INTO transactions(amount,tx_type,accid) VALUES(2000,"withdraw",1003);
INSERT INTO transactions(amount,tx_type,accid) VALUES(4000,"withdraw",1003);
