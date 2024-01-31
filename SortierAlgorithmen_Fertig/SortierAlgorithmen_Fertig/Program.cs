using System;

namespace SortierAlgorithmen_Fertig
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int choice;
            int[] numbers;

            while (true)
            {
                Console.WriteLine("1. Zufällige Zahlen generieren");
                Console.WriteLine("2. Zahlen manuell eingeben");
                Console.Write("Wähle eine Option: ");

                if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle 1 oder 2.");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Write("Gib die Anzahl der Zufallszahlen ein: ");
                    if (!int.TryParse(Console.ReadLine(), out int n))
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte gib eine ganze Zahl ein.");
                        continue;
                    }
                    numbers = GenerateRandomNumbers(n);
                    break;
                }
                else if (choice == 2)
                {
                    numbers = InputNumbers();
                    break;
                }
            }

            Console.WriteLine("\nWähle einen Sortieralgorithmus:");
            Console.WriteLine("1. Bubblesort");
            Console.WriteLine("2. Selectionsort");
            Console.WriteLine("3. Quicksort");

            int sortChoice;
            while (true)
            {
                Console.Write("Deine Wahl: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out sortChoice) || sortChoice < 1 || sortChoice > 3)
                {
                    Console.WriteLine("Ungültige Wahl für den Sortieralgorithmus.");
                    continue;
                }
                break;
            }

            int[] sortedNumbers;
            switch (sortChoice)
            {
                case 1:
                    sortedNumbers = Bubblesort.Sort(numbers);
                    break;
                case 2:
                    sortedNumbers = Selectionsort.Sort(numbers);
                    break;
                case 3:
                    sortedNumbers = Quicksort.Sort(numbers);
                    break;
                case 4:
                    sortedNumbers = DerDessenNamenNichtGenanntWerdenDarf.Sort(numbers);
                    break;
                default:
                    Console.WriteLine("Ungültige Wahl für den Sortieralgorithmus.");
                    return;
            }

            Console.WriteLine("\nWähle die Sortierreihenfolge:");
            Console.WriteLine("1. Aufsteigend");
            Console.WriteLine("2. Absteigend");
            Console.WriteLine("3. Zickzack");

            int orderChoice;
            while (true)
            {
                Console.Write("Deine Wahl: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out orderChoice) || orderChoice < 1 || orderChoice > 3)
                {
                    Console.WriteLine("Ungültige Wahl für die Sortierreihenfolge.");
                    continue;
                }
                break;
            }

            switch (orderChoice)
            {
                case 1:
                    PrintSortedNumbers(sortedNumbers, "aufsteigend");
                    break;
                case 2:
                    Array.Reverse(sortedNumbers);
                    PrintSortedNumbers(sortedNumbers, "absteigend");
                    break;
                case 3:
                    PrintZickzack(sortedNumbers);
                    break;
                default:
                    Console.WriteLine("Ungültige Wahl für die Sortierreihenfolge.");
                    return;
            }
        }

        public static int[] GenerateRandomNumbers(int n)
        {
            Random rand = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = rand.Next(1, 101); // Zufallszahlen zwischen 1 und 100
            }
            return numbers;
        }

        public static int[] InputNumbers()
        {
            Console.Write("Gib die Anzahl der Zahlen ein: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Gib die Zahl {i + 1} ein: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            return numbers;
        }

        public static void PrintSortedNumbers(int[] arr, string order)
        {
            Console.Write($"Sortierte Zahlen ({order}): ");
            if (order == "absteigend")
            {
                Array.Reverse(arr);
            }
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public static void PrintZickzack(int[] arr)
        {
            int[] zickzackSorted = new int[arr.Length];
            int left = 0, right = arr.Length - 1, idx = 0;
            while (left <= right)
            {
                zickzackSorted[idx++] = arr[right--];
                if (left <= right)
                {
                    zickzackSorted[idx++] = arr[left++];
                }
            }
            Console.Write("Sortierte Zahlen (zickzack): ");
            foreach (int num in zickzackSorted)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
