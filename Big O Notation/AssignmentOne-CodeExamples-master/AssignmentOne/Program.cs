using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        //linear
        int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 };
        void PrintAllItems(int[] intArray2)
        {
            foreach (var item in intArray2)
            {
                Console.WriteLine(intArray2);
            }
        }

        Random random = new Random();
        for (int y = 0; y < 5; y++)
        {
            Console.WriteLine(random.Next(7));
            //returns values less than 7
            //it prints numbers less than 7 and it could also be seven so the entire amount have 7 items
            //it can only print 7 items
        }



        //quadratic
        int[] intArray3 = new int[5] { 10, 20, 30, 40, 55 };
        void PrintAllPossibleOrderedPairs(int[] intArray3)
        {
            foreach (var firstItem in intArray3)
            {
                foreach (var secondItem in intArray3)
                {
                    Console.WriteLine($"{firstItem}, {secondItem}");
                }
            }

        }

        int h = 7, z = 11;
        while (h < 10)
        {
            Console.WriteLine("First Numeber = {0}", h);
            h++;
            while (z < 14)
            {
                Console.WriteLine("Second Numebr = {0}", z);
                z++;
            }
            //prints out two numbers in a nested loop, which gives a total of n^2 prints
            //It shows the quadractic run time that we want to portray those n^2
        }
        


        //constant
        int[] intArray4 = new int[7] { 2, 5, 7, 9, 11, 13, 15 };
        void PrintFirstItem(int[] intArray4)
        {
            Console.WriteLine(intArray4[0]);
        }

        bool IsOdd(int number)
        {
            return number % 2 == 0;
            //prints out an odd number
            //it can either be 11 or 10001
            //but as we can see it needs one step to do it's job
        }
    }

}