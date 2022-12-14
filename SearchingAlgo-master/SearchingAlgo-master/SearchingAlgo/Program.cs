using System.Timers;
using static System.Console;


namespace SearchingAlgo
{
    class Program
    {
        static double[] newTimes = new double[3];
        public static System.Timers.Timer bTimer;
        public static int[] keys;
        private static int key;

        public static ElapsedEventHandler OnTimedEvent { get; private set; }


        static void Main(string[] arg)
        {
            string textFilePath = "score.text";
            string[] stringScores = File.ReadAllLines(textFilePath);
            int[] scores = Array.ConvertAll(stringScores, int.Parse);
            
        }

       

        public static void SetTimer()
        {
            // Create a timer with a two second interval.
            bTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            bTimer.Elapsed += OnTimedEvent;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
        }

        #region LinearSearch
        //Linear Search Guide
        /*Description: search sequentially checks each element of a data set. 
         * It is generally not as efficient as other options unless the data set is very small
         * Best Case: O(1)
         * Worst Case: O(n)
         * PuesdoCode:
         * Begin
1) Set i = 0
2) If Li = T, go to line 4
3) Increase i by 1 and go to line 2
4) If i < n then return i
En
         */
         
         static int LinearSearch(int[] array, int val)
        {
            SetTimer();
            bTimer.Start();
            for (int m = 0; m < array.Length; m++)
            {
                if (array[m] == val)
                {
                    return m;
                }
            }
            bTimer.Stop();
            bTimer.Elapsed += OnTimedEvent;
            WriteLine("Linear Search took " + newTimes[0] + "seconds to search the data.");
            //if the value is not found
            return -1;
        }

        #endregion

        #region BinarySearch
        //Binary Search Guide
        /*Description:requires a sorted data set. It compares the value in the middle of the data set to the value being searched for. 
         * If the values are equal, the target has been found.
         * The search procedure is repeated recursively with the remaining half of the data set that will contain the target value.
         * Best Case: O(1)
         * Worst Case: O(n log n)
         * PuesdoCode:
         * function binary_search(A, n, T) is
    L := 0
    R := n − 1
    while L ≤ R do
        m := floor((L + R) / 2)
        if A[m] < T then
            L := m + 1
        else if A[m] > T then
            R := m − 1
        else:
            return m
    return unsuccessful
         */

        static int BinarySearch(int[] array, int key)
        {
            SetTimer();
            bTimer.Start();
            int min = 0;
            int max = array.Length;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (array[mid] == key)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            bTimer.Stop();
            bTimer.Elapsed += OnTimedEvent;
            WriteLine("Binary Search took " + newTimes[1] + "seconds to search the data.");
            //if it can't find the value
            return min;

        }

        #endregion

        #region InterpolationSearch
        //Interpolation Search Guide
        /*Description: Requires a sorted data set. 
         * Binary search always chooses the middle of the data set before discarding one half or the other. 
         * Interpolation search uses keys.
         * Best Case: O (log log n)
         * Worst Case: O(n)
         * Step 1 − Start searching data from middle of the list.
Step 2 − If it is a match, return the index of the item, and exit.
Step 3 − If it is not a match, probe position.
Step 4 − Divide the list using probing formula and find the new midle.
Step 5 − If data is greater than middle, search in higher sub-list.
Step 6 − If data is smaller than middle, search in lower sub-list.
Step 7 − Repeat until match.
         */

        static int InterpolationSearch(int[] array, int lowIndex, int highIndex )
        {
            SetTimer();
            bTimer.Start();
            int pos = 0;

            while (lowIndex < highIndex && key >= array[lowIndex] && key <= array[highIndex])
            {
                pos = lowIndex = ((highIndex - lowIndex) / (array[highIndex] - array[lowIndex])) * (key - array[lowIndex]);
                if (array[pos] == key)
                {
                    return pos;
                }
                if (array[pos] < key)
                {
                    return InterpolationSearch(keys, pos + 1, highIndex);
                }
                if (array[pos] > key)
                {
                    return InterpolationSearch(keys, lowIndex, pos - 1);
                }
            }
            bTimer.Stop();
            bTimer.Elapsed += OnTimedEvent;
            WriteLine("Interpolation Search took " + newTimes[2] + "seconds to search the data.");
            return -1;


        }

        #endregion

        //Summary of data
        /*
         * Linear was slow because there are a lot of data points that it had to search through to find the right one.
         * The data set provide has over 400 scores provide and it's nearing about 500 scores.
         * Since it has so much data to go through, it's too much for it and it's runtime became significantly slower.
         * Binary was fastest but not by much being that it was kinda uniformly distributed but not sorted all the way through.
         * It was significantly better for this data set because it could handle the ammount given.
         * Interpolation was pretty, it looked all over for a specific key, in this case and all numbers were mostly uniformly distrubuted.
         * Though it wasn't sorted.
         * This seaching algorithm was significantly better because it searched through many areas for the keys.
         * I was hoping it would be the fastest after reading on it.
         * Be mindful
         
         
         */
    }
}

