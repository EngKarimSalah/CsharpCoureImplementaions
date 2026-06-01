namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare an array of integers with a size of 3
            //int[] grades = new int[3];


            //for (int i = 0; i < grades.Length; i++)
            //{
            //    grades[i] = int.Parse(Console.ReadLine());
            //}

            //for (int i = 0; i < grades.Length; i++)
            //{
            //    Console.Write("The grade number " + (i + 1) + " is: ");
            //    Console.WriteLine(grades[i]);
            //}
            /////////////////////////////////////////
            //array methods and properties


            int[] numbers = { 5, 18, 22, 9, 22 };

            int index = Array.IndexOf(numbers, 22);
            if (index == -1)
            {
                Console.WriteLine("Item not found in the array.");
            }
            else
            {
                Console.WriteLine("Item found at index: " + index);
            }

            Console.WriteLine("The length of the array is: " + numbers.Length); // Outputs 5

            Array.Sort(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }


           


            }
    }
}
