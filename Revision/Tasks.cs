using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Revision
{
    public static class Tasks
    {
        public static void BirthData()
        {
            // 1. Ask for the input: year of birth
            Console.WriteLine("Enter birth year: ");
            int birthYear = int.Parse(Console.ReadLine());
            // 2. Loop through all the years from YYYY to current
            for (int year = birthYear; year <= DateTime.Now.Year; year++)
            {
                // 2.1. Print out the year
                Console.WriteLine(year);
            }
        }

        public static void SquareNumbers()
        {
            Console.Write("Enter number N: ");
            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for(int i = 1; i <= N; i++)
            {
                int square = i * i;
                Console.WriteLine("{0} = {1}", i, square);

                // sum = sum + square;
                // OR
                sum += square;
            }

            string label = "Sum = {0}"; // "Summa ir {0}"
            // 1. using format:
            Console.WriteLine(label, sum);
            // 2. Using variables:
            //Console.WriteLine($"Sum = {sum}");
            // 3. String join
            //Console.WriteLine("Sum = " + sum);
            // 4. Just value
            //Console.WriteLine(sum);
        }

        public static void NNumbers()
        {
            //Input: 
            //• count N 
            //• N numbers

            //Output: 
            //• sum of N numbers 
            //• average of N numbers

            //Example: 
            //• N = 3 
            //• N1 = 5 
            //• N2 = 7 
            //• N3 = 2 
            //SUM = 14 
            //AVG = 4,67

            Console.Write("How many numbers? ");
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i <= N; i++)
            {
                Console.WriteLine("Enter number: ");
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine("SUM = {0}", sum);
            Console.WriteLine("AVG = {0}", (double)sum / N);
        }

        public static void Stop()
        {
            int sum = 0;
            int N = 0;

            while(true)
            {
                Console.WriteLine("Enter number (or STOP):");
                string input = Console.ReadLine();
                // stop, STOP, Stop
                //if(input.ToLower() == "stop")
                if(input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // stop was not entered
                int number = int.Parse(input);
                sum += number;
                N++; // ++N; N+=1; N=N+1;
            }

            Console.WriteLine("Sum = {0}", sum);
            Console.WriteLine("AVG = {0}", (double)sum / N);
        }

        public static void Hashes()
        {
            Console.WriteLine("Enter number N: ");
            int N = int.Parse(Console.ReadLine());

            for(int line = 1; line <= N; line++)
            {
                for(int row = 1; row <= N; row++)
                {
                    Console.Write("#");
                }

                Console.WriteLine();
            }
        }

        public static void Triangle()
        {
            Console.WriteLine("Enter number N: ");
            int N = int.Parse(Console.ReadLine());

            for(int line = 1; line <= N; line++)
            {
                for(int row = 1; row <= line; row++)
                {
                    Console.Write(row);
                }
                Console.WriteLine();
            }
        }

        public static void ExampleArrays()
        {
            int[] numbers = new int[3];
            numbers[0] = 5;
            numbers[1] = 3;
            numbers[2] = 78;
            //numbers[3] = 66; // ERROR!

            // same as above:
            int[] numbers2 = new[] { 5, 3, 78 };
            int[] numbers3 = { 5, 3, 78 };
        }

        public static void CheckArray()
        {
            //Input: 
            //• Number N

            //Output: 
            //• Message if N is in the array[0, 10, 20, 30, 40, 50] 
            //• Index of the number N

            int[] numbers = { 0, 10, 20, 30, 40, 50 };

            Console.WriteLine("Enter number N:");
            int N = int.Parse(Console.ReadLine());
            bool isNumberFound = false;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == N)
                {
                    Console.WriteLine("Number found at position {0}!", i);
                    isNumberFound = true;
                    break;
                }
                // NOT ELSE:
                // else
                // {
                //     Console.WriteLine("Number not found in the array!");
                // }
            }

            //if(isNumberFound == false)
            if(!isNumberFound)
            {
                Console.WriteLine("Number not found in the array!");
            }

            // to loop through arrays:
            /*
            foreach(int number in numbers)
            {
                if(number == N)
                {
                    Console.WriteLine("Number found!");
                    break;
                }
            }
            */

            // built-in methods
            /*
            bool isNumberInTheArray = numbers.Contains(N);
            if(isNumberInTheArray)
            {
                Console.WriteLine("Number is in the array!");
            }
            else
            {
                Console.WriteLine("Number is not in the array!");
            }
            */
        }

        public static void Reverse()
        {
            List<int> numbers = new List<int>();

            while(true)
            {
                Console.WriteLine("Enter number (0 to stop): ");
                int num = int.Parse(Console.ReadLine());
                if(num == 0)
                {
                    break;
                }

                numbers.Add(num);
            }

            // Solution I:
            // Loop from Z - A
            for(int i = numbers.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(numbers[i]);
            }

            // Solution II:
            numbers = numbers.OrderByDescending(n => n).ToList();
            foreach(int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
