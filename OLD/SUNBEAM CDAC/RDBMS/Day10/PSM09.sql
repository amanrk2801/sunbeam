DROP TRIGGER IF EXISTS update_balance;
DELIMITER $$
CREATE TRIGGER update_balance
BEFORE INSERT ON transactions
FOR EACH ROW
BEGIN
    IF NEW.tx_type="deposit" THEN
        UPDATE accounts SET balance = balance+NEW.amount WHERE accno = NEW.accid;
    ELSE
        UPDATE accounts SET balance = balance-NEW.amount WHERE accno = NEW.accid;
    END IF;
END;
$$
DELIMITER ;