DROP PROCEDURE IF EXISTS sp_hello;

DELIMITER $$
CREATE PROCEDURE sp_hello()
BEGIN
    SELECT "HEllO WORLD" AS msg;
END
$$
DELIMITER ;

-- to import use souurce command
-- SOURCE <path to the PSM01.sql>
-- to execute 
-- CALL sp_hello();