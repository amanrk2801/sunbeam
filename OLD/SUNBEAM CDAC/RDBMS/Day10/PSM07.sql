-- write a program to check weather given number is even or odd
DROP PROCEDURE IF EXISTS sp_evenodd;

DELIMITER $$
CREATE PROCEDURE sp_evenodd(IN num INT)
BEGIN
    IF num%2 = 0 THEN
        SELECT "Given number is even" msg;
    ELSE
        SELECT "Given number is odd" msg;
    END IF;
END;
$$
DELIMITER ;