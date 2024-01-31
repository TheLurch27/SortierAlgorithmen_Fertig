using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen_Fertig
{
    internal class DerDessenNamenNichtGenanntWerdenDarf
    {
        private static Random random = new Random();

        public static int[] Sort(int[] arr)
        {
            while (!IsSorted(arr))
            {
                Shuffle(arr);
            }
            return arr;
        }

        private static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static void Shuffle(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int temp = arr[i];
                int randomIdx = random.Next(i, n);
                arr[i] = arr[randomIdx];
                arr[randomIdx] = temp;
            }
        }
    }
}
