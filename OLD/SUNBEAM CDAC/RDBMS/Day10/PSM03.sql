-- write a progarm to calculate area of circle
DROP PROCEDURE IF EXISTS sp_circlearea;

DELIMITER $$
-- procedure
CREATE PROCEDURE sp_circlearea()
BEGIN
    DECLARE radius INT DEFAULT 10;
    DECLARE area DECIMAL(7,2);
    SET area = 3.14 * radius * radius;
    SELECT radius,area;
END;
$$

DELIMITER ;