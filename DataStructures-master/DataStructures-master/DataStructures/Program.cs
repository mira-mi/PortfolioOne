using System.Collections;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using System.Runtime.CompilerServices;


internal class Program
{
    private static void Main(string[] args)
    {
        

        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Cheese");
            hashtable.Add(2, "Lemons");
            hashtable.Add(3, "Apple");
            hashtable.Add(4, "Plum");
            hashtable.Add(5, "Mustard Gas");
            hashtable.Add(6, "Cyanide");
            WriteLine(hashtable);

            //Array
            string[] animals = { "aligator", "dog", "cat", "bird", "squirrel", "axolotl" };
            WriteLine(animals.Length);

            //So this top one shows hashtable vs an array
            /*A hashtable seems more beneficial when you have multiple data sets
             * an array seems more beneficial when you have one type of data set
             * see with the hashtable, it has to have two data types in there to be whole
             * it needs more than a string or an int to be considered a hashtable
             * the hashtable takes in a data set in the form of key-value pairs
             * the array is basically an object
             * if it had just one, it would seen as a hashset instead of table
             * with an array, it could have either or
             * I think more complex systems should have hashtable used while less complex ones shouldn't
             * I believe that the hashtables are more efficient because you can have a bit more plus they have ways that can help if there are collisions
             */



            //Stack
            Stack myStack = new Stack();
            myStack.Push("sandwhich");
            myStack.Push("bread");
            myStack.Push("lettuce");
            myStack.Push("1234639");
            myStack.Push("5678965");
            myStack.Push("y");

            foreach (var elem in myStack)
            {
                WriteLine(elem.ToString());
            }

            //Queue
            Queue myqueue = new Queue();
            myqueue.Enqueue("smeep");
            myqueue.Enqueue("Smorp");
            myqueue.Enqueue("2");
            myqueue.Enqueue("78874");
            myqueue.Enqueue("trippin");
            myqueue.Enqueue("sonic");
            
            foreach(var ele in myqueue)
            {
                WriteLine(ele);
            }

            //I feel like Stacks and Queue are interchangable
            /*a stack is a data structure where things can be inserted and deleted from the top
             * a queue is a data structure where things can be inserted deleted from the rear.
             * stack follows LIFO,last in first out, while queue follows FIFO, first in first out
             * stack is a non generic collection class
             * queue is a special type of collection
             * I think queues are more suficient in removing old data, since it removes from the rear
             * while stacks are more suficient in removing near the top
             * I would prefer to use queue for these types of structures
             * I feel like queue one is more efficient because it solves problems having sequential processing
             * that is a specific order received by the senses
             */
        }
    }
}