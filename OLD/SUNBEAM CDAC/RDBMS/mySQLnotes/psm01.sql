drop procedure if exists sp_hello;
delimiter $$
create procedure sp_hello()
begin
    select 'HELLO World kamlu'  as msg;

end;
$$
delimiter ;