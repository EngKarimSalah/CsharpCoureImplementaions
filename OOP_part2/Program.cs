namespace OOP_part2
{


    public class BankAccount
    {
        public int AccountId { get; }
        public string holderName;
        public double balance;
        public BankAccount(int Id, double amount)
        {
            AccountId = Id;
            balance = amount;
        }
        public void checkBalance()
        {
            Console.WriteLine(balance);
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            BankAccount b1 = new BankAccount(1, 100);
            accounts.Add(b1);
            BankAccount b2 = new BankAccount(2, 205);
            accounts.Add(b2);
            accounts.Add(new BankAccount(3, 210));
            accounts.Add(new BankAccount(4, 113));


            Console.WriteLine("enter your name: ");
            string userName = Console.ReadLine();


            accounts[0].holderName = userName;
            accounts[1].holderName = "Ali";
            accounts[2].holderName = "Sara";
            accounts[3].holderName = "Omar";


            // Get all accounts with balance above 150 ( where )
            // select * from accounts where balance > 150

            List<BankAccount> selectedAccounts = accounts.Where(b => b.balance > 150).ToList();//Linq function where 
            if (selectedAccounts.Count > 0)
            {
                foreach (BankAccount account in selectedAccounts) { Console.WriteLine(account.holderName); }
            }


            //Get specific account by id ( firstordefault )
            Console.WriteLine("Enter your account number: ");
            int accountNumner = int.Parse(Console.ReadLine());

            BankAccount selectedAccount = accounts.FirstOrDefault(b => b.AccountId == accountNumner);//linq firstordefualt 
            if (selectedAccount != null)
            {
                selectedAccount.checkBalance();

            }

            //check if exist ?
            bool result = accounts.Any(b => b.balance > 10000);


            //get all holder names
            //select name from accounts
            List<string> names = accounts.Select(b => b.holderName).ToList();

            //select balance from accounts
            List<double> balances = accounts.Select(b => b.balance).ToList();

            //ordering
            List<BankAccount> orderedAccounts = accounts.OrderByDescending(b => b.balance).ToList();


            //composition
            // select * from accounts where balance > 150 order by balance
            List<BankAccount> orderedSelectedAccounts = accounts.Where(b => b.balance > 150)
                                                                .OrderByDescending(b=>b.balance)
                                                                .ToList();//Linq function where 

            //aggregation Functions
            int numberOfAccounts = accounts.Count(); 
            double averageOfBalances =  accounts.Average(b => b.balance);
            double maxBalance = accounts.Max(b => b.balance);
            double minBalance = accounts.Min(b => b.balance);

            //remove all by linq
            int removed = accounts.RemoveAll(b => b.balance < 150);
        }


    }
}
}
