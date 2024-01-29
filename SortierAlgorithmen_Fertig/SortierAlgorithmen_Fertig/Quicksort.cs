using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen_Fertig
{
    internal class Quicksort
    {
        public static int[] Sort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }
            int pivot = arr[arr.Length / 2];
            int[] left = new int[arr.Length];
            int[] middle = new int[arr.Length];
            int[] right = new int[arr.Length];
            int l = 0, m = 0, r = 0;
            foreach (int num in arr)
            {
                if (num < pivot)
                {
                    left[l++] = num;
                }
                else if (num == pivot)
                {
                    middle[m++] = num;
                }
                else
                {
                    right[r++] = num;
                }
            }
            return ConcatArrays(Sort(TrimArray(left, l)), middle, Sort(TrimArray(right, r)));
        }

        private static int[] ConcatArrays(int[] left, int[] middle, int[] right)
        {
            int[] result = new int[left.Length + middle.Length + right.Length];
            Array.Copy(left, 0, result, 0, left.Length);
            Array.Copy(middle, 0, result, left.Length, middle.Length);
            Array.Copy(right, 0, result, left.Length + middle.Length, right.Length);
            return result;
        }

        private static int[] TrimArray(int[] arr, int size)
        {
            int[] result = new int[size];
            Array.Copy(arr, 0, result, 0, size);
            return result;
        }
    }
}
