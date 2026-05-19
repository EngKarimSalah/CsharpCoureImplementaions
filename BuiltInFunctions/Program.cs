namespace Functions

{
    internal class Program
    {
        //user defined function Parts 
        // method head 
        // method bode 
        /*
        [access_modifier] [return_type] [function_name]([parameters])  ==> function head / signature 
        {
            // Function body
        }

        - access_modifier: defines the accessibility of the function (e.g., public, private, protected, internal)
        - return_type: specifies the type of value the function returns (e.g., void, int, string)
        - function_name: the name of the function, which should be descriptive of its purpose
        note: any programming block should implement a single task or a closely related set of tasks.
        ( single responsibility principle )
        - parameters: a comma-separated list of input values that the function can accept. 
        Each parameter has a type and a name (e.g., int number, string name)

        function signature should be unique within the scope 
        any 2 functions should be different in name, return type, parameters ( types, number, order )

        - function body : contains the code that defines what the function does. It can include variable declarations, control structures,
        and other statements that perform the desired operations when the function is called.

        */



        // example of a user defined function that prints the main menu
        //function implementaion 
        public static void PrintMainMenu()  // no return , no parameters
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("0. Add Account Information");
            Console.WriteLine("1. View Account Information");
            Console.WriteLine("2. Edit Account Information");
            Console.WriteLine("3. Deposit Funds");
            Console.WriteLine("4. Withdraw Funds");
            Console.WriteLine("5. Show balance");
            Console.WriteLine("6. Exit");

        }

        public static void PrintWelcomeMssage(string name) //no return , with parameters
        {
            Console.WriteLine("Welcome to the application " + name);
        }

        public static DateTime GetTodaysDate() // return type is DateTime, no parameters
        { 
            return DateTime.Today;  
        }

        public static int AddNumbers(int num1, int num2) // return type is int, with parameters
        {
            return num1 + num2;
        }



        //Function overloading : same function name with different signatures 
        //( return type, parameters types, number, order )

        public static void Writeline()
        {

        }
        public static void Writeline(int input)
        {
            Console.WriteLine(input);   
        }
        public static void Writeline(string input)
        {
            Console.WriteLine(input);
        }

         // optional parameters
        public static void ResgiterMemberShip(string name, string email, string nationality ="Omani")
        {
            //do some code to resgiter the user for the membership
        }
        public static void ResgiterMemberShip(string name, string email)
        {
            //do some code to resgiter the user for the membership
        }



        //call by value vs call by reference vs output parameters
        public static int sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int sum(int num1, int num2, out int result)
        {
            result = num1 + num2;
            return result;
        }

        public static int Decrease(ref int number)
        {
            return number-1;
        }


        //main method
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the functions demo!");
            Console.WriteLine("Enter a first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second number:");
            int secondNumber = int.Parse(Console.ReadLine());

            int result = sum(firstNumber, secondNumber);

            ////////////////////////////////////////////////////

            Console.WriteLine("Enter number to decrease:");
            int n = int.Parse(Console.ReadLine());

            int decreasedNumber = Decrease(ref n);
            /////////////////////////

            int r;
            sum(5,6,out r);

            //function calls



            ResgiterMemberShip(email:"karim@gmail.com", name:"karim");

            PrintWelcomeMssage("Ali");

            PrintMainMenu();

            Console.WriteLine();
            Console.WriteLine(1);
            Console.WriteLine("karim");
            Console.WriteLine(DateTime.Now);

            ResgiterMemberShip("karimn","karim@gmail.com");

           


            ////system storage variables 
            //string name = "";


            ////processing
            //Console.WriteLine("Resgister new user");
            //Console.WriteLine("Enter your name");
            //string input = Console.ReadLine();

            //if (input.Length <= 20)
            //{
            //    name = input; // store the user input in the name variable
            //}
            //else
            //{
            //    Console.WriteLine("Name must be less than or equal to 20 characters.");
            //}

            //double result = Math.Pow(3, 6);


            //////////////////////////////////////////////////////////////////



        }




    }
}
