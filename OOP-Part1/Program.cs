namespace OOP_Part1
{
    //OOP has four principles ( Encapsulation, inhertnance, polymorphism, abstraction )
    // Encapsulation ==> proper access levels
    public class BankAccount
    {
        public string holderName;// public allow set and get
        public int accountId { get; }  //public get only   , instance attribute 

        public static string BankName = "NBO";

        private string password;  //private with set ability through function
        public void ForgetPassword(string newPassword) //set new password
        {
            password = newPassword;
        }



        double balance; //private with set and get ability through functions
        public void Deposite(double amount)
        {
            balance + = amount;
        }

        public void withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine("withdraw succedd");
            }
            else
            {
                Console.WriteLine("Sorry withdrawal failed due to insuffient balance");
            }

        }

        public void ShowBalance(string password)
        {
            if (password == "secret")
            {
                Console.WriteLine(balance);
            }
            else
            {
                Console.WriteLine("invalid password");
            }
        }

        public BankAccount() { }
        public BankAccount(int Id, string name, double amount) //parametrized constructor
        {
            accountId = Id;
            holderName = name;
            //    this.balance = balance;
            balance = amount;
        }
    
    }

    //garbage collector  ==> call destructor to remove thw whole object

public class Trainee
    {
        //attibutes
        private int traineeId;
                string traineeName;
        public string traineeNationality;
        public int gpa;
        public List<string> subjects;


        //methods 
        public Trainee() //parameterless constructor
        {
            traineeNationality = "Omani";
        }
        public Trainee(int id, string name) //parametrized constructor
        {
            traineeId= id;
            traineeName= name;
            traineeNationality = "Omani";
        }
        public void RegisterSubject(string subject)
        {
            subjects.Add(subject);
            printSubjectsCount();

        }

        private void printSubjectsCount()
        {
           Console.WriteLine( subjects.Count());
        }



       public void ShowGpa()
        {
            Console.WriteLine(gpa);
        }
    }

    

    internal class Program
    {

        static void Main(string[] args)
        {

            int x; //declare
            x = 10; //assignment

            int z = 10; //declare + initialization

            BankAccount y = new BankAccount(1, "karim", 100); //declare + initialization
            y.holderName = "karim";
            Console.WriteLine(y.holderName);

            Console.WriteLine(y.accountId);
            //y.accountId = 10; XXXX


            BankAccount B1 = new BankAccount();
            BankAccount B2 = new BankAccount();

            B1.holderName = "karim";
            B2.holderName = "mohamed";

            Console.WriteLine(BankAccount.BankName);

           

            Console.WriteLine();

            y.Deposite(15);
            y.withdraw(10);
           // y.ShowBalance();






            Trainee r = new Trainee();
            Trainee s = new Trainee(2,"Ali");

            //y.accountId = 1;                   //assignment
            //y.holderName = "karim";
            //y.balance = 100;

        }
    }
}

