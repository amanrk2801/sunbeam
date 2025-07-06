delimiter $$
drop procedure if exists sp_hello2;
create procedure sp_hello2()
begin
insert into result values(1,'cute kamlu topper kamlu');
insert into result values(2,'cute hemu topper hemu');
insert into result value(3,'cute abhishek slipper cell abhishek');
end;
$$
delimiter ;