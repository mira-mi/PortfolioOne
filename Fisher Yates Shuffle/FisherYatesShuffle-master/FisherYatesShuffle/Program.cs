using System.Collections;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Text;

class Program
{
    private string QuotesFilePath = "RandomThing.txt";
    //haven't done this in a while

    private static Random random = new Random();
    //or this

    public static void Shuffle<T>(T[] QuotesFilePath)
    {
        int n = QuotesFilePath.Length;  
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + random.Next(n - 1);
            T t = QuotesFilePath[r];
            QuotesFilePath[r] = QuotesFilePath[i];
            QuotesFilePath[i] = t;
            //this is almost built like a random number generator
            //it was a weird form of the number generator
        }

    }

    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("RandomThing.txt");
        for (int i = 0; i < lines.Length;i++)
        {
            var fields = lines[i].Split(' ');
        }
        Shuffle(lines);
        Console.WriteLine("Shuffle: {0}", string.Join(",", lines));
      /*this is all what the application does
       * it takes an external data file called RandomThing.txt and shuffles it
       * it uses a random generator as well to send out a random one
       * it's built like a random number generator almost
       */
    }


}


