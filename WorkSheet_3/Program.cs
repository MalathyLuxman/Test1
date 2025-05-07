using System;
using System.Drawing;
using System.Net;

namespace WorkSheet_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            //1. Remove duplicates from a sorted array efficiently, while ensuring that the remaining elements are in their original order.
            //Two pinter pattern
            DrawLine("2. Remove duplicates from a sorted array");
            int[] arr = [1,1,1,2,2,3,4,4,5,6];
            PrintArray(arr, "Original Array");
            RemoveDuplicats(arr, 0);
            //2. Each element is allowed to appear at most twice.
            DrawLine("2. Each element is allowed to appear at most twice");
            arr = [1,1,1,2,2,3,4,4,5,6];
            PrintArray(arr, "Original Array");
            RemoveDuplicats(arr, 1);
            //RemoveDuplicats(2);
            //3. Fetch only the unique numbers and their count.
            DrawLine("2. Fetch only the unique numbers and their count");
            arr = [1,1,1,2,2,3,4,4,5,6];
            PrintArray(arr, "Original Array");
            RemoveDuplicats(arr, 0);
            
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
        static void RemoveDuplicats(int[] arr, int duplicatesAllowed)
        {
            if(arr.Length == 0)
                return;
            
            int i=duplicatesAllowed;
            
            for(int j=duplicatesAllowed; j<arr.Length; j++)
            {
                if(arr[i-duplicatesAllowed] != arr[j])
                {
                    i++;
                    arr[i] = arr[j];
                }
            }

            i++;

            Console.WriteLine($"Elements: {string.Join(", ", arr[..i])} New Length: {i}" );
        }
    }
}