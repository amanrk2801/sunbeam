-- write a program to calculate square of a number
-- provide the number through the parameter and take the output from same parameter

DROP PROCEDURE IF EXISTS sp_sqr2;
DELIMITER $$
CREATE PROCEDURE sp_sqr2(INOUT res INT)
BEGIN
    SET res = res*res;
END;
$$
DELIMITER ;

-- SOURCE <PATH to the PSM06.sql>
-- SELECT @res; -- NULL
-- SET @res = 9;
-- SELECT @res; -- 9
-- CALL sp_sqr2(@res);
-- SELECT @res; -- 81