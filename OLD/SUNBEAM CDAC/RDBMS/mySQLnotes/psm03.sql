delimiter $$
drop procedure if exists sp_circlearea;
create procedure sp_circlearea()
begin
    declare radius int default 10;
    declare area double;
    set area= 3.14 * radius * radius;
    select radius,area;
end;
$$
delimiter ;