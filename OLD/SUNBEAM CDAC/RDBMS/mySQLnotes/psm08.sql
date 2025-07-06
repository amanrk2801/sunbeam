drop procedure if exists sp_sumeven;
delimiter $$
create procedure sp_sumeven(in low int,in high int)
begin
    declare sum int default 0;
    while low<=high do
         if low%2=0 then
         set sum=sum+low;
         end if;
         set low=low+1;
    end while;
    select sum;     

    
end;
$$
delimiter ;