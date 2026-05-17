namespace FirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-. Write a C# program that prints from 1 to 10
            int counter;

            for (counter = 1; counter <= 10; counter++)
                {
                    Console.WriteLine(counter);
                }


            //2- print welcome message to the user and ask for their name
            Console.WriteLine("Welcome to the application!");
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello" + userName);

        }
    }
}
