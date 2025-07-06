drop procedure if exists sp_evenodd;
delimiter $$
create procedure sp_evenodd(in num int)
begin
    if num%2=0 then

      select 'given number is even' msg;
    else
      select 'given number is odd' msg;
    end if;
    
end;
$$
delimiter ;    