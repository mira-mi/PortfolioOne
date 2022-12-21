# SearchingAlgorithms
This week I learned three new Algorithms and they were about searching

#Linear Searching
- Linear search sequentially checks each element of a data set. It is generally not as efficient as other options unless the data set is very small.

-Worst-case: O(n)
-Best-case: O(1)
-Average: O(n/2)
-Pseudocode
Begin
1) Set i = 0
2) If Li = T, go to line 4
3) Increase i by 1 and go to line 2
4) If i < n then return i
End

#Binary Searching
-Binary search requires a sorted data set. It compares the value in the middle of the data set to the value being searched for. 
-If the values are equal, the target has been found.

-If the values are not equal, the algorithm determines which half of the data set will contain the target (is the target less than or greater than the element in the middle of the sorted array?). 

-The search procedure is repeated recursively with the remaining half of the data set that will contain the target value.

-Pseudocode

function binary_search(A, n, T) is
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
    
    #Interpolation Searching
    -Requires a sorted data set. Binary search always chooses the middle of the data set before discarding one half or the other. 
    -Interpolation search uses keys. For interpolation search to work efficiently data must be uniformly distributed (in addition to being sorted).

-Best case: O (log log n)
-Worst case:  O(n)
-This one tends to work if the data set in already sorted and uniformly distributed

(puesdo code and help was found here https://www.tutorialspoint.com/Interpolation-Search)
