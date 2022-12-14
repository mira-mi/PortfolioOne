﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;
using static System.Console;

namespace AssignV
{
     class Program
    {
        static double[] differentTimes = new double[6];
        public static System.Timers.Timer aTimer;

        // timer was set by using microsoft vs
        public static ElapsedEventHandler OnTimedEvent { get; private set; }
        // event handler was easier to deal with the timer



        static void Main(string[] args)
        {
            string textFilePath = "score.text";
            string[] stringScores = File.ReadAllLines(textFilePath);
            int[] scores = Array.ConvertAll(stringScores, int.Parse);
            Bubblesort(scores);
            WriteLine("Bubble sort algorithm took " + differentTimes[0] + " seconds to sort the array of scores.");
            Insertionsort(scores);
            WriteLine("nIsertion sort algorithm took " + differentTimes[1] + " seconds to sort the array of scores.");
            Selectionsort(scores);
            WriteLine("Selection sort algorithm took " + differentTimes[2] + " seconds to sort the array of scores.");
            Heapsort(scores);
            WriteLine("Heap sort algorithm took " + differentTimes[3] + " seconds to sort the array of scores.");
            Quicksort(scores, 0, scores.Length - 1);
            WriteLine("Quick sort algorithm took " + differentTimes[4] + " seconds to sort the array of scores.");
            Mergesort(scores, 0, scores.Length - 1);
            WriteLine("Merge sort algorithm took " + differentTimes[5] + " seconds to sort the array of scores.");

            string fastestThing = ThingieFast();
            Console.WriteLine("In the end,we see that the " + fastestThing + " was the fastest algorithm.");


        }

        private static string Thingie()
        {
            throw new NotImplementedException();
        }

        public static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        #region BubbleSort
        /*BubbleSort 
         * Description: starts at the beginning of an array and swaps the first two elements if the first is greater than the second. 
         * Moving to the next pair, the same comparison is made.
         * Best Case: O(n)
         * Worst Case: O(n^2)
         * puesdocode:
         * Bubblesort(Data: values[])
    // Repeat until the array is sorted.
    Boolean: not_sorted = True
    While (not_sorted)
        // Assume we won't find a pair to swap.
        not_sorted = False
        // Search the array for adjacent items that are out of order.
        For i = 0 To <length of values> - 1

// See if items i and i - 1 are out of order.
            If (values[i] < values[i - 1]) Then
                // Swap them.
                Data: temp = values[i]
                values[i] = values[i - 1]
                values[i - 1] = temp
 
                // The array isn't sorted after all.
                not_sorted = True
            End If
        Next i
    End While
End Bubblesort 
         */

        static int[] Bubblesort(int[] array)
        {
            SetTimer();
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        notSorted = true;
                    }
                }
            }
            
            aTimer.Stop();
            aTimer.Elapsed += OnTimedEvent;
            return array;
        }

        #endregion

        #region InsertionSort
        /*Description: a simple sorting algorithm that builds the final sorted set one item at a time. 
         * It is efficient on small data sets but is much less efficient on large sets than quicksort, heapsort, or merge sort. 
         * Best Case: 0(n)
         * Worst Case: 0(n^2)
         * Puesdocode:
         * Insertionsort(Data: values[])
   For i = 0 To <length of values> - 1
       // Move item i into position
       //in the sorted part of the array
       < Find  the first index j where
         j < i and values[j] > values[i].>
       <Move the item into position j.>
   Next i
End Insertionsort
         */
        static int[] Insertionsort(int[] array)
        {
            SetTimer();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j - 1];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            aTimer.Stop();
            return array;
        }

        #endregion

        #region SelectionSort
        /*Description: an in-place comparison sorting algorithm. 
         * It is inefficient on large lists, and generally performs worse than insertion sort. 
         * Best Case: O(n)
         * Worst Case: 0(n^2)
         * Puesdocode:
         * Selectionsort(Data: values[])
    For i = 0 To <length of values> - 1
        // Find the item that belongs in position i.
        <Find the smallest item with index j >= i.>
        <Swap values[i] and values[j].>
    Next i
End Selectionsort  
         */

        static int[] Selectionsort(int[] array)
        {
            SetTimer();
            int temp, smallest;
            for (int i = 0; i < array.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }

            aTimer.Stop();
            aTimer.Elapsed += OnTimedEvent;
            return array;

        }

        #endregion

        #region HeapSort
        /*Description: a comparison-based sort-in-place algorithm that takes no extra storage.
         * It is often described as an improved selection sort.
         * Best Case: O(n log n)
         * Worst Case: 0(n log n)
         * Puesdocode:
         * Heapsort(Data: values)
    <Turn the array into a heap.>
 
    For i = <length of values> - 1 To 0 Step -1
        // Swap the root item and the last item.
        Data: temp = values[0]
        values[0] = values[i]
        values[i] = temp
 
        <Consider the item in position i to be removed from the heap,
         so the heap now holds i - 1 items. Push the new root value
         down into the heap to restore the heap property.>
    Next i
End Heapsort  
         */

        static int[] Heapsort(int[] array)
        {
            SetTimer();
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                addToHeap(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                addToHeap(array, i, 0);
            }
            
            aTimer.Stop();
            aTimer.Elapsed += OnTimedEvent;
            return array;
        }

        private static void addToHeap(int[] array, int n, int i)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region QuickSort
        /*Description:  is a  comparison-based sort-in-place divide-and-conquer strategy.
         * Best Case: O(n log n)
         * Worst Case: O(n^2)
         * Puesdocode:
         * algorithm quicksort(A, lo, hi) is
    if lo < hi then
        p := pivot(A, lo, hi)
        left, right := partition(A, p, lo, hi)  // note: multiple return values
        quicksort(A, lo, left - 1)
        quicksort(A, right + 1, hi)
         */


        static int[] Quicksort(int[] array, int leftIndex, int rightIndex)
        {
            SetTimer();
            var m = leftIndex;
            var f = rightIndex;
            var pivot = array[leftIndex];
            while (m <= f)
            {
                while (array[m] < pivot)
                {
                    m++;
                }

                while (array[f] > pivot)
                {
                    f--;
                }
                if (m <= f)
                {
                    int temp = array[m];
                    array[m] = array[f];
                    array[f] = temp;
                    m++;
                    f--;
                }
            }
            if (leftIndex < f)
                Quicksort(array, leftIndex, f);
            if (m < rightIndex)
                Quicksort(array, m, rightIndex);
            
            aTimer.Stop();
            aTimer.Elapsed += OnTimedEvent;
            return array;
        }
        #endregion

        #region MergeSort
        /*Description: Instead of picking a dividing item and splitting the items into two groups holding items that are larger and smaller than the dividing item, 
         * mergesort splits the items into two halves holding an equal number of items. 
         * It then recursively calls itself to sort the two halves.
         * Best Case: O(n log n)
         * Worst Case: Oo(n log n)
         * Puesdocode:
         * Mergesort(Data: values[], Data: scratch[], Integer: start, Integer: end)
    // If the array contains only one item, it is already sorted.

If (start == end) Then Return
 
    // Break the array into left and right halves.
    Integer: midpoint = (start + end) / 2
 
    // Call Mergesort to sort the two halves.
    Mergesort(values, scratch, start, midpoint)
    Mergesort(values, scratch, midpoint + 1, end)
 
    // Merge the two sorted halves.
    Integer: left_index = start
    Integer: right_index = midpoint + 1
    Integer: scratch_index = left_index
    While ((left_index <= midpoint) And (right_index <= end))
        If (values[left_index] <= values[right_index]) Then
            scratch[scratch_index] = values[left_index]
            left_index = left_index + 1
        Else
            scratch[scratch_index] = values[right_index]
            right_index = right_index + 1
        End If
        scratch_index = scratch_index + 1    End While
 
    // Finish copying whichever half is not empty.
    For i = left_index To midpoint
        scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    For i = right_index To end

scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    // Copy the values back into the original values array.
    For i = start To end
        values[i] = scratch[i]
    Next i
End Mergesort
         */

        static int[] Mergesort(int[] array, int leftArray, int rightArray)
        {
            SetTimer();
            if (leftArray < rightArray)
            {
                int mid = leftArray + (rightArray - leftArray) / 2;
                Mergesort(array, leftArray, mid);
                Mergesort(array, mid + 1, rightArray);
                Merge(array, leftArray, mid, rightArray);
            }
            aTimer.Stop();
            aTimer.Elapsed += OnTimedEvent;
            return array;
        }

         static void Merge(int[] array, int leftArray, int middleArray, int rightArray)
        {
            var leftArrayLength = middleArray - leftArray + 1;
            var rightArrayLength = rightArray - middleArray;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int p, x;
            for (p = 0; p < leftArrayLength; ++p)
                leftTempArray[p] = array[leftArray + p];
            for (x = 0; x < rightArrayLength; ++x)
                rightTempArray[x] = array[middleArray + 1 + x];
            p = 0;
            x = 0;
            int g = leftArray;
            while (p < leftArrayLength && x < rightArrayLength)
            {
                if (leftTempArray[p] <= rightTempArray[x])
                {
                    array[p++] = leftTempArray[x++];
                }
                else
                {
                    array[g++] = rightTempArray[x++];
                }
            }
            while (p < leftArrayLength)
            {
                array[g++] = leftTempArray[p++];
            }
            while (x < rightArrayLength)
            {
                array[g++] = rightTempArray[x++];
            }
        }


        #endregion

        static string ThingieFast()
        {
            string fastestThing= " ";
            int[] diffTimes = Quicksort(Array.ConvertAll(differentTimes, Convert.ToInt32), 0,differentTimes.Length - 1);
            foreach (double l in differentTimes)
            {
                if (l == differentTimes[0])
                    fastestThing = Array.IndexOf(differentTimes, l).ToString();
            }
            if (fastestThing == 0.ToString())
            {
                fastestThing = "bubble sort";
            }
            else if (fastestThing == 1.ToString())
            {
                fastestThing = "insertion sort";
            }
            else if (fastestThing == 2.ToString())
            {
                fastestThing = "selection sort";
            }
            else if (fastestThing == 3.ToString())
            {
                fastestThing = "heap sort";
            }
            else if (fastestThing == 4.ToString())
            {
                fastestThing = "quick sort";
            }
            else if (fastestThing == 5.ToString())
            {
                fastestThing = "merge sort";
            }
            return fastestThing;
        }
    }


}





