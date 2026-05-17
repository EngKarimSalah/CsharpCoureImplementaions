namespace FirstConsoleApp
{
    internal class Program
    {

        static void CountOneToTen()
        {
            //1-. Write a C# program that prints from 1 to 10
            int counter;

            for (counter = 1; counter <= 10; counter++)
            {
                Console.WriteLine(counter);
            }
        }

        static void PrintWelcomeMessage()
        {
            //2- print welcome message to the user and ask for their name
            Console.WriteLine("Welcome to the application!");
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello" + userName);
        }


        static void Main(string[] args)
        {
            //rejon 1 : system storage ( variables )
            // store banck account information
            string accountHolderName = "";
            string HolderEmail = "";
            string AccountNumber = "";
            double accountBalance = 0;
            bool isAccountActive = false; // account has not been created yet


            //string Accoun1Name = "";  string Account1Number = "";  bool isAcc1Active = false;
            //string Account2Name = ""; string Accoun2Number = "";   bool isAcc2Active = false;   


            //rejon 2 : system processing ( menu functions )
            // print main menu
            bool exit = false;
            while(exit == false)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("0. Add Account Information");
                Console.WriteLine("1. View Account Information");
                Console.WriteLine("2. Edit Account Information");
                Console.WriteLine("3. Deposit Funds");
                Console.WriteLine("4. Withdraw Funds");
                Console.WriteLine("5. Show balance");
                Console.WriteLine("6. Exit");

                Console.WriteLine("please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {


                    case 0: // add account information
                        if (isAccountActive == true)
                        {
                            Console.WriteLine("account information already exists please edit account information if you want to change it");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("enter account holder name:");
                            accountHolderName = Console.ReadLine();
                            Console.WriteLine("enter account number:");
                            AccountNumber = Console.ReadLine();
                            Console.WriteLine("enter account balance:");
                            accountBalance = double.Parse(Console.ReadLine());

                            isAccountActive = true;
                            Console.WriteLine("account information added successfully.");
                        }
                        break;

                    case 1:// view account information

                        if (isAccountActive == false)
                        {
                            Console.WriteLine("no account information found please add account information first");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Account Holder Name: " + accountHolderName);
                            Console.WriteLine("Account Number: " + AccountNumber);
                            Console.WriteLine("Account balance: " + accountBalance);
                        }
                        break;

                    case 2:// edit account information
                        Console.WriteLine("choose an option to edit:");
                        Console.WriteLine("1. Edit Account Holder Name");
                        Console.WriteLine("2. Edit Account Holder Email");
                        int choice = int.Parse(Console.ReadLine());

                        if (choice == 1)
                        {
                            Console.WriteLine("enter new account holder name:");
                            accountHolderName = Console.ReadLine();
                            Console.WriteLine("account holder name updated successfully.");
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("enter new account holder email:");
                            HolderEmail = Console.ReadLine();
                            Console.WriteLine("account holder email updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("invalid option please try again");
                        }

                        break;

                    case 3: // deposit funds
                        Console.WriteLine("Enter Account Number:");
                        string accNum = Console.ReadLine();

                        Console.WriteLine("Enter Amount to Deposit:");
                        double amount = double.Parse(Console.ReadLine());

                        if (AccountNumber == accNum)
                        {

                            //  accountBalance = accountBalance + amount; 

                            accountBalance += amount;
                            Console.WriteLine("Funds deposited successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid account number.");
                        }
                        break;

                    case 4: // withdraw funds

                        Console.WriteLine("Enter Account Number:");
                        string AccNum = Console.ReadLine();

                        Console.WriteLine("Enter Amount to Withdraw:");
                        double Amount = double.Parse(Console.ReadLine());

                        if (AccountNumber == AccNum)
                        {

                            if (Amount > accountBalance)
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                            else
                            {
                                accountBalance -= Amount;
                                Console.WriteLine("Funds withdrawn successfully.");
                            }



                        }
                        else
                        {
                            Console.WriteLine("Invalid account number.");

                        }

                        break;

                    case 5:// show balance
                        Console.WriteLine("Account balance is: " + accountBalance);

                        break;

                    case 6: // exit
                        exit = true;
                        break;

                    default:// invalid option
                        Console.WriteLine("invalid option please try again");
                        break;
                }

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear(); // clear the console for better user experience

            }

        }



  }
}
