drop trigger if exists update_balance;
delimiter $$
create trigger update_balance
after insert on transactions
for each row
begin
   if new.tx_type='deposit'  then
      update  accounts set balance=balance+new.amount where accno=new.accid;

   else
      update accounts set balance=balance-new.amount where accno=new.accid;
      
   end if;
end;
$$
delimiter ;