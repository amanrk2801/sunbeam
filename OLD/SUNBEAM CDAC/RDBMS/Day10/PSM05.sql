-- write a program to calculate square of a number
-- provide the number through 1 parameter and take the output from another parameter

DROP PROCEDURE IF EXISTS sp_sqr;
DELIMITER $$
CREATE PROCEDURE sp_sqr(IN num INT,OUT res INT)
BEGIN
    SET res = num*num;
END;
$$
DELIMITER ;

-- SOURCE <PATH to the PSM05.sql>
-- SELECT @res; -- NULL
-- CALL sp_sqr(5,@res);
-- SELECT @res; -- 25