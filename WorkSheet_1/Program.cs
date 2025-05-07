//1. Find the missing number in an array of size N-1, containing integers from 1 to N with no duplicates. (Summation pattern)
//Array need not be in sorted format.

using System;
using System.Net;

namespace WorkSheet_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Find 1 missing number 
            DrawLine("1. Find 1 missing number");
            MissingNumberFinder();
            //2. Find the missing and repeating number from the array - 1 Missing and 1 Repeating.
            DrawLine("2. Find the missing and repeating number from the array - 1 Missing and 1 Repeating");
            MissingAndRepeatingNumber();
            //3. Find all Missing numbers from the array - could be unsorted too.
            DrawLine("3. Find all Missing numbers from the array - could be unsorted too.");
            AllMissingNumbers();
            //4. Find kth element from the matrix - which is sorted row wise and column wise.
            DrawLine("4. Find kth element from the matrix");
            KthElementMatrix();
        }

        static void PrintArray(int[] arr, string str)
        {
            Console.WriteLine($"{str}  {string.Join(" ", arr)}");
        }

        static void DrawLine(string str)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(str);
        }

        static void MissingNumberFinder()
        {
            int[] arr = {10, 12, 15, 13, 14, 1, 2, 3, 11,  4, 6, 7, 8, 9 };
            PrintArray(arr , "Original Array");
            int n = arr.Length +1 ;
            int actualSum = n *(n+1)/2;
            //Console.WriteLine($"{actualSum}");
            int sum = 0;
            for(int i=0; i<arr.Length; i++)
            {
                sum += arr[i];
            }            

            int missingNum = actualSum - sum;
            Console.WriteLine($"The missing num is {missingNum}");
            //Time complexity O(N)
        }

        static void MissingAndRepeatingNumber()
        {
            int[] arr = {10, 12, 15, 13, 14, 1, 2, 3, 11,  4, 6, 7, 8, 9 , 9};
            PrintArray(arr, "Original Array is");
            int n = arr.Length;
            int sum = n*(n+1)/2;
            //Console.WriteLine ($"{sum}");
            int repeatingNumber = 0;
            int actualSum = 0; 
            bool flag = false;
            for(int i=0;i<arr.Length;i++)
            {
                actualSum += arr[i];
                if(!flag)
                {
                    int temp = arr[i];
                    for(int j= 0; j< arr.Length;j++)
                    {
                        if(arr[j] == temp && j!= i)
                        {
                            repeatingNumber = temp;
                            flag= true;
                            break;
                        }
                    }
                }
            }

            actualSum = actualSum - repeatingNumber;
            int missingNumber = sum - actualSum;
            Console.WriteLine($"The Missing number is {missingNumber}, and the RepeatingNumber is {repeatingNumber}");

        }
    
        static void AllMissingNumbers()
        {
            int[] arr = {1,3,5,6,8,9,10};
            PrintArray(arr, "Original Array is");
            SortArray(arr);
            PrintArray(arr, "Array After Sorting is");
            int prev = arr[0];
            List<int> missingNumbers = new List<int>();
            for(int i=1;i<arr.Length;i++)
            {
                if(arr[i] != prev+1)
                {
                    prev++;
                    missingNumbers.Add(prev);
                    i--;
                }
                else
                    prev = arr[i];
            }

            PrintArray(missingNumbers.ToArray(), "Missing Numbers are");
        }
        static void SortArray(int[] arr)
        {
            for(int i=1; i<arr.Length;i++)
            {
                int key = arr[i];
                int j= i-1;
                while(j>0 && arr[j]>key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }

                arr[j+1] = key;

            }
        }
         static void KthElementMatrix()
         {
            int[,] matrix = {
                /*{1,13,14},
                {10,15,19},
                {11,16,20},
                {12,17,21}*/
                {1,3,5},
                {2,4,6}
                //{12,10,13}
            };

            int k = 4; // To find the 7th smallest element
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int low = matrix[0, 0];
            int high = matrix[row - 1, col - 1];
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                Console.WriteLine($"low= {low} high= {high} mid= {mid}");
                int count = CountLessEqual(matrix, mid);
                Console.WriteLine($"Count: {count}");
                if (count < k)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            Console.WriteLine($"The {k}th smallest element is {low}");
        }
        static int CountLessEqual(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int count = 0;
            int i = row - 1; // Start from the bottom-left corner
            int j = 0;
            while (i >= 0 && j < col)
            {
                if (matrix[i, j] <= target)
                {
                    count += i + 1;
                    j++;
                }
                else
                {
                    i--;
                }
            }

            return count;
        }
    }
    

}
