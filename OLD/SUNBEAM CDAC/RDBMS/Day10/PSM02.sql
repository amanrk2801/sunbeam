-- write a procedure to insert heelo world in result table
DROP PROCEDURE IF EXISTS sp_hello2;

DELIMITER $$
CREATE PROCEDURE sp_hello2()
BEGIN
    INSERT INTO result VALUES(1,"HELLO WORLD");
END;
$$
DELIMITER ;