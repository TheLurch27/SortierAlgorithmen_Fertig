using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen_Fertig
{
    internal class Selectionsort
    {
        public static int[] Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIdx])
                    {
                        minIdx = j;
                    }
                }
                int temp = arr[minIdx];
                arr[minIdx] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
    }
}
