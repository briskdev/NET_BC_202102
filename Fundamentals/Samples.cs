using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundamentals
{
    public class Samples
    {
        public static void LastDigit()
        {
            Console.WriteLine("Enter number A:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number B:");
            int n2 = int.Parse(Console.ReadLine());

            // compare last digits
            // / * + - %
            // 5 / 2 = 2
            // 5 % 2 = 1 --> check if number odd/even
            // 5 % 10 = 5 --> last digit of a number
            // 47 % 10 = 7 --> last digit of a number
            // 4 % 2 = 0 -> even
            // 3 % 2 = 1 -> odd

            if(n1 % 10 == n2 % 10)
            {
                Console.WriteLine("Ends with a same digit");
            }
        }

        public static void CountE()
        {
            Console.WriteLine("Enter word:");
            string word = Console.ReadLine(); // string = array of char

            //does not return a count - just true/false
            bool isThereAnyLettersE = word.Contains('e');

            if(isThereAnyLettersE)
            {
                foreach (char letter in word)
                {
                    //if(letter == 'e' || letter == 'E')
                    if(Char.ToLower(letter) == 'e')
                    {
                        // found small or capital letter 'e'
                    }
                }
            }
        }

        public static void CompareFirstAndLast()
        {
            List<int> numbers = new List<int>() { 
                5, 1, 4, 78, 5 
            };

            // remember to check for element count
            if (numbers.Count > 0) 
            { 
                int first = numbers[0];
                int last = numbers[numbers.Count - 1]; // x.Length - 1 -> for arrays

                int alsoFirst = numbers.First();
                int alsoLast = numbers.Last();
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

        public static void SumNumberDigits()
        {
            int number = 5230424;
            // sum of digits = ? = 5 + 2 + 3 + 0 + 4 + 2 + 4
            // hint: use %10

            // n = 5230424
            // d1 = 5230424 % 10 = 4 <--
            // n/10 = 5230424/10 = 523042
            // d2 = 523042 % 10 = 2  <--
            // n/10 = 523042/10 = 52304
            // d3 = 52304 % 10 = 4  <--
            // ...
            int sum = 0;
            while(number != 0)
            {
                sum += number % 10; // take last digit
                number /= 10; // remove last digit. Same as: number = number / 10;
            }

            Console.WriteLine("Sum of digits = {0}", sum);
        }

        public static void Linq()
        {
            var students = new List<Student>();
            // TODO: fill the list with data

            // ordered by full name
            var result = students.OrderBy(st => st.Surname).ThenBy(st => st.Name).ToList();

            // filter & order
            var class5 = students          
                .Where(st => st.Class == 5 && st.AverageGrade >= 7)// only students in class 5 with grade >= 7
                .OrderBy(st => st.Surname)
                .ToList();

            // filter: students from class 5 and 6
            var class56 = students.Where(st => st.Class == 5 || st.Class == 6).ToList();

            // filter & calculate
            var class5Average = students.Where(st => st.Class == 5).Average(st => st.AverageGrade);

            // highest grade data in class 4
            var highestGrade4 = students.Where(st => st.Class == 4).Max(st => st.AverageGrade);
            var studentWithHighestGrade4 = students.Find(st => st.Class == 4 && st.AverageGrade == highestGrade4);

            var first = students.FirstOrDefault(st => st.Class == 4 && st.AverageGrade == highestGrade4);

            // WHERE vs FIND
            // Use WHERE if result is multiple records
            // Use FIND if result is one record
            // -- returns NULL if no matching element

            // FIRST vs FIRSTORDEFAULT
            // Use FIRST if you know there will be a matching record
            // -- throws error if no matching element
            // Use FIRSTORDEFAULT if you don't know if any records satisfy criteria
            // -- returns NULL if no matching element

            // FIND vs FIRSTORDEFAULT
            // No difference
        }
    }
}
