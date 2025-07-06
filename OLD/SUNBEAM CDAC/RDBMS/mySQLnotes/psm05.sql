delimiter $$
drop procedure if exists sp_square;
create procedure sp_square(in num int,out res int)
begin
    set res=num*num;
    insert into result values(res,'square of number');
end;
$$
delimiter ;