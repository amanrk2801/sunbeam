delimiter $$
drop procedure if exists sp_rectanglearea;
create procedure sp_rectanglearea(in l double,in b double)
begin
    declare area double;
    set area= l * b;
    select l,b,area;
    insert into result values(area,'area of rectangle');

end;
$$
delimiter ;