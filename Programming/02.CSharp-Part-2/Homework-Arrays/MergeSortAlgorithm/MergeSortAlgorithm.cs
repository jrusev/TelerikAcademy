using System;

public class MergeSortAlgorithm
{
    static void Main()
    {
        // Write a program that sorts an array of integers using the merge sort algorithm

        int[] numbers = { 8, 4, 7, 2, 1, 3, 5, 9, 6 };
        Console.WriteLine("Unsorted: {0}", String.Join(", ", numbers)); // prints the array elements, separated by comma

        int[] sorted = MergeSort(numbers); // calls the MergeSort() method to sort the numbers
        Console.WriteLine("  Sorted: {0}", String.Join(", ", sorted));
    }

    public static int[] MergeSort(int[] unsorted)
    {
        // divides the unsorted array into halves
        // until it gets to subarrays of one element
        // then calls MergeArrays() to merge the subarrays
        if (unsorted.Length > 1)
        {
            int mid = unsorted.Length / 2;
            int[] unsortedA = new int[mid]; // left half of the unsorted array
            Array.Copy(unsorted, 0, unsortedA, 0, mid);

            int[] unsortedB = new int[unsorted.Length - (mid)]; // right half of the unsorted array
            Array.Copy(unsorted, mid, unsortedB, 0, unsorted.Length - (mid));

            int[] sortedA = MergeSort(unsortedA);
            int[] sortedB = MergeSort(unsortedB);

            int[] mergedAB = MergeArrays(sortedA, sortedB);

            return mergedAB;
        }
        else
        {
            return unsorted;
        }
    }

    static int[] MergeArrays(int[] sortedA, int[] sortedB)
    {
        // merges two sorted integer arrays (sortedA and sortedB)
        // the resulting merged array (mergedAB) is automatically sorted
        // the sorted arrays need not be of the same size
        int[] mergedAB = new int[sortedA.Length + sortedB.Length];
        int indexA = 0;
        int indexB = 0;
        for (int i = 0; i < mergedAB.Length; i++)
        {
            if (indexA > sortedA.Length - 1)
            {
                mergedAB[i] = sortedB[indexB];
                indexB++;
            }
            else if (indexB > sortedB.Length - 1)
            {
                mergedAB[i] = sortedA[indexA];
                indexA++;
            }
            else
            {
                if (sortedA[indexA] < sortedB[indexB])
                {
                    mergedAB[i] = sortedA[indexA];
                    indexA++;
                }
                else
                {
                    mergedAB[i] = sortedB[indexB];
                    indexB++;
                }
            }
        }
        return mergedAB;
    }


    // https://github.com/jasssonpet/TelerikAcademy/blob/master/Programming/2.CSharpPartTwo/1.Arrays/13.MergeSort/Program.cs
    // by Jason Zhekov, https://github.com/jasssonpet
    static void Merge(int[] arr, int[] temp, int left, int mid, int right)
    {
        int indexLeft = left, indexRight = mid + 1, indexCopy = left;

        // copies from both arrays
        while (indexLeft <= mid && indexRight <= right)
            if (arr[indexLeft] < arr[indexRight]) temp[indexCopy++] = arr[indexLeft++];
            else temp[indexCopy++] = arr[indexRight++];

        while (indexLeft <= mid) temp[indexCopy++] = arr[indexLeft++]; // Copy items left from first array
        while (indexRight <= right) temp[indexCopy++] = arr[indexRight++]; // ... or from second array

        for (indexLeft = left; indexLeft <= right; indexLeft++) arr[indexLeft] = temp[indexLeft]; // Save to the original array       
    }
    
    public static void MergeSort(int[] arr, int[] temp, int left, int right)
    {
        if (left >= right) return; // nothing left to sort (subarrays of 1 element)

        int mid = left + (right - left) / 2; // split the array in two halves

        MergeSort(arr, temp, left, mid); // sort the left half
        MergeSort(arr, temp, mid + 1, right); // sort the right half

        Merge(arr, temp, left, mid, right); // merge the two sorted halves
    }
    //// 

    public static void MergePNakov(int[] arr, int[] temp, int l, int r)
    {
        // from "Programming=++Algorithms", by P.Nakov, p.450
        int i, j, k, m;
        if (r <= l) return;
        m = (r + l) / 2;
        MergePNakov(arr, temp, l, m);
        MergePNakov(arr, temp, m + 1, r);
        for (i = m + 1; i > l; i--)
            temp[i - 1] = arr[i - 1];
        for (j = m; j < r; j++)
            temp[r + m - j] = arr[j + 1];
        for (k = l; k <= r; k++)
            arr[k] = (temp[i] < temp[j]) ? temp[i++] : temp[j--];
    }
    /////
}