namespace _03_ImprovedEvents
{
    class BalanceEventArgs : EventArgs
    {
        public double Amount { get; set; }
        public DateTime TxTime { get; set; }
    }
    delegate void BalanceHandler(Account acc, BalanceEventArgs e);
    class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }

        //public event BalanceHandler LowBalanceHandler = null;
        private event BalanceHandler _lowBalanceHandler = null;
        public event BalanceHandler LowBalanceHandler
        {
            add
            {
                _lowBalanceHandler += value;
            }
            remove
            {
                _lowBalanceHandler -= value;
            }
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                if (_lowBalanceHandler != null)
                {
                    BalanceEventArgs e = new BalanceEventArgs()
                    {
                        Amount = amount,
                        TxTime = DateTime.Now,
                    };
                    _lowBalanceHandler(this, e);
                    return;
                }
                throw new Exception("No LowBalanceHandler Available.");
            }
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"Account: Id={Id}, Type={Type}, Balance={Balance}";
        }
    }

    class AxisBank
    {
        public static void SendLowBalanceSMS(Account acc, BalanceEventArgs e)
        {
            Console.WriteLine($"SMS: Account {acc.Id} has low balance while withdraw Rs. {e.Amount}.");
        }
        public void TestTransaction()
        {
            Account obj = new Account() { Id = 1, Type = "Saving", Balance = 0.0 }; ;
            obj.LowBalanceHandler += SendLowBalanceSMS;
            Console.WriteLine("Axis: Before Deposit: " + obj);
            obj.Deposit(3000);
            Console.WriteLine("Axis: After Deposit: " + obj);
            Console.WriteLine("Axis: Before Withdraw: " + obj);
            obj.Withdraw(4000);
            Console.WriteLine("Axis: After Withdraw: " + obj);
        }
    }

    class HdfcBank
    {
        public static void SendLowBalanceSMS(Account acc, BalanceEventArgs e)
        {
            Console.WriteLine($"SMS: Account {acc.Id} has low balance while withdraw Rs. {e.Amount}.");
        }
        public static void SendLowBalanceEmail(Account acc, BalanceEventArgs e)
        {
            Console.WriteLine($"Email: Account {acc.Id} has low balance while withdraw Rs. {e.Amount}.");
        }
        public void TestTransaction()
        {
            Account obj = new Account() { Id = 1, Type = "Saving", Balance = 0.0 }; ;
            obj.LowBalanceHandler += SendLowBalanceSMS; // event subscribe
            obj.LowBalanceHandler += SendLowBalanceEmail; // event subscribe
            Console.WriteLine("Hdfc: Before Deposit: " + obj);
            obj.Deposit(2000);
            Console.WriteLine("Hdfc: After Deposit: " + obj);
            Console.WriteLine("Hdfc: Before Withdraw: " + obj);
            obj.Withdraw(5000);
            Console.WriteLine("Hdfc: After Withdraw: " + obj);
            obj.LowBalanceHandler -= SendLowBalanceSMS; // event unsubscribe
            obj.Withdraw(3000);
            Console.WriteLine("Hdfc: After Withdraw: " + obj);
        }
    }
    class CitiBank
    {
        public void TestTransaction()
        {
            Account obj = new Account() { Id = 1, Type = "Saving", Balance = 0.0 }; ;
            obj.LowBalanceHandler += CitiLowBalancePhoneCall;
            Console.WriteLine("Citi: Before Deposit: " + obj);
            obj.Deposit(40000);
            Console.WriteLine("Citi: After Deposit: " + obj);
            Console.WriteLine("Citi: Before Withdraw: " + obj);
            obj.Withdraw(50000);
            Console.WriteLine("Citi: After Withdraw: " + obj);
        }

        private void CitiLowBalancePhoneCall(Account acc, BalanceEventArgs e)
        {
            Console.WriteLine($"Phone: Low Balance for Account {acc.Id}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AxisBank b1 = new AxisBank();
            b1.TestTransaction();
            Console.WriteLine();
            HdfcBank b2 = new HdfcBank();
            b2.TestTransaction();
            Console.WriteLine();
            CitiBank b3 = new CitiBank();
            b3.TestTransaction();
        }
    }
}
