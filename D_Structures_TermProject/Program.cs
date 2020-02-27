using System;
using System.Diagnostics;

namespace D_Structures_TermProject
{
    class Program
    {

        public static void BubbleSort(int[] arr)
        {
            for (int i = arr.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    int temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        //Prints array
        public static void PrintArray(int[] arr)
        {
            for (int item = 0; item < arr.Length; item++)
            {
                Console.Write(arr[item] + " ");
            }
            Console.WriteLine("\n");
                
        }

        public static void FillArray(int[] arr, int input)
        {
            Random rand = new Random();
            int range;

            if (input >= 500)
                range = input * 10; //This if statment keeps the range of data values at 10x the array size. Our 3 array sizes for testing are 500, 2500, 5000.
            else
                range = input;

            for (int i = 0; i < arr.Length; i++)
            {
                int values = rand.Next(1, range);

                arr[i] = values;
            }
        }

        static void Main(string[] args)
        {
           
            Console.Write("Please enter the number of integers for your array: ");
            int userInput = int.Parse(Console.ReadLine());


            Stopwatch timer = new Stopwatch();

            System.TimeSpan[] time = new System.TimeSpan[1000];

            for (int i = 0; i < 1000; i++)
            {
                int[] array = new int[userInput];

                FillArray(array, userInput);
                //PrintArray(array);
                
                timer.Start();
                BubbleSort(array); 
                timer.Stop();

                time[i] = timer.Elapsed;
                timer.Reset();
                
                //PrintArray(array);
            }

            double totalTime = 0.0;

            // I am using this to average the run time of each sort
            for (int i = 0; i < time.Length; i++)
            {
                 totalTime += time[i].TotalSeconds;
            }
            Console.WriteLine("Average BubbleSort() time: " + totalTime / time.Length);

            //67Console.ReadKey();
            //Console.Clear();

            // I created a new time array to determine if values were not being cleared from orignial
            System.TimeSpan[] sTime = new System.TimeSpan[1000];


            //I have the same setup for calculating time for the Selection Sort
            for (int i = 0; i < 1000; i++)
            {
                int[] array = new int[userInput];

                FillArray(array, userInput);
                //PrintArray(array);

                timer.Start();
                SelectionSort(array);
                timer.Stop();

                sTime[i] = timer.Elapsed;
                timer.Reset();

                //PrintArray(array);
            }

            totalTime = 0;
            // I am using this to average the run time of each sort
            for (int i = 0; i < sTime.Length; i++)
            {
                totalTime += sTime[i].TotalSeconds;
            }
            Console.WriteLine("Average SelectionSort() time: " + totalTime / sTime.Length);
        }
    }
}
