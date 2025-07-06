drop procedure if exists sp_sqr2;
delimiter $$
create procedure sp_sqr2(INOUT res int)
begin
    set res=res*res;
end;
$$
delimiter ;    