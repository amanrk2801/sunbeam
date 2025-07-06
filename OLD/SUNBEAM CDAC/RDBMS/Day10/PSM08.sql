-- write a program to sum all the even numbers in the given range
DROP PROCEDURE IF EXISTS sp_sumeven;
DELIMITER $$
CREATE PROCEDURE sp_sumeven(IN low INT,IN high INT)
BEGIN
    DECLARE sum INT DEFAULT 0;

    WHILE low<=high DO
        IF low%2=0 THEN   
            SET sum = sum + low;
        END IF;  
        SET low = low + 1;
    END WHILE;
    SELECT sum;
END;
$$
DELIMITER ;