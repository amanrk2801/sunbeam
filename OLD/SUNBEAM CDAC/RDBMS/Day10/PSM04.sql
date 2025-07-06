-- write a program to calculate are of rectangle by taking
-- 2 parameters length and breadth
DROP PROCEDURE IF EXISTS sp_rectanglearea;
DELIMITER $$
CREATE PROCEDURE sp_rectanglearea(IN length INT,IN breadth INT)
BEGIN
    DECLARE area INT;
    SET area = length * breadth;
    SELECT length,breadth,area;
    INSERT INTO result VALUES(area,"Area of Rectangle");
END;
$$
DELIMITER ;

-- SOURCE <path to the PSM04.sql>
-- CALL sp_rectanglearea(10,5);

-- add the area and msg as "Area of rectangle" in result table